using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit; 
using System.IO; 
using System.Windows.Forms;

namespace eShift_Logistics_System.Helpers
{
    public static class EmailHelper
    {
        /// <summary>
        /// SMTP configuration for sending emails.
        /// </summary>
        private static readonly string emailAddress = "8b78dd58987492"; 
        private static readonly string emailPassword = "4e176a6f5d26dd";
        private static readonly string smtpHost = "smtp.mailtrap.io"; 
        private static readonly int smtpPort = 587;

        /// <summary>
        /// Sends an email with optional attachment.
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachmentPath"></param>
        /// <param name="isHtml"></param>
        public static void SendEmail(string toEmail, string subject, string body, string attachmentPath = null, bool isHtml = false)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("eShift Logistics", emailAddress));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                if (isHtml)
                {
                    bodyBuilder.HtmlBody = body;
                }
                else
                {
                    bodyBuilder.TextBody = body;
                }

                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    if (File.Exists(attachmentPath))
                    {
                        bodyBuilder.Attachments.Add(attachmentPath);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Attachment file not found at '{attachmentPath}'. Email sent without it.");
                    }
                }

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(emailAddress, emailPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
                Console.WriteLine($"Email sent successfully to {toEmail} for subject: {subject}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email to {toEmail} with subject '{subject}': {ex.Message}");
                MessageBox.Show($"Failed to send email to {toEmail}. Error: {ex.Message}", "Email Sending Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sends a simple email without attachment.
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachmentPath"></param>
        public static void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentPath)
        {
            SendEmail(toEmail, subject, body, attachmentPath: attachmentPath);
        }

    }
}
