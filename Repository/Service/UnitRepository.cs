using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class UnitRepository : IUnitRepository
    {
        /// <summary>
        /// Adds a new transport unit to the database.
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(TransportUnit unit)
        {
            string query = @"
                INSERT INTO transport_units (unit_number, truck_id, driver_id, assistant_id, status, is_active)
                VALUES (@unit_number, @truck_id, @driver_id, @assistant_id, @status, @is_active)";
            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@unit_number", unit.UnitNumber);
                command.Parameters.AddWithValue("@truck_id", unit.TruckId);
                command.Parameters.AddWithValue("@driver_id", unit.DriverId);
                command.Parameters.AddWithValue("@assistant_id", unit.AssistantId);
                command.Parameters.AddWithValue("@status", (int)unit.Status);
                command.Parameters.AddWithValue("@is_active", unit.IsActive ? 1 : 0);
            });
        }

        /// <summary>
        /// Updates an existing transport unit in the database.
        /// </summary>
        /// <param name="unit"></param>
        public void UpdateUnit(TransportUnit unit)
        {
            string query = @"
                UPDATE transport_units 
                SET unit_number = @unit_number, truck_id = @truck_id, driver_id = @driver_id, 
                    assistant_id = @assistant_id, status = @status, is_active = @is_active
                WHERE id = @id";
            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", unit.Id);
                command.Parameters.AddWithValue("@unit_number", unit.UnitNumber);
                command.Parameters.AddWithValue("@truck_id", unit.TruckId);
                command.Parameters.AddWithValue("@driver_id", unit.DriverId);
                command.Parameters.AddWithValue("@assistant_id", unit.AssistantId);
                command.Parameters.AddWithValue("@status", (int)unit.Status);
                command.Parameters.AddWithValue("@is_active", unit.IsActive ? 1 : 0);
            });
        }

        /// <summary>
        /// Deletes a transport unit from the database by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUnit(int id)
        {
            string query = "DELETE FROM transport_units WHERE id = @id";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves a transport unit by its ID from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TransportUnit GetUnitById(int id)
        {
            string query = "SELECT * FROM transport_units WHERE id = @id";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TransportUnit
                            {
                                Id = reader.GetInt32("id"),
                                UnitNumber = reader.GetString("unit_number"),
                                TruckId = reader.GetInt32("truck_id"),
                                DriverId = reader.GetInt32("driver_id"),
                                AssistantId = reader.GetInt32("assistant_id"),
                                Status = (TransportUnitStatus)reader.GetInt32("status"),
                                IsActive = reader.GetBoolean("is_active")
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves all transport units from the database.
        /// </summary>
        /// <returns></returns>
        public List<TransportUnit> GetAllUnits()
        {
            string query = @"
            SELECT 
                tu.id, tu.unit_number, tu.status, tu.is_active,
                tu.truck_id, tu.driver_id, tu.assistant_id,
                t.license_plate,
                d.name as driver_name,
                a.name as assistant_name
            FROM transport_units tu
            INNER JOIN trucks t ON tu.truck_id = t.id
            INNER JOIN drivers d ON tu.driver_id = d.id
            LEFT JOIN assistants a ON tu.assistant_id = a.id"; 

            return DatabaseHelper.ExecuteReader(query, reader =>
            {
                return new TransportUnit
                {
                    Id = Convert.ToInt32(reader["id"]),
                    UnitNumber = reader.GetString("unit_number"),
                    Status = (TransportUnitStatus)reader.GetInt32("status"),
                    IsActive = reader.GetBoolean("is_active"),
                    TruckId = Convert.ToInt32(reader["truck_id"]),
                    DriverId = Convert.ToInt32(reader["driver_id"]),
                    AssistantId = reader.GetInt32("assistant_id"),

                    Truck = new Truck
                    {
                        Id = Convert.ToInt32(reader["truck_id"]),
                        LicensePlate = reader.GetString("license_plate")
                    },

                    Driver = new Driver
                    {
                        Id = Convert.ToInt32(reader["driver_id"]),
                        Name = reader.GetString("driver_name")
                    },

                    Assistant = new Assistant
                    {
                        Id = reader.GetInt32("assistant_id"),
                        Name = reader.GetString("assistant_name")
                    }
                };
            });
        }

        /// <summary>
        /// Retrieves the last transport unit ID from the database.
        /// </summary>
        /// <returns></returns>
        public int GetLastUnitId()
        {
            string query = "SELECT MAX(id) FROM transport_units";

            object result = DatabaseHelper.ExecuteScalar(query);

            if (result != DBNull.Value && result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        /// <summary>
        /// Retrieves all available transport units that are not currently assigned to any job.
        /// </summary>
        /// <returns></returns>
        public List<TransportUnit> GetAvailableUnits(int? currentUnitId = null)
        {
            string query = @"
                SELECT * FROM transport_units 
                WHERE is_active = true 
                AND (status = @status OR id = @currentUnitId)";

            return DatabaseHelper.ExecuteReader(query,
                reader => new TransportUnit
                {
                    Id = Convert.ToInt32(reader["id"]),
                    UnitNumber = reader["unit_number"].ToString()
                },
                new MySqlParameter("@status", (int)TransportUnitStatus.Free),
                new MySqlParameter("@currentUnitId", currentUnitId ?? (object)DBNull.Value)
            );
        }
    }
 }
