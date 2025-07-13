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

        List<Job> GetAllJobsWithDetails();

    }
}
