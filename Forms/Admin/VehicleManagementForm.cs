using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
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
using System.Windows.Forms.Design;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class VehicleManagementForm : Form
    {
        private readonly ITruckService _truckService;
        private readonly IDriverService _driverService;
        private readonly IAssistantService _assistantService;
        private readonly IUnitService _unitService;

        private List<Truck> _allTrucks; // This will hold the master list of trucks
        private List<Driver> _allDrivers;
        private List<Assistant> _allAssistants;
        private List<TransportUnit> _allUnits;

        public VehicleManagementForm()
        {
            _truckService = new TruckService(new TruckRepositroy());
            //_driverService = new DriverService(new DriverRepository());
            _assistantService = new AssistantService(new AssistantRepository());
            //_unitService = new UnitService(new UnitRepository());
            InitializeComponent();
        }

        private void VehicleManagementForm_Load(object sender, EventArgs e)
        {
            SetupTrucksGrid();
            SetupDriversGrid();
            SetupAssistantsGrid();
            SetupUnitsGrid();


            LoadAllData();

            // Attach event handlers
            // Trucks
            this.btnAddNewTruck.Click += new System.EventHandler(this.btnAddNewTruck_Click);
            this.btnTruckSearch.Click += new System.EventHandler(this.btnTruckSearch_Click);
            this.dgvTrucks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrucks_CellClick);
            // Drivers
            this.btnAddNewDriver.Click += new System.EventHandler(this.btnAddNewDriver_Click);
            this.btnDriverSearch.Click += new System.EventHandler(this.btnDriverSearch_Click);
            this.dgvDrivers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDrivers_CellClick);
            // Assistants
            this.btnAddNewAssistant.Click += new System.EventHandler(this.btnAddNewAssistant_Click);
            this.btnAssistantSearch.Click += new System.EventHandler(this.btnAssistantSearch_Click);
            this.dgvAssistants.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssistants_CellClick);
            // Units
            this.btnAddNewUnit.Click += new System.EventHandler(this.btnAddNewUnit_Click);
            this.btnUnitSearch.Click += new System.EventHandler(this.btnUnitSearch_Click);
            this.dgvUnits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnits_CellClick);
        }

        private void LoadAllData()
        {
            LoadTrucksData();
            LoadDriversData();
            LoadAssistantsData();
            LoadUnitsData();
        }


        /// <summary>
        /// Sets up the DataGridView for displaying trucks with appropriate columns and properties.
        /// </summary>
        private void SetupTrucksGrid()
        {
            dgvTrucks.Columns.Clear();
            dgvTrucks.AutoGenerateColumns = false;

            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });

            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "LicensePlate", HeaderText = "License Plate", DataPropertyName = "LicensePlate", Width = 120 });
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Model", HeaderText = "Make & Model", DataPropertyName = "Model", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Capacity", HeaderText = "Capacity (kg)", DataPropertyName = "Capacity", Width = 120 });
            dgvTrucks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });

            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 };
            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 };

            dgvTrucks.Columns.AddRange(new DataGridViewColumn[] { btnEdit, btnDelete });
        }

        /// <summary>
        /// Loads all trucks from the service and binds them to the DataGridView.
        /// </summary>
        private void LoadTrucksData()
        {
            try
            {
                _allTrucks = _truckService.GetAllTrucks();
                BindDataToGrid(_allTrucks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load truck data.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _allTrucks = new List<Truck>();
            }
        }

        /// <summary>
        /// Binds the provided list of trucks to the DataGridView.
        /// </summary>
        /// <param name="trucks"></param>
        private void BindDataToGrid(List<Truck> trucks)
        {
            dgvTrucks.DataSource = null;
            dgvTrucks.DataSource = trucks;
        }

        /// <summary>
        /// Handles cell clicks in the DataGridView for editing or deleting trucks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    _truckService.DeleteTruck(truckId);
                    MessageBox.Show($"Truck {licensePlate} deleted.");
                    LoadTrucksData();
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Add New Truck" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewTruck_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditTruckForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTrucksData();
            }
        }

        /// <summary>
        /// Handles the click event for the truck search button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTruckSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtTruckSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                BindDataToGrid(_allTrucks);
                return;
            }

            var filteredList = _allTrucks.Where(t =>
                (t.Model?.ToLower().Contains(searchText) ?? false) ||
                (t.LicensePlate?.ToLower().Contains(searchText) ?? false)
            ).ToList();

            BindDataToGrid(filteredList);
        }

        private void SetupDriversGrid()
        {
            dgvDrivers.Columns.Clear();
            dgvDrivers.AutoGenerateColumns = false;
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", HeaderText = "Full Name", DataPropertyName = "FullName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "LicenseNumber", HeaderText = "License No.", DataPropertyName = "LicenseNumber", Width = 150 });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone", DataPropertyName = "Phone", Width = 120 });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });
            dgvDrivers.Columns.AddRange(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 },
                                        new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 });
        }

        private void LoadDriversData()
        {
            //_allDrivers = _driverService.GetAllDrivers();
            //BindDataToGrid(_allDrivers);
        }

        private void BindDataToGrid(List<Driver> drivers)
        {
            dgvDrivers.DataSource = null;
            dgvDrivers.DataSource = drivers;
        }

        private void btnDriverSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtDriverSearch.Text.Trim().ToLower();
            var filteredList = _allDrivers.Where(d => d.FullName.ToLower().Contains(searchText) || d.LicenseNumber.ToLower().Contains(searchText)).ToList();
            BindDataToGrid(filteredList);
        }

        private void dgvDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Add Edit/Delete logic here...
        }

        private void btnAddNewDriver_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opening Add/Edit Driver form...");
        }

        private void SetupAssistantsGrid()
        {
            dgvAssistants.Columns.Clear();
            dgvAssistants.AutoGenerateColumns = false;
            dgvAssistants.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvAssistants.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAssistants.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone", DataPropertyName = "Phone", Width = 120 });
            dgvAssistants.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });
            dgvAssistants.Columns.AddRange(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 },
                                           new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 });
        }

        private void LoadAssistantsData()
        {
            _allAssistants = _assistantService.GetAllAssistants();
            BindDataToGrid(_allAssistants);
        }

        private void BindDataToGrid(List<Assistant> assistants)
        {
            dgvAssistants.DataSource = null;
            dgvAssistants.DataSource = assistants;
        }

        private void btnAssistantSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtAssistantSearch.Text.Trim().ToLower();
            var filteredList = _allAssistants.Where(a => a.Name.ToLower().Contains(searchText)).ToList();
            BindDataToGrid(filteredList);
        }

        private void dgvAssistants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int assistantId = Convert.ToInt32(dgvAssistants.Rows[e.RowIndex].Cells["Id"].Value);
            string assistantName = dgvAssistants.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            if (dgvAssistants.Columns[e.ColumnIndex].Name == "Edit")
            {
                var editForm = new AddEditAssistantForm(assistantId);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAssistantsData();
                }
            }
            else if (dgvAssistants.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirmResult = MessageBox.Show($"Are you sure you want to delete assistant {assistantName}?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                     _assistantService.DeleteAssistant(assistantId);

                    MessageBox.Show($"Assistant {assistantName} has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAssistantsData();
                }
            }
        }

        private void btnAddNewAssistant_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditAssistantForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAssistantsData();
            }
        }

        private void SetupUnitsGrid()
        {
            dgvUnits.Columns.Clear();
            dgvUnits.AutoGenerateColumns = false;
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitNumber", HeaderText = "Unit #", DataPropertyName = "UnitNumber", Width = 120 });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "Truck", HeaderText = "Truck", DataPropertyName = "Truck", Width = 150 });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "Driver", HeaderText = "Driver", DataPropertyName = "Driver", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "Assistant", HeaderText = "Assistant", DataPropertyName = "Assistant", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });
            dgvUnits.Columns.AddRange(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 },
                                      new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 });
        }

        private void LoadUnitsData()
        {
            //_allUnits = _unitService.GetAllUnits(); // This service method should eager load Truck, Driver, Assistant
            //BindDataToGrid(_allUnits);
        }

        private void BindDataToGrid(List<TransportUnit> units)
        {
            dgvUnits.DataSource = null;
            var displayList = units.Select(u => new
            {
                u.Id,
                u.UnitNumber,
                Truck = u.Truck?.LicensePlate ?? "N/A",
                Driver = u.Driver?.FullName ?? "N/A",
                Assistant = u.Assistant?.Name ?? "N/A",
                u.Status
            }).ToList();
            dgvUnits.DataSource = displayList;
        }

        private void btnUnitSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtUnitSearch.Text.Trim().ToLower();
            var filteredList = _allUnits.Where(u =>
                u.UnitNumber.ToLower().Contains(searchText) ||
                (u.Truck?.LicensePlate.ToLower().Contains(searchText) ?? false) ||
                (u.Driver?.FullName.ToLower().Contains(searchText) ?? false)
            ).ToList();
            BindDataToGrid(filteredList);
        }

        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // Add Edit/Delete logic here...
        }

        private void btnAddNewUnit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opening Add/Edit Transport Unit form...");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
