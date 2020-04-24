using System;

namespace TrainDB {
    public sealed class Trip {
        /// <summary>
        ///     Backing Database Access Object
        /// </summary>
        public TripDAO DAO { get; set; }

        /// <summary>
        ///     Date of the trip
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Train associated to the trip
        /// </summary>
        public Train Train { get; set; }

        /// <summary>
        ///     Product being transported
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        ///     Discrete number of tonnes transported on this trip
        /// </summary>
        public long TonsTransported { get; set; }

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="date">Date of the trip</param>
        /// <param name="trainId">ID of the train associated to this trip</param>
        public Trip(string date = null, string trainId = null) {
            DAO = new TripDAO();
            Date = date is null ? DateTime.Now : DateTime.Parse(date);
            Train = new Train(trainId);
            TonsTransported = 1;
        }
    }
}