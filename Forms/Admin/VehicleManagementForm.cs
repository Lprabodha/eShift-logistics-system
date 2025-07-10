using eShift_Logistics_System.Models;
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
    public partial class VehicleManagementForm : Form
    {
        private List<Truck> _allTrucks; // This will hold the master list of trucks

        public VehicleManagementForm()
        {
            InitializeComponent();
        }

        private void VehicleManagementForm_Load(object sender, EventArgs e)
        {
            SetupTrucksGrid();
            LoadTrucksData();

            // Attach event handlers
            this.dgvTrucks.CellClick += new DataGridViewCellEventHandler(this.dgvTrucks_CellClick);
            this.btnAddNewTruck.Click += new EventHandler(this.btnAddNewTruck_Click);
            this.btnTruckSearch.Click += new EventHandler(this.btnTruckSearch_Click);
        }

        private void SetupTrucksGrid()
        {
            dgvTrucks.Columns.Clear();
            dgvTrucks.AutoGenerateColumns = false;

            // Add hidden ID column
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });

            // Add visible data columns
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "LicensePlate", HeaderText = "License Plate", DataPropertyName = "LicensePlate", Width = 120 });
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Model", HeaderText = "Make & Model", DataPropertyName = "Model", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Capacity", HeaderText = "Capacity (kg)", DataPropertyName = "Capacity", Width = 120 });
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });

            // Add action buttons
            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 };
            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 };

            dgvTrucks.Columns.AddRange(new DataGridViewColumn[] { btnEdit, btnDelete });
        }

        private void LoadTrucksData()
        {
            // In a real app, get this list from a service.
            _allTrucks = new List<Truck>
            {
                new Truck { Id = 1, LicensePlate = "CBE-1234", Model = "Isuzu Elf", Capacity = 2500, Status = TruckStatus.Available },
                new Truck { Id = 2, LicensePlate = "CBA-5678", Model = "Mitsubishi Canter", Capacity = 3000, Status = TruckStatus.OnJob },
                new Truck { Id = 3, LicensePlate = "CAB-9012", Model = "Toyota Dyna", Capacity = 2000, Status = TruckStatus.InMaintenance },
                new Truck { Id = 4, LicensePlate = "CBC-3456", Model = "Fuso Fighter", Capacity = 5000, Status = TruckStatus.Available }
            };

            // Bind the full list to the grid
            BindDataToGrid(_allTrucks);
        }

        // A new helper method to bind any list of trucks to the grid
        private void BindDataToGrid(List<Truck> trucks)
        {
            dgvTrucks.DataSource = null;
            dgvTrucks.DataSource = trucks;
        }

        private void dgvTrucks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int truckId = Convert.ToInt32(dgvTrucks.Rows[e.RowIndex].Cells["Id"].Value);
            string licensePlate = dgvTrucks.Rows[e.RowIndex].Cells["LicensePlate"].Value.ToString();

            if (dgvTrucks.Columns[e.ColumnIndex].Name == "Edit")
            {
                var editForm = new AddEditTruckForm(truckId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTrucksData();
                }
            }
            else if (dgvTrucks.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirmResult = MessageBox.Show($"Delete truck {licensePlate}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // _truckService.DeleteTruck(truckId);
                    MessageBox.Show($"Truck {licensePlate} deleted.");
                    LoadTrucksData();
                }
            }
        }

        private void btnAddNewTruck_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditTruckForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTrucksData();
            }
        }

        private void btnTruckSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtTruckSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                BindDataToGrid(_allTrucks); // If search is empty, show all trucks
                return;
            }

            var filteredList = _allTrucks.Where(t =>
                (t.Model?.ToLower().Contains(searchText) ?? false) ||
                (t.LicensePlate?.ToLower().Contains(searchText) ?? false)
            ).ToList();

            BindDataToGrid(filteredList);
        }
    }
}
