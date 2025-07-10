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
   public class AssistantRepository: IAssistantRepository
    {

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

        public bool DeleteAssistant(int id)
        {
            string query = "DELETE FROM assistants WHERE id = @id";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            return rowsAffected > 0;
        }

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

        Assistant IAssistantRepository.GetAssistantById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
