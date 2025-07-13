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

    }
}
