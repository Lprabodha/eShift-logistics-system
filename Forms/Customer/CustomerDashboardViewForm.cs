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

namespace eShift_Logistics_System.Forms.Customer
{
    public partial class CustomerDashboardViewForm : Form
    {
        private readonly int _customerId;
        private readonly IJobService _jobService;
        private readonly IUserService _userService;

        public CustomerDashboardViewForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

            _jobService = new JobService(new JobRepository());
            _userService = new UserService(new UserRepository());
        }

        private void CustomerDashboardViewForm_Load(object sender, EventArgs e)
        {
            SetupRecentJobsGrid();
            LoadDashboardData();
        }

        private void SetupRecentJobsGrid()
        {
            dgvRecentJobs.Columns.Clear();
            dgvRecentJobs.AutoGenerateColumns = false;

            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobNumber", HeaderText = "Job #", DataPropertyName = "JobNumber", Width = 120 });
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Destination", HeaderText = "Destination", DataPropertyName = "DeliveryLocation", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "RequestedDate", HeaderText = "Requested Date", DataPropertyName = "RequestedDate", Width = 120 });
            dgvRecentJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 110 });
        }

        private void LoadDashboardData()
        {
            try
            {
                var customer = _userService.GetUserById(_customerId);
                if (customer != null)
                {
                    lblWelcome.Text = $"Welcome, {customer.FirstName}!";
                }

                lblTotalJobsValue.Text = _jobService.GetJobCountByCustomer(_customerId).ToString();
                lblInTransitValue.Text = _jobService.GetJobCountByCustomer(_customerId, JobStatus.Ongoing).ToString();
                lblCompletedJobsValue.Text = _jobService.GetJobCountByCustomer(_customerId, JobStatus.Completed).ToString();

                var recentJobs = _jobService.GetRecentJobsByCustomer(_customerId, 5);
                dgvRecentJobs.DataSource = recentJobs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
