using System;
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
        ///     Reads all the products transported by a specific train on the given date range
        /// </summary>
        /// <param name="train">Train to filter by</param>
        /// <param name="dateRange">Date range to filter by</param>
        /// <returns>A list with the obtained data</returns>
        public List<Product> ReadAll(Train train, (DateTime Start, DateTime End)? dateRange) {
            if (train is null || dateRange is null)
                return ReadAll();

            var products = DatabaseBroker.GetInstance(this.path).ExecuteQuery(@"
                SELECT Products.ProductID, Products.ProductDescription FROM Products
                JOIN Trips ON Trips.Product = Products.ProductID
                WHERE Trips.Train = @train AND Trips.TripDate BETWEEN @start AND @end",

                ("train", train.ID),
                ("start", dateRange?.Start.ToSQLiteDateFormat()),
                ("end", dateRange?.End.ToSQLiteDateFormat()));

            Products.Clear();
            foreach (var row in products) {
                Products.Add(new Product((long) row["ProductID"]) {
                    Description = (string) row["ProductDescription"]
                });
            }

            return Products;
        }

        /// <summary>
        ///     Obtains a ranking of the products that have been transported the most
        ///     within the specified date range
        /// </summary>
        /// <param name="dateRange">The date range</param>
        /// <returns>A list of <see cref="Product"/>s.</returns>
        public List<Product> QueryRanking((DateTime Start, DateTime End) dateRange) {
            var rows = DatabaseBroker.GetInstance(this.path).ExecuteQuery(@"
                SELECT
	                COUNT(Products.ProductID) AS ProductCount,
	                Products.ProductID,
	                Products.ProductDescription
                FROM Products
                JOIN Trips ON Trips.Product = Products.ProductID
                WHERE Trips.TripDate BETWEEN @start AND @end
                GROUP BY Products.ProductID
                ORDER BY ProductCount DESC",

                ("start", dateRange.Start.ToSQLiteDateFormat()),
                ("end", dateRange.End.ToSQLiteDateFormat()));

            var products = new List<Product>();
            foreach (var row in rows) {
                products.Add(new Product((long) row["ProductID"]) {
                    Description = (string) row["ProductDescription"],
                    ProductCount = (long) row["ProductCount"]
                });
            }

            return products;
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
