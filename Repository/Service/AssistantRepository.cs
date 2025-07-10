using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class AssistantRepository : IAssistantRepository
    {
        /// <summary>
        /// Adds a new assistant to the repository.
        /// </summary>
        /// <param name="assistant"></param>
        public void AddAssistant(Assistant assistant)
        {
            string query = @"
                INSERT INTO assistants 
                (name, phone, address, is_active, status)
                VALUES 
                (@name, @phone, @address, @is_active, @status)";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@name", assistant.Name);
                command.Parameters.AddWithValue("@phone", assistant.Phone);
                command.Parameters.AddWithValue("@address", assistant.Address);
                command.Parameters.AddWithValue("@is_active", assistant.IsActive);
                command.Parameters.AddWithValue("@status", (int)assistant.Status);
            });
        }

        /// <summary>
        /// Updates an existing assistant in the repository.
        /// </summary>
        /// <param name="assistant"></param>
        public void UpdateAssistant(Assistant assistant)
        {
            string query = @"
                UPDATE assistants 
                SET name = @name, phone = @phone, address = @address, is_active = @is_active, status = @status
                WHERE id = @id";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", assistant.Id);
                command.Parameters.AddWithValue("@name", assistant.Name);
                command.Parameters.AddWithValue("@phone", assistant.Phone);
                command.Parameters.AddWithValue("@address", assistant.Address);
                command.Parameters.AddWithValue("@is_active", assistant.IsActive);
                command.Parameters.AddWithValue("@status", (int)assistant.Status);
            });
        }

        /// <summary>
        /// Deletes an assistant from the repository by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAssistant(int id)
        {
            string query = "DELETE FROM assistants WHERE id = @id";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves all assistants from the repository.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Assistant> GetAllAssistants()
        {
            List<Assistant> trucks = new List<Assistant>();
            string query = "SELECT * FROM assistants";

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            trucks.Add(new Assistant
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Phone = reader["phone"]?.ToString(),
                                Address = reader["address"]?.ToString(),
                                Status = (AssistantStatus)Convert.ToInt32(reader["status"]),
                                IsActive = Convert.ToInt32(reader["is_active"]) == 1
                            });
                        }
                    }

                    return trucks;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving trucks from the database.", ex);
                }
            }
        }

        /// <summary>
        /// Retrieves an assistant by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Assistant GetAssistantById(int id)
        {
            string query = "SELECT * FROM assistants WHERE id = @id";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Assistant
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Phone = reader["phone"]?.ToString(),
                                Address = reader["address"]?.ToString(),
                                Status = (AssistantStatus)Convert.ToInt32(reader["status"]),
                                IsActive = Convert.ToInt32(reader["is_active"]) == 1
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if a phone number already exists in the repository, excluding a specific assistant ID.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="assitantIdToExclude"></param>
        /// <returns></returns>
        public bool IsPhoneNumberExists(string phoneNumber, int assitantIdToExclude)
        {
            string query = "SELECT COUNT(*) FROM assistants WHERE phone = @phone AND id != @id";
            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@phone", phoneNumber),
                new MySqlParameter("@id", assitantIdToExclude));
            return Convert.ToInt32(result) > 0;
        }

        public List<Assistant> GetAvailableAssistants(int? currentAssistantId = null)
        {

            string query = @"
                SELECT * FROM assistants 
                WHERE is_active = true AND (id NOT IN (SELECT assistant_id FROM transport_units WHERE assistant_id IS NOT NULL) 
                OR id = @currentAssistantId)";

            return DatabaseHelper.ExecuteReader(query, reader =>
            {
                return new Assistant
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString()
                };
            },
            new MySqlParameter("@currentAssistantId", currentAssistantId ?? (object)DBNull.Value));
        }

    }
}
