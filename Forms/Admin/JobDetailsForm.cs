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

        private readonly IJobService _jobService;
        private readonly IUnitService _unitService;
        private readonly IJobStatusService _jobStatusService;

        /// <summary>
        /// Form for displaying and managing job details, including loads and transport units.
        /// </summary>
        /// <param name="jobId"></param>
        public JobDetailsForm(int jobId)
        {
            InitializeComponent();
            _jobId = jobId;

            // Initialize services
            _jobService = new JobService(new JobRepository());
            _unitService = new UnitService(new UnitRepository());
            _jobStatusService = new JobStatusService(new JobStatusRepository());
        }

        /// <summary>
        /// Handles the form load event to initialize job details, loads grid, and available transport units.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JobDetailsForm_Load(object sender, EventArgs e)
        {
            SetupLoadsGrid();
            LoadJobDetails();
            LoadAvailableUnitsComboBox();

            btnAddLoad.Click += btnAddLoad_Click;
            dgvLoads.CellClick += dgvLoads_CellClick;
            btnAssignAndSave.Click += btnAssignAndSave_Click;
        }

        /// <summary>
        /// Loads the job details by fetching the job from the service and populating the UI controls.
        /// </summary>
        private void LoadJobDetails()
        {
            try
            {
                _currentJob = _jobService.GetJobWithDetailsById(_jobId);

                if (_currentJob == null)
                {
                    MessageBox.Show("Job not found.", "Error");
                    this.Close();
                    return;
                }

                PopulateStaticDetails();
                BindProductsToGrid(_currentJob.JobProducts);

                _currentLoads = _currentJob.Loads ?? new List<Load>();
                RefreshLoadsGrid();

                bool isEditable = (_currentJob.Status == JobStatus.PendingConfirmation);
                SetEditMode(isEditable);

                bool canUpdateStatus = (_currentJob.Status == JobStatus.Accepted || _currentJob.Status == JobStatus.Ongoing || _currentJob.Status == JobStatus.PendingConfirmation);
                grpStatusUpdate.Visible = canUpdateStatus;
                if (canUpdateStatus)
                {
                    PopulateStatusUpdateComboBox();
                }

                LoadAvailableUnitsComboBox(_currentJob.TransportUnitId);
                if (_currentJob.TransportUnitId.HasValue)
                {
                    cboTransportUnit.SelectedValue = _currentJob.TransportUnitId.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading job details: {ex.Message}");
            }
        }

        /// <summary>
        /// Populates the static details of the job into the respective text boxes on the form.
        /// </summary>
        private void PopulateStaticDetails()
        {
            txtJobNumber.Text = _currentJob.JobNumber;
            txtRequestedDate.Text = _currentJob.RequestedDate.ToString("yyyy-MM-dd");
            txtStatus.Text = _currentJob.Status.ToString();
            txtPickupAddress.Text = _currentJob.PickupLocation;
            txtDeliveryAddress.Text = _currentJob.DeliveryLocation;
            txtCustomerName.Text = _currentJob.Customer?.FullName;
            txtCustomerPhone.Text = _currentJob.Customer?.Phone;
            txtCustomerEmail.Text = _currentJob.Customer?.Email;
            txtEstimatedCost.Text = _currentJob.EstimatedCost.ToString("C");
        }

        /// <summary>
        /// Populates the status update combo box based on the current job status.
        /// </summary>
        private void PopulateStatusUpdateComboBox()
        {
            cboUpdateStatus.Items.Clear();

            if (_currentJob.Status == JobStatus.Accepted)
            {
                cboUpdateStatus.Items.Add(JobStatus.Ongoing);
                cboUpdateStatus.Items.Add(JobStatus.Cancelled);
            }
            else if (_currentJob.Status == JobStatus.Ongoing)
            {
                cboUpdateStatus.Items.Add(JobStatus.Completed);
            }
            else if (_currentJob.Status == JobStatus.PendingConfirmation)
            {
                cboUpdateStatus.Items.Add(JobStatus.Cancelled);
            }

            if (cboUpdateStatus.Items.Count > 0)
            {
                cboUpdateStatus.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Sets the edit mode for the form, enabling or disabling controls based on the provided flag.
        /// </summary>
        /// <param name="enabled"></param>
        private void SetEditMode(bool enabled)
        {
            pnlAddLoad.Enabled = enabled;
            grpCosting.Enabled = enabled;
            cboTransportUnit.Enabled = enabled;
            btnAssignAndSave.Enabled = enabled;

            if (dgvLoads.Columns.Contains("Remove"))
            {
                dgvLoads.Columns["Remove"].Visible = enabled;
            }
        }

        /// <summary>
        /// Initializes the DataGridView for displaying loads, setting up columns and properties.
        /// </summary>
        private void SetupLoadsGrid()
        {
            dgvLoads.Columns.Clear();
            dgvLoads.AutoGenerateColumns = false;
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", DataPropertyName = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { Name = "Weight", HeaderText = "Weight (kg)", DataPropertyName = "Weight", Width = 80 });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { Name = "Volume", HeaderText = "Volume (m³)", DataPropertyName = "Volume", Width = 80 });
            dgvLoads.Columns.Add(new DataGridViewButtonColumn { Name = "Remove", HeaderText = "", Text = "Remove", UseColumnTextForButtonValue = true, Width = 80 });
        }

        /// <summary>
        /// Loads the available transport units into the combo box, allowing the user to select a unit for the job.
        /// </summary>
        /// <param name="currentUnitId"></param>
        private void LoadAvailableUnitsComboBox(int? currentUnitId = null)
        {
            try
            {
                var availableUnits = _unitService.GetAvailableUnits(_currentJob?.TransportUnitId);

                var placeholderUnit = new TransportUnit { Id = 0, UnitNumber = "--- Select a Unit ---" };
                availableUnits.Insert(0, placeholderUnit);

                cboTransportUnit.DataSource = availableUnits;
                cboTransportUnit.DisplayMember = "UnitNumber";
                cboTransportUnit.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transport units: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Binds the list of job products to the DataGridView for display, showing product names and quantities.
        /// </summary>
        /// <param name="products"></param>
        private void BindProductsToGrid(List<JobProduct> products)
        {
            dgvJobProducts.DataSource = null;

            if (products != null && products.Any())
            {
                var displayList = products.Select(p => new
                {
                    ProductName = p.Product?.Name ?? "N/A",
                    p.Quantity
                }).ToList();

                dgvJobProducts.DataSource = displayList;
            }
        }

        /// <summary>
        /// Handles the click event for the "Add Load" button, validating input and adding a new load to the job.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handles the cell click event for the DataGridView, allowing the user to remove a load by clicking the "Remove" button in the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLoads_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLoads.Columns[e.ColumnIndex].Name == "Remove")
            {
                _currentLoads.RemoveAt(e.RowIndex);
                RefreshLoadsGrid();
            }
        }

        /// <summary>
        /// Refreshes the DataGridView displaying loads, updating the data source and recalculating totals.
        /// </summary>
        private void RefreshLoadsGrid()
        {
            dgvLoads.DataSource = null;
            if (_currentLoads.Any())
            {
                dgvLoads.DataSource = _currentLoads;
            }
            UpdateCalculations();
        }

        /// <summary>
        /// Updates the total weight, volume, and estimated cost based on the current loads.
        /// </summary>
        private void UpdateCalculations()
        {
            decimal totalWeight = _currentLoads.Sum(l => l.Weight);
            decimal totalVolume = _currentLoads.Sum(l => l.Volume);

            txtTotalWeight.Text = totalWeight.ToString("N2");
            txtTotalVolume.Text = totalVolume.ToString("N3");

            decimal estimatedCost = _jobService.CalculateEstimatedCost(_currentLoads);
            txtEstimatedCost.Text = estimatedCost.ToString("C");
        }

        /// <summary>
        /// Handles the click event for the "Assign and Save" button, validating inputs and saving the job details along with assigned transport unit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                _jobStatusService.AddLogJobStatus(_jobId, _currentJob.Status.ToString(), null, "Admin finalized job and assigned unit");

                MessageBox.Show("Job details saved and unit assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the click event for the "Update Status" button, validating the selected status and updating the job status accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (cboUpdateStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a new status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newStatus = (JobStatus)cboUpdateStatus.SelectedItem;

            var confirmResult = MessageBox.Show($"Are you sure you want to update the status to '{newStatus}'?",
                                              "Confirm Status Change",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _jobService.UpdateJobStatus(_jobId, newStatus);

                    _jobStatusService.AddLogJobStatus(_jobId, newStatus.ToString(), null, "Admin updated status");

                    MessageBox.Show("Job status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadJobDetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating the status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
