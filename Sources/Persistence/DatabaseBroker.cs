using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;

namespace TrainDB {
    /// <summary>
    ///     Provides application-wide access to a SQLite database connection.
    /// </summary>
    public sealed class DatabaseBroker {
        #region Static members

        /// <summary>
        ///     Current instance of the database broker
        /// </summary>
        private static DatabaseBroker currentInstance;

        #endregion

        #region Instance members

        private readonly SQLiteConnection connection;

        #endregion

        #region Static methods

        public static DatabaseBroker GetInstance(string path = null) {
            if (path == null) {
                // no database file was provided
                return currentInstance;
            }

            // if the connection string matches the one used to construct the current database connection,
            // return this broker instance
            string connectionString = "URI=file:" + path;
            if (currentInstance?.connection?.ConnectionString == connectionString)
                return currentInstance;

            // otherwise, close the existing connection (if open) and create a new broker
            currentInstance?.CloseConnection();
            currentInstance = new DatabaseBroker(connectionString);
            return currentInstance;
        }

        #endregion

        /// <summary>
        ///     Creates a database broker instance
        /// </summary>
        /// <param name="connectionString">Connection string for the SQLite database</param>
        private DatabaseBroker(string connectionString) {
            this.connection = new SQLiteConnection(connectionString);
        }

        #region Connection management

        /// <summary>
        ///     Opens the connection with the database
        /// </summary>
        public void OpenConnection() {
            if (this.connection.State == ConnectionState.Closed) {
                this.connection.Open();

                // enable SQLite foreign key restrictions support. Without this,
                // DELETE/UPDATE operations may leave the database in an inconsistent state
                ExecuteNonQuery("PRAGMA foreign_keys = ON");
            }
        }

        /// <summary>
        ///     Closes the connection with the database
        /// </summary>
        public void CloseConnection() {
            if (this.connection.State == ConnectionState.Open)
                this.connection.Close();
        }

        #endregion

        #region Statement/query execution methods

        /// <summary>
        ///     Executes a non-query command on the database
        /// </summary>
        /// <param name="sql">Command text</param>
        /// <param name="parameters">A variadic set of parameter tuples to be bound to the query</param>
        /// <returns>The number of affected rows</returns>
        public int ExecuteNonQuery(string sql, params (string name, object value)[] parameters) {
            // create command
            using (var cmd = new SQLiteCommand(sql, this.connection)) {
                Debug.WriteLine(sql);

                // bind command parameters
                foreach (var (name, value) in parameters) {
                    cmd.Parameters.AddWithValue('@' + name, value);
                    Debug.WriteLine($"    {name}: {value}");
                }
                cmd.Prepare();

                // execute statement
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Executes an insertion command on the database
        /// </summary>
        /// <param name="sql">Command text</param>
        /// <param name="parameters">A variadic set of parameter tuples to be bound to the query</param>
        /// <returns>The ID of the inserted row</returns>
        public long ExecuteInsert(string sql, params (string name, object value)[] parameters) {
            if (ExecuteNonQuery(sql, parameters) == 0)
                return 0;

            return this.connection.LastInsertRowId;
        }

        /// <summary>
        ///     Executes a query command on the database
        /// </summary>
        /// <param name="sql">Command text</param>
        /// <param name="parameters">A variadic set of parameter tuples to be bound to the query</param>
        /// <returns>A list of rows returned by the query</returns>
        public IEnumerable<Dictionary<string, object>> ExecuteQuery(string sql, params (string name, object value)[] parameters) {
            // create command
            using (var cmd = new SQLiteCommand(sql, this.connection)) {
                Debug.WriteLine(sql);

                // bind command parameters
                foreach (var (name, value) in parameters) {
                    cmd.Parameters.AddWithValue('@' + name, value);
                    Debug.WriteLine($"    {name}: {value}");
                }
                cmd.Prepare();

                // read rows returned by the database
                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    if (!reader.HasRows) {
                        // no rows returned, get away with an empty array
                        return Array.Empty<Dictionary<string, object>>();
                    }

                    // populate all rows
                    var rows = new List<Dictionary<string, object>>();
                    while (reader.Read()) {
                        var row = new Dictionary<string, object>();

                        // iterate over all columns and populate all values
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader.GetValue(i);

                        rows.Add(row);
                    }

                    // convert to immutable enumerable
                    return rows.ToArray();
                }
            }
        }

        #endregion
    }
}
