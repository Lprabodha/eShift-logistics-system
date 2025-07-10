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
        private readonly int? _unitId;
        private TransportUnit _editingUnit; 

         private readonly IUnitService _unitService;
        private readonly ITruckService _truckService;
        private readonly IAssistantService _assistantService;
        private readonly IDriverService _driverService;

        public AddEditTransportUnitForm(int? unitId = null)
        {
            InitializeComponent();
            _unitId = unitId;
            _unitService = new UnitService(new UnitRepository());
            _truckService = new TruckService(new TruckRepositroy());
            _assistantService = new AssistantService(new AssistantRepository());
            _driverService = new DriverService(new DriverRepository());
        }

        private void AddEditUnitForm_Load(object sender, EventArgs e)
        {

            if (_unitId.HasValue)
            {
                lblTitle.Text = "Edit Transport Unit";
                LoadComboBoxData(_editingUnit.TruckId, _editingUnit.DriverId, _editingUnit.AssistantId);
                SetSelectedValues();
                LoadUnitData();
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

        private void GenerateUnitNumber()
        {
            try
            {
                int unitCount = _unitService.GetTotalUnitCount();
                int nextId = unitCount + 1;
                string year = DateTime.Now.ToString("yyyy");

                _editingUnit.UnitNumber = $"UNIT-{year}-{nextId:D3}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not generate unit number: {ex.Message}", "Error");
            }
        }

        private void SetSelectedValues()
        {
            if (_editingUnit == null) return;

            cboTruck.SelectedValue = _editingUnit.TruckId;
            cboDriver.SelectedValue = _editingUnit.DriverId;

            cboAssistant.SelectedValue = _editingUnit.AssistantId;

            cboStatus.SelectedItem = _editingUnit.Status;
            chkIsActive.Checked = _editingUnit.IsActive;
        }

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

        private void LoadUnitData()
        {
             _editingUnit = _unitService.GetUnitById(_unitId.Value);

            // Populate controls from the loaded object
            cboTruck.SelectedValue = _editingUnit.TruckId;
            cboDriver.SelectedValue = _editingUnit.DriverId;
            cboAssistant.SelectedValue = _editingUnit.AssistantId;
            cboStatus.SelectedItem = _editingUnit.Status;
            chkIsActive.Checked = _editingUnit.IsActive;
        }

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
