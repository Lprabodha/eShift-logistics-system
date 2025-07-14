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
        /// <summary>
        /// Sends a confirmation email to the customer when a job is created.
        /// </summary>
        /// <param name="job"></param>
        void SendJobConfirmationEmail(Job job);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        void SendJobApprovedEmail(Job job);

        /// <summary>
        /// Sends an email to the customer when a job is declined.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="newStatus"></param>
        void SendJobStatusUpdateEmail(Job job, JobStatus newStatus);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        void SendJobCompletionEmailWithInvoice(Job job);
    }
}
