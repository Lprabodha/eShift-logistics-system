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

    }
}
