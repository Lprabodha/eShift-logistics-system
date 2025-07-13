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

        void AddLogJobStatus(int jobId, string status, int? updatedBy, string note = "");
    }
}
