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

        public Train(string id = null) {
            ID = id;
            DAO = new TrainDAO();
            Type = new TrainType();
        }
    }
}
