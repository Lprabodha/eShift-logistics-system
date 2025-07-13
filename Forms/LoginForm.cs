using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
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
        private readonly IUserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            ApplyPlaceholderText();

            _userRepository = new UserRepository();
            _userService = new UserService(_userRepository);
        }

        private void ApplyPlaceholderText()
        {
            PlaceholderHelper.SetPlaceholder(txtEmail, "Enter your email");
            PlaceholderHelper.SetPlaceholder(txtPassword, "Enter your Password", isPassword: true);
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new CustomerRegisterForm();
            this.Hide();

            registerForm.FormClosed += (s, args) => this.Close();
            registerForm.Show();
        }

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
                var authenticatedUser = _userService.AuthenticateUser(email, password);

                if (authenticatedUser == null)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Hide();

                if (authenticatedUser.UserType == UserType.Admin)
                {
                    var adminForm = new AdminDashboardForm();
                    adminForm.FormClosed += (s, args) => this.Close();
                    adminForm.Show();
                }
                else if (authenticatedUser.UserType == UserType.Customer)
                {
                    var customerForm = new CustomerDashboardForm(authenticatedUser.Id);
                    customerForm.FormClosed += (s, args) => this.Close();
                    customerForm.Show();
                }
                else
                {
                    MessageBox.Show("Unknown user role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login process failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
