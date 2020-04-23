namespace TrainDB {
    public sealed class Product {
        /// <summary>
        ///     Backing database access object for this product
        /// </summary>
        public ProductDAO DAO { get; private set; }

        /// <summary>
        ///     Unique identifier associated with this product
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        ///     product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="id">Product ID</param>
        public Product(long id = 0) {
            ID = id;
            DAO = new ProductDAO();
        }

        /// <summary>
        ///     Obtains a string representation for this product
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"[#{ID}] {Description}";
        }
    }
}
