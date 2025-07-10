using eShift_Logistics_System.Properties;

namespace eShift_Logistics_System.Forms
{
    partial class CustomerRegisterForm
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

        #region

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerRegisterForm));
            pnlLeft = new Panel();
            label4 = new Label();
            picIllustration = new PictureBox();
            lblAppName = new Label();
            pnlRight = new Panel();
            label7 = new Label();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            txtConfirmPassword = new TextBox();
            label6 = new Label();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            txtPassword = new TextBox();
            label5 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnlEmail = new Panel();
            picEmailIcon = new PictureBox();
            txtFirstName = new TextBox();
            pnlPassword = new Panel();
            picPasswordIcon = new PictureBox();
            txtEmail = new TextBox();
            btnRegister = new Button();
            lblNoAccount = new Label();
            lnkRegister = new LinkLabel();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIllustration).BeginInit();
            pnlRight.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEmailIcon).BeginInit();
            pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPasswordIcon).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(label4);
            pnlLeft.Controls.Add(picIllustration);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(394, 525);
            pnlLeft.TabIndex = 1;
            pnlLeft.Paint += pnlLeft_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(35, 71);
            label4.Name = "label4";
            label4.Size = new Size(334, 20);
            label4.TabIndex = 14;
            label4.Text = "Effortless logistics for household goods transport";
            // 
            // picIllustration
            // 
            picIllustration.Image = (Image)resources.GetObject("picIllustration.Image");
            picIllustration.Location = new Point(35, 116);
            picIllustration.Name = "picIllustration";
            picIllustration.Size = new Size(324, 324);
            picIllustration.SizeMode = PictureBoxSizeMode.Zoom;
            picIllustration.TabIndex = 0;
            picIllustration.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAppName.ForeColor = Color.FromArgb(65, 84, 241);
            lblAppName.Location = new Point(35, 37);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(219, 32);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "E-Shift Household";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(249, 249, 249);
            pnlRight.Controls.Add(label7);
            pnlRight.Controls.Add(panel3);
            pnlRight.Controls.Add(label6);
            pnlRight.Controls.Add(panel2);
            pnlRight.Controls.Add(label5);
            pnlRight.Controls.Add(panel1);
            pnlRight.Controls.Add(label3);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(pnlEmail);
            pnlRight.Controls.Add(pnlPassword);
            pnlRight.Controls.Add(btnRegister);
            pnlRight.Controls.Add(lblNoAccount);
            pnlRight.Controls.Add(lnkRegister);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(394, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(376, 525);
            pnlRight.TabIndex = 0;
            pnlRight.Paint += pnlRight_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(40, 347);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 19;
            label7.Text = "Confirm Password *";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(txtConfirmPassword);
            panel3.Location = new Point(43, 368);
            panel3.Name = "panel3";
            panel3.Size = new Size(280, 42);
            panel3.TabIndex = 18;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(9, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(21, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(39, 11);
            txtConfirmPassword.MaxLength = 10;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(228, 18);
            txtConfirmPassword.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(43, 282);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 17;
            label6.Text = "Password *";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtPassword);
            panel2.Location = new Point(46, 300);
            panel2.Name = "panel2";
            panel2.Size = new Size(280, 42);
            panel2.TabIndex = 16;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(9, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(39, 11);
            txtPassword.MaxLength = 10;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(228, 18);
            txtPassword.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(43, 215);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 15;
            label5.Text = "Phone Number *";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtPhoneNumber);
            panel1.Location = new Point(46, 233);
            panel1.Name = "panel1";
            panel1.Size = new Size(280, 42);
            panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 22);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.None;
            txtPhoneNumber.Font = new Font("Segoe UI", 10F);
            txtPhoneNumber.Location = new Point(39, 11);
            txtPhoneNumber.MaxLength = 12;
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(228, 18);
            txtPhoneNumber.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(47, 37);
            label3.Name = "label3";
            label3.Size = new Size(175, 21);
            label3.TabIndex = 13;
            label3.Text = "Sign up to your account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(44, 145);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 12;
            label2.Text = "Email Address *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(44, 74);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 11;
            label1.Text = "Name *";
            // 
            // pnlEmail
            // 
            pnlEmail.BackColor = Color.White;
            pnlEmail.BorderStyle = BorderStyle.FixedSingle;
            pnlEmail.Controls.Add(picEmailIcon);
            pnlEmail.Controls.Add(txtFirstName);
            pnlEmail.Location = new Point(47, 92);
            pnlEmail.Name = "pnlEmail";
            pnlEmail.Size = new Size(280, 42);
            pnlEmail.TabIndex = 4;
            // 
            // picEmailIcon
            // 
            picEmailIcon.ErrorImage = null;
            picEmailIcon.Image = (Image)resources.GetObject("picEmailIcon.Image");
            picEmailIcon.InitialImage = null;
            picEmailIcon.Location = new Point(9, 9);
            picEmailIcon.Name = "picEmailIcon";
            picEmailIcon.Size = new Size(21, 22);
            picEmailIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picEmailIcon.TabIndex = 0;
            picEmailIcon.TabStop = false;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(39, 11);
            txtFirstName.MaxLength = 100;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(228, 18);
            txtFirstName.TabIndex = 1;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.White;
            pnlPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlPassword.Controls.Add(picPasswordIcon);
            pnlPassword.Controls.Add(txtEmail);
            pnlPassword.Location = new Point(47, 163);
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
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(39, 11);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(228, 18);
            txtEmail.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(65, 84, 241);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(47, 426);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(280, 47);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Create Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblNoAccount
            // 
            lblNoAccount.AutoSize = true;
            lblNoAccount.Location = new Point(96, 484);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(142, 15);
            lblNoAccount.TabIndex = 9;
            lblNoAccount.Text = "Already have an account?";
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.LinkColor = Color.FromArgb(65, 84, 241);
            lnkRegister.Location = new Point(244, 484);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(43, 15);
            lnkRegister.TabIndex = 10;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Sign In";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // CustomerRegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 525);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CustomerRegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "e-Shift - Register";
            Load += CustomerRegisterForm_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIllustration).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlEmail.ResumeLayout(false);
            pnlEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEmailIcon).EndInit();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPasswordIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        // End of designer generated code
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picIllustration;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.PictureBox picEmailIcon;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox picPasswordIcon;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label6;
        private Panel panel2;
        private PictureBox pictureBox2;
        private TextBox txtPassword;
        private Label label5;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TextBox txtPhoneNumber;
        private Label label7;
        private Panel panel3;
        private PictureBox pictureBox3;
        private TextBox txtConfirmPassword;
    }
}