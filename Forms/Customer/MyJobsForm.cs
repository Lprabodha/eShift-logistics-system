using eShift_Logistics_System.Models;
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
        private List<Job> _myJobs;
        private JobStatus _currentTrackingStatus;

        // private readonly IJobService _jobService;

        public MyJobsForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            // _jobService = new JobService(new JobRepository());
        }

        private void MyJobsForm_Load(object sender, EventArgs e)
        {
            SetupMyJobsGrid();
            LoadCustomerJobs();

            dgvMyJobs.SelectionChanged += dgvMyJobs_SelectionChanged;
            dgvMyJobs.CellClick += dgvMyJobs_CellClick;
        }

        private void SetupMyJobsGrid()
        {
            dgvMyJobs.AutoGenerateColumns = false;
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobNumber", HeaderText = "Job #", DataPropertyName = "JobNumber", Width = 120 });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "PickupLocation", HeaderText = "Pickup", DataPropertyName = "PickupLocation", Width = 150 });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "DeliveryLocation", HeaderText = "Delivery", DataPropertyName = "DeliveryLocation", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "RequestedDate", HeaderText = "Requested Date", DataPropertyName = "RequestedDate", Width = 120 });
            dgvMyJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 110 });

            var btnView = new DataGridViewButtonColumn { Name = "ViewDetails", HeaderText = "Details", Text = "View Details", UseColumnTextForButtonValue = true, Width = 100 };
            var btnCancel = new DataGridViewButtonColumn { Name = "Cancel", HeaderText = "Action", Text = "Cancel Job", UseColumnTextForButtonValue = true, Width = 100 };
            dgvMyJobs.Columns.AddRange(new DataGridViewColumn[] { btnView, btnCancel });
        }

        private void LoadCustomerJobs()
        {
            // _myJobs = _jobService.GetJobsByCustomerId(_customerId);
            // Using placeholder data
            _myJobs = new List<Job> { new Job { Id = 1, JobNumber = "JOB-2025-004", Status = JobStatus.Accepted, PickupLocation = "Kandy", DeliveryLocation = "Colombo" }, new Job { Id = 2, JobNumber = "JOB-2025-005", Status = JobStatus.PendingConfirmation, PickupLocation = "Jaffna", DeliveryLocation = "Galle" } };

            dgvMyJobs.DataSource = _myJobs;
        }

        private void dgvMyJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMyJobs.SelectedRows.Count > 0)
            {
                var status = (JobStatus)dgvMyJobs.SelectedRows[0].Cells["Status"].Value;
                _currentTrackingStatus = status;
                pnlTracker.Invalidate(); // Redraw the tracker panel
            }
        }

        private void dgvMyJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMyJobs.Columns[e.ColumnIndex].Name == "ViewDetails")
            {
                // Open a read-only JobSummaryForm
            }
            else if (dgvMyJobs.Columns[e.ColumnIndex].Name == "Cancel")
            {
                var status = (JobStatus)dgvMyJobs.Rows[e.RowIndex].Cells["Status"].Value;
                if (status == JobStatus.PendingConfirmation || status == JobStatus.Accepted)
                {
                    // Confirm cancellation and call service
                }
                else
                {
                    MessageBox.Show("This job cannot be cancelled as it is already in progress.", "Cancellation Not Allowed");
                }
            }
        }

        private void pnlTracker_Paint(object sender, PaintEventArgs e)
        {
            // This method custom paints the progress bar
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int stepCount = 5;
            int panelWidth = pnlTracker.Width - 40; // Margins
            int stepWidth = panelWidth / (stepCount - 1);
            int y = pnlTracker.Height / 2;

            // Draw the background line
            g.DrawLine(new Pen(Color.LightGray, 3), 20, y, panelWidth + 20, y);

            // Determine how many steps are completed
            int currentStep = (int)_currentTrackingStatus;

            // Draw the highlighted progress line
            if (currentStep > 1)
            {
                int progressWidth = (currentStep - 1) * stepWidth;
                g.DrawLine(new Pen(Color.FromArgb(65, 84, 241), 5), 20, y, 20 + progressWidth, y);
            }

            // Draw each step circle
            for (int i = 1; i <= stepCount; i++)
            {
                int x = 20 + (i - 1) * stepWidth;
                Rectangle rect = new Rectangle(x - 10, y - 10, 20, 20);

                if (i <= currentStep)
                {
                    g.FillEllipse(new SolidBrush(Color.FromArgb(65, 84, 241)), rect);
                    g.DrawEllipse(new Pen(Color.White, 2), rect);
                }
                else
                {
                    g.FillEllipse(new SolidBrush(Color.LightGray), rect);
                }
            }
        }
    }
}
