namespace eShift_Logistics_System.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pnlLeft = new Panel();
            picIllustration = new PictureBox();
            pnlRight = new Panel();
            lblWelcome = new Label();
            lblAppName = new Label();
            pnlEmail = new Panel();
            picEmailIcon = new PictureBox();
            txtEmail = new TextBox();
            pnlPassword = new Panel();
            picPasswordIcon = new PictureBox();
            txtPassword = new TextBox();
            chkRememberMe = new CheckBox();
            lnkForgotPassword = new LinkLabel();
            btnLogin = new Button();
            lblNoAccount = new Label();
            lnkRegister = new LinkLabel();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIllustration).BeginInit();
            pnlRight.SuspendLayout();
            pnlEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEmailIcon).BeginInit();
            pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPasswordIcon).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(picIllustration);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(394, 525);
            pnlLeft.TabIndex = 1;
            // 
            // picIllustration
            // 
            picIllustration.Image = (Image)resources.GetObject("picIllustration.Image");
            picIllustration.Location = new Point(35, 84);
            picIllustration.Name = "picIllustration";
            picIllustration.Size = new Size(324, 356);
            picIllustration.SizeMode = PictureBoxSizeMode.Zoom;
            picIllustration.TabIndex = 0;
            picIllustration.TabStop = false;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(249, 249, 249);
            pnlRight.Controls.Add(lblWelcome);
            pnlRight.Controls.Add(lblAppName);
            pnlRight.Controls.Add(pnlEmail);
            pnlRight.Controls.Add(pnlPassword);
            pnlRight.Controls.Add(chkRememberMe);
            pnlRight.Controls.Add(lnkForgotPassword);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(lblNoAccount);
            pnlRight.Controls.Add(lnkRegister);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(394, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(376, 525);
            pnlRight.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(44, 56);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(130, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAppName.ForeColor = Color.FromArgb(65, 84, 241);
            lblAppName.Location = new Point(44, 86);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(219, 32);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "E-Shift Household";
            // 
            // pnlEmail
            // 
            pnlEmail.BackColor = Color.White;
            pnlEmail.BorderStyle = BorderStyle.FixedSingle;
            pnlEmail.Controls.Add(picEmailIcon);
            pnlEmail.Controls.Add(txtEmail);
            pnlEmail.Location = new Point(47, 189);
            pnlEmail.Name = "pnlEmail";
            pnlEmail.Size = new Size(280, 42);
            pnlEmail.TabIndex = 4;
            // 
            // picEmailIcon
            // 
            picEmailIcon.ErrorImage = (Image)resources.GetObject("picEmailIcon.ErrorImage");
            picEmailIcon.Image = (Image)resources.GetObject("picEmailIcon.Image");
            picEmailIcon.InitialImage = (Image)resources.GetObject("picEmailIcon.InitialImage");
            picEmailIcon.Location = new Point(9, 9);
            picEmailIcon.Name = "picEmailIcon";
            picEmailIcon.Size = new Size(21, 22);
            picEmailIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picEmailIcon.TabIndex = 0;
            picEmailIcon.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(39, 11);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(228, 18);
            txtEmail.TabIndex = 1;
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtEmail.Enter += txtEmail_TextChanged;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.White;
            pnlPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlPassword.Controls.Add(picPasswordIcon);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Location = new Point(47, 241);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(280, 42);
            pnlPassword.TabIndex = 5;
            // 
            // picPasswordIcon
            // 
            picPasswordIcon.Image = (Image)resources.GetObject("picPasswordIcon.Image");
            picPasswordIcon.Location = new Point(9, 9);
            picPasswordIcon.Name = "picPasswordIcon";
            picPasswordIcon.Size = new Size(21, 22);
            picPasswordIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picPasswordIcon.TabIndex = 0;
            picPasswordIcon.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(39, 11);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(228, 18);
            txtPassword.TabIndex = 1;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(47, 293);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(104, 19);
            chkRememberMe.TabIndex = 6;
            chkRememberMe.Text = "Remember me";
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.LinkColor = Color.FromArgb(65, 84, 241);
            lnkForgotPassword.Location = new Point(234, 293);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(100, 15);
            lnkForgotPassword.TabIndex = 7;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Forgot Password?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(65, 84, 241);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(47, 330);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(280, 47);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblNoAccount
            // 
            lblNoAccount.AutoSize = true;
            lblNoAccount.Location = new Point(96, 396);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(131, 15);
            lblNoAccount.TabIndex = 9;
            lblNoAccount.Text = "Don't have an account?";
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.LinkColor = Color.FromArgb(65, 84, 241);
            lnkRegister.Location = new Point(228, 396);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(49, 15);
            lnkRegister.TabIndex = 10;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Register";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 525);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIllustration).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlEmail.ResumeLayout(false);
            pnlEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEmailIcon).EndInit();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPasswordIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picIllustration;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.PictureBox picEmailIcon;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox picPasswordIcon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.LinkLabel lnkRegister;
    }
}