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
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            // Initial setup
            SetupCustomersGrid();
            SetupJobHistoryGrid();
            LoadCustomersData();
            UpdateStatusStrip();

            // Populate filter combobox
            cboFilterStatus.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            cboFilterStatus.SelectedIndex = 0;
        }

        private void SetupCustomersGrid()
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "Customer ID", DataPropertyName = "ID", Width = 120 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", HeaderText = "Full Name", DataPropertyName = "FullName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email Address", DataPropertyName = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 80 });

            var btnStatus = new DataGridViewButtonColumn { Name = "ChangeStatus", HeaderText = "Change Status", Text = "Toggle Status", UseColumnTextForButtonValue = true, Width = 110 };
            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 70 };

            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { btnStatus, btnDelete });
        }

        private void SetupJobHistoryGrid()
        {
            dgvJobHistory.Columns.Clear();
            dgvJobHistory.AutoGenerateColumns = false;
            dgvJobHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobID", HeaderText = "Job ID", DataPropertyName = "JobID", Width = 120 });
            dgvJobHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "Destination", HeaderText = "Destination", DataPropertyName = "Destination", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvJobHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date", DataPropertyName = "Date", Width = 120 });
            dgvJobHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "JobStatus", HeaderText = "Status", DataPropertyName = "JobStatus", Width = 100 });
        }

        private void LoadCustomersData()
        {
            // In a real app, load from a database. Using placeholder data.
            dgvCustomers.Rows.Clear();
            dgvCustomers.Rows.Add("C-001", "John Keells", "contact@jkh.lk", "Active");
            dgvCustomers.Rows.Add("C-002", "Hemas Holdings", "info@hemas.com", "Active");
            dgvCustomers.Rows.Add("C-003", "MAS Holdings", "hr@masholdings.com", "Active");
            dgvCustomers.Rows.Add("C-004", "Brandix", "info@brandix.com", "Inactive");

            // Attach event handlers
            dgvCustomers.CellClick += DgvCustomers_CellClick;
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                string customerId = dgvCustomers.SelectedRows[0].Cells["ID"].Value.ToString();
                LoadDetailsForCustomer(customerId);
            }
        }

        private void LoadDetailsForCustomer(string customerId)
        {
            // Load Job History
            dgvJobHistory.Rows.Clear();
            if (customerId == "C-001")
            {
                dgvJobHistory.Rows.Add("JB-0125", "Kandy", "2025-07-01", "Completed");
                dgvJobHistory.Rows.Add("JB-0110", "Galle", "2025-06-15", "Completed");
            }
            else if (customerId == "C-002")
            {
                dgvJobHistory.Rows.Add("JB-0120", "Jaffna", "2025-06-28", "Pending");
            }

            // Load Notes
            txtNotes.Text = $"Notes for customer {customerId} will appear here. This area can be used to log important information, special requirements, or communication history.";
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks

            string customerId = dgvCustomers.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            string customerName = dgvCustomers.Rows[e.RowIndex].Cells["FullName"].Value.ToString();

            switch (dgvCustomers.Columns[e.ColumnIndex].Name)
            {
                case "ChangeStatus":
                    ToggleCustomerStatus(e.RowIndex, customerName);
                    break;
                case "Delete":
                    DeleteCustomer(e.RowIndex, customerName);
                    break;
            }
        }

        private void EditCustomer(string customerId)
        {
    
        }

        private void ToggleCustomerStatus(int rowIndex, string customerName)
        {
            var statusCell = dgvCustomers.Rows[rowIndex].Cells["Status"];
            string currentStatus = statusCell.Value.ToString();
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";

            var confirmResult = MessageBox.Show($"Are you sure you want to change status of {customerName} to {newStatus}?",
                                 "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Update database here
                statusCell.Value = newStatus; // Update grid
                MessageBox.Show($"{customerName}'s status has been updated to {newStatus}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusStrip();
            }
        }

        private void DeleteCustomer(int rowIndex, string customerName)
        {
            var confirmResult = MessageBox.Show($"Are you sure you want to delete {customerName}?\nThis action cannot be undone.",
                                 "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Delete from database here
                dgvCustomers.Rows.RemoveAt(rowIndex);
                MessageBox.Show($"{customerName} has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusStrip();
            }
        }

        private void UpdateStatusStrip()
        {
            int total = dgvCustomers.Rows.Count;
            int active = 0;
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "Active")
                {
                    active++;
                }
            }
            lblTotalCustomers.Text = $"Total Customers: {total}";
            lblActiveCustomers.Text = $"Active: {active}";
            lblInactiveCustomers.Text = $"Inactive: {total - active}";
        }
    }

}
