using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TrainDB {
    public class TrainDAO {
        /// <summary>
        ///     Optional path used to construct the database broker
        /// </summary>
        private readonly string path;

        /// <summary>
        ///     Trains from the last database population
        /// </summary>
        public List<Train> Trains { get; }

        /// <summary>
        ///     Database Access Object for the Trains table
        /// </summary>
        /// <param name="path">Path of the database file, used to construct the database broker</param>
        /// <remarks>A <paramref name="path"/> is not required if a broker instance has already been created</remarks>
        public TrainDAO(string path = null) {
            Trains = new List<Train>();
            this.path = path;
        }

        #region Population Methods

        /// <summary>
        ///     Reads all the trains from the database
        /// </summary>
        /// <returns>A list with the obtained data</returns>
        public List<Train> ReadAll() {
            var trains = DatabaseBroker.GetInstance(this.path).ExecuteQuery("SELECT TrainID, TrainType FROM Trains");

            Trains.Clear();
            foreach (var row in trains) {
                var train = new Train((string) row["TrainID"]) {
                    Type = new TrainType((long) row["TrainType"])
                };
                train.Type.DAO.Read(train.Type);
                Trains.Add(train);
            }

            return Trains;
        }

        /// <summary>
        ///     Fills a Train instance with data retrieved from the database
        /// </summary>
        /// <param name="train">The target instance</param>
        /// <returns>The train instance</returns>
        public Train Read(Train train) {
            // query information for the given train type object
            var trains = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT TrainType FROM Trains WHERE TrainID = @id", ("id", train.ID));

            if (!trains.Any())
                throw new KeyNotFoundException("Could not find a train with this ID");

            // fill object properties
            var trainInfo = trains.First();
            train.Type = new TrainType((long) trainInfo["TrainType"]);
            train.Type.DAO.Read(train.Type);

            return train;
        }

        #endregion

        #region Non-query Methods

        /// <summary>
        ///     Inserts a new train into the database
        /// </summary>
        /// <param name="train">Train to be inserted</param>
        /// <returns>The train instance</returns>
        public Train Insert(Train train) {
            if (train.Type.ID == 0) {
                // this train has a new train type -- insert it first
                train.Type.DAO.Insert(train.Type);
            }

            long numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("INSERT INTO Trains(TrainID, TrainType) VALUES(@id, @type)",
                    ("id", train.ID),
                    ("type", train.Type.ID));

            if (numRows == 0)
                throw new DataException("Could not perform insert operation");

            return train;
        }

        /// <summary>
        ///     Updates the row associated with the given train from the database
        /// </summary>
        /// <param name="train">Train to be updated</param>
        /// <returns>The train instance</returns>
        public Train Update(Train train) {
            // update the train type information
            train.Type.DAO.Update(train.Type);

            // update train information
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("UPDATE Trains SET TrainType=@type WHERE TrainID=@id",
                    ("id", train.ID),
                    ("type", train.Type.ID));

            if (numRows == 0)
                throw new DataException("Could not perform update operation");

            return train;
        }

        /// <summary>
        ///     Deletes the row associated with the given train from the database
        /// </summary>
        /// <param name="train">Train to be deleted</param>
        /// <returns>The train instance</returns>
        public Train Delete(Train train) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("DELETE FROM Trains WHERE TrainID=@id", ("id", train.ID));

            if (numRows == 0)
                throw new DataException("Could not perform delete operation");

            return train;
        }

        #endregion
    }
}
