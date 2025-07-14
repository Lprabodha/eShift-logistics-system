using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
    public interface IJobService
    {
        /// <summary>
        /// Creates a new job with a unique job number based on the current year and the last job ID.
        /// </summary>
        /// <param name="job"></param>
        void CreateNewJob(Job job);

        /// <summary>
        /// Retrieves all jobs with their details, including associated products and transport units.
        /// </summary>
        /// <returns></returns>
        List<Job> GetAllJobsWithDetails();

        /// <summary>
        /// Finalizes a job by updating its status and completion date.
        /// </summary>
        /// <param name="job"></param>
        void AssignUnitAndFinalizeJob(Job job);

        /// <summary>
        /// Calculates the estimated cost for a list of loads based on predefined rates and other criteria.
        /// </summary>
        /// <param name="loads"></param>
        /// <returns></returns>
        decimal CalculateEstimatedCost(List<Load> loads);

        /// <summary>
        /// Retrieves a job by its ID, including all associated details such as products and transport units.
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
        /// Retrieves the count of jobs based on their status. If no status is provided, it returns the total count of all jobs.
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
        /// Retrieves a list of the most recent jobs assigned to the current user, limited to a specified number.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        List<Job> GetLatestAssignedJobs(int limit = 5);

        /// <summary>
        /// Retrieves the count of jobs associated with a specific customer ID, optionally filtered by status.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        int GetJobCountByCustomer(int customerId, JobStatus? status = null);

        /// <summary>
        /// Retrieves a list of the most recent jobs for a specific customer, limited to a specified number.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        List<Job> GetRecentJobsByCustomer(int customerId, int limit = 5);

        /// <summary>
        /// Cancels a job by its ID, updating its status to 'Cancelled' and setting the completion date to the current date.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        bool CancelJob(int jobId);

    }
}
