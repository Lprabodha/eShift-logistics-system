using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IJobRepository
    {
        /// <summary>
        /// Retrieves the last job ID from the database.
        /// </summary>
        /// <returns></returns>
        int GetLastJobId();

        /// <summary>
        ///  
        /// </summary>
        /// <param name="job"></param>
        void CreateJob(Job job);

        /// <summary>
        /// Retrieves all jobs with their details, including associated products and transport units.
        /// </summary>
        /// <returns></returns>
        List<Job> GetAllJobsWithDetails();

        /// <summary>
        /// Finalizes a job by updating its status and completion date.
        /// </summary>
        /// <param name="job"></param>
        void FinalizeJob(Job job);

        /// <summary>
        /// Calculates the estimated cost for a list of loads based on predefined rates and other criteria.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Job GetJobWithDetailsById(int jobId);

        /// <summary>
        /// Updates the status of a job based on its ID and the new status provided.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="newStatus"></param>
        void UpdateJobStatus(int jobId, JobStatus newStatus);

        /// <summary>
        /// Retrieves all jobs associated with a specific customer ID, including their details.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<Job> GetJobsByCustomerId(int customerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        int GetJobCountByStatus(JobStatus? status = null);

        /// <summary>
        /// Retrieves a list of the most recent jobs, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        List<Job> GetRecentJobs(int limit = 5);

        /// <summary>
        /// Retrieves a list of the most recent jobs, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        List<Job> GetLatestAssignedJobs(int limit);

        /// <summary>
        /// Retrieves the count of jobs based on their status. If no status is provided, it returns the total count of all jobs.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        int GetJobCountByCustomer(int customerId, JobStatus? status = null);

        /// <summary>
        /// Retrieves a list of recent jobs for a specific customer, limited to a specified number.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        List<Job> GetRecentJobsByCustomer(int customerId, int limit);

        bool CancelJob(int jobId);
    }
}
