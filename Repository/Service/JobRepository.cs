using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

                    int loadSequence = 1;

                    foreach (var load in job.Loads)
                    {
                        load.LoadNumber = $"{job.JobNumber}-L{loadSequence:D2}";

                        using (var cmdLoad = new MySqlCommand(
                            @"INSERT INTO loads (job_id, load_number, description, weight, volume) 
                    VALUES (@job_id, @load_number, @description, @weight, @volume)", conn, transaction))
                        {
                            cmdLoad.Parameters.AddWithValue("@job_id", job.Id);
                            cmdLoad.Parameters.AddWithValue("@load_number", load.LoadNumber);
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

        /// <summary>
        /// Updates the status of a job based on its ID and the new status provided.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="newStatus"></param>
        public void UpdateJobStatus(int jobId, JobStatus newStatus)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string getUnitIdQuery = "SELECT transport_unit_id FROM jobs WHERE id = @jobId";
                    int? unitId = null;
                    using (var cmd = new MySqlCommand(getUnitIdQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        var result = cmd.ExecuteScalar();
                        unitId = result != DBNull.Value && result != null ? Convert.ToInt32(result) : (int?)null;
                    }

                    string jobUpdateQuery = "UPDATE jobs SET status = @newStatus, completion_date = IF(@newStatus = @completedStatus, NOW(), completion_date) WHERE id = @jobId";
                    using (var cmd = new MySqlCommand(jobUpdateQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@newStatus", (int)newStatus);
                        cmd.Parameters.AddWithValue("@completedStatus", (int)JobStatus.Completed);
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        cmd.ExecuteNonQuery();
                    }

                    if (unitId.HasValue && (newStatus == JobStatus.Completed || newStatus == JobStatus.Cancelled))
                    {
                        UpdateUnitAndComponentStatus(unitId, TransportUnitStatus.Free, conn, transaction);
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
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="unitStatus"></param>
        /// <param name="conn"></param>
        /// <param name="transaction"></param>
        private void UpdateUnitAndComponentStatus(int? unitId, TransportUnitStatus unitStatus, MySqlConnection conn, MySqlTransaction transaction)
        {
            if (!unitId.HasValue) return;

            string getIdsQuery = "SELECT truck_id, driver_id, assistant_id FROM transport_units WHERE id = @unitId";
            using (var cmd = new MySqlCommand(getIdsQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@unitId", unitId.Value);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return;
                    int truckId = reader.GetInt32("truck_id");
                    int driverId = reader.GetInt32("driver_id");
                    int? assistantId = reader.IsDBNull(reader.GetOrdinal("assistant_id")) ? (int?)null : reader.GetInt32("assistant_id");
                    reader.Close();

                    var truckComponentStatus = (unitStatus == TransportUnitStatus.Free) ? TruckStatus.Available : TruckStatus.OnJob;
                    var driverComponentStatus = (unitStatus == TransportUnitStatus.Free) ? DriverStatus.Available : DriverStatus.Assigned;
                    var assistantComponentStatus = (unitStatus == TransportUnitStatus.Free) ? AssistantStatus.Available : AssistantStatus.Assigned;

                    // Update Transport Unit
                    string unitQuery = "UPDATE transport_units SET status = @status WHERE id = @id";
                    using (var unitCmd = new MySqlCommand(unitQuery, conn, transaction))
                    {
                        unitCmd.Parameters.AddWithValue("@status", (int)unitStatus);
                        unitCmd.Parameters.AddWithValue("@id", unitId.Value);
                        unitCmd.ExecuteNonQuery();
                    }

                    // Update Truck
                    string truckQuery = "UPDATE trucks SET status = @status WHERE id = @id";
                    using (var truckCmd = new MySqlCommand(truckQuery, conn, transaction))
                    {
                        truckCmd.Parameters.AddWithValue("@status", (int)truckComponentStatus);
                        truckCmd.Parameters.AddWithValue("@id", truckId);
                        truckCmd.ExecuteNonQuery();
                    }

                    // Update Driver
                    string driverQuery = "UPDATE drivers SET status = @status WHERE id = @id";
                    using (var driverCmd = new MySqlCommand(driverQuery, conn, transaction))
                    {
                        driverCmd.Parameters.AddWithValue("@status", (int)driverComponentStatus);
                        driverCmd.Parameters.AddWithValue("@id", driverId);
                        driverCmd.ExecuteNonQuery();
                    }

                    // Update Assistant (if one exists)
                    if (assistantId.HasValue)
                    {
                        string assistantQuery = "UPDATE assistants SET status = @status WHERE id = @id";
                        using (var assistantCmd = new MySqlCommand(assistantQuery, conn, transaction))
                        {
                            assistantCmd.Parameters.AddWithValue("@status", (int)assistantComponentStatus);
                            assistantCmd.Parameters.AddWithValue("@id", assistantId.Value);
                            assistantCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves all jobs associated with a specific customer ID, including their details.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Job> GetJobsByCustomerId(int customerId)
        {
            string query = @"
                SELECT
                    j.id, j.job_number, j.pickup_location, j.delivery_location, j.requested_date, j.status,
                    j.dispatch_date, j.completion_date, j.description, j.estimated_cost, j.actual_cost,
                    j.transport_unit_id, j.created_date, j.notes
                FROM jobs j
                WHERE j.customer_id = @customerId
                ORDER BY j.requested_date DESC";

            try
            {
                return DatabaseHelper.ExecuteReader(query, reader =>
                {
                    return new Job
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JobNumber = reader["job_number"] == DBNull.Value ? string.Empty : reader["job_number"].ToString(),
                        PickupLocation = reader["pickup_location"] == DBNull.Value ? string.Empty : reader["pickup_location"].ToString(),
                        DeliveryLocation = reader["delivery_location"] == DBNull.Value ? string.Empty : reader["delivery_location"].ToString(),
                        RequestedDate = Convert.ToDateTime(reader["requested_date"]),
                        Status = (JobStatus)Convert.ToInt32(reader["status"]),
                        DispatchDate = reader["dispatch_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["dispatch_date"]),
                        CompletionDate = reader["completion_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["completion_date"]),
                        Description = reader["description"] == DBNull.Value ? null : reader["description"].ToString(),
                        EstimatedCost = Convert.ToDecimal(reader["estimated_cost"]),
                        ActualCost = reader["actual_cost"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["actual_cost"]),
                        TransportUnitId = reader["transport_unit_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["transport_unit_id"]),
                        CreatedDate = Convert.ToDateTime(reader["created_date"]),
                        Notes = reader["notes"] == DBNull.Value ? null : reader["notes"].ToString()
                    };
                }, new MySqlParameter("@customerId", customerId));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JobRepository.GetJobsByCustomerId: {ex.Message}");
                throw; 
            }
        }

        /// <summary>
        /// Retrieves the count of jobs based on their status. If no status is provided, it returns the total count of jobs.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetJobCountByStatus(JobStatus? status = null)
        {
            string query = "SELECT COUNT(*) FROM jobs";
            if (status.HasValue)
            {
                query += " WHERE status = @status";
            }

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (status.HasValue)
                {
                    cmd.Parameters.AddWithValue("@status", (int)status.Value);
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Retrieves a list of the most recent jobs, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Job> GetRecentJobs(int limit = 5)
        {
            string query = @"
            SELECT j.job_number, c.first_name, c.last_name, j.delivery_location, j.status 
            FROM jobs j
            INNER JOIN users c ON j.customer_id = c.id
            ORDER BY j.created_date DESC
            LIMIT @limit";

            return DatabaseHelper.ExecuteReader(query, reader => new Job
            {
                JobNumber = reader["job_number"].ToString(),
                Customer = new User { FirstName = reader["first_name"].ToString(), LastName = reader["last_name"].ToString() },
                DeliveryLocation = reader["delivery_location"].ToString(),
                Status = (JobStatus)Convert.ToInt32(reader["status"])
            }, new MySqlParameter("@limit", limit));
        }

        /// <summary>
        /// Retrieves a list of the most recent jobs assigned to transport units, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Job> GetLatestAssignedJobs(int limit = 5)
        {
            string query = @"
            SELECT 
                j.job_number, j.status,
                tu.unit_number,
                d.name as driver_name
            FROM jobs j
            INNER JOIN transport_units tu ON j.transport_unit_id = tu.id
            INNER JOIN drivers d ON tu.driver_id = d.id
            WHERE j.transport_unit_id IS NOT NULL
            ORDER BY j.created_date DESC
            LIMIT @limit";

            return DatabaseHelper.ExecuteReader(query, reader => new Job
            {
                JobNumber = reader["job_number"].ToString(),
                Status = (JobStatus)Convert.ToInt32(reader["status"]),
                TransportUnit = new TransportUnit
                {
                    UnitNumber = reader["unit_number"].ToString(),
                    Driver = new Driver { Name = reader["driver_name"].ToString() }
                }
            }, new MySqlParameter("@limit", limit));
        }

        /// <summary>
        /// Retrieves the count of jobs for a specific customer, optionally filtered by status.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetJobCountByCustomer(int customerId, JobStatus? status = null)
        {
            string query = "SELECT COUNT(*) FROM jobs WHERE customer_id = @customerId";
            if (status.HasValue)
            {
                query += " AND status = @status";
            }

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);
                if (status.HasValue)
                {
                    cmd.Parameters.AddWithValue("@status", (int)status.Value);
                }
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Retrieves a list of the most recent jobs for a specific customer, limited to a specified number.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Job> GetRecentJobsByCustomer(int customerId, int limit = 5)
        {
            string query = @"
            SELECT job_number, delivery_location, requested_date, status 
            FROM jobs 
            WHERE customer_id = @customerId
            ORDER BY created_date DESC
            LIMIT @limit";

            return DatabaseHelper.ExecuteReader(query, reader => new Job
            {
                JobNumber = reader["job_number"].ToString(),
                DeliveryLocation = reader["delivery_location"].ToString(),
                RequestedDate = Convert.ToDateTime(reader["requested_date"]),
                Status = (JobStatus)Convert.ToInt32(reader["status"])
            }, new MySqlParameter("@customerId", customerId), new MySqlParameter("@limit", limit));
        }


        /// <summary>
        /// Cancels a job by updating its status to Cancelled and freeing up the associated transport unit if it exists.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public bool CancelJob(int jobId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // First, get the transport_unit_id from the job to be cancelled
                    string getUnitQuery = "SELECT transport_unit_id FROM jobs WHERE id = @jobId";
                    int? unitId = null;
                    using (var cmd = new MySqlCommand(getUnitQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        var result = cmd.ExecuteScalar();
                        unitId = result != DBNull.Value && result != null ? Convert.ToInt32(result) : (int?)null;
                    }

                    // Update the job's status to Cancelled
                    string cancelQuery = "UPDATE jobs SET status = @status WHERE id = @jobId";
                    using (var cmd = new MySqlCommand(cancelQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@status", (int)JobStatus.Cancelled);
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        cmd.ExecuteNonQuery();
                    }

                    // If a transport unit was assigned, free it up
                    if (unitId.HasValue)
                    {
                        UpdateUnitAndComponentStatus(unitId, TransportUnitStatus.Free, conn, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
