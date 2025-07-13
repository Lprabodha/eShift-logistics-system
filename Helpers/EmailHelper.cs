using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Helpers
{
    public class EmailHelper
    {
        public static void SendNewUserRegistrationEmail(string toEmail, string userName)
        {
            // Logic to send email for new user registration
            Console.WriteLine($"Sending registration email to {toEmail} for user {userName}");
        }

        public static void SendPickupConfirmationEmail(string toEmail, string pickupDetails)
        {
            // Logic to send email for pickup confirmation
            Console.WriteLine($"Sending pickup confirmation email to {toEmail} with details: {pickupDetails}");
        }

        public static void SendJobStatusUpdateEmail(string toEmail, string jobId, string status)
        {
            // Logic to send email for job status update
            Console.WriteLine($"Sending job status update email to {toEmail} for job {jobId} with status: {status}");
        }

        public static void SendJobCompletionEmail(string toEmail, string jobId)
        {
            // Logic to send email for job completion
            Console.WriteLine($"Sending job completion email to {toEmail} for job {jobId}");
        }

        public static void SendJobCancellationEmail(string toEmail, string jobId)
        {
            // Logic to send email for job cancellation
            Console.WriteLine($"Sending job cancellation email to {toEmail} for job {jobId}");
        }

        public static void SendJobRescheduleEmail(string toEmail, string jobId, string newSchedule)
        {
            // Logic to send email for job reschedule
            Console.WriteLine($"Sending job reschedule email to {toEmail} for job {jobId} with new schedule: {newSchedule}");
        }

        public static void SendAdminApprovalEmail(string toEmail, string jobId)
        {
            // Logic to send email for admin approval of job status
            Console.WriteLine($"Sending admin approval email to {toEmail} for job {jobId}");
        }

        public static void SendEmail(string toEmail, string subject, string body)
        {
            // Logic to send a generic email
            Console.WriteLine($"Sending email to {toEmail} with subject: {subject}");
            Console.WriteLine($"Email body: {body}");
        }

        public static void SendEmailWithTemplate(string toEmail, string templateName, Dictionary<string, string> templateData)
        {
            // Logic to send an email using a specific template
            Console.WriteLine($"Sending email to {toEmail} using template: {templateName}");
            foreach (var data in templateData)
            {
                Console.WriteLine($"{data.Key}: {data.Value}");
            }
        }

        public static void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentPath)
        {
            // Logic to send an email with an attachment
            Console.WriteLine($"Sending email to {toEmail} with subject: {subject}");
            Console.WriteLine($"Email body: {body}");
            Console.WriteLine($"Attachment path: {attachmentPath}");
        }

        public static void SendBulkEmail(List<string> toEmails, string subject, string body)
        {
            // Logic to send bulk emails
            foreach (var email in toEmails)
            {
                Console.WriteLine($"Sending bulk email to {email} with subject: {subject}");
                Console.WriteLine($"Email body: {body}");
            }
        }

        public static void SendEmailWithCC(string toEmail, string ccEmail, string subject, string body)
        {
            // Logic to send an email with CC
            Console.WriteLine($"Sending email to {toEmail} with CC to {ccEmail}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Email body: {body}");
        }

        public static void SendEmailWithBCC(string toEmail, string bccEmail, string subject, string body)
        {
            // Logic to send an email with BCC
            Console.WriteLine($"Sending email to {toEmail} with BCC to {bccEmail}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Email body: {body}");
        }

        public static void SendEmailWithHtmlBody(string toEmail, string subject, string htmlBody)
        {
            // Logic to send an email with HTML body
            Console.WriteLine($"Sending HTML email to {toEmail} with subject: {subject}");
            Console.WriteLine($"HTML Email body: {htmlBody}");
        }

        public static void SendEmailWithPriority(string toEmail, string subject, string body, string priority)
        {
            // Logic to send an email with priority
            Console.WriteLine($"Sending email to {toEmail} with subject: {subject} and priority: {priority}");
            Console.WriteLine($"Email body: {body}");
        }

    }
}
