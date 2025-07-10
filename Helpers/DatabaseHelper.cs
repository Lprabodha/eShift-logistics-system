using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Server=localhost;Database=e_shift_logistics;Uid=root;Pwd=";

        /// <summary>
        /// Creates and opens a new MySQL database connection using the specified connection string.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static MySqlConnection GetConnection()
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to create a database connection.", ex);
            }
        }

        /// <summary>
        /// Executes a non-query command (INSERT, UPDATE, DELETE) against the database.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string query, Action<MySqlCommand> parameters = null)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                parameters?.Invoke(command);
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a query that returns a single value (e.g., COUNT, MAX) from the database.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Executes a query that returns a list of results, mapping each row to an object of type T using the provided mapping function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="mapFunc"></param>
        /// <returns></returns>
        public static List<T> ExecuteReader<T>(string query, Func<MySqlDataReader, T> mapFunc)
        {
            var results = new List<T>();

            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(mapFunc(reader));
                    }
                }
            }

            return results;
        }
}
}
