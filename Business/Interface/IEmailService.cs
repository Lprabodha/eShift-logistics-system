using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
    public interface IEmailService
    {
        void SendJobConfirmationEmail(Job job);
        void SendJobApprovedEmail(Job job);
        void SendJobStatusUpdateEmail(Job job, JobStatus newStatus);
        void SendJobCompletionEmailWithInvoice(Job job);
    }
}
