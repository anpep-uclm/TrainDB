namespace TrainDB {
    public sealed class TrainType {
        /// <summary>
        ///     Backing database access object for this train type
        /// </summary>
        public TrainTypeDAO DAO { get; private set; }

        /// <summary>
        ///     Unique identifier associated with this train type
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        ///     Train type description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Maximum capacity in tons
        /// </summary>
        public long MaximumCapacity { get; set; }

        /// <summary>
        ///     Number of trips this train type has made
        /// </summary>
        /// <remarks>
        ///     This property is used by the <see cref="TrainTypeRankingTab"/>
        /// </remarks>
        public long? TripCount { get; set; }

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="id">Train type ID</param>
        public TrainType(long id = 0) {
            ID = id;
            DAO = new TrainTypeDAO();
        }

        /// <summary>
        ///     Obtains a string representation for this train type
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"[#{ID}] {Description}";
        }
    }
}
