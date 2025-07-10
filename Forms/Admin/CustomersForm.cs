using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class CustomersForm : Form
    {
        private readonly IUserService _userService;
        private List<User> _allCustomers; // This will hold the master list of customers

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

            dgvCustomers.CellClick += DgvCustomers_CellClick;
            dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;
            btnSearch.Click += btnSearch_Click;
            btnClear.Click += btnClear_Click;
            cboFilterStatus.SelectedIndexChanged += cboFilterStatus_SelectedIndexChanged;

            LoadAndBindInitialData();

            cboFilterStatus.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            cboFilterStatus.SelectedIndex = 0;
        }

        private void SetupCustomersGrid()
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerNumber", HeaderText = "Customer ID", DataPropertyName = "CustomerNumber", Width = 120 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Full Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email Address", DataPropertyName = "Email", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 80 });

            // Note: I've added the "Edit" button back as it's a critical function.
            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 70 };
            var btnStatus = new DataGridViewButtonColumn { Name = "ChangeStatus", HeaderText = "Change Status", Text = "Toggle Status", UseColumnTextForButtonValue = true, Width = 110 };
            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 70 };

            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { btnEdit, btnStatus, btnDelete });
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

        private void LoadAndBindInitialData()
        {
            try
            {
                _allCustomers = _userService.GetAllUsers()
                                        .Where(u => u.UserType == UserType.Customer)
                                        .ToList();

                BindDataToGrid(_allCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load customer data.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _allCustomers = new List<User>();
            }
            UpdateStatusStrip();
        }

        private void BindDataToGrid(List<User> customers)
        {
            if (customers == null || customers.Count == 0)
            {
                dgvCustomers.DataSource = null;
                dgvCustomers.Rows.Clear();
                MessageBox.Show("No customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var displayList = customers.Select(u => new
            {
                CustomerNumber = u.CustomerNumber ?? "N/A",
                Name = u.FirstName, 
                Email = u.Email,
                Status = u.IsActive ? "Active" : "Inactive"
            }).ToList();

            dgvCustomers.DataSource = null; // Clear previous binding
            dgvCustomers.DataSource = displayList;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
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
            }
            txtNotes.Text = $"Notes for customer {customerId} appear here.";
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            string customerId = dgvCustomers.Rows[e.RowIndex].Cells["CustomerNumber"].Value?.ToString();
            if (string.IsNullOrEmpty(customerId)) return; 

            switch (dgvCustomers.Columns[e.ColumnIndex].Name)
            {
                case "Edit":
                    EditCustomer(customerId);
                    break;
                case "ChangeStatus":
                    ToggleCustomerStatus(customerId);
                    break;
                case "Delete":
                    DeleteCustomer(customerId);
                    break;
            }
        }

        private void EditCustomer(string customerId)
        {

        }

        private void ToggleCustomerStatus(string customerId)
        {
            var customer = _allCustomers.FirstOrDefault(c => c.CustomerNumber == customerId);
            if (customer == null) return;

            string newStatus = customer.IsActive ? "Inactive" : "Active";
            var confirm = MessageBox.Show($"Change status of {customer.FirstName} to {newStatus}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                 bool success = _userService.ToggleUserStatus(customerId);
                LoadAndBindInitialData(); // Refresh data from source
                MessageBox.Show("Status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteCustomer(string customerId)
        {
            var customer = _allCustomers.FirstOrDefault(c => c.CustomerNumber == customerId);
            if (customer == null) return;

            var confirm = MessageBox.Show($"Are you sure you want to delete {customer.FirstName}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                 bool success = _userService.DeleteUser(customerId);
                LoadAndBindInitialData(); 
                MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateStatusStrip()
        {
            int total = _allCustomers.Count;
            int active = _allCustomers.Count(u => u.IsActive);

            lblTotalCustomers.Text = $"Total Customers: {total}";
            lblActiveCustomers.Text = $"Active: {active}";
            lblInactiveCustomers.Text = $"Inactive: {total - active}";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString() ?? "All";

            var filteredList = _allCustomers.Where(u =>
                (string.IsNullOrEmpty(searchText) ||
                 (u.CustomerNumber?.ToLower().Contains(searchText) ?? false) ||
                 (u.FirstName?.ToLower().Contains(searchText) ?? false) ||
                 (u.Email?.ToLower().Contains(searchText) ?? false))
                &&
                (selectedStatus == "All" ||
                 (selectedStatus == "Active" && u.IsActive) ||
                 (selectedStatus == "Inactive" && !u.IsActive))
            ).ToList();

            BindDataToGrid(filteredList);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0;
            BindDataToGrid(_allCustomers); 
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick(); 
        }
    }
}