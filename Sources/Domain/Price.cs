using System;

namespace TrainDB {
    public sealed class Price {
        /// <summary>
        ///     Backing database access object for this price
        /// </summary>
        public PriceDAO DAO { get; set; }

        /// <summary>
        ///     Product associated to this price
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        ///     Date of price registration
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Value of the product
        /// </summary>
        public double EurosPerTon { get; set; }

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="productId">ID of the associated product</param>
        /// <param name="date">Price date</param>
        public Price(long productId = 0, string date = null) {
            Product = new Product(productId);
            Date = date is null ? DateTime.Now : DateTime.Parse(date);
            DAO = new PriceDAO();
        }
    }
}
