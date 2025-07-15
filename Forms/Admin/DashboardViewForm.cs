using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class DashboardViewForm : Form
    {
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        public DashboardViewForm()
        {
            InitializeComponent();

            _jobService = new JobService(new JobRepository());
            _userService = new UserService(new UserRepository());
        }

        private void DashboardViewForm_Load(object sender, EventArgs e)
        {
            // Set up the columns and styles for the DataGridViews
            SetupRecentJobsGrid();
            SetupLoadAssignmentsGrid();

            // Load placeholder or real data
            LoadDashboardData();
        }

        private void SetupRecentJobsGrid()
        {
            dgvRecentJobs.Columns.Clear();
            dgvRecentJobs.AutoGenerateColumns = false;
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobNumber", HeaderText = "Job #", DataPropertyName = "JobNumber", Width = 120 });
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "Customer", DataPropertyName = "CustomerName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Destination", HeaderText = "Destination", DataPropertyName = "DeliveryLocation", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 110 });
        }

        private void SetupLoadAssignmentsGrid()
        {
            dgvLoadAssignments.Columns.Clear();
            dgvLoadAssignments.AutoGenerateColumns = false;
            dgvLoadAssignments.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobNumber", HeaderText = "Job #", DataPropertyName = "JobNumber", Width = 120 });
            dgvLoadAssignments.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitNumber", HeaderText = "Unit #", DataPropertyName = "UnitNumber", Width = 120 });
            dgvLoadAssignments.Columns.Add(new DataGridViewTextBoxColumn { Name = "DriverName", HeaderText = "Driver", DataPropertyName = "DriverName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvLoadAssignments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 110 });
        }

        private void LoadDashboardData()
        {
            try
            {
                lblTotalJobsValue.Text = _jobService.GetJobCountByStatus().ToString();
                lblPendingJobsValue.Text = _jobService.GetJobCountByStatus(JobStatus.PendingConfirmation).ToString();
                lblCompletedJobsValue.Text = _jobService.GetJobCountByStatus(JobStatus.Completed).ToString();
                lblActiveCustomersValue.Text = _userService.GetActiveCustomerCount().ToString();

                var recentJobs = _jobService.GetRecentJobs();
                var displayList = recentJobs.Select(j => new
                {
                    j.JobNumber,
                    CustomerName = j.Customer.FullName,
                    j.DeliveryLocation,
                    j.Status
                }).ToList();

                dgvRecentJobs.DataSource = displayList;

                var latestAssignments = _jobService.GetLatestAssignedJobs(5);
                var assignmentsList = latestAssignments.Select(j => new
                {
                    j.JobNumber,
                    UnitNumber = j.TransportUnit.UnitNumber,
                    DriverName = j.TransportUnit.Driver.Name,
                    j.Status
                }).ToList();
                dgvLoadAssignments.DataSource = assignmentsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}", "Error");
            }
        }

        private void btnCreateUnit_Click(object sender, EventArgs e)
        {

        }

        // You would add event handlers for your shortcut buttons here. For example:
        // private void btnAddJob_Click(object sender, EventArgs e) { ... }
        // private void btnCreateUnit_Click(object sender, EventArgs e) { ... }
    }
}
