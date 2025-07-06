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

        private void ApplyCustomStyles()
        {
            this.Font = new Font("Segoe UI", 9F);
        }

        private void ApplyPlaceholderText()
        {
            SetPlaceholder(txtEmail, "Enter your email");
            SetPlaceholder(txtPassword, "Enter your Password", isPassword: true);
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

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerRegisterForm registerForm = new CustomerRegisterForm();
            this.Hide();
            registerForm.Show();
        }
    }
}
