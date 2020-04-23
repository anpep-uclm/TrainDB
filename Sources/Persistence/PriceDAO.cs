using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TrainDB {
    public class PriceDAO {
        /// <summary>
        ///     Optional path used to construct the database broker
        /// </summary>
        private readonly string path;

        /// <summary>
        ///     Prices from the last database population
        /// </summary>
        public List<Price> Prices { get; }

        /// <summary>
        ///     Database Access Object for the Products table
        /// </summary>
        /// <param name="path">Path of the database file, used to construct the database broker</param>
        /// <remarks>A <paramref name="path"/> is not required if a broker instance has already been created</remarks>
        public PriceDAO(string path = null) {
            Prices = new List<Price>();
            this.path = path;
        }

        #region Population Methods

        /// <summary>
        ///     Reads all the train types from the database
        /// </summary>
        /// <returns>A list with the obtained data</returns>
        public List<Price> ReadAll() {
            var prices = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT Product, PriceDate, EurosPerTon FROM Prices");

            Prices.Clear();
            foreach (var row in prices) {
                var price = new Price((long) row["Product"], (string) row["PriceDate"]) {
                    EurosPerTon = (double) row["EurosPerTon"]
                };
                price.Product.DAO.Read(price.Product);
                Prices.Add(price);
            }

            return Prices;
        }

        /// <summary>
        ///     Fills a Price instance with data retrieved from the database
        /// </summary>
        /// <param name="price">The target instance</param>
        /// <returns>The price instance</returns>
        public Price Read(Price price) {
            // query information for the given price object
            var prices = DatabaseBroker.GetInstance(this.path)
                .ExecuteQuery("SELECT EurosPerTon FROM Prices WHERE Product = @product AND PriceDate = @date",
                    ("product", price.Product),
                    ("date", price.Date.ToSQLiteDateFormat()));

            if (!prices.Any())
                throw new KeyNotFoundException("Could not find a price for this product on the specified date");

            // fill object properties
            var priceInfo = prices.First();
            price.EurosPerTon = (double) priceInfo["EurosPerTon"];

            return price;
        }

        #endregion

        #region Non-query Methods

        /// <summary>
        ///     Inserts a new price into the database
        /// </summary>
        /// <param name="price">Price to be inserted</param>
        /// <returns>The price instance</returns>
        public Price Insert(Price price) {
            if (price.Product.ID == 0) {
                // this price is associated with a new product -- insert it first
                price.Product.DAO.Insert(price.Product);
            }

            long numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("INSERT INTO Prices(Product, PriceDate, EurosPerTon) VALUES(@product, @date, @value)",
                    ("product", price.Product.ID),
                    ("date", price.Date.ToSQLiteDateFormat()),
                    ("value", price.EurosPerTon));

            if (numRows == 0)
                throw new DataException("Could not perform insert operation");

            return price;
        }

        /// <summary>
        ///     Updates the row associated with the given price from the database
        /// </summary>
        /// <param name="price">Price to be updated</param>
        /// <returns>The price instance</returns>
        public Price Update(Price price) {
            // update the product information
            price.Product.DAO.Update(price.Product);

            // update price information
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("UPDATE Prices SET EurosPerTon = @value WHERE Product = @product AND PriceDate = @date",
                    ("value", price.EurosPerTon),
                    ("product", price.Product.ID),
                    ("date", price.Date.ToSQLiteDateFormat()));

            if (numRows == 0)
                throw new DataException("Could not perform update operation");

            return price;
        }

        /// <summary>
        ///     Deletes the row associated with the given price from the database
        /// </summary>
        /// <param name="price">Price to be deleted</param>
        /// <returns>The price instance</returns>
        public Price Delete(Price price) {
            int numRows = DatabaseBroker.GetInstance(this.path)
                .ExecuteNonQuery("DELETE FROM Prices WHERE Product = @product AND PriceDate = @date",
                    ("product", price.Product.ID),
                    ("date", price.Date.ToSQLiteDateFormat()));

            if (numRows == 0)
                throw new DataException("Could not perform delete operation");

            return price;
        }

        #endregion
    }
}
