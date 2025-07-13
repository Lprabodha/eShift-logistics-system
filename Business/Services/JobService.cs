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
        public JobService(IJobRepository jobservice)
        {
            _jobservice = jobservice;
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


        public void UpdateJobStatus(int jobId, JobStatus newStatus)
        {
            _jobservice.UpdateJobStatus(jobId, newStatus);
        }
    }
}
