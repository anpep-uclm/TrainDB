using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TrainDB {
    public sealed class TripDAO {
        /// <summary>
        ///     Optional path used to construct the database broker
        /// </summary>
        private readonly string path;

        /// <summary>
        ///     Trips from the last database population
        /// </summary>
        public List<Trip> Trips { get; }

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="path">Path of the database file used to construct the datbase broker</param>
        /// <remarks>A <paramref name="path"/> is not required if a broker instance has already been created</remarks>
        public TripDAO(string path = null) {
            Trips = new List<Trip>();
            this.path = path;
        }

        #region Population Methods

        /// <summary>
        ///     Reads all the trips from the database
        /// </summary>
        /// <returns>A list with the obtained data</returns>
        public List<Trip> ReadAll() {
            var trips = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT TripDate, Train, Product, TonsTransported FROM Trips");

            Trips.Clear();
            foreach (var row in trips) {
                var trip = new Trip((string) row["TripDate"], (string) row["Train"]) {
                    Product = new Product((long) row["Product"]),
                    TonsTransported = (long) row["TonsTransported"]
                };
                
                trip.Train.DAO.Read(trip.Train);
                trip.Product.DAO.Read(trip.Product);

                Trips.Add(trip);
            }

            return Trips;
        }

        /// <summary>
        ///     Fills a Trip instance with data retrieved from the database
        /// </summary>
        /// <param name="trip">The target instance</param>
        /// <returns>The trip instance</returns>
        public Trip Read(Trip trip) {
            // query information from the database
            var trips = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT TonsTransported FROM Trips WHERE Product = @product AND TripDate = @date AND Train = @train",
                    ("product", trip.Product.ID),
                    ("date", trip.Date.ToSQLiteDateFormat()),
                    ("train", trip.Train.ID));

            if (!trips.Any())
                throw new KeyNotFoundException("Could not find a trip associated with this train at the specified date");

            // fill object propetries
            var tripInfo = trips.First();
            trip.TonsTransported = (long) tripInfo["TonsTransported"];

            trip.Product.DAO.Read(trip.Product);

            return trip;
        }

        #endregion

        #region Non-query Methods

        /// <summary>
        ///     Inserts a new trip into the database
        /// </summary>
        /// <param name="trip">Trip to be inserted</param>
        /// <returns>The trip instance</returns>
        public Trip Insert(Trip trip) {
            // this trip may be associated with a new train. We should insert it first but
            // we can not use its ID to check whether or not it already exists on the database.
            // This could be solved with an additional property or method that indicates if
            // the object was just inserted or retrieved from database, but for simplicity we
            // won't be doing any automatic insertion here

            if (trip.Product.ID == 0) {
                // this trip is associated with a new product -- insert it first
                trip.Product.DAO.Insert(trip.Product);
            }

            long numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("INSERT INTO Trips(TripDate, Train, Product, TonsTransported) VALUES(@date, @train, @product, @tons)",
                    ("date", trip.Date.ToSQLiteDateFormat()),
                    ("train", trip.Train.ID),
                    ("product", trip.Product.ID),
                    ("tons", trip.TonsTransported));

            if (numRows == 0)
                throw new DataException("Could not perform insert operation");

            return trip;
        }

        /// <summary>
        ///     Updates the row associated with the given trip from the database
        /// </summary>
        /// <param name="trip">Trip to be updated</param>
        /// <returns>The trip instance</returns>
        public Trip Update(Trip trip) {
            // update product and train information
            trip.Product.DAO.Update(trip.Product);
            trip.Train.DAO.Update(trip.Train);

            // update trip information
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("UPDATE Trips SET TonsTransported = @tons WHERE Product = @product AND TripDate = @date AND Train = @train",
                    ("product", trip.Product.ID),
                    ("tons", trip.TonsTransported),
                    ("date", trip.Date.ToSQLiteDateFormat()),
                    ("train", trip.Train.ID));

            if (numRows == 0)
                throw new DataException("Could not perform update operation");

            return trip;
        }  

        /// <summary>
        ///     Deletes the row associated with the given trip from the database
        /// </summary>
        /// <param name="trip">Trip to be deleted</param>
        /// <returns>The trip instance</returns>
        public Trip Delete(Trip trip) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("DELETE FROM Trips WHERE Product = @product AND TripDate = @date AND Train = @train",
                    ("product", trip.Product.ID),
                    ("date", trip.Date.ToSQLiteDateFormat()),
                    ("train", trip.Train.ID));

            if (numRows == 0)
                throw new DataException("Could not pefrorm delete operation");

            return trip;
        }

        #endregion
    }
}
