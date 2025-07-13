using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    public class JobStatusService : IJobStatusService
    {

        private readonly IJobStatusRepository _jobStatusService;

        public JobStatusService(IJobStatusRepository jobStatusService)
        {
            _jobStatusService = jobStatusService;
        }

        public void AddLogJobStatus(int jobId, string status, int? updatedBy, string note = "")
        {
            _jobStatusService.AddLogJobStatus(jobId, status, updatedBy, note);
        }

    }
}
