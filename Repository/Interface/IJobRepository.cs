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

        List<Job> GetAllJobsWithDetails();

    }
}
