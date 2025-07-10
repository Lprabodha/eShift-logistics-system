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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class VehicleManagementForm : Form
    {
        /// <summary>
        /// Represents the services used for managing trucks, drivers, assistants, and transport units.
        /// </summary>
        private readonly ITruckService _truckService;
        private readonly IDriverService _driverService;
        private readonly IAssistantService _assistantService;
        private readonly IUnitService _unitService;

        /// <summary>
        /// Lists to hold all trucks, drivers, assistants, and transport units loaded from the database.
        /// </summary>
        private List<Truck> _allTrucks; 
        private List<Driver> _allDrivers;
        private List<Assistant> _allAssistants;
        private List<TransportUnit> _allUnits;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleManagementForm"/> class.
        /// </summary>
        public VehicleManagementForm()
        {
            _truckService = new TruckService(new TruckRepositroy());
            _driverService = new DriverService(new DriverRepository());
            _assistantService = new AssistantService(new AssistantRepository());
            _unitService = new UnitService(new UnitRepository());
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the VehicleManagementForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads all data from the database for trucks, drivers, assistants, and transport units.
        /// </summary>
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

        /// <summary>
        /// Sets up the DataGridView for displaying drivers with appropriate columns and properties.
        /// </summary>
        private void SetupDriversGrid()
        {
            dgvDrivers.Columns.Clear();
            dgvDrivers.AutoGenerateColumns = false;
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "LicenseNumber", HeaderText = "License No.", DataPropertyName = "LicenseNumber", Width = 150 });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Phone", DataPropertyName = "Phone", Width = 120 });
            dgvDrivers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", Width = 100 });
            dgvDrivers.Columns.AddRange(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 },
                                        new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 });
        }

        /// <summary>
        /// Loads all drivers from the service and binds them to the DataGridView.
        /// </summary>
        private void LoadDriversData()
        {
            _allDrivers = _driverService.GetAllDrivers();
            BindDataToGrid(_allDrivers);
        }

        /// <summary>
        /// Binds the provided list of drivers to the DataGridView.
        /// </summary>
        /// <param name="drivers"></param>
        private void BindDataToGrid(List<Driver> drivers)
        {
            dgvDrivers.DataSource = null;
            dgvDrivers.DataSource = drivers;
        }

        /// <summary>
        /// Handles the click event for the driver search button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDriverSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtDriverSearch.Text.Trim().ToLower();
            var filteredList = _allDrivers.Where(d => d.Name.ToLower().Contains(searchText) || d.LicenseNumber.ToLower().Contains(searchText)).ToList();
            BindDataToGrid(filteredList);
        }

        /// <summary>
        /// Handles cell clicks in the DataGridView for editing or deleting drivers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int driverId = Convert.ToInt32(dgvDrivers.Rows[e.RowIndex].Cells["Id"].Value);
            string driverName = dgvDrivers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            if (dgvDrivers.Columns[e.ColumnIndex].Name == "Edit")
            {
                var editForm = new AddEditDriverForm(driverId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDriversData();
                }
            }
            else if (dgvDrivers.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirmResult = MessageBox.Show($"Are you sure you want to delete driver {driverName}?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    _driverService.DeleteDriver(driverId);
                    MessageBox.Show($"Driver {driverName} has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDriversData();
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Add New Driver" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddNewDriver_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditDriverForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadDriversData();
            }
        }

        /// <summary>
        /// Sets up the DataGridView for displaying assistants with appropriate columns and properties.
        /// </summary>
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

        /// <summary>
        /// Loads all assistants from the service and binds them to the DataGridView.
        /// </summary>
        private void LoadAssistantsData()
        {
            _allAssistants = _assistantService.GetAllAssistants();
            BindDataToGrid(_allAssistants);
        }

        /// <summary>
        /// Binds the provided list of assistants to the DataGridView.
        /// </summary>
        /// <param name="assistants"></param>
        private void BindDataToGrid(List<Assistant> assistants)
        {
            dgvAssistants.DataSource = null;
            dgvAssistants.DataSource = assistants;
        }

        /// <summary>
        /// Handles the click event for the assistant search button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAssistantSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtAssistantSearch.Text.Trim().ToLower();
            var filteredList = _allAssistants.Where(a => a.Name.ToLower().Contains(searchText)).ToList();
            BindDataToGrid(filteredList);
        }

        /// <summary>
        /// Handles cell clicks in the DataGridView for editing or deleting assistants.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handles the click event for the "Add New Assistant" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewAssistant_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditAssistantForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadAssistantsData();
            }
        }

        /// <summary>
        /// Sets up the DataGridView for displaying transport units with appropriate columns and properties.
        /// </summary>
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

        /// <summary>
        /// Loads all transport units from the service and binds them to the DataGridView.
        /// </summary>
        private void LoadUnitsData()
        {
            _allUnits = _unitService.GetAllUnits(); 
            BindDataToGrid(_allUnits);
        }

        /// <summary>
        /// Binds the provided list of transport units to the DataGridView.
        /// </summary>
        /// <param name="units"></param>

        private void BindDataToGrid(List<TransportUnit> units)
        {
            dgvUnits.DataSource = null;
            var displayList = units.Select(u => new
            {
                u.Id,
                u.UnitNumber,
                Truck = u.Truck?.LicensePlate ?? "N/A",
                Driver = u.Driver?.Name ?? "N/A",
                Assistant = u.Assistant?.Name ?? "N/A",
                u.Status
            }).ToList();
            dgvUnits.DataSource = displayList;
        }

        /// <summary>
        /// Handles the click event for the unit search button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnitSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtUnitSearch.Text.Trim().ToLower();

            var filteredList = _allUnits.Where(u =>
                u.UnitNumber.ToLower().Contains(searchText) ||

                (u.Truck?.LicensePlate ?? "").ToLower().Contains(searchText) ||
                (u.Driver?.Name ?? "").ToLower().Contains(searchText) ||
                (u.Assistant?.Name ?? "").ToLower().Contains(searchText)

            ).ToList();

            BindDataToGrid(filteredList);
        }

        /// <summary>
        /// Handles cell clicks in the DataGridView for editing or deleting transport units.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUnits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int unitId = Convert.ToInt32(dgvUnits.Rows[e.RowIndex].Cells["Id"].Value);
            var status = (TransportUnitStatus)dgvUnits.Rows[e.RowIndex].Cells["Status"].Value;
            string unitNumber = dgvUnits.Rows[e.RowIndex].Cells["UnitNumber"].Value.ToString();

            if (dgvUnits.Columns[e.ColumnIndex].Name == "Edit")
            {

                if (status == TransportUnitStatus.OnJob || status == TransportUnitStatus.Assigned)
                {
                    MessageBox.Show($"This Transport Unit cannot be edited because it is currently '{status}'.",
                            "Edit Not Allowed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    return;

                }

                var editForm = new AddEditTransportUnitForm(unitId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUnitsData();
                }
            }
            else if (dgvUnits.Columns[e.ColumnIndex].Name == "Delete")
            {

                if(status == TransportUnitStatus.OnJob || status == TransportUnitStatus.Assigned)
                {
                    MessageBox.Show($"This Transport Unit cannot be deleted because it is currently '{status}'.",
                            "Delete Not Allowed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show($"Are you sure you want to delete transport unit {unitNumber}?",
                                             "Confirm Deletion",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    _unitService.DeleteUnit(unitId);
                    MessageBox.Show($"Transport unit {unitNumber} has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUnitsData();
                }
            }
        }

        /// <summary>
        /// Handles the click event for the "Add New Transport Unit" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewUnit_Click(object sender, EventArgs e)
        {

            var addForm = new AddEditTransportUnitForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUnitsData();
            }

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewUnit_Click_1(object sender, EventArgs e)
        {

        }
    }
}
