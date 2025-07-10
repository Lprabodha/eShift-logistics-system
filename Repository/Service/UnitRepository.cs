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

        public bool DeleteUnit(int id)
        {
            string query = "DELETE FROM transport_units WHERE id = @id";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            return rowsAffected > 0;
        }

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

        public List<TransportUnit> GetAllUnits()
        {
            List<TransportUnit> units = new List<TransportUnit>();
            string query = "SELECT * FROM transport_units";
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            units.Add(new TransportUnit
                            {
                                Id = reader.GetInt32("id"),
                                UnitNumber = reader.GetString("unit_number"),
                                TruckId = reader.GetInt32("truck_id"),
                                DriverId = reader.GetInt32("driver_id"),
                                AssistantId = reader.GetInt32("assistant_id"),
                                Status = (TransportUnitStatus)reader.GetInt32("status"),
                                IsActive = reader.GetBoolean("is_active")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving units: " + ex.Message);
                }
            }
            return units;

        }

        public int GetTotalUnitCount()
        {
            string query = "SELECT COUNT(id) FROM transport_units";
            object result = DatabaseHelper.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
    }
 }
