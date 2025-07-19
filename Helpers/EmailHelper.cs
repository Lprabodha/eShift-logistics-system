using MimeKit;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Windows.Forms;

namespace eShift_Logistics_System.Helpers
{
    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachmentPath { get; set; }
        public bool IsHtml { get; set; }
    }

    public static class EmailHelper
    {
        private static readonly string emailAddress = "8b78dd58987492";
        private static readonly string emailPassword = "4e176a6f5d26dd";
        private static readonly string smtpHost = "smtp.mailtrap.io";
        private static readonly int smtpPort = 587;

        // Email queue and background worker
        private static readonly ConcurrentQueue<EmailMessage> _emailQueue = new ConcurrentQueue<EmailMessage>();
        private static readonly AutoResetEvent _queueNotifier = new AutoResetEvent(false);
        private static readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private static readonly Task _workerTask;

        static EmailHelper()
        {
            // Start the background worker
            _workerTask = Task.Factory.StartNew(ProcessQueue, TaskCreationOptions.LongRunning);
        }

        public static void QueueEmail(string toEmail, string subject, string body, string attachmentPath = null, bool isHtml = false)
        {
            _emailQueue.Enqueue(new EmailMessage
            {
                ToEmail = toEmail,
                Subject = subject,
                Body = body,
                AttachmentPath = attachmentPath,
                IsHtml = isHtml
            });
            _queueNotifier.Set();
        }

        private static void ProcessQueue()
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                while (_emailQueue.TryDequeue(out var email))
                {
                    try
                    {
                        SendEmail(email.ToEmail, email.Subject, email.Body, email.AttachmentPath, email.IsHtml);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Queue Email Error: {ex.Message}");
                    }
                }
                _queueNotifier.WaitOne(TimeSpan.FromSeconds(5)); // Wait for new emails or timeout
            }
        }

        public static void StopQueue()
        {
            _cts.Cancel();
            _queueNotifier.Set();
            _workerTask.Wait();
        }

        /// <summary>
        /// Sends an email with optional attachment.
        /// </summary>
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

        public static void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentPath)
        {
            SendEmail(toEmail, subject, body, attachmentPath: attachmentPath);
        }
    }
}