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
    public class JobRepository : IJobRepository
    {
        /// <summary>
        /// Retrieves the last job ID from the database.
        /// </summary>
        /// <returns></returns>
        public int GetLastJobId()
        {
            string query = "SELECT MAX(id) FROM jobs";
            object result = DatabaseHelper.ExecuteScalar(query);
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : 0;
        }

        /// <summary>
        /// Creates a new job in the database along with its associated products.
        /// </summary>
        /// <param name="job"></param>
        public void CreateJob(Job job)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string jobQuery = @"
                        INSERT INTO jobs (job_number, customer_id, pickup_location, delivery_location, requested_date, description, status) 
                        VALUES (@job_number, @customer_id, @pickup_location, @delivery_location, @requested_date, @description, @status);
                        SELECT LAST_INSERT_ID();"; 

                    using (var cmdJob = new MySqlCommand(jobQuery, conn, transaction))
                    {
                        cmdJob.Parameters.AddWithValue("@job_number", job.JobNumber);
                        cmdJob.Parameters.AddWithValue("@customer_id", job.CustomerId);
                        cmdJob.Parameters.AddWithValue("@pickup_location", job.PickupLocation);
                        cmdJob.Parameters.AddWithValue("@delivery_location", job.DeliveryLocation);
                        cmdJob.Parameters.AddWithValue("@requested_date", job.RequestedDate);
                        cmdJob.Parameters.AddWithValue("@description", job.Description);
                        cmdJob.Parameters.AddWithValue("@status", (int)job.Status);

                        // Execute and get the new Job ID
                        job.Id = Convert.ToInt32(cmdJob.ExecuteScalar());
                    }

                    foreach (var item in job.JobProducts)
                    {
                        string productQuery = @"
                            INSERT INTO job_products (job_id, product_id, quantity) 
                            VALUES (@job_id, @product_id, @quantity)";

                        using (var cmdProduct = new MySqlCommand(productQuery, conn, transaction))
                        {
                            cmdProduct.Parameters.AddWithValue("@job_id", job.Id);
                            cmdProduct.Parameters.AddWithValue("@product_id", item.ProductId);
                            cmdProduct.Parameters.AddWithValue("@quantity", item.Quantity);
                            cmdProduct.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; 
                }
            }
        }


        /// <summary>
        /// Retrieves a list of all jobs with their associated customer and transport unit details.
        /// </summary>
        public List<Job> GetAllJobsWithDetails()
        {
            string query = @"
                SELECT 
                    j.id, j.job_number, j.pickup_location, j.delivery_location, j.requested_date, j.status,
                    c.id as customer_id, c.first_name, c.last_name,
                    tu.id as unit_id, tu.unit_number,
                    t.id as truck_id, t.license_plate,
                    d.id as driver_id, d.name as driver_name,
                    a.id as assistant_id, a.name as assistant_name
                FROM jobs j
                INNER JOIN users c ON j.customer_id = c.id
                LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                LEFT JOIN trucks t ON tu.truck_id = t.id
                LEFT JOIN drivers d ON tu.driver_id = d.id
                LEFT JOIN assistants a ON tu.assistant_id = a.id
                ORDER BY j.created_date DESC";

            return DatabaseHelper.ExecuteReader(query, reader => MapToJob(reader));
        }


        /// <summary>
        /// Maps a MySqlDataReader to a Job object, including customer and transport unit details.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Job MapToJob(MySqlDataReader reader)
        {
            var job = new Job
            {
                Id = Convert.ToInt32(reader["id"]),
                JobNumber = reader["job_number"].ToString(),
                PickupLocation = reader["pickup_location"].ToString(),
                DeliveryLocation = reader["delivery_location"].ToString(),
                RequestedDate = Convert.ToDateTime(reader["requested_date"]),
                Status = (JobStatus)Convert.ToInt32(reader["status"]),
                Customer = new User
                {
                    Id = Convert.ToInt32(reader["customer_id"]),
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString()
                }
            };

            if (reader["unit_id"] != DBNull.Value)
            {
                job.TransportUnit = new TransportUnit
                {
                    Id = Convert.ToInt32(reader["unit_id"]),
                    UnitNumber = reader["unit_number"].ToString(),
                    Truck = new Truck { Id = Convert.ToInt32(reader["truck_id"]), LicensePlate = reader["license_plate"].ToString() },
                    Driver = new Driver { Id = Convert.ToInt32(reader["driver_id"]), Name = reader["driver_name"].ToString() },
                    Assistant = reader["assistant_id"] == DBNull.Value ? null : new Assistant { Id = Convert.ToInt32(reader["assistant_id"]), Name = reader["assistant_name"].ToString() }
                };
            }

            return job;
        }


        /// <summary>
        /// Finalizes a job by saving its loads, updating its cost, and assigning a transport unit
        /// within a single database transaction.
        /// </summary>
        public void FinalizeJob(Job job)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    using (var cmdDelete = new MySqlCommand("DELETE FROM loads WHERE job_id = @job_id", conn, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@job_id", job.Id);
                        cmdDelete.ExecuteNonQuery();
                    }

                    foreach (var load in job.Loads)
                    {
                        using (var cmdLoad = new MySqlCommand(
                            @"INSERT INTO loads (job_id, description, weight, volume) 
                              VALUES (@job_id, @description, @weight, @volume)", conn, transaction))
                        {
                            cmdLoad.Parameters.AddWithValue("@job_id", job.Id);
                            cmdLoad.Parameters.AddWithValue("@description", load.Description);
                            cmdLoad.Parameters.AddWithValue("@weight", load.Weight);
                            cmdLoad.Parameters.AddWithValue("@volume", load.Volume);
                            cmdLoad.ExecuteNonQuery();
                        }
                    }

                    using (var cmdJobUpdate = new MySqlCommand(
                        @"UPDATE jobs SET status = @status, estimated_cost = @cost, 
                          transport_unit_id = @unitId WHERE id = @id", conn, transaction))
                    {
                        cmdJobUpdate.Parameters.AddWithValue("@status", (int)job.Status);
                        cmdJobUpdate.Parameters.AddWithValue("@cost", job.EstimatedCost);
                        cmdJobUpdate.Parameters.AddWithValue("@unitId", job.TransportUnitId);
                        cmdJobUpdate.Parameters.AddWithValue("@id", job.Id);
                        cmdJobUpdate.ExecuteNonQuery();
                    }

                    using (var cmdUnitUpdate = new MySqlCommand(
                        "UPDATE transport_units SET status = @status WHERE id = @id", conn, transaction))
                    {
                        cmdUnitUpdate.Parameters.AddWithValue("@status", (int)TransportUnitStatus.Assigned);
                        cmdUnitUpdate.Parameters.AddWithValue("@id", job.TransportUnitId);
                        cmdUnitUpdate.ExecuteNonQuery();
                    }

                    if (job.TransportUnit?.DriverId != null)
                    {
                        using (var cmdDriverUpdate = new MySqlCommand(
                            "UPDATE drivers SET status = @status WHERE id = @id", conn, transaction))
                        {
                            cmdDriverUpdate.Parameters.AddWithValue("@status", (int)DriverStatus.Assigned);
                            cmdDriverUpdate.Parameters.AddWithValue("@id", job.TransportUnit.DriverId);
                            cmdDriverUpdate.ExecuteNonQuery();
                        }
                    }

                    if (job.TransportUnit?.AssistantId != null)
                    {
                        using (var cmdDriverUpdate = new MySqlCommand(
                            "UPDATE assistants SET status = @status WHERE id = @id", conn, transaction))
                        {
                            cmdDriverUpdate.Parameters.AddWithValue("@status", (int)DriverStatus.Assigned);
                            cmdDriverUpdate.Parameters.AddWithValue("@id", job.TransportUnit.AssistantId);
                            cmdDriverUpdate.ExecuteNonQuery();
                        }
                    }

                    if (job.TransportUnit?.TruckId != null)
                    {
                        using (var cmdDriverUpdate = new MySqlCommand(
                            "UPDATE trucks SET status = @status WHERE id = @id", conn, transaction))
                        {
                            cmdDriverUpdate.Parameters.AddWithValue("@status", (int)DriverStatus.Assigned);
                            cmdDriverUpdate.Parameters.AddWithValue("@id", job.TransportUnit.TruckId);
                            cmdDriverUpdate.ExecuteNonQuery();
                        }
                    }


                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; 
                }
            }
        }

        /// <summary>
        /// Retrieves a job by its ID, including all associated details such as products and transport units.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>

        public Job GetJobWithDetailsById(int jobId)
        {
            Job job = null;
            string query = @"
                SELECT 
                    j.*, 
                    c.id as customer_id, c.first_name, c.last_name, c.email, c.phone as customer_phone,
                    jp.product_id, jp.quantity, p.name as product_name,
                    tu.id as unit_id, tu.unit_number
                FROM jobs j
                INNER JOIN users c ON j.customer_id = c.id
                LEFT JOIN job_products jp ON j.id = jp.job_id
                LEFT JOIN products p ON jp.product_id = p.id
                LEFT JOIN transport_units tu ON j.transport_unit_id = tu.id
                WHERE j.id = @jobId";

            DatabaseHelper.ExecuteReader(query, reader =>
            {
                if (job == null)
                {
                    job = new Job
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobNumber = reader["job_number"].ToString(),
                        PickupLocation = reader["pickup_location"].ToString(),
                        DeliveryLocation = reader["delivery_location"].ToString(),
                        RequestedDate = Convert.ToDateTime(reader["requested_date"]),
                        Status = (JobStatus)Convert.ToInt32(reader["status"]),
                        EstimatedCost = reader.IsDBNull(reader.GetOrdinal("estimated_cost")) ? 0 : reader.GetDecimal("estimated_cost"),
                        TransportUnitId = reader.IsDBNull(reader.GetOrdinal("transport_unit_id")) ? (int?)null : Convert.ToInt32(reader["transport_unit_id"]),
                        Customer = new User
                        {
                            Id = Convert.ToInt32(reader["customer_id"]),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Phone = reader["customer_phone"].ToString()
                        }
                    };
                }
                if (!reader.IsDBNull(reader.GetOrdinal("product_id")))
                {
                    job.JobProducts.Add(new JobProduct
                    {
                        ProductId = Convert.ToInt32(reader["product_id"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Product = new Product { Name = reader["product_name"].ToString() }
                    });
                }
                if (job.TransportUnit == null && !reader.IsDBNull(reader.GetOrdinal("unit_id")))
                {
                    job.TransportUnit = new TransportUnit { Id = Convert.ToInt32(reader["unit_id"]), UnitNumber = reader["unit_number"].ToString() };
                }
                return job; 
            }, new MySqlParameter("@jobId", jobId));

            return job;
        }

    }
}
