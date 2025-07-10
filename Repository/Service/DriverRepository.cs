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
    public class DriverRepository: IDriverRepository
    {
        /// <summary>
        /// Adds a new driver to the repository.
        /// </summary>
        /// <param name="driver"></param>
        public void AddDriver(Driver driver)
        {
            string query = @"
                INSERT INTO drivers 
                (name, license_number, phone, address, status, is_active)
                VALUES 
                (@name, @license_number, @phone, @address, @status, @is_active)";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@name", driver.Name);
                command.Parameters.AddWithValue("@license_number", driver.LicenseNumber);
                command.Parameters.AddWithValue("@phone", driver.Phone);
                command.Parameters.AddWithValue("@address", driver.Address);
                command.Parameters.AddWithValue("@status", (int)driver.Status);
                command.Parameters.AddWithValue("@is_active", driver.IsActive);
            });
        }

        /// <summary>
        /// Updates an existing driver in the repository.
        /// </summary>
        /// <param name="driver"></param>
        public void UpdateDriver(Driver driver)
        {
            string query = @"
                UPDATE drivers 
                SET name = @name, license_number = @license_number, phone = @phone, 
                    address = @address, status = @status, is_active = @is_active
                WHERE id = @id";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", driver.Id);
                command.Parameters.AddWithValue("@name", driver.Name);
                command.Parameters.AddWithValue("@license_number", driver.LicenseNumber);
                command.Parameters.AddWithValue("@phone", driver.Phone);
                command.Parameters.AddWithValue("@address", driver.Address);
                command.Parameters.AddWithValue("@status", (int)driver.Status);
                command.Parameters.AddWithValue("@is_active", driver.IsActive);
            });
        }

        /// <summary>
        /// Deletes a driver from the repository by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDriver(int id)
        {
            string query = "DELETE FROM drivers WHERE id = @id";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@id", id);
            });
            return rowsAffected > 0;
        }

        /// <summary>
        /// Retrieves a driver by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Driver GetDriverById(int id)
        {

            string query = "SELECT * FROM drivers WHERE id = @id";
            using (var conn = DatabaseHelper.GetConnection())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Driver
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                Phone = reader.GetString("phone"),
                                LicenseNumber = reader.GetString("license_number"),
                                Address = reader.GetString("address"),
                                IsActive = reader.GetBoolean("is_active"),
                                Status = (DriverStatus)reader.GetInt32("status")
                            };
                        }
                    }
                }
            }
            return null;

        }

        /// <summary>
        /// Retrieves all drivers from the repository.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            string query = "SELECT * FROM drivers";
            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(new Driver
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                Phone = reader.GetString("phone"),
                                LicenseNumber = reader.GetString("license_number"),
                                Address = reader.GetString("address"),
                                IsActive = reader.GetBoolean("is_active"),
                                Status = (DriverStatus)reader.GetInt32("status")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    throw new Exception("Error retrieving drivers", ex);
                }
            }
            return drivers;
        }

        /// <summary>
        /// Checks if a phone number already exists in the repository, excluding a specific driver ID.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="driverIdToExclude"></param>
        /// <returns></returns>
        public bool IsPhoneNumberExists(string phoneNumber, int driverIdToExclude)
        {
            string query = "SELECT COUNT(1) FROM drivers WHERE phone = @phone AND id != @id";

            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@phone", phoneNumber),
                new MySqlParameter("@id", driverIdToExclude));
            return Convert.ToInt64(result) > 0;
        }

        /// <summary>
        /// Checks if a license number already exists in the repository, excluding a specific driver ID.
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="driverIdToExclude"></param>
        /// <returns></returns>
        public bool IsLicenseNumberExists(string licenseNumber, int driverIdToExclude)
        {
            string query = "SELECT COUNT(1) FROM drivers WHERE license_number = @licenseNumber AND id != @id";

            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@licenseNumber", licenseNumber),
                new MySqlParameter("@id", driverIdToExclude));

            return Convert.ToInt64(result) > 0;
        }


        public List<Driver> GetAvailableDrivers(int? currentDrivertId = null)
        {

            string query = @"
                SELECT * FROM drivers 
                WHERE is_active = true AND (id NOT IN (SELECT truck_id FROM transport_units WHERE driver_id IS NOT NULL) 
                OR id = @currentDrivertId)";

            return DatabaseHelper.ExecuteReader(query, reader =>
            {
                return new Driver
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString()
                };
            },
            new MySqlParameter("@currentDrivertId", currentDrivertId ?? (object)DBNull.Value));
        }
    }
}
