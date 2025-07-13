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
    }
}
