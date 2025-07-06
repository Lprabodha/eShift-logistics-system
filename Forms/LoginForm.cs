using eShift_Logistics_System.Helpers;
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
        public LoginForm()
        {
            InitializeComponent();
            ApplyCustomStyles();
            ApplyPlaceholderText();
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
    }
}
