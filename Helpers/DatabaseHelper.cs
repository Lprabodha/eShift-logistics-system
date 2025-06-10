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
        private static readonly string connectionString = "Server=localhost;Database=eshift_db;Uid=root;Pwd=";

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

        // Executes an insert, update, or delete command
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {

            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {

                if(parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteNonQuery();

            }
        }

        // Executes a scalar command (returns a single value)
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
    }
}
