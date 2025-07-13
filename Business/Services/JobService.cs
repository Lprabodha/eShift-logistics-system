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
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobservice;
        public JobService(IJobRepository jobservice)
        {
            _jobservice = jobservice;
        }
        public void CreateNewJob(Job job)
        {
            int lastId = _jobservice.GetLastJobId();
            string year = DateTime.Now.ToString("yyyy");
            job.JobNumber = $"JOB-{year}-{(lastId + 1):D4}";

            _jobservice.CreateJob(job);
        }
    }
}
