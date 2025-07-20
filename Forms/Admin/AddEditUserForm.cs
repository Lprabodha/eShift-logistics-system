using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Service;
using eShift_Logistics_System.Validators;
using FluentValidation;
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
  
    public partial class AddEditUserForm : Form
    {
        private readonly int? _userId;
        private User _currentUser;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;


        public AddEditUserForm(int? userId = null)
        {
            InitializeComponent();
            _userId = userId;
            _userService = new UserService(new UserRepository());
            _emailService = new EmailService();
        }

        private async void AddEditUserForm_Load(object sender, EventArgs e)
        {
            if (_userId.HasValue)
            {
                lblTitle.Text = "Edit Customer Details";
                LoadUserData();
                ConfigureFormForEdit();
            }
            else
            {
                lblTitle.Text = "Add New Customer";
                ConfigureFormForAdd();
            }
        }

        private void ConfigureFormForAdd()
        {

            lblPassword.Visible = txtPassword.Visible = true;
            lblConfirmPassword.Visible = txtConfirmPassword.Visible = true;
            chkIsActive.Checked = true; 
        }
        private void ConfigureFormForEdit()
        {
            lblPassword.Visible = txtPassword.Visible = false;
            lblConfirmPassword.Visible = txtConfirmPassword.Visible = false;
        }

        private void LoadUserData()
        {
            try
            {
                if (!_userId.HasValue)
                {
                    MessageBox.Show("No user ID provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var user = _userService.GetUserById(_userId.Value);

                if (user == null)
                {
                    MessageBox.Show("The selected user could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtFirstName.Text = user.FirstName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                txtAddress.Text = user.Address;
                chkIsActive.Checked = user.IsActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer data: {ex.Message}", "Error", MessageBoxButtons.OK);
                Console.WriteLine($"Error loading customer data for ID {_userId}: {ex}");
                this.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the Save button.
        /// </summary>
        private async void btnSave_Click(object sender, EventArgs e) 
        {
            var user = new User
            {
                FirstName = txtFirstName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                UserType = UserType.Customer,
                IsActive = chkIsActive.Checked,
                PasswordHash = txtPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text
            };

            if (_userId.HasValue && string.IsNullOrEmpty(txtPassword.Text) && string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                user.PasswordHash = _currentUser?.PasswordHash;
                user.ConfirmPassword = _currentUser?.PasswordHash;
            }

            var validator = new UserValidator(new UserRepository());
            var results = validator.Validate(user);

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
                if (_userId.HasValue)
                {
                    _userService.UpdateUser(user);
                    MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    _userService.AddUser(user);

                    try
                    {
                        _emailService.SendAccountCreatedEmail(user);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error sending account email: " + ex.Message);
                    }

                    MessageBox.Show("New customer added successfully!", "Success", MessageBoxButtons.OK);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving customer: {ex.Message}", "Error", MessageBoxButtons.OK);
                Console.WriteLine($"Error saving customer (ID: {_userId}, Email: {user.Email}): {ex}");
            }
        }
    }
}
