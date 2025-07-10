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
   public class TruckRepositroy : ITruckRepository
    {
        /// <summary>
        /// Repository class for managing truck operations.
        /// </summary>
        /// <param name="truck"></param>
        public void AddTruck(Truck truck)
        {
            string query = @"
                INSERT INTO trucks 
                (truck_number, model, license_plate, capacity, status, is_active)
                VALUES 
                (@truck_number, @model, @license_plate, @capacity, @status, @is_active)";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@truck_number", truck.TruckNumber);
                command.Parameters.AddWithValue("@model", truck.Model);
                command.Parameters.AddWithValue("@capacity", truck.Capacity);
                command.Parameters.AddWithValue("@status", (int)truck.Status);
                command.Parameters.AddWithValue("@license_plate", truck.LicensePlate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@is_active", truck.IsActive);
            });

        }

        /// <summary>
        /// Deletes a truck from the system by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteTruck(int id)
        {

            string query = "DELETE FROM trucks WHERE id = @id";
            try
            {
                DatabaseHelper.ExecuteNonQuery(query, command =>
                {
                    command.Parameters.AddWithValue("@id", id);
                });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting truck from the database.", ex);
            }
        }

        /// <summary>
        /// Retrieves all trucks from the system.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Truck> GetAllTrucks()
        {
            List<Truck> trucks = new List<Truck>();
            string query = "SELECT * FROM trucks";

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            trucks.Add(new Truck
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                TruckNumber = reader["truck_number"].ToString(),
                                Model = reader["model"].ToString(),
                                LicensePlate = reader["license_plate"]?.ToString(),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                Status = (TruckStatus)Convert.ToInt32(reader["status"]),
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
        /// Updates an existing truck in the system.
        /// </summary>
        /// <param name="truck"></param>
        public void UpdateTruck(Truck truck)
        {

            string query = @"
                UPDATE trucks 
                SET truck_number = @truck_number, 
                    model = @model, 
                    license_plate = @license_plate, 
                    capacity = @capacity, 
                    status = @status, 
                    is_active = @is_active
                WHERE id = @id";
            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", truck.Id);
                command.Parameters.AddWithValue("@truck_number", truck.TruckNumber);
                command.Parameters.AddWithValue("@model", truck.Model);
                command.Parameters.AddWithValue("@capacity", truck.Capacity);
                command.Parameters.AddWithValue("@status", (int)truck.Status);
                command.Parameters.AddWithValue("@license_plate", truck.LicensePlate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@is_active", truck.IsActive);
            });
        }

        /// <summary>
        /// Checks if a truck number already exists in the system, excluding a specific truck ID.
        /// </summary>
        /// <param name="truckNumber"></param>
        /// <param name="truckIdToExclude"></param>
        /// <returns></returns>
        public bool IsTruckNumberExists(string truckNumber, int truckIdToExclude)
        {
            const string query = "SELECT COUNT(1) FROM trucks WHERE truck_number = @truckNumber AND id != @truckId";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@truckNumber", truckNumber);
                cmd.Parameters.AddWithValue("@truckId", truckIdToExclude);

                var count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        /// <summary>
        /// Retrieves a truck by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Truck GetTruckById(int id)
        {
            const string query = "SELECT * FROM trucks WHERE id = @id LIMIT 1";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Truck
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                TruckNumber = reader["truck_number"].ToString(),
                                Model = reader["model"].ToString(),
                                LicensePlate = reader["license_plate"] == DBNull.Value ? null : reader["license_plate"].ToString(),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                Status = Enum.TryParse<TruckStatus>(reader["status"].ToString(), out var status) ? status : TruckStatus.Available,
                                IsActive = Convert.ToBoolean(reader["is_active"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving truck by ID: " + ex.Message, ex);
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if a license plate already exists in the system, excluding a specific truck ID.
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="truckIdToExclude"></param>
        /// <returns></returns>

        public bool IsLicensePlateExists(string licensePlate, int truckIdToExclude)
        {
            string query = "SELECT COUNT(1) FROM trucks WHERE license_plate = @licensePlate AND id != @id";

            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@licensePlate", licensePlate),
                new MySqlParameter("@id", truckIdToExclude));

            return Convert.ToInt64(result) > 0;
        }

        /// <summary>
        /// Retrieves a list of available trucks.
        /// </summary>
        /// <returns></returns>
        public List<Truck> GetAvailableTrucks(int? currentTruckId = null)
        {

            string query = @"
                SELECT * FROM trucks 
                WHERE is_active = true AND (id NOT IN (SELECT truck_id FROM transport_units WHERE truck_id IS NOT NULL) 
                OR id = @currentTruckId)";

            return DatabaseHelper.ExecuteReader(query, reader =>
            {
                return new Truck
                {
                    Id = Convert.ToInt32(reader["id"]),
                    LicensePlate = reader["license_plate"].ToString()
                };
            },
            new MySqlParameter("@currentTruckId", currentTruckId ?? (object)DBNull.Value));
        }

    }
}
