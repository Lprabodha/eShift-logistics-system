namespace eShift_Logistics_System.Forms.Customer
{
    partial class CustomerDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboardForm));
            pnlSidebar = new Panel();
            pnlMyProfile = new Panel();
            picMyProfile = new PictureBox();
            lblMyProfile = new Label();
            pnlRequestPickup = new Panel();
            picRequestPickup = new PictureBox();
            lblRequestPickup = new Label();
            pnlMyJobs = new Panel();
            picMyJobs = new PictureBox();
            lblMyJobs = new Label();
            pnlDashboard = new Panel();
            picDashboard = new PictureBox();
            lblDashboard = new Label();
            pnlUser = new Panel();
            btnLogout = new Label();
            lblUserName = new Label();
            picUserAvatar = new PictureBox();
            pnlHeader = new Panel();
            lblAppName = new Label();
            picAppLogo = new PictureBox();
            pnlMainContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlMyProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyProfile).BeginInit();
            pnlRequestPickup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picRequestPickup).BeginInit();
            pnlMyJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyJobs).BeginInit();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).BeginInit();
            pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAppLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(65, 84, 241);
            pnlSidebar.Controls.Add(pnlMyProfile);
            pnlSidebar.Controls.Add(pnlRequestPickup);
            pnlSidebar.Controls.Add(pnlMyJobs);
            pnlSidebar.Controls.Add(pnlDashboard);
            pnlSidebar.Controls.Add(pnlUser);
            pnlSidebar.Controls.Add(pnlHeader);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 600);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMyProfile
            // 
            pnlMyProfile.BackColor = Color.Transparent;
            pnlMyProfile.Controls.Add(picMyProfile);
            pnlMyProfile.Controls.Add(lblMyProfile);
            pnlMyProfile.Cursor = Cursors.Hand;
            pnlMyProfile.Location = new Point(20, 240);
            pnlMyProfile.Name = "pnlMyProfile";
            pnlMyProfile.Size = new Size(220, 45);
            pnlMyProfile.TabIndex = 4;
            // 
            // picMyProfile
            // 
            picMyProfile.Image = (Image)resources.GetObject("picMyProfile.Image");
            picMyProfile.Location = new Point(15, 10);
            picMyProfile.Name = "picMyProfile";
            picMyProfile.Size = new Size(24, 24);
            picMyProfile.SizeMode = PictureBoxSizeMode.Zoom;
            picMyProfile.TabIndex = 1;
            picMyProfile.TabStop = false;
            // 
            // lblMyProfile
            // 
            lblMyProfile.AutoSize = true;
            lblMyProfile.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblMyProfile.ForeColor = Color.FromArgb(240, 240, 240);
            lblMyProfile.Location = new Point(55, 12);
            lblMyProfile.Name = "lblMyProfile";
            lblMyProfile.Size = new Size(81, 20);
            lblMyProfile.TabIndex = 0;
            lblMyProfile.Text = "My Profile";
            // 
            // pnlRequestPickup
            // 
            pnlRequestPickup.BackColor = Color.FromArgb(255, 107, 107);
            pnlRequestPickup.Controls.Add(picRequestPickup);
            pnlRequestPickup.Controls.Add(lblRequestPickup);
            pnlRequestPickup.Cursor = Cursors.Hand;
            pnlRequestPickup.Location = new Point(20, 300);
            pnlRequestPickup.Name = "pnlRequestPickup";
            pnlRequestPickup.Size = new Size(220, 45);
            pnlRequestPickup.TabIndex = 3;
            // 
            // picRequestPickup
            // 
            picRequestPickup.Image = (Image)resources.GetObject("picRequestPickup.Image");
            picRequestPickup.Location = new Point(15, 10);
            picRequestPickup.Name = "picRequestPickup";
            picRequestPickup.Size = new Size(24, 24);
            picRequestPickup.SizeMode = PictureBoxSizeMode.Zoom;
            picRequestPickup.TabIndex = 1;
            picRequestPickup.TabStop = false;
            // 
            // lblRequestPickup
            // 
            lblRequestPickup.AutoSize = true;
            lblRequestPickup.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblRequestPickup.ForeColor = Color.White;
            lblRequestPickup.Location = new Point(55, 12);
            lblRequestPickup.Name = "lblRequestPickup";
            lblRequestPickup.Size = new Size(116, 20);
            lblRequestPickup.TabIndex = 0;
            lblRequestPickup.Text = "Request Pickup";
            // 
            // pnlMyJobs
            // 
            pnlMyJobs.BackColor = Color.Transparent;
            pnlMyJobs.Controls.Add(picMyJobs);
            pnlMyJobs.Controls.Add(lblMyJobs);
            pnlMyJobs.Cursor = Cursors.Hand;
            pnlMyJobs.Location = new Point(20, 180);
            pnlMyJobs.Name = "pnlMyJobs";
            pnlMyJobs.Size = new Size(220, 45);
            pnlMyJobs.TabIndex = 2;
            // 
            // picMyJobs
            // 
            picMyJobs.Image = (Image)resources.GetObject("picMyJobs.Image");
            picMyJobs.Location = new Point(15, 10);
            picMyJobs.Name = "picMyJobs";
            picMyJobs.Size = new Size(24, 24);
            picMyJobs.SizeMode = PictureBoxSizeMode.Zoom;
            picMyJobs.TabIndex = 1;
            picMyJobs.TabStop = false;
            // 
            // lblMyJobs
            // 
            lblMyJobs.AutoSize = true;
            lblMyJobs.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblMyJobs.ForeColor = Color.FromArgb(240, 240, 240);
            lblMyJobs.Location = new Point(55, 12);
            lblMyJobs.Name = "lblMyJobs";
            lblMyJobs.Size = new Size(67, 20);
            lblMyJobs.TabIndex = 0;
            lblMyJobs.Text = "My Jobs";
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.Transparent;
            pnlDashboard.Controls.Add(picDashboard);
            pnlDashboard.Controls.Add(lblDashboard);
            pnlDashboard.Cursor = Cursors.Hand;
            pnlDashboard.Location = new Point(20, 120);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(220, 45);
            pnlDashboard.TabIndex = 1;
            // 
            // picDashboard
            // 
            picDashboard.Image = (Image)resources.GetObject("picDashboard.Image");
            picDashboard.Location = new Point(15, 10);
            picDashboard.Name = "picDashboard";
            picDashboard.Size = new Size(24, 24);
            picDashboard.SizeMode = PictureBoxSizeMode.Zoom;
            picDashboard.TabIndex = 1;
            picDashboard.TabStop = false;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(240, 240, 240);
            lblDashboard.Location = new Point(55, 12);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(85, 20);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            // 
            // pnlUser
            // 
            pnlUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlUser.BackColor = Color.Transparent;
            pnlUser.Controls.Add(btnLogout);
            pnlUser.Controls.Add(lblUserName);
            pnlUser.Controls.Add(picUserAvatar);
            pnlUser.Location = new Point(20, 520);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(220, 60);
            pnlUser.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.AutoSize = true;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Font = new Font("Segoe UI", 8.25F);
            btnLogout.ForeColor = Color.FromArgb(200, 200, 255);
            btnLogout.Location = new Point(60, 32);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(44, 13);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(60, 12);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(107, 17);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Customer Name";
            // 
            // picUserAvatar
            // 
            picUserAvatar.Image = (Image)resources.GetObject("picUserAvatar.Image");
            picUserAvatar.Location = new Point(10, 10);
            picUserAvatar.Name = "picUserAvatar";
            picUserAvatar.Size = new Size(36, 36);
            picUserAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picUserAvatar.TabIndex = 0;
            picUserAvatar.TabStop = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Controls.Add(picAppLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(260, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(70, 25);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(79, 30);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "E-Shift";
            // 
            // picAppLogo
            // 
            picAppLogo.Image = (Image)resources.GetObject("picAppLogo.Image");
            picAppLogo.Location = new Point(25, 20);
            picAppLogo.Name = "picAppLogo";
            picAppLogo.Size = new Size(40, 40);
            picAppLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picAppLogo.TabIndex = 0;
            picAppLogo.TabStop = false;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(247, 248, 255);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(260, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(740, 600);
            pnlMainContent.TabIndex = 1;
            // 
            // CustomerDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "E-Shift Customer Dashboard";
            Load += CustomerDashboardForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlMyProfile.ResumeLayout(false);
            pnlMyProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyProfile).EndInit();
            pnlRequestPickup.ResumeLayout(false);
            pnlRequestPickup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picRequestPickup).EndInit();
            pnlMyJobs.ResumeLayout(false);
            pnlMyJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyJobs).EndInit();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).EndInit();
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAppLogo).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.PictureBox picAppLogo;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label btnLogout;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox picUserAvatar;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Panel pnlMyProfile;
        private System.Windows.Forms.Label lblMyProfile;
        private System.Windows.Forms.Panel pnlRequestPickup;
        private System.Windows.Forms.Label lblRequestPickup;
        private System.Windows.Forms.Panel pnlMyJobs;
        private System.Windows.Forms.Label lblMyJobs;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.PictureBox picDashboard;
        private System.Windows.Forms.PictureBox picMyProfile;
        private System.Windows.Forms.PictureBox picRequestPickup;
        private System.Windows.Forms.PictureBox picMyJobs;
    }
}