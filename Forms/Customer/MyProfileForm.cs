using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Customer
{
    public partial class MyProfileForm : Form
    {
        private readonly int _customerId;
        // private readonly IUserService _userService;

        // In your real application, you would pass the logged-in customer's ID here
        public MyProfileForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            // _userService = new UserService(new UserRepository());
        }

        private void MyProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            // In a real app, get the user from your service:
            // var customer = _userService.GetUserById(_customerId);

            // Using placeholder data for demonstration
            var customer = new
            {
                Name = "John Keells",
                Email = "contact@jkh.lk",
                Phone = "0112345678",
                Address = "123, Galle Road, Colombo 03"
            };

            if (customer == null)
            {
                MessageBox.Show("Could not load your profile.", "Error");
                return;
            }

            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create user object with updated info
            // var updatedProfile = new User { Id = _customerId, Name = txtName.Text, ... };
            // _userService.UpdateProfile(updatedProfile);

            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill in all password fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // In a real app, call your service to change the password
            // bool success = _userService.ChangePassword(_customerId, currentPassword, newPassword);
            // if(success) { ... } else { ... }

            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
    }
}
