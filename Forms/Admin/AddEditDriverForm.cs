using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
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
    /// <summary>
    /// Form for adding or editing a driver in the logistics system.
    /// </summary>
    public partial class AddEditDriverForm : Form
    {
        private readonly int? _driverId;
         private readonly IDriverService _driverService;

        /// <summary>
        /// Constructor for the AddEditDriverForm.
        /// </summary>
        /// <param name="driverId"></param>
        public AddEditDriverForm(int? driverId = null)
        {
            InitializeComponent();
            _driverId = driverId;
             _driverService = new DriverService(new DriverRepository());
        }

        /// <summary>
        /// Handles the Load event of the AddEditDriverForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditDriverForm_Load(object sender, EventArgs e)
        {
            cboStatus.DataSource = Enum.GetValues(typeof(DriverStatus));

            if (_driverId.HasValue)
            {
                lblTitle.Text = "Edit Driver";
                LoadDriverData();
            }
            else
            {
                lblTitle.Text = "Add New Driver";
                cboStatus.SelectedItem = DriverStatus.Available;
            }
        }

        /// <summary>
        /// Loads the driver data into the form fields for editing.
        /// </summary>
        private void LoadDriverData()
        {
             var driver = _driverService.GetDriverById(_driverId.Value);
  
            if (driver == null)
            {
                MessageBox.Show("Driver not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = driver.Name;
            txtLicenseNumber.Text = driver.LicenseNumber;
            txtPhone.Text = driver.Phone;
            txtAddress.Text = driver.Address;
            cboStatus.SelectedItem = driver.Status;
            chkIsActive.Checked = driver.IsActive;
        }

        /// <summary>
        /// Handles the Save button click event to add or update driver details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSave_Click(object sender, EventArgs e)
        {

            var driver = new Driver
            {
                Name = txtName.Text.Trim(),
                LicenseNumber = txtLicenseNumber.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Status = (DriverStatus)cboStatus.SelectedItem,
                IsActive = chkIsActive.Checked
            };

            if (_driverId.HasValue)
            {
                driver.Id = _driverId.Value;
            }

            var validator = new DriverValidator(new DriverRepository());
            var results = validator.Validate(driver);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                return;
            }


            if (_driverId.HasValue)
            {
                 _driverService.UpdateDriver(driver);
                MessageBox.Show("Driver details updated successfully!", "Success");
            }
            else
            {
                 _driverService.AddDriver(driver);
                MessageBox.Show("New driver added successfully!", "Success");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
