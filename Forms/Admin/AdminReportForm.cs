using ClosedXML.Excel;
using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Service;
using eShift_Logistics_System.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class AdminReportForm : Form
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IUnitService _transportUnitService;
        private DataTable _currentReportData;

        private readonly Dictionary<string, ReportType> _reportTypeMapping = new Dictionary<string, ReportType>
        {
            { "Job Summary", ReportType.JobSummary },
            { "Revenue Report", ReportType.RevenueReport },
            { "Transport Unit Utilization", ReportType.TransportUnitUtilization },
            { "Customer Activity", ReportType.CustomerActivity },
            { "Driver Activity", ReportType.DriverActivity },
            { "Assistant Activity", ReportType.AssistantActivity },
            { "Overall Job Status Breakdown", ReportType.OverallJobStatusBreakdown },
            { "Cancelled Jobs", ReportType.CancelledJobs },
            { "User List", ReportType.UserList }
        };

        private enum ReportType
        {
            JobSummary,
            RevenueReport,
            TransportUnitUtilization,
            CustomerActivity,
            DriverActivity,
            AssistantActivity,
            OverallJobStatusBreakdown,
            CancelledJobs,
            UserList
        }


        public AdminReportForm()
        {
            InitializeComponent();
            _reportService = new ReportService(new ReportRepository());
            _userService = new UserService(new UserRepository());
            _driverService = new DriverService(new DriverRepository());
            _transportUnitService = new UnitService(new UnitRepository());
        }

        private void AdminReportForm_Load(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            PopulateReportTypes();
            PopulateJobStatuses();
            PopulateUsers();
            PopulateTransportUnits();
            PopulateDrivers();
            SetDefaultFilterDates();
            UpdateFilterVisibility();
        }

        private void PopulateReportTypes()
        {
            cmbReportType.Items.Clear();
            foreach (var reportName in _reportTypeMapping.Keys)
            {
                cmbReportType.Items.Add(reportName);
            }
            cmbReportType.SelectedIndex = 0;
        }

        private void PopulateJobStatuses()
        {
            cmbJobStatus.Items.Clear();
            cmbJobStatus.Items.Add("All");
            foreach (JobStatus status in Enum.GetValues(typeof(JobStatus)))
            {
                cmbJobStatus.Items.Add(status.ToString());
            }
            cmbJobStatus.SelectedIndex = 0;
        }

        private void PopulateUsers()
        {
            cmbUser.Items.Clear();
            cmbUser.Items.Add(new ComboBoxItem(0, "All Users"));
            try
            {
                List<User> users = _userService.GetAllUsers();
                foreach (User user in users.OrderBy(u => u.FullName))
                {
                    cmbUser.Items.Add(new ComboBoxItem(user.Id, $"{user.FullName} ({user.UserType})"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users for filter: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in PopulateUsers: {ex}");
            }
            cmbUser.SelectedIndex = 0;
        }

        private void PopulateDrivers()
        {
            cmbDriver.Items.Clear();
            cmbDriver.Items.Add(new ComboBoxItem(0, "All Drivers"));
            try
            {
                List<Driver> drivers = _driverService.GetAllDrivers();
                foreach (Driver driver in drivers.OrderBy(d => d.Name))
                {
                    cmbDriver.Items.Add(new ComboBoxItem(driver.Id, driver.Name));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading drivers for filter: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in PopulateDrivers: {ex}");
            }
            cmbDriver.SelectedIndex = 0;
        }

        private void PopulateTransportUnits()
        {
            cmbTransportUnit.Items.Clear();
            cmbTransportUnit.Items.Add(new ComboBoxItem(0, "All Units"));
            try
            {
                List<TransportUnit> units = _transportUnitService.GetAllUnits();
                foreach (TransportUnit unit in units.OrderBy(u => u.UnitNumber))
                {
                    cmbTransportUnit.Items.Add(new ComboBoxItem(unit.Id, unit.UnitNumber));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transport units for filter: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in PopulateTransportUnits: {ex}");
            }
            cmbTransportUnit.SelectedIndex = 0;
        }

        private class ComboBoxItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
            public ComboBoxItem(int value, string text) { Value = value; Text = text; }
            public override string ToString() => Text;
        }

        private void SetDefaultFilterDates()
        {
            dtpEndDate.Value = DateTime.Today;
            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterVisibility();
            dgvReportResults.DataSource = null;
            _currentReportData = null;
        }

        private void UpdateFilterVisibility()
        {
            ReportType selectedType;
            string selectedText = cmbReportType.SelectedItem.ToString();
            string enumName = selectedText.Replace(" ", "").Replace("Report", "").Replace("Unit", "").Replace("List", "");

            if (!Enum.TryParse(enumName, out selectedType))
            {
                selectedType = ReportType.JobSummary;
            }

            lblStartDate.Visible = dtpStartDate.Visible = false;
            lblEndDate.Visible = dtpEndDate.Visible = false;
            lblJobStatus.Visible = cmbJobStatus.Visible = false;
            lblUser.Visible = cmbUser.Visible = false;
            lblDriver.Visible = cmbDriver.Visible = false;
            lblTransportUnit.Visible = cmbTransportUnit.Visible = false;

            switch (selectedType)
            {
                case ReportType.JobSummary:
                case ReportType.CancelledJobs:
                    lblStartDate.Visible = dtpStartDate.Visible = true;
                    lblEndDate.Visible = dtpEndDate.Visible = true;
                    lblJobStatus.Visible = cmbJobStatus.Visible = (selectedType == ReportType.JobSummary);
                    lblUser.Visible = cmbUser.Visible = true;
                    break;
                case ReportType.RevenueReport:
                case ReportType.TransportUnitUtilization:
                    lblStartDate.Visible = dtpStartDate.Visible = true;
                    lblEndDate.Visible = dtpEndDate.Visible = true;
                    lblTransportUnit.Visible = cmbTransportUnit.Visible = (selectedType == ReportType.TransportUnitUtilization);
                    break;
                case ReportType.CustomerActivity:
                    lblStartDate.Visible = dtpStartDate.Visible = true;
                    lblEndDate.Visible = dtpEndDate.Visible = true;
                    lblUser.Visible = cmbUser.Visible = true;
                    break;
                case ReportType.DriverActivity:
                case ReportType.AssistantActivity:
                    lblStartDate.Visible = dtpStartDate.Visible = true;
                    lblEndDate.Visible = dtpEndDate.Visible = true;
                    lblDriver.Visible = cmbDriver.Visible = (selectedType == ReportType.DriverActivity);
                    lblUser.Visible = cmbUser.Visible = (selectedType == ReportType.AssistantActivity);
                    break;
                case ReportType.OverallJobStatusBreakdown:
                    break;
                case ReportType.UserList:
                    break;
                default:
                    break;
            }
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ReportType selectedType;
            string selectedText = cmbReportType.SelectedItem.ToString();
            string enumName = selectedText.Replace(" ", "").Replace("Report", "").Replace("Unit", "").Replace("List", "");

            if (!Enum.TryParse(enumName, out selectedType))
            {
                MessageBox.Show("Please select a valid report type.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

            JobStatus? jobStatus = null;
            if (cmbJobStatus.Visible && cmbJobStatus.SelectedItem != null && cmbJobStatus.SelectedItem.ToString() != "All")
            {
                Enum.TryParse(cmbJobStatus.SelectedItem.ToString(), out JobStatus parsedStatus);
                jobStatus = parsedStatus;
            }

            int? userId = null;
            if (cmbUser.Visible && cmbUser.SelectedItem is ComboBoxItem selectedUserItem && selectedUserItem.Value > 0)
            {
                userId = selectedUserItem.Value;
            }

            int? driverId = null;
            if (cmbDriver.Visible && cmbDriver.SelectedItem is ComboBoxItem selectedDriverItem && selectedDriverItem.Value > 0)
            {
                driverId = selectedDriverItem.Value;
            }

            int? transportUnitId = null;
            if (cmbTransportUnit.Visible && cmbTransportUnit.SelectedItem is ComboBoxItem selectedUnitItem && selectedUnitItem.Value > 0)
            {
                transportUnitId = selectedUnitItem.Value;
            }

            try
            {
                dgvReportResults.DataSource = null;
                _currentReportData = null;

                DataTable reportData = null;
                switch (selectedType)
                {
                    case ReportType.JobSummary:
                        reportData = await _reportService.GetJobSummaryReportAsync(startDate, endDate, jobStatus, userId);
                        break;
                    case ReportType.RevenueReport:
                        reportData = await _reportService.GetRevenueReportAsync(startDate, endDate);
                        break;
                    case ReportType.TransportUnitUtilization:
                        reportData = await _reportService.GetTransportUnitUtilizationReportAsync(startDate, endDate, transportUnitId);
                        break;
                    case ReportType.CustomerActivity:
                        reportData = await _reportService.GetCustomerActivityReportAsync(startDate, endDate, userId);
                        break;
                    case ReportType.DriverActivity:
                        reportData = await _reportService.GetDriverActivityReportAsync(startDate, endDate, driverId);
                        break;
                    case ReportType.AssistantActivity:
                        reportData = await _reportService.GetAssistantActivityReportAsync(startDate, endDate, userId);
                        break;
                    case ReportType.OverallJobStatusBreakdown:
                        reportData = await _reportService.GetOverallJobStatusBreakdownAsync();
                        break;
                    case ReportType.CancelledJobs:
                        reportData = await _reportService.GetCancelledJobsReportAsync(startDate, endDate);
                        break;
                    case ReportType.UserList:
                        reportData = await _reportService.GetUserListReportAsync(null);
                        break;
                    default:
                        MessageBox.Show("Report type not implemented yet.", "Not Implemented", MessageBoxButtons.OK);
                        return;
                }

                _currentReportData = reportData;

                if (_currentReportData != null && _currentReportData.Rows.Count > 0)
                {
                    dgvReportResults.AutoGenerateColumns = true;
                    dgvReportResults.DataSource = _currentReportData;
                    MessageBox.Show($"Report generated successfully with {_currentReportData.Rows.Count} records.", "Report Generated", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("No data found for the selected criteria.", "No Data", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Report Error", MessageBoxButtons.OK);
                Console.WriteLine($"Report generation error: {ex}");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_currentReportData == null || _currentReportData.Rows.Count == 0)
            {
                MessageBox.Show("Please generate a report first.", "No Data to Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF File (*.pdf)|*.pdf|Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Export Report As";
                saveFileDialog.FileName = $"{cmbReportType.SelectedItem.ToString().Replace(" ", "_")}_Report_{DateTime.Now:yyyyMMdd}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (saveFileDialog.FilterIndex == 1) // PDF
                        {
                            ExportToPdf(_currentReportData, saveFileDialog.FileName);
                            MessageBox.Show("Report exported to PDF successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (saveFileDialog.FilterIndex == 2) // Excel
                        {
                            ExportToExcel(_currentReportData, saveFileDialog.FileName);
                            MessageBox.Show("Report exported to Excel successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // Open the file after saving
                        Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToExcel(DataTable dataTable, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(dataTable, "ReportData");
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(filePath);
            }
        }

        private void ExportToPdf(DataTable dataTable, string filePath)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(36);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Calibri"));

                    page.Header()
                        .PaddingBottom(10)
                        .Column(col =>
                        {
                            col.Item().Text($"{cmbReportType.SelectedItem.ToString()} Report")
                                .SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);
                            col.Item().Text($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}").FontSize(8);
                        });

                    page.Content()
                        .Table(table =>
                        {
                            // Step 1: Define Columns
                            table.ColumnsDefinition(columns =>
                            {
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    columns.RelativeColumn();
                                }
                            });

                            // Step 2: Define Header
                            table.Header(header =>
                            {
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    header.Cell().Border(1).Background(Colors.Grey.Lighten3).Padding(2).Text(column.ColumnName).Bold();
                                }
                            });

                            // Step 3: Add Rows
                            foreach (DataRow row in dataTable.Rows)
                            {
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten1).Padding(2).Text(row[column]?.ToString() ?? "");
                                }
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf(filePath);
        }

    }
}