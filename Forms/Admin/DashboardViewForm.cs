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
        public DashboardViewForm()
        {
            InitializeComponent();
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
            dgvRecentJobs.ColumnCount = 4;
            dgvRecentJobs.Columns[0].Name = "JobID";
            dgvRecentJobs.Columns[1].Name = "Customer";
            dgvRecentJobs.Columns[2].Name = "Destination";
            dgvRecentJobs.Columns[3].Name = "Status";
        }

        private void SetupLoadAssignmentsGrid()
        {
            dgvLoadAssignments.ColumnCount = 4;
            dgvLoadAssignments.Columns[0].Name = "AssignmentID";
            dgvLoadAssignments.Columns[1].Name = "TruckNo";
            dgvLoadAssignments.Columns[2].Name = "Driver";
            dgvLoadAssignments.Columns[3].Name = "Status";
        }

        private void LoadDashboardData()
        {
            // In a real application, you would fetch this data from your database.
            // For now, we will use placeholder data.

            // Example metrics
            lblTotalJobsValue.Text = "132";
            lblPendingJobsValue.Text = "8";
            lblCompletedJobsValue.Text = "124";
            lblActiveCustomersValue.Text = "73";

            // Example data for Recent Jobs grid
            dgvRecentJobs.Rows.Add("JB-00125", "Alpha Industries", "Kandy", "Pending");
            dgvRecentJobs.Rows.Add("JB-00124", "Central Hardware", "Galle", "Completed");
            dgvRecentJobs.Rows.Add("JB-00123", "Beta Solutions", "Jaffna", "Completed");
            dgvRecentJobs.Rows.Add("JB-00122", "Mega Corp", "Colombo 07", "Pending");

            // Example data for Load Assignments grid
            dgvLoadAssignments.Rows.Add("AS-0034", "CBB-4512", "S. Perera", "In Transit");
            dgvLoadAssignments.Rows.Add("AS-0033", "CBA-1121", "K. Silva", "Loading");
            dgvLoadAssignments.Rows.Add("AS-0032", "CBC-9870", "M. Fernando", "Delivered");
        }

        // You would add event handlers for your shortcut buttons here. For example:
        // private void btnAddJob_Click(object sender, EventArgs e) { ... }
        // private void btnCreateUnit_Click(object sender, EventArgs e) { ... }
    }
}
