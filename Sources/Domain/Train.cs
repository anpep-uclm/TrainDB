namespace TrainDB {
    public sealed class Train {
        /// <summary>
        ///     Backing database access object for this train
        /// </summary>
        public TrainDAO DAO { get; private set; }

        /// <summary>
        ///     Unique identifier associated with this train
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///     Train type
        /// </summary>
        public TrainType Type { get; set; }

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="id">Train ID</param>
        public Train(string id = null) {
            ID = id;
            DAO = new TrainDAO();
            Type = new TrainType();
        }

        /// <summary>
        ///     Obtains a string representation for this train
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{ID} ({Type?.Description})";
        }
    }
}
