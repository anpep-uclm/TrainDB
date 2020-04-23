using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TrainDB {
    public class TrainTypeDAO {
        /// <summary>
        ///     Optional path used to construct the database broker
        /// </summary>
        private readonly string path;

        /// <summary>
        ///     Train types from the last database population
        /// </summary>
        public List<TrainType> TrainTypes { get; }

        /// <summary>
        ///     Database Access Object for the TrainTypes table
        /// </summary>
        /// <param name="path">Path of the database file, used to construct the database broker</param>
        /// <remarks>A <paramref name="path"/> is not required if a broker instance has already been created</remarks>
        public TrainTypeDAO(string path = null) {
            TrainTypes = new List<TrainType>();
            this.path = path;
        }

        #region Population Methods

        /// <summary>
        ///     Reads all the train types from the database
        /// </summary>
        /// <returns>A list with the obtained data</returns>
        public List<TrainType> ReadAll() {
            var trainTypes = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT TrainTypeID, TrainTypeDescription, MaxCapacity FROM TrainTypes");

            TrainTypes.Clear();
            foreach (var row in trainTypes) {
                TrainTypes.Add(new TrainType((long) row["TrainTypeID"]) {
                    Description = (string) row["TrainTypeDescription"],
                    MaximumCapacity = (long) row["MaxCapacity"]
                });
            }

            return TrainTypes;
        }

        /// <summary>
        ///     Fills a TrainType instance with data retrieved from the database
        /// </summary>
        /// <param name="trainType">The target instance</param>
        /// <returns>The train type instance</returns>
        public TrainType Read(TrainType trainType) {
            // query information for the given train type object
            var trainTypes = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT TrainTypeDescription, MaxCapacity FROM TrainTypes WHERE TrainTypeID = @id",
                    ("id", trainType.ID));

            if (!trainTypes.Any())
                throw new KeyNotFoundException("Could not find a train type with this ID");

            // fill object properties
            var trainTypeInfo = trainTypes.First();
            trainType.Description = (string) trainTypeInfo["TrainTypeDescription"];
            trainType.MaximumCapacity = (long) trainTypeInfo["MaxCapacity"];

            return trainType;
        }

        #endregion

        #region Non-query Methods

        /// <summary>
        ///     Inserts a new train type into the database
        /// </summary>
        /// <param name="trainType">Train type to be inserted</param>
        /// <returns>The train type instance</returns>
        public TrainType Insert(TrainType trainType) {
            long trainTypeId = DatabaseBroker.GetInstance(this.path)
                .ExecuteInsert("INSERT INTO TrainTypes(TrainTypeDescription, MaxCapacity) VALUES(@description, @capacity)",
                    ("description", trainType.Description),
                    ("capacity", trainType.MaximumCapacity));

            if (trainTypeId == 0)
                throw new DataException("Could not perform insert operation");

            trainType.ID = trainTypeId;
            return trainType;
        }

        /// <summary>
        ///     Updates the row associated with the given train type from the database
        /// </summary>
        /// <param name="trainType">Train type to be updated</param>
        /// <returns>The train type instance</returns>
        public TrainType Update(TrainType trainType) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("UPDATE TrainTypes SET TrainTypeDescription=@description, MaxCapacity=@capacity WHERE TrainTypeID=@id",
                    ("id", trainType.ID),
                    ("description", trainType.Description),
                    ("capacity", trainType.MaximumCapacity));

            if (numRows == 0)
                throw new DataException("Could not perform update operation");

            return trainType;
        }

        /// <summary>
        ///     Deletes the row associated with the given train type from the database
        /// </summary>
        /// <param name="trainType">Train type to be deleted</param>
        /// <returns>The train type instance</returns>
        public TrainType Delete(TrainType trainType) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("DELETE FROM TrainTypes WHERE TrainTypeID=@id", ("id", trainType.ID));

            if (numRows == 0)
                throw new DataException("Could not perform delete operation");

            return trainType;
        }

        #endregion
    }
}
