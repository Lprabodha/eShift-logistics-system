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
        public CustomerRegisterForm()
        {
            InitializeComponent();
            ApplyCustomStyles();
            ApplyPlaceholderText();
        }

        private void ApplyCustomStyles()
        {
            this.Font = new Font("Segoe UI", 9F);
        }


        private void ApplyPlaceholderText()
        {
            SetPlaceholder(txtFirstName, "Enter your First Name");
            SetPlaceholder(txtPhoneNumber, "Enter your phone number");
            SetPlaceholder(txtPassword, "Enter your Password", isPassword: true);
            SetPlaceholder(txtConfirmPassword, "Confirm your Password", isPassword: true);
        }

        private void SetPlaceholder(TextBox textbox, string placeholder, bool isPassword = false)
        {
            textbox.Text = placeholder;
            textbox.ForeColor = Color.Gray;
            textbox.GotFocus += (s, e) =>
            {
                if (textbox.Text == placeholder)
                {
                    textbox.Text = "";
                    textbox.ForeColor = Color.Black;
                    if (isPassword) textbox.UseSystemPasswordChar = true;
                }
            };
            textbox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    textbox.Text = placeholder;
                    textbox.ForeColor = Color.Gray;
                    if (isPassword) textbox.UseSystemPasswordChar = false;
                }
            };
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
