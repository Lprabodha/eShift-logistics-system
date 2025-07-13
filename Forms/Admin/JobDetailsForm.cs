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
    public partial class JobDetailsForm : Form
    {
        private readonly int _jobId;
        private Job _currentJob;
        private List<Load> _currentLoads = new List<Load>();

        // In a real app, these would be injected.
        private readonly IJobService _jobService;
        private readonly IUnitService _unitService;

        public JobDetailsForm(int jobId)
        {
            InitializeComponent();
            _jobId = jobId;

            // Initialize services
            _jobService = new JobService(new JobRepository());
            _unitService = new UnitService(new UnitRepository());
        }

        private void JobDetailsForm_Load(object sender, EventArgs e)
        {
            SetupLoadsGrid();
            LoadJobDetails();
            LoadAvailableUnitsComboBox();

            // Attach event handlers
            btnAddLoad.Click += btnAddLoad_Click;
            dgvLoads.CellClick += dgvLoads_CellClick;
            btnAssignAndSave.Click += btnAssignAndSave_Click;
        }

        private void LoadJobDetails()
        {
            // In a real app, fetch this from the database
            // _currentJob = _jobService.GetJobWithDetailsById(_jobId);

            // Using placeholder data for demonstration
            _currentJob = new Job
            {
                Id = _jobId,
                JobNumber = "JOB-2025-003",
                RequestedDate = DateTime.Now.AddDays(1),
                Status = JobStatus.PendingConfirmation,
                PickupLocation = "Matara",
                DeliveryLocation = "Negombo",
                Customer = new User { FirstName = "Peter", LastName = "Brandix", Email = "peter@brandix.com", Phone = "0719876543" },
                Loads = new List<Load>() // Start with an empty list of loads
            };

            if (_currentJob == null)
            {
                MessageBox.Show("Job not found.", "Error");
                this.Close();
                return;
            }

            // Populate the read-only fields
            txtJobNumber.Text = _currentJob.JobNumber;
            txtRequestedDate.Text = _currentJob.RequestedDate.ToShortDateString();
            txtStatus.Text = _currentJob.Status.ToString();
            txtPickupAddress.Text = _currentJob.PickupLocation;
            txtDeliveryAddress.Text = _currentJob.DeliveryLocation;
            txtCustomerName.Text = _currentJob.Customer.FullName;
            txtCustomerPhone.Text = _currentJob.Customer.Phone;
            txtCustomerEmail.Text = _currentJob.Customer.Email;

            _currentLoads = _currentJob.Loads ?? new List<Load>();
            RefreshLoadsGrid();
        }


        private void SetupLoadsGrid()
        {
            dgvLoads.Columns.Clear();
            dgvLoads.AutoGenerateColumns = false;
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", DataPropertyName = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { Name = "Weight", HeaderText = "Weight (kg)", DataPropertyName = "Weight", Width = 80 });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { Name = "Volume", HeaderText = "Volume (m³)", DataPropertyName = "Volume", Width = 80 });
            dgvLoads.Columns.Add(new DataGridViewButtonColumn { Name = "Remove", HeaderText = "", Text = "Remove", UseColumnTextForButtonValue = true, Width = 80 });
        }

        private void LoadAvailableUnitsComboBox()
        {
            var availableUnits = _unitService.GetAvailableUnits();
            cboTransportUnit.DataSource = availableUnits;
            cboTransportUnit.DisplayMember = "UnitNumber";
            cboTransportUnit.ValueMember = "Id";
        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoadDescription.Text) || numLoadWeight.Value <= 0 || numLoadVolume.Value <= 0)
            {
                MessageBox.Show("Please provide a valid description, weight, and volume for the load.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentLoads.Add(new Load
            {
                Description = txtLoadDescription.Text,
                Weight = numLoadWeight.Value,
                Volume = numLoadVolume.Value
            });

            RefreshLoadsGrid();
            txtLoadDescription.Clear();
            numLoadWeight.Value = 0;
            numLoadVolume.Value = 0;
        }

        private void dgvLoads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLoads.Columns[e.ColumnIndex].Name == "Remove")
            {
                _currentLoads.RemoveAt(e.RowIndex);
                RefreshLoadsGrid();
            }
        }

        private void RefreshLoadsGrid()
        {
            dgvLoads.DataSource = null;
            if (_currentLoads.Any())
            {
                dgvLoads.DataSource = _currentLoads;
            }
            UpdateCalculations();
        }

        private void UpdateCalculations()
        {
            decimal totalWeight = _currentLoads.Sum(l => l.Weight);
            decimal totalVolume = _currentLoads.Sum(l => l.Volume);

            txtTotalWeight.Text = totalWeight.ToString("N2");
            txtTotalVolume.Text = totalVolume.ToString("N3");

            decimal estimatedCost = _jobService.CalculateEstimatedCost(_currentLoads);
            txtEstimatedCost.Text = estimatedCost.ToString("C"); 
        }

        private void btnAssignAndSave_Click(object sender, EventArgs e)
        {
            if (!_currentLoads.Any())
            {
                MessageBox.Show("Please add at least one load to the job before saving.", "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTransportUnit.SelectedItem == null || (int)cboTransportUnit.SelectedValue == 0)
            {
                MessageBox.Show("Please assign a transport unit to the job.", "Cannot Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentJob.Loads = _currentLoads;
            _currentJob.TransportUnitId = (int)cboTransportUnit.SelectedValue;

            try
            {
                _jobService.AssignUnitAndFinalizeJob(_currentJob);

                MessageBox.Show("Job details saved and unit assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
