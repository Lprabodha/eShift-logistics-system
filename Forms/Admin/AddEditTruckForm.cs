using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using eShift_Logistics_System.Validators;
using MySqlX.XDevAPI.Common;
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
    public partial class AddEditTruckForm : Form
    {
        private readonly int? _truckId; 
        private readonly ITruckService _truckService;

        /// <summary>
        /// Constructor for Add mode.
        /// </summary>
        public AddEditTruckForm()
        {
            InitializeComponent();
            _truckId = null; // Ensure truckId is null for Add mode
            ITruckRepository truckRepository = new TruckRepositroy();
            _truckService = new TruckService(truckRepository);
        }

        //  for EDIT mode
        public AddEditTruckForm(int truckId)
        {
            InitializeComponent();
            _truckId = truckId;

            ITruckRepository truckRepository = new TruckRepositroy();
            _truckService = new TruckService(truckRepository);
        }

        /// <summary>
        /// Form Load event handler to initialize the form based on whether it's in Add or Edit mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditTruckForm_Load(object sender, EventArgs e)
        {
            // Populate the status combobox from the enum
            cboStatus.DataSource = Enum.GetValues(typeof(TruckStatus));

            if (_truckId.HasValue)
            {
                // EDIT MODE
                lblTitle.Text = "Edit Truck";
                LoadTruckData();
            }
            else
            {
                // ADD MODE
                lblTitle.Text = "Add New Truck";
                cboStatus.SelectedItem = TruckStatus.Available;
            }
        }

        /// <summary>
        /// Loads the truck data into the form fields for editing.
        /// </summary>
        private void LoadTruckData()
        {
             var truck = _truckService.GetTruckById(_truckId.Value);


            txtTruckNumber.Text = truck.TruckNumber;
            txtModel.Text = truck.Model;
            txtLicensePlate.Text = truck.LicensePlate;
            numCapacity.Value = truck.Capacity;
            cboStatus.SelectedItem = truck.Status;
            chkIsActive.Checked = truck.IsActive;
        }

        /// <summary>
        /// Handles the Save button click event to validate and save the truck data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Truck truck = new Truck
            {
                TruckNumber = txtTruckNumber.Text.Trim(),
                Model = txtModel.Text.Trim(),
                LicensePlate = txtLicensePlate.Text.Trim(),
                Capacity = (int)numCapacity.Value,
                Status = (TruckStatus)cboStatus.SelectedItem,
                IsActive = chkIsActive.Checked
            };

            if (_truckId.HasValue)
            {
                truck.Id = _truckId.Value; 
            }

            var validator = new TruckValidator(new TruckRepositroy()); 
            var results = validator.Validate(truck);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                return;
            }

            if (_truckId.HasValue)
            {
                truck.Id = _truckId.Value;
                _truckService.UpdateTruck(truck);  
                MessageBox.Show("Truck details updated successfully!", "Success");
            }
            else
            {
                _truckService.AddTruck(truck);
                MessageBox.Show("New truck added successfully!", "Success");
            }

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
    }
}
