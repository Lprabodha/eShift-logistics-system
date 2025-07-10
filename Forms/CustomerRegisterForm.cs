using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using eShift_Logistics_System.Validators;
using FluentValidation.Results;
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
    public partial class CustomerRegisterForm : Form
    {
        private readonly IUserService _userService;
        public CustomerRegisterForm()
        {
            InitializeComponent();
            ApplyCustomStyles();
            ApplyPlaceholderText();

            IUserRepository userRepository = new UserRepository();
            _userService = new UserService(userRepository);

        }

        /// <summary>
        /// Applies custom styles to the registration form, such as font settings.
        /// </summary>
        private void ApplyCustomStyles()
        {
            this.Font = new Font("Segoe UI", 9F);
        }


        /// <summary>
        /// Sets placeholder text for the input fields in the registration form.
        /// </summary>
        private void ApplyPlaceholderText()
        {
            PlaceholderHelper.SetPlaceholder(txtFirstName, "Enter your First Name");
            PlaceholderHelper.SetPlaceholder(txtPhoneNumber, "Enter your phone number");
            PlaceholderHelper.SetPlaceholder(txtEmail, "Enter your Email");
            PlaceholderHelper.SetPlaceholder(txtPassword, "Enter your Password", isPassword: true);
            PlaceholderHelper.SetPlaceholder(txtConfirmPassword, "Confirm your Password", isPassword: true);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the link click event for the registration link to navigate to the login form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the click event for the register button to validate and register a new user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {

            var user = new User
            {
                FirstName = PlaceholderHelper.GetInput(txtFirstName),
                Phone = PlaceholderHelper.GetInput(txtPhoneNumber),
                Email = PlaceholderHelper.GetInput(txtEmail),
                PasswordHash = PlaceholderHelper.GetInput(txtPassword),
                ConfirmPassword = PlaceholderHelper.GetInput(txtConfirmPassword),
            };

            var userRepo = new UserRepository();
            UserValidator validator = new UserValidator(userRepo);
            ValidationResult results = validator.Validate(user);

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
                _userService.AddUser(user);
                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerRegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
