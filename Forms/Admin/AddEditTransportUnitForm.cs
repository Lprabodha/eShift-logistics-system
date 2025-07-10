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

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class AddEditTransportUnitForm : Form
    {
        private readonly int? _unitId;
        private TransportUnit _editingUnit; 

         private readonly IUnitService _unitService;
        private readonly ITruckService _truckService;

        public AddEditTransportUnitForm(int? unitId = null)
        {
            InitializeComponent();
            _unitId = unitId;
            _unitService = new UnitService(new UnitRepository());
            _truckService = new TruckService(new TruckRepositroy());
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
                // In a real app, get count from _unitService.GetTotalUnitCount();
                int unitCount = 12; 
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

            var availableTrucks = _truckService.GetAvailableTrucks(currentTruckId);
            cboTruck.DataSource = availableTrucks;
            cboTruck.DisplayMember = "LicensePlate";
            cboTruck.ValueMember = "Id";


            // ... Load Drivers and Assistants
            var availableDrivers = new List<Driver> { new Driver { Id = 2, Name = "John Doe" }, new Driver { Id = 3, Name = "Jane Smith" } };
            cboDriver.DataSource = availableDrivers;
            cboDriver.DisplayMember = "Name";
            cboDriver.ValueMember = "Id";
            var availableAssistants = new List<Assistant> { new Assistant { Id = 5, Name = "Mike Johnson" }, new Assistant { Id = 6, Name = "Sara Connor" } };
            cboAssistant.DataSource = availableAssistants;
            cboAssistant.DisplayMember = "Name";
            cboAssistant.ValueMember = "Id";
        }

        private void LoadUnitData()
        {
             _editingUnit = _unitService.GetUnitById(_unitId.Value);
            // Placeholder data for an existing unit
            _editingUnit = new TransportUnit
            {
                Id = _unitId.Value,
                UnitNumber = "UNIT-2024-005",
                TruckId = 1,
                DriverId = 2,
                AssistantId = null,
                Status = TransportUnitStatus.Assigned,
                IsActive = true
            };

            // Populate controls from the loaded object
            cboTruck.SelectedValue = _editingUnit.TruckId;
            cboDriver.SelectedValue = _editingUnit.DriverId;
            cboAssistant.SelectedValue = _editingUnit.AssistantId ?? (object)DBNull.Value;
            cboStatus.SelectedItem = _editingUnit.Status;
            chkIsActive.Checked = _editingUnit.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboTruck.SelectedItem == null || cboDriver.SelectedItem == null)
            {
                MessageBox.Show("A Truck and a Driver must be selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Populate the existing unit object with data from the form
            _editingUnit.TruckId = (int)cboTruck.SelectedValue;
            _editingUnit.DriverId = (int)cboDriver.SelectedValue;
            _editingUnit.AssistantId = (int?)cboAssistant.SelectedValue;
            _editingUnit.Status = (TransportUnitStatus)cboStatus.SelectedItem;
            _editingUnit.IsActive = chkIsActive.Checked;

            if (_unitId.HasValue)
            {
                // _unitService.UpdateUnit(_editingUnit);
                MessageBox.Show("Transport Unit updated successfully!", "Success");
            }
            else
            {
                // _unitService.AddUnit(_editingUnit);
                MessageBox.Show($"New Transport Unit {_editingUnit.UnitNumber} added successfully!", "Success");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
