using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TrainDB {
    public class ProductDAO {
        /// <summary>
        ///     Optional path used to construct the database broker
        /// </summary>
        private readonly string path;

        /// <summary>
        ///     products from the last database population
        /// </summary>
        public List<Product> Products { get; }

        /// <summary>
        ///     Database Access Object for the Products table
        /// </summary>
        /// <param name="path">Path of the database file, used to construct the database broker</param>
        /// <remarks>A <paramref name="path"/> is not required if a broker instance has already been created</remarks>
        public ProductDAO(string path = null) {
            Products = new List<Product>();
            this.path = path;
        }

        #region Population Methods

        /// <summary>
        ///     Reads all the products from the database
        /// </summary>
        /// <returns>A list with the obtained data</returns>
        public List<Product> ReadAll() {
            var products = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT ProductID, ProductDescription FROM Products");

            Products.Clear();
            foreach (var row in products) {
                Products.Add(new Product((long) row["ProductID"]) {
                    Description = (string) row["ProductDescription"]
                });
            }

            return Products;
        }

        /// <summary>
        ///     Fills a Product instance with data retrieved from the database
        /// </summary>
        /// <param name="product">The target instance</param>
        /// <returns>The product instance</returns>
        public Product Read(Product product) {
            // query information for the given product object
            var products = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT ProductDescription FROM Products WHERE ProductID = @id",
                    ("id", product.ID));

            if (!products.Any())
                throw new KeyNotFoundException("Could not find a product with this ID");

            // fill object properties
            var productInfo = products.First();
            product.Description = (string) productInfo["ProductDescription"];

            return product;
        }

        #endregion

        #region Non-query Methods

        /// <summary>
        ///     Inserts a new product into the database
        /// </summary>
        /// <param name="product">product to be inserted</param>
        /// <returns>The product instance</returns>
        public Product Insert(Product product) {
            long productId = DatabaseBroker.GetInstance(this.path)
                .ExecuteInsert("INSERT INTO Products(ProductDescription) VALUES(@description)",
                    ("description", product.Description));

            if (productId == 0)
                throw new DataException("Could not perform insert operation");

            product.ID = productId;
            return product;
        }

        /// <summary>
        ///     Updates the row associated with the given product from the database
        /// </summary>
        /// <param name="product">product to be updated</param>
        /// <returns>The product instance</returns>
        public Product Update(Product product) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("UPDATE Products SET ProductDescription=@description WHERE ProductID=@id",
                    ("id", product.ID),
                    ("description", product.Description));

            if (numRows == 0)
                throw new DataException("Could not perform update operation");

            return product;
        }

        /// <summary>
        ///     Deletes the row associated with the given product from the database
        /// </summary>
        /// <param name="product">product to be deleted</param>
        /// <returns>The product instance</returns>
        public Product Delete(Product product) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("DELETE FROM Products WHERE ProductID=@id", ("id", product.ID));

            if (numRows == 0)
                throw new DataException("Could not perform delete operation");

            return product;
        }

        #endregion
    }
}
