using eShift_Logistics_System.Forms.Admin;
using eShift_Logistics_System.Forms.Customer;
using eShift_Logistics_System.Helpers;
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

namespace eShift_Logistics_System.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;

        public LoginForm()
        {
            InitializeComponent();
            ApplyCustomStyles();
            ApplyPlaceholderText();

            _userRepository = new UserRepository();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Applies custom styles to the login form, such as font settings.
        /// </summary>
        private void ApplyCustomStyles()
        {
            this.Font = new Font("Segoe UI", 9F);
        }

        /// <summary>
        /// Sets placeholder text for the input fields in the login form.
        /// </summary>
        private void ApplyPlaceholderText()
        {
            PlaceholderHelper.SetPlaceholder(txtEmail, "Enter your email");
            PlaceholderHelper.SetPlaceholder(txtPassword, "Enter your Password", isPassword: true);
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the link click event for the registration link.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerRegisterForm registerForm = new CustomerRegisterForm();
            this.Hide();
            registerForm.Show();
        }

        /// <summary>
        /// Handles the click event for the login button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {

            var email = PlaceholderHelper.GetInput(txtEmail);
            var password = PlaceholderHelper.GetInput(txtPassword);

            var user = new User
            {
                Email = email,
                PasswordHash = password
            };

            var validator = new LoginValidator();
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
                // Fetch user by email
                var existingUser = _userRepository.GetUserByEmail(email);

                if (existingUser == null)
                {
                    MessageBox.Show("No account found with this email.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verify hashed password
                if (!CommonHelper.VerifyPassword(password, existingUser.PasswordHash))
                {
                    MessageBox.Show("Incorrect password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Redirect based on user type
                if (existingUser.UserType == UserType.Admin)
                {
                    AdminDashboardForm adminForm = new AdminDashboardForm();
                    adminForm.Show();
                }
                else
                {
                    CustomerDashboardForm customerForm = new CustomerDashboardForm();
                    customerForm.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
