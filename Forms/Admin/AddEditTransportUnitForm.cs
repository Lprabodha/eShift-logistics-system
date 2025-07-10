using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using eShift_Logistics_System.Validators;
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
    public partial class AddEditTransportUnitForm : Form
    {
        /// <summary>
        /// Optional ID of the transport unit being edited. If null, a new unit will be created.
        /// </summary>
        private readonly int? _unitId;
        private TransportUnit _editingUnit;

        /// <summary>
        /// Service for managing transport units in the logistics system.
        /// </summary>
        private readonly IUnitService _unitService;
        private readonly ITruckService _truckService;
        private readonly IAssistantService _assistantService;
        private readonly IDriverService _driverService;

        /// <summary>
        /// Constructor for the AddEditTransportUnitForm.
        /// </summary>
        /// <param name="unitId"></param>
        public AddEditTransportUnitForm(int? unitId = null)
        {
            InitializeComponent();
            _unitId = unitId;
 
            _unitService = new UnitService(new UnitRepository());
            _truckService = new TruckService(new TruckRepositroy());
            _assistantService = new AssistantService(new AssistantRepository());
            _driverService = new DriverService(new DriverRepository());
        }

        /// <summary>
        /// Handles the Load event of the AddEditUnitForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditUnitForm_Load(object sender, EventArgs e)
        {
            cboStatus.DataSource = Enum.GetValues(typeof(TransportUnitStatus));

            if (_unitId.HasValue)
            {
                LoadUnitData();

                lblTitle.Text = "Edit Transport Unit";
                LoadComboBoxData(_editingUnit.TruckId, _editingUnit.DriverId, _editingUnit.AssistantId);
                SetSelectedValues();
            }
            else
            {
                lblTitle.Text = "Add New Transport Unit";
                _editingUnit = new TransportUnit();
                LoadComboBoxData();
                GenerateUnitNumber();
            }

            cboStatus.DataSource = Enum.GetValues(typeof(TransportUnitStatus));
        }

        /// <summary>
        /// Generates a new unit number based on the current year and the last unit ID in the database.
        /// </summary>
        private void GenerateUnitNumber()
        {
            try
            {
                int unitCount = _unitService.GetLastUnitId();
                int nextId = unitCount + 1;
                string year = DateTime.Now.ToString("yyyy");

                _editingUnit.UnitNumber = $"UNIT-{year}-{nextId:D3}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not generate unit number: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Sets the selected values for the combo boxes based on the editing unit's properties.
        /// </summary>

        private void SetSelectedValues()
        {
            if (_editingUnit == null) return;

            cboTruck.SelectedValue = _editingUnit.TruckId;
            cboDriver.SelectedValue = _editingUnit.DriverId;

            cboAssistant.SelectedValue = _editingUnit.AssistantId;

            cboStatus.SelectedItem = _editingUnit.Status;
            chkIsActive.Checked = _editingUnit.IsActive;
        }

        /// <summary>
        /// Loads data into the combo boxes for trucks, drivers, and assistants.
        /// </summary>
        /// <param name="currentTruckId"></param>
        /// <param name="currentDriverId"></param>
        /// <param name="currentAssistantId"></param>
        private void LoadComboBoxData(int? currentTruckId = null, int? currentDriverId = null, int? currentAssistantId = null)
        {

            try
            {
                var availableTrucks = _truckService.GetAvailableTrucks(currentTruckId);
                var placeholderTruck = new Truck { Id = 0, LicensePlate = "--- Select a Truck ---" };
                availableTrucks.Insert(0, placeholderTruck);

                cboTruck.DataSource = availableTrucks;
                cboTruck.DisplayMember = "LicensePlate";
                cboTruck.ValueMember = "Id";

                var availableDrivers = _driverService.GetAvailableDrivers(currentDriverId);
                var placeholderDriver = new Driver { Id = 0, Name = "--- Select a Driver ---" };
                availableDrivers.Insert(0, placeholderDriver);

                cboDriver.DataSource = availableDrivers;
                cboDriver.DisplayMember = "Name";
                cboDriver.ValueMember = "Id";

                var availableAssistants = _assistantService.GetAvailableAssistants(currentAssistantId);
                var placeholderAssitant = new Assistant  { Id = 0, Name = "--- Select a Assistant ---" };

                availableAssistants.Insert(0, placeholderAssitant);
                cboAssistant.DataSource = availableAssistants;
                cboAssistant.DisplayMember = "Name";
                cboAssistant.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data for dropdowns: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Loads the transport unit data into the form controls for editing.
        /// </summary>
        private void LoadUnitData()
        {
             _editingUnit = _unitService.GetUnitById(_unitId.Value);

            cboTruck.SelectedValue = _editingUnit.TruckId;
            cboDriver.SelectedValue = _editingUnit.DriverId;
            cboAssistant.SelectedValue = _editingUnit.AssistantId;
            cboStatus.SelectedItem = _editingUnit.Status;
            chkIsActive.Checked = _editingUnit.IsActive;
        }

        /// <summary>
        /// Handles the Save button click event to save the transport unit data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            _editingUnit.TruckId = (int)cboTruck.SelectedValue;
            _editingUnit.DriverId = (int)cboDriver.SelectedValue;
            _editingUnit.AssistantId = (int)cboAssistant.SelectedValue;
            _editingUnit.Status = (TransportUnitStatus)cboStatus.SelectedItem;
            _editingUnit.IsActive = chkIsActive.Checked;

            var validator = new TransportUnitValidator(new UnitRepository());
            var results = validator.Validate(_editingUnit);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                return;
            }

            try
            {
                if (_unitId.HasValue)
                {
                    _unitService.UpdateUnit(_editingUnit);
                    MessageBox.Show("Transport Unit updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _unitService.AddUnit(_editingUnit);
                    MessageBox.Show($"New Transport Unit {_editingUnit.UnitNumber} added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
