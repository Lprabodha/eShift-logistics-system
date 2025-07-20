using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IJobStatusRepository
    {
        /// <summary>
        /// Adds a log entry for a job status change.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="status"></param>
        /// <param name="updatedBy"></param>
        /// <param name="note"></param>
        void AddLogJobStatus(int jobId, string status, int? updatedBy, string note = "");
    }
}
