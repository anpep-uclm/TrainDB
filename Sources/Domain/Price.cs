using System;

namespace TrainDB {
    public sealed class Price {
        public PriceDAO DAO { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public double EurosPerTon { get; set; }

        public Price(long productId = 0, string date = null) {
            Product = new Product(productId);
            Date = date is null ? DateTime.Now : DateTime.Parse(date);
            DAO = new PriceDAO();
        }
    }
}
