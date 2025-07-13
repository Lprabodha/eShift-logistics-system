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
        void CreateNewJob(Job job);
    }
}
