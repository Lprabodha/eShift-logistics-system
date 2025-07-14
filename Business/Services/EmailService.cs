using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System;
using System.IO;
using System.Linq;

namespace eShift_Logistics_System.Business.Services
{
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Sends a confirmation email to the customer when a job is created.
        /// </summary>
        /// <param name="job"></param>
        public void SendJobConfirmationEmail(Job job)
        {
            if (job?.Customer == null || string.IsNullOrEmpty(job.Customer.Email))
            {
                Console.WriteLine($"Cannot send confirmation email: Customer or Email is missing for Job #{job?.JobNumber}");
                return;
            }

            string subject = $"Pickup Request Received - Job #{job.JobNumber}";
            string body = $"Dear {job.Customer.FirstName},\n\nThank you for your request. We have received it and will process it shortly.\n\nYour Job Number is: {job.JobNumber}";
            EmailHelper.SendEmail(job.Customer.Email, subject, body);
        }

        /// <summary>
        /// Sends an email to the customer when their job is approved and scheduled for pickup.
        /// </summary>
        /// <param name="job"></param>
        public void SendJobApprovedEmail(Job job)
        {
            if (job?.Customer == null || string.IsNullOrEmpty(job.Customer.Email))
            {
                Console.WriteLine($"Cannot send approval email: Customer or Email is missing for Job #{job?.JobNumber}");
                return;
            }

            string subject = $"Your Job Has Been Approved - Job #{job.JobNumber}";
            string body = $"Dear {job.Customer.FirstName},\n\nYour job has been approved and scheduled for pickup.\nThe estimated cost is: {job.EstimatedCost:C}";
            EmailHelper.SendEmail(job.Customer.Email, subject, body);
        }

        /// <summary>
        /// Sends an email to the customer when the status of their job is updated.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="newStatus"></param>
        public void SendJobStatusUpdateEmail(Job job, JobStatus newStatus)
        {
            if (job?.Customer == null || string.IsNullOrEmpty(job.Customer.Email))
            {
                Console.WriteLine($"Cannot send status update email: Customer or Email is missing for Job #{job?.JobNumber}");
                return;
            }

            string subject = $"Job Status Update - Job #{job.JobNumber}";
            string body = $"Dear {job.Customer.FirstName},\n\nThe status of your job has been updated to: {newStatus}.\n\n";
            if (newStatus == JobStatus.Ongoing)
            {
                body += "Our team is on the way!";
            }
            EmailHelper.SendEmail(job.Customer.Email, subject, body);
        }

        /// <summary>
        /// Sends a completion email to the customer with an attached invoice when their job is completed.
        /// </summary>
        /// <param name="job"></param>
        public void SendJobCompletionEmailWithInvoice(Job job)
        {
            if (job?.Customer == null || string.IsNullOrEmpty(job.Customer.Email))
            {
                Console.WriteLine($"Cannot send completion email: Customer or Email is missing for Job #{job?.JobNumber}");
                return;
            }

            string subject = $"Your Job is Complete! - Invoice for Job #{job.JobNumber}";
            string body = $"Dear {job.Customer.FirstName},\n\nWe are pleased to inform you that your job has been completed. Please find your invoice attached.\n\nThank you for choosing e-Shift!";

            try
            {
                string invoicePath = GenerateInvoicePdf(job);

                EmailHelper.SendEmailWithAttachment(job.Customer.Email, subject, body, invoicePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating or sending invoice for Job #{job.JobNumber}: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates a PDF invoice for the given job and saves it to a temporary file.
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        private string GenerateInvoicePdf(Job job)
        {
            string filePath = Path.Combine(Path.GetTempPath(), $"Invoice_{job.JobNumber}.pdf");

             QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Header().Element(headerContainer => ComposeInvoiceHeader(headerContainer, job));
                    page.Content().Element(contentContainer => ComposeInvoiceContent(contentContainer, job));
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Page ");
                        text.CurrentPageNumber();
                    });
                });
            }).GeneratePdf(filePath);

            return filePath;
        }

        /// <summary>
        /// Composes the header of the invoice with job details.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="job"></param>
        private void ComposeInvoiceHeader(IContainer container, Job job)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice").Style(titleStyle);
                    column.Item().Text($"Invoice #: INV-{job.JobNumber}");
                    column.Item().Text($"Date: {DateTime.Now:d}");
                });
                row.ConstantItem(100).Height(50).Placeholder(); 
            });
        }

        /// <summary>
        /// Composes the main content of the invoice, including customer details, job details, and shipment loads.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="job"></param>
        private void ComposeInvoiceContent(IContainer container, Job job)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);

                column.Item().Text("Bill To:").SemiBold().FontSize(12);
                column.Item().Text(job.Customer?.FullName ?? "N/A");
                column.Item().Text(job.Customer?.Address ?? "N/A");
                column.Item().Text(job.Customer?.Phone ?? "N/A");
                column.Item().Text(job.Customer?.Email ?? "N/A");

                column.Item().PaddingVertical(10).LineHorizontal(1);

                // Job Details
                column.Item().Text("Job Details:").SemiBold().FontSize(12);
                column.Item().Text($"Job Number: {job.JobNumber}");
                column.Item().Text($"Pickup Location: {job.PickupLocation}");
                column.Item().Text($"Delivery Location: {job.DeliveryLocation}");
                column.Item().Text($"Requested Date: {job.RequestedDate:d}");
                column.Item().Text($"Status: {job.Status}");

                column.Item().PaddingVertical(10).LineHorizontal(1);

                // Loads Table
                column.Item().Text("Shipment Loads:").SemiBold().FontSize(12);
                column.Item().Element(tableContainer =>
                {
                    tableContainer.Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        // Table Header
                        table.Header(header =>
                        {
                            header.Cell().BorderBottom(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3).Padding(5).Text("Description").SemiBold();
                            header.Cell().BorderBottom(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Weight (kg)").SemiBold();
                            header.Cell().BorderBottom(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Volume (m³)").SemiBold();
                        });

                        // Table Rows
                        if (job.Loads != null)
                        {
                            foreach (var load in job.Loads)
                            {
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten1).Padding(5).Text(load.Description);
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten1).Padding(5).AlignRight().Text(load.Weight.ToString("N2"));
                                table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten1).Padding(5).AlignRight().Text(load.Volume.ToString("N3"));
                            }
                        }
                    });
                });

                column.Item().PaddingTop(10).AlignRight().Text($"Total Estimated Cost: {job.EstimatedCost:C}").Bold().FontSize(12);

                // Add a final note/thank you
                column.Item().PaddingTop(20).Text("Thank you for choosing e-Shift Logistics!").Italic();
            });
        }
    }
}
