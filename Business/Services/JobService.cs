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
    }
}
