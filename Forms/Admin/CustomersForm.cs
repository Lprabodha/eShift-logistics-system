using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class CustomersForm : Form
    {
        private readonly IUserService _userService;
        private List<User> _allCustomers = new();
        private bool _hasRealCustomerData = true;

        public CustomersForm()
        {
            InitializeComponent();
            IUserRepository userRepository = new UserRepository();
            _userService = new UserService(userRepository);
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            SetupCustomersGrid();
            SetupJobHistoryGrid();
            LoadCustomersData();
            UpdateStatusStrip();

            cboFilterStatus.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            cboFilterStatus.SelectedIndex = 0;

            dgvCustomers.CellClick += DgvCustomers_CellClick;
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
        }

        private void SetupCustomersGrid()
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerNumber", HeaderText = "Customer ID", DataPropertyName = "CustomerNumber", Width = 120 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Full Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
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
            try
            {
                _allCustomers = _userService.GetAllUsers()
                                 .Where(u => u.UserType == UserType.Customer)
                                 .ToList();

                BindCustomerGrid(_allCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load customer data.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindCustomerGrid(List<User> customerList)
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.Rows.Clear();
            dgvCustomers.Columns.Clear();

            if (customerList.Count == 0)
            {
                _hasRealCustomerData = false;

                var colMessage = new DataGridViewTextBoxColumn
                {
                    Name = "colMessage",
                    HeaderText = "",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };

                dgvCustomers.Columns.Add(colMessage);
                dgvCustomers.Rows.Add("No customers found.");
                dgvCustomers.ReadOnly = true;
                dgvCustomers.ClearSelection();
                return;
            }

            _hasRealCustomerData = true;
            SetupCustomersGrid();

            var displayList = customerList.Select(u => new
            {
                CustomerNumber = u.CustomerNumber ?? "N/A",
                Name = u.FirstName,
                Email = u.Email,
                Status = u.IsActive ? "Active" : "Inactive"
            }).ToList();

            dgvCustomers.DataSource = displayList;

            dgvCustomers.CellClick -= DgvCustomers_CellClick;
            dgvCustomers.CellClick += DgvCustomers_CellClick;

            dgvCustomers.SelectionChanged -= DgvCustomers_SelectionChanged;
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0 && _hasRealCustomerData)
            {
                string customerId = dgvCustomers.SelectedRows[0].Cells["CustomerNumber"].Value?.ToString();
                if (!string.IsNullOrEmpty(customerId))
                {
                    LoadDetailsForCustomer(customerId);
                }
            }
        }

        private void LoadDetailsForCustomer(string customerId)
        {
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
            txtNotes.Text = $"Notes for customer {customerId} will appear here.";
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !_hasRealCustomerData) return;

            var row = dgvCustomers.Rows[e.RowIndex];
            string customerId = row.Cells["CustomerNumber"].Value?.ToString();
            string customerName = row.Cells["Name"].Value?.ToString();
            if (customerId == null || customerName == null) return;

            switch (dgvCustomers.Columns[e.ColumnIndex].Name)
            {
                case "ChangeStatus":
                    ToggleCustomerStatus(customerId, customerName);
                    break;
                case "Delete":
                    DeleteCustomer(e.RowIndex, customerName);
                    break;
            }
        }

        private void ToggleCustomerStatus(string customerId, string customerName)
        {
            var confirm = MessageBox.Show($"Change status of {customerName}?", "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = _userService.ToggleUserStatus(customerId);

                if (success)
                {
                    LoadCustomersData();
                    MessageBox.Show($"{customerName}'s status has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteCustomer(int rowIndex, string customerName)
        {
            var confirmResult = MessageBox.Show($"Are you sure you want to delete {customerName}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                dgvCustomers.Rows.RemoveAt(rowIndex);
                MessageBox.Show($"{customerName} has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusStrip();
            }
        }

        private void UpdateStatusStrip()
        {
            if (!_hasRealCustomerData)
            {
                lblTotalCustomers.Text = "Total Customers: 0";
                lblActiveCustomers.Text = "Active: 0";
                lblInactiveCustomers.Text = "Inactive: 0";
                return;
            }

            int total = dgvCustomers.Rows.Count;
            int active = dgvCustomers.Rows.Cast<DataGridViewRow>()
                           .Count(row => row.Cells["Status"].Value?.ToString() == "Active");

            lblTotalCustomers.Text = $"Total Customers: {total}";
            lblActiveCustomers.Text = $"Active: {active}";
            lblInactiveCustomers.Text = $"Inactive: {total - active}";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filtered = _allCustomers.Where(u =>
                (u.CustomerNumber?.ToLower().Contains(searchText) ?? false) ||
                (u.FirstName?.ToLower().Contains(searchText) ?? false) ||
                (u.Email?.ToLower().Contains(searchText) ?? false)
            ).Where(u =>
                selectedStatus == "All" ||
                (selectedStatus == "Active" && u.IsActive) ||
                (selectedStatus == "Inactive" && !u.IsActive)
            ).ToList();

            BindCustomerGrid(filtered);
            UpdateStatusStrip();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
    }
}
