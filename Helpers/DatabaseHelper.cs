using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// Executes a query and returns a list of objects, safely handling parameters.
        /// </summary>
        public static List<T> ExecuteReader<T>(string query, Func<MySqlDataReader, T> mapFunc, params MySqlParameter[] parameters)
        {
            var results = new List<T>();
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(mapFunc(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database query failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return results;
        }

        /// <summary>
        /// Executes a query asynchronously and returns a DataTable containing the results.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static async Task<DataTable> ExecuteReaderAsyncToDataTable(string query, params MySqlParameter[] parameters)
        {
            var dataTable = new DataTable();
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var reader = await cmd.ExecuteReaderAsync()) 
                    {
                        dataTable.Load(reader); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database query for report failed: {ex.Message}", "Database Error");
                Console.WriteLine($"[DatabaseHelper] Error in ExecuteReaderAsyncToDataTable: {ex}");
                return new DataTable(); // Return an empty DataTable on error
            }
            return dataTable;
        }
    }
}
