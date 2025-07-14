namespace eShift_Logistics_System.Forms.Customer
{
    partial class MyProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlProfileDetails = new Panel();
            btnSaveChanges = new Button();
            txtAddress = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            pnlChangePassword = new Panel();
            btnChangePassword = new Button();
            txtConfirmPassword = new TextBox();
            label7 = new Label();
            txtNewPassword = new TextBox();
            label6 = new Label();
            txtCurrentPassword = new TextBox();
            label5 = new Label();
            label8 = new Label();
            pnlProfileDetails.SuspendLayout();
            pnlChangePassword.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 0, 0, 10);
            lblTitle.Size = new Size(160, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "My Profile";
            // 
            // pnlProfileDetails
            // 
            pnlProfileDetails.BackColor = Color.White;
            pnlProfileDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlProfileDetails.Controls.Add(btnSaveChanges);
            pnlProfileDetails.Controls.Add(txtAddress);
            pnlProfileDetails.Controls.Add(label4);
            pnlProfileDetails.Controls.Add(txtPhone);
            pnlProfileDetails.Controls.Add(label3);
            pnlProfileDetails.Controls.Add(txtEmail);
            pnlProfileDetails.Controls.Add(label2);
            pnlProfileDetails.Controls.Add(txtName);
            pnlProfileDetails.Controls.Add(label1);
            pnlProfileDetails.Dock = DockStyle.Top;
            pnlProfileDetails.Location = new Point(30, 80);
            pnlProfileDetails.Name = "pnlProfileDetails";
            pnlProfileDetails.Padding = new Padding(15);
            pnlProfileDetails.Size = new Size(680, 260);
            pnlProfileDetails.TabIndex = 1;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = Color.FromArgb(65, 84, 241);
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(135, 200);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(140, 40);
            btnSaveChanges.TabIndex = 4;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.Location = new Point(135, 120);
            txtAddress.MaxLength = 256;
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(520, 65);
            txtAddress.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 123);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 6;
            label4.Text = "Address";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Location = new Point(135, 85);
            txtPhone.MaxLength = 15;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(520, 23);
            txtPhone.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 88);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Phone";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BackColor = Color.Gainsboro;
            txtEmail.Location = new Point(135, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(520, 23);
            txtEmail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 53);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(135, 15);
            txtName.MaxLength = 256;
            txtName.Name = "txtName";
            txtName.Size = new Size(520, 23);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 18);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Full Name";
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.BackColor = Color.White;
            pnlChangePassword.BorderStyle = BorderStyle.FixedSingle;
            pnlChangePassword.Controls.Add(btnChangePassword);
            pnlChangePassword.Controls.Add(txtConfirmPassword);
            pnlChangePassword.Controls.Add(label7);
            pnlChangePassword.Controls.Add(txtNewPassword);
            pnlChangePassword.Controls.Add(label6);
            pnlChangePassword.Controls.Add(txtCurrentPassword);
            pnlChangePassword.Controls.Add(label5);
            pnlChangePassword.Controls.Add(label8);
            pnlChangePassword.Dock = DockStyle.Top;
            pnlChangePassword.Location = new Point(30, 340);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Padding = new Padding(15);
            pnlChangePassword.Size = new Size(680, 190);
            pnlChangePassword.TabIndex = 2;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.DarkGray;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(135, 131);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(150, 40);
            btnChangePassword.TabIndex = 3;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.Location = new Point(135, 95);
            txtConfirmPassword.MaxLength = 12;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(520, 23);
            txtConfirmPassword.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 98);
            label7.Name = "label7";
            label7.Size = new Size(104, 15);
            label7.TabIndex = 4;
            label7.Text = "Confirm Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.Location = new Point(135, 60);
            txtNewPassword.MaxLength = 12;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(520, 23);
            txtNewPassword.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 63);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 2;
            label6.Text = "New Password";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCurrentPassword.Location = new Point(135, 25);
            txtCurrentPassword.MaxLength = 12;
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(520, 23);
            txtCurrentPassword.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 28);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 0;
            label5.Text = "Current Password";
            // 
            // label8
            // 
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 5;
            // 
            // MyProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 255);
            ClientSize = new Size(740, 600);
            Controls.Add(pnlChangePassword);
            Controls.Add(pnlProfileDetails);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MyProfileForm";
            Padding = new Padding(30);
            Text = "MyProfileForm";
            Load += MyProfileForm_Load;
            pnlProfileDetails.ResumeLayout(false);
            pnlProfileDetails.PerformLayout();
            pnlChangePassword.ResumeLayout(false);
            pnlChangePassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlProfileDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Panel pnlChangePassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label5;
    }
}