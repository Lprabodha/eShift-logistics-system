using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Customer
{
    public partial class MyJobsForm : Form
    {
        private readonly int _customerId;
        private List<Job> _allCustomerJobs; 
        private List<Job> _filteredJobs;
        private JobStatus _currentTrackingStatus;

        private readonly IJobService _jobService;

        private Dictionary<JobStatus, Label> _statusLabels;

        public MyJobsForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            _jobService = new JobService(new JobRepository());

            InitializeStatusLabels(); 
            SetupMyJobsGrid(); 
            SetupFilterControls();  
        }

        private void InitializeStatusLabels()
        {
            _statusLabels = new Dictionary<JobStatus, Label>
            {
                { JobStatus.PendingConfirmation, lblStatusPending },
                { JobStatus.Accepted, lblStatusAssigned },
                { JobStatus.Ongoing, lblStatusOnJob },
                { JobStatus.Completed, lblStatusCompleted }
            };
        }

        private void SetupFilterControls()
        {
            cmbFilterStatus.Items.Add("All Statuses");
            foreach (JobStatus status in Enum.GetValues(typeof(JobStatus)))
            {
                if (status != JobStatus.Cancelled)
                {
                    cmbFilterStatus.Items.Add(status.ToString());
                }
            }
            cmbFilterStatus.SelectedIndex = 0;

            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnClearFilters.Click += btnClearFilters_Click;
        }

        private void MyJobsForm_Load(object sender, EventArgs e)
        {
            LoadAllCustomerJobsSynchronous();

            ApplyFilters();

            dgvMyJobs.SelectionChanged += dgvMyJobs_SelectionChanged;
            dgvMyJobs.CellClick += dgvMyJobs_CellClick;

            if (_filteredJobs != null && _filteredJobs.Any())
            {
                dgvMyJobs.Rows[0].Selected = true;
                dgvMyJobs_SelectionChanged(dgvMyJobs, EventArgs.Empty);
            }
            else
            {
                _currentTrackingStatus = JobStatus.PendingConfirmation;
                UpdateJobTrackerLabels(_currentTrackingStatus);
                pnlTracker.Invalidate();
            }
        }

        private void SetupMyJobsGrid()
        {
            dgvMyJobs.AutoGenerateColumns = false;
            dgvMyJobs.Columns.Clear();

            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobNumber", HeaderText = "Job #", DataPropertyName = "JobNumber", Width = 100 });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "PickupLocation", HeaderText = "Pickup", DataPropertyName = "PickupLocation", Width = 140 });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "DeliveryLocation", HeaderText = "Delivery", DataPropertyName = "DeliveryLocation", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RequestedDate",
                HeaderText = "Requested Date",
                DataPropertyName = "RequestedDate",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });

            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });

            var btnView = new DataGridViewButtonColumn
            {
                Name = "ViewDetails",
                HeaderText = "Details",
                Text = "View Details",
                UseColumnTextForButtonValue = true,
                Width = 100,
            };
            var btnCancel = new DataGridViewButtonColumn
            {
                Name = "Cancel",
                HeaderText = "Action",
                Text = "Cancel Job",
                UseColumnTextForButtonValue = true,
                Width = 100,
            };
            dgvMyJobs.Columns.AddRange(new DataGridViewColumn[] { btnView, btnCancel });
        }


        private void LoadAllCustomerJobsSynchronous()
        {
            try
            {
                _allCustomerJobs = _jobService.GetJobsByCustomerId(_customerId); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sorry, we couldn't load your jobs right now. Please try again later.\n\nError: {ex.Message}",
                                "Error Loading Jobs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"[MyJobsForm] Error in LoadAllCustomerJobsSynchronous for customer ID {_customerId}: {ex}");
                _allCustomerJobs = new List<Job>();
            }
        }

        private void ApplyFilters()
        {
            if (_allCustomerJobs == null)
            {
                _filteredJobs = new List<Job>();
                dgvMyJobs.DataSource = _filteredJobs;
                _currentTrackingStatus = JobStatus.PendingConfirmation;
                UpdateJobTrackerLabels(_currentTrackingStatus);
                pnlTracker.Invalidate();
                return;
            }

            IEnumerable<Job> query = _allCustomerJobs;

            if (cmbFilterStatus.SelectedItem != null && cmbFilterStatus.SelectedItem.ToString() != "All Statuses")
            {
                if (Enum.TryParse(cmbFilterStatus.SelectedItem.ToString(), out JobStatus selectedStatus))
                {
                    query = query.Where(job => job.Status == selectedStatus);
                }
            }

            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(job =>
                    (job.JobNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (job.PickupLocation?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (job.DeliveryLocation?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false)
                );
            }

            _filteredJobs = query.ToList();
            dgvMyJobs.DataSource = _filteredJobs;

            if (_filteredJobs.Any())
            {
                dgvMyJobs.Rows[0].Selected = true;
                dgvMyJobs_SelectionChanged(dgvMyJobs, EventArgs.Empty);
            }
            else
            {
                _currentTrackingStatus = JobStatus.PendingConfirmation;
                UpdateJobTrackerLabels(_currentTrackingStatus);
                pnlTracker.Invalidate();
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            txtSearch.Clear();
        }

        private void dgvMyJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMyJobs.SelectedRows.Count > 0)
            {
                Job selectedJob = dgvMyJobs.SelectedRows[0].DataBoundItem as Job;
                if (selectedJob != null)
                {
                    _currentTrackingStatus = selectedJob.Status;
                    UpdateJobTrackerLabels(selectedJob.Status);
                    pnlTracker.Invalidate();
                }
            }
            else
            {
                _currentTrackingStatus = JobStatus.PendingConfirmation;
                UpdateJobTrackerLabels(_currentTrackingStatus);
                pnlTracker.Invalidate();
            }
        }

        private void dgvMyJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            Job selectedJob = dgvMyJobs.Rows[e.RowIndex].DataBoundItem as Job;

            if (selectedJob == null) return;

            if (dgvMyJobs.Columns[e.ColumnIndex].Name == "ViewDetails")
            {

                JobSummaryForm jobSummaryForm = new JobSummaryForm(selectedJob.Id);
                jobSummaryForm.ShowDialog();
            }
            else if (dgvMyJobs.Columns[e.ColumnIndex].Name == "Cancel")
            {
                if (selectedJob.Status == JobStatus.PendingConfirmation || selectedJob.Status == JobStatus.Accepted)
                {
                    var confirmResult = MessageBox.Show(
                        $"Are you sure you want to cancel Job Number: {selectedJob.JobNumber}?",
                        "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            bool success = _jobService.CancelJob(selectedJob.Id); 
                            if (success)
                            {
                                MessageBox.Show($"Job Number: {selectedJob.JobNumber} has been cancelled successfully.",
                                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadAllCustomerJobsSynchronous();
                                ApplyFilters();
                            }
                            else
                            {
                                MessageBox.Show("Failed to cancel the job. It might have been updated by someone else, or an internal error occurred. Please try again.",
                                                "Cancellation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An unexpected error occurred during cancellation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine($"[MyJobsForm] Error canceling job {selectedJob.Id}: {ex}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This job cannot be cancelled as it is already in progress or completed.",
                                    "Cancellation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UpdateJobTrackerLabels(JobStatus currentStatus)
        {
            foreach (var labelEntry in _statusLabels)
            {
                labelEntry.Value.Font = new Font(labelEntry.Value.Font, FontStyle.Regular);
                labelEntry.Value.ForeColor = SystemColors.ControlText;
            }

            Color highlightColor = Color.FromArgb(65, 84, 241);
            Font highlightFont = new Font(lblStatusPending.Font.FontFamily, lblStatusPending.Font.Size, FontStyle.Bold);

            foreach (var status in _statusLabels.Keys.OrderBy(s => (int)s))
            {
                if ((int)currentStatus >= (int)status)
                {
                    _statusLabels[status].ForeColor = highlightColor;
                    _statusLabels[status].Font = highlightFont;
                }
            }
        }

        private void pnlTracker_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int padding = 20;
            int panelWidth = pnlTracker.Width - (2 * padding);
            int lineHeight = pnlTracker.Height / 2;

            int stepCount = _statusLabels.Count;
            if (stepCount == 0 || panelWidth <= 0 || pnlTracker.Height <= 0) return;

            int stepDistance = panelWidth / (stepCount - 1);
            int circleRadius = 8;

            Pen defaultLinePen = new Pen(Color.LightGray, 3);
            Brush defaultCircleBrush = new SolidBrush(Color.LightGray);
            Pen highlightLinePen = new Pen(Color.FromArgb(65, 84, 241), 5);
            Brush highlightCircleBrush = new SolidBrush(Color.FromArgb(65, 84, 241));

            g.DrawLine(defaultLinePen, padding, lineHeight, padding + panelWidth, lineHeight);

            int currentStatusValue = (int)_currentTrackingStatus;

            var orderedStatuses = _statusLabels.Keys.OrderBy(s => (int)s).ToList();

            for (int i = 0; i < orderedStatuses.Count; i++)
            {
                JobStatus status = orderedStatuses[i];
                Label label = _statusLabels[status];
                int circleX = label.Location.X + (label.Width / 2) - pnlTracker.Location.X;

                Rectangle circleRect = new Rectangle(circleX - circleRadius, lineHeight - circleRadius, circleRadius * 2, circleRadius * 2);

                bool isHighlighted = currentStatusValue >= (int)status;

                g.FillEllipse(isHighlighted ? highlightCircleBrush : defaultCircleBrush, circleRect);
                g.DrawEllipse(isHighlighted ? highlightLinePen : defaultLinePen, circleRect);

                if (i < orderedStatuses.Count - 1)
                {
                    Label nextLabel = _statusLabels[orderedStatuses[i + 1]];
                    int nextCircleX = nextLabel.Location.X + (nextLabel.Width / 2) - pnlTracker.Location.X;

                    bool segmentHighlighted = isHighlighted && currentStatusValue >= (int)orderedStatuses[i + 1];

                    g.DrawLine(segmentHighlighted ? highlightLinePen : defaultLinePen,
                               circleX + circleRadius, lineHeight,
                               nextCircleX - circleRadius, lineHeight);
                }
            }

            defaultLinePen.Dispose();
            defaultCircleBrush.Dispose();
            highlightLinePen.Dispose();
            highlightCircleBrush.Dispose();
        }
    }
}
