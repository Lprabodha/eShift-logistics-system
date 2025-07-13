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
    public partial class JobManagementForm : Form
    {
        private List<Job> _allJobs;
        private readonly IJobService _jobService;

        public JobManagementForm()
        {
            InitializeComponent();
            _jobService = new JobService(new JobRepository());
        }

        private void JobManagementForm_Load(object sender, EventArgs e)
        {
            SetupJobsGrid();
            PopulateFilterComboBox();
            LoadJobsData();

            btnFilter.Click += btnFilter_Click;
            dgvJobs.CellClick += dgvJobs_CellClick;
        }

        private void SetupJobsGrid()
        {
            dgvJobs.Columns.Clear();
            dgvJobs.AutoGenerateColumns = false;

            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobNumber", HeaderText = "Job #", DataPropertyName = "JobNumber", Width = 120 });
            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "Customer", DataPropertyName = "CustomerName", Width = 150 });
            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "RequestedDate", HeaderText = "Requested Date", DataPropertyName = "RequestedDate", Width = 120 });
            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "PickupLocation", HeaderText = "Pickup", DataPropertyName = "PickupLocation", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "DeliveryLocation", HeaderText = "Delivery", DataPropertyName = "DeliveryLocation", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 110 });

            var btnManage = new DataGridViewButtonColumn { Name = "Manage", HeaderText = "Action", Text = "Manage Job", UseColumnTextForButtonValue = true, Width = 120 };
            dgvJobs.Columns.Add(btnManage);
        }

        private void PopulateFilterComboBox()
        {
            cboStatusFilter.Items.Add("All");
            cboStatusFilter.Items.AddRange(Enum.GetNames(typeof(JobStatus)));
            cboStatusFilter.SelectedIndex = 0;
        }

        private void LoadJobsData()
        {
            try
            {
                _allJobs = _jobService.GetAllJobsWithDetails();

                BindDataToGrid(_allJobs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load jobs: {ex.Message}", "Error");
            }
        }

        private void BindDataToGrid(List<Job> jobs)
        {
            dgvJobs.DataSource = null;
            if (jobs != null)
            {
                var displayList = jobs.Select(j => new {
                    j.Id,
                    j.JobNumber,
                    CustomerName = j.Customer?.FullName ?? "N/A",
                    j.RequestedDate,
                    j.PickupLocation,
                    j.DeliveryLocation,
                    j.Status
                }).ToList();
                dgvJobs.DataSource = displayList;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (_allJobs == null) return;

            var filteredList = _allJobs;
            string searchText = txtSearch.Text.Trim().ToLower();
            string statusFilter = cboStatusFilter.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(searchText))
            {
                filteredList = filteredList.Where(j =>
                    j.JobNumber.ToLower().Contains(searchText) ||
                    (j.Customer?.FullName.ToLower().Contains(searchText) ?? false)
                ).ToList();
            }

            if (statusFilter != "All")
            {
                filteredList = filteredList.Where(j => j.Status.ToString() == statusFilter).ToList();
            }

            filteredList = filteredList.Where(j =>
                j.RequestedDate.Date >= dtpStartDate.Value.Date &&
                j.RequestedDate.Date <= dtpEndDate.Value.Date
            ).ToList();

            BindDataToGrid(filteredList);
        }

        private void dgvJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvJobs.Columns[e.ColumnIndex].Name == "Manage")
            {
                int jobId = Convert.ToInt32(dgvJobs.Rows[e.RowIndex].Cells["Id"].Value);
                var jobDetailsForm = new JobDetailsForm(jobId);
                jobDetailsForm.ShowDialog();
                LoadJobsData(); 
            }
        }
    }
}
