using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    /// <summary>
    /// Service for managing job creation and business logic related to jobs.
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobservice;
        private readonly IEmailService _emailService;
        public JobService(IJobRepository jobservice)
        {
            _jobservice = jobservice;
            _emailService = new EmailService();
        }

        /// <summary>
        /// Creates a new job with a unique job number based on the current year and the last job ID.
        /// </summary>
        /// <param name="job"></param>
        public void CreateNewJob(Job job)
        {
            int lastId = _jobservice.GetLastJobId();
            string year = DateTime.Now.ToString("yyyy");
            job.JobNumber = $"JOB-{year}-{(lastId + 1):D4}";

            try
            {
                _emailService.SendJobConfirmationEmail(job);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Email Error] Failed to send confirmation for Job #{job.JobNumber}: {ex.Message}");
            }

            _jobservice.CreateJob(job);
        }

        /// <summary>
        /// Retrieves all jobs with their details, including associated products and transport units.
        /// </summary>
        /// <returns></returns>
        public List<Job> GetAllJobsWithDetails()
        {
            return _jobservice.GetAllJobsWithDetails();
        }

        /// <summary>
        /// Finalizes a job by updating its status and estimated cost, and assigning it to a transport unit.
        /// </summary>
        /// <param name="job"></param>
        public void AssignUnitAndFinalizeJob(Job job)
        {
            job.EstimatedCost = CalculateEstimatedCost(job.Loads);
            job.Status = JobStatus.Accepted;

            _jobservice.FinalizeJob(job);

            try
            {
                var customer = new UserRepository().GetUserById(job.CustomerId); 
                job.Customer = customer;
                _emailService.SendJobApprovedEmail(job);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Email Error] Failed to send approval for Job #{job.JobNumber}: {ex.Message}");
            }
        }

        /// <summary>
        /// Calculates the estimated cost for a list of loads based on predefined rates and other criteria.
        /// </summary>
        /// <param name="loads"></param>
        /// <returns></returns>
        public decimal CalculateEstimatedCost(List<Load> loads)
        {
            const decimal baseRate = 5000m;
            const decimal ratePerKg = 100m;
            const decimal ratePerCubicMeter = 20000m;

            if (loads == null || !loads.Any()) return 0;

            decimal totalWeight = loads.Sum(l => l.Weight);
            decimal totalVolume = loads.Sum(l => l.Volume);

            decimal weightCost = totalWeight * ratePerKg;
            decimal volumeCost = totalVolume * ratePerCubicMeter;

            return baseRate + Math.Max(weightCost, volumeCost);
        }

        /// <summary>
        /// Retrieves a job by its ID, including all associated details such as products and transport units.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public Job GetJobWithDetailsById(int jobId)
        {
            return _jobservice.GetJobWithDetailsById(jobId);
        }

        /// <summary>
        /// Updates the status of a job based on its ID and the new status provided.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="newStatus"></param>
        public void UpdateJobStatus(int jobId, JobStatus newStatus)
        {
            _jobservice.UpdateJobStatus(jobId, newStatus);

            try
            {
                var updatedJob = _jobservice.GetJobWithDetailsById(jobId);
                if (updatedJob != null)
                {
                    if (newStatus == JobStatus.Completed)
                    {
                        _emailService.SendJobCompletionEmailWithInvoice(updatedJob);
                    }
                    else
                    {
                        _emailService.SendJobStatusUpdateEmail(updatedJob, newStatus);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Email Error] Failed to send status update for Job #{jobId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves jobs associated with a specific customer by their ID.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Job> GetJobsByCustomerId(int customerId)
        {
            return _jobservice.GetJobsByCustomerId(customerId);
        }

        /// <summary>
        /// Retrieves the count of jobs based on their status. If no status is provided, it returns the total count of all jobs.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetJobCountByStatus(JobStatus? status = null)
        {
            return _jobservice.GetJobCountByStatus(status);
        }

        /// <summary>
        /// Retrieves a list of recent jobs, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Job> GetRecentJobs(int limit = 5)
        {
            return _jobservice.GetRecentJobs(limit);
        }

        /// <summary>
        /// Retrieves a list of the most recent jobs assigned to transport units, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Job> GetLatestAssignedJobs(int limit = 5)
        {
            return _jobservice.GetLatestAssignedJobs(limit);
        }

        /// <summary>
        /// Retrieves the count of jobs for a specific customer based on their ID and an optional status filter.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetJobCountByCustomer(int customerId, JobStatus? status = null)
        {
            return _jobservice.GetJobCountByCustomer(customerId, status);
        }

        /// <summary>
        /// Retrieves a list of the most recent jobs for a specific customer, limited to a specified number.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Job> GetRecentJobsByCustomer(int customerId, int limit = 5)
        {
            return _jobservice.GetRecentJobsByCustomer(customerId, limit);
        }

        /// <summary>
        /// Cancels a job by its ID, updating its status to 'Cancelled' and removing any associated transport unit.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public bool CancelJob(int jobId)
        {
            return _jobservice.CancelJob(jobId);
        }
    }
}
