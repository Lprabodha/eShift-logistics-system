namespace eShift_Logistics_System.Forms.Admin
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            pnlSidebar = new Panel();
            pnlReports = new Panel();
            imgHelp = new PictureBox();
            lblHelp = new Label();
            pnlProduct = new Panel();
            imgPromote = new PictureBox();
            lblPromote = new Label();
            pnlVehicle = new Panel();
            imgIncome = new PictureBox();
            lblIncome = new Label();
            pnlJobs = new Panel();
            imgCustomers = new PictureBox();
            lblCustomers = new Label();
            pnlCustomer = new Panel();
            imgProduct = new PictureBox();
            lblProduct = new Label();
            pnlDashboard = new Panel();
            imgDashboard = new PictureBox();
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
            pnlReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgHelp).BeginInit();
            pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgPromote).BeginInit();
            pnlVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgIncome).BeginInit();
            pnlJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgCustomers).BeginInit();
            pnlCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgProduct).BeginInit();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgDashboard).BeginInit();
            pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserAvatar).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAppLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(65, 84, 241);
            pnlSidebar.Controls.Add(pnlReports);
            pnlSidebar.Controls.Add(pnlProduct);
            pnlSidebar.Controls.Add(pnlVehicle);
            pnlSidebar.Controls.Add(pnlJobs);
            pnlSidebar.Controls.Add(pnlCustomer);
            pnlSidebar.Controls.Add(pnlDashboard);
            pnlSidebar.Controls.Add(pnlUser);
            pnlSidebar.Controls.Add(pnlHeader);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 680);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlReports
            // 
            pnlReports.BackColor = Color.Transparent;
            pnlReports.Controls.Add(imgHelp);
            pnlReports.Controls.Add(lblHelp);
            pnlReports.Cursor = Cursors.Hand;
            pnlReports.Location = new Point(20, 420);
            pnlReports.Name = "pnlReports";
            pnlReports.Size = new Size(220, 45);
            pnlReports.TabIndex = 6;
            // 
            // imgHelp
            // 
            imgHelp.Image = (Image)resources.GetObject("imgHelp.Image");
            imgHelp.Location = new Point(15, 10);
            imgHelp.Name = "imgHelp";
            imgHelp.Size = new Size(24, 24);
            imgHelp.SizeMode = PictureBoxSizeMode.Zoom;
            imgHelp.TabIndex = 1;
            imgHelp.TabStop = false;
            // 
            // lblHelp
            // 
            lblHelp.AutoSize = true;
            lblHelp.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblHelp.ForeColor = Color.FromArgb(240, 240, 240);
            lblHelp.Location = new Point(55, 12);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(64, 20);
            lblHelp.TabIndex = 0;
            lblHelp.Text = "Reports";
            // 
            // pnlProduct
            // 
            pnlProduct.BackColor = Color.Transparent;
            pnlProduct.Controls.Add(imgPromote);
            pnlProduct.Controls.Add(lblPromote);
            pnlProduct.Cursor = Cursors.Hand;
            pnlProduct.Location = new Point(20, 360);
            pnlProduct.Name = "pnlProduct";
            pnlProduct.Size = new Size(220, 45);
            pnlProduct.TabIndex = 5;
            // 
            // imgPromote
            // 
            imgPromote.Image = (Image)resources.GetObject("imgPromote.Image");
            imgPromote.Location = new Point(15, 10);
            imgPromote.Name = "imgPromote";
            imgPromote.Size = new Size(24, 24);
            imgPromote.SizeMode = PictureBoxSizeMode.Zoom;
            imgPromote.TabIndex = 1;
            imgPromote.TabStop = false;
            // 
            // lblPromote
            // 
            lblPromote.AutoSize = true;
            lblPromote.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPromote.ForeColor = Color.FromArgb(240, 240, 240);
            lblPromote.Location = new Point(55, 12);
            lblPromote.Name = "lblPromote";
            lblPromote.Size = new Size(141, 17);
            lblPromote.TabIndex = 0;
            lblPromote.Text = "Product Management";
            // 
            // pnlVehicle
            // 
            pnlVehicle.BackColor = Color.Transparent;
            pnlVehicle.Controls.Add(imgIncome);
            pnlVehicle.Controls.Add(lblIncome);
            pnlVehicle.Cursor = Cursors.Hand;
            pnlVehicle.Location = new Point(20, 300);
            pnlVehicle.Name = "pnlVehicle";
            pnlVehicle.Size = new Size(220, 45);
            pnlVehicle.TabIndex = 4;
            // 
            // imgIncome
            // 
            imgIncome.Image = (Image)resources.GetObject("imgIncome.Image");
            imgIncome.Location = new Point(15, 10);
            imgIncome.Name = "imgIncome";
            imgIncome.Size = new Size(24, 24);
            imgIncome.SizeMode = PictureBoxSizeMode.Zoom;
            imgIncome.TabIndex = 1;
            imgIncome.TabStop = false;
            // 
            // lblIncome
            // 
            lblIncome.AutoSize = true;
            lblIncome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIncome.ForeColor = Color.FromArgb(240, 240, 240);
            lblIncome.Location = new Point(55, 12);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(137, 17);
            lblIncome.TabIndex = 0;
            lblIncome.Text = "Vehicle Management";
            // 
            // pnlJobs
            // 
            pnlJobs.BackColor = Color.Transparent;
            pnlJobs.Controls.Add(imgCustomers);
            pnlJobs.Controls.Add(lblCustomers);
            pnlJobs.Cursor = Cursors.Hand;
            pnlJobs.Location = new Point(20, 240);
            pnlJobs.Name = "pnlJobs";
            pnlJobs.Size = new Size(220, 45);
            pnlJobs.TabIndex = 3;
            // 
            // imgCustomers
            // 
            imgCustomers.Image = (Image)resources.GetObject("imgCustomers.Image");
            imgCustomers.Location = new Point(15, 10);
            imgCustomers.Name = "imgCustomers";
            imgCustomers.Size = new Size(24, 24);
            imgCustomers.SizeMode = PictureBoxSizeMode.Zoom;
            imgCustomers.TabIndex = 1;
            imgCustomers.TabStop = false;
            // 
            // lblCustomers
            // 
            lblCustomers.AutoSize = true;
            lblCustomers.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomers.ForeColor = Color.FromArgb(240, 240, 240);
            lblCustomers.Location = new Point(55, 12);
            lblCustomers.Name = "lblCustomers";
            lblCustomers.Size = new Size(115, 17);
            lblCustomers.TabIndex = 0;
            lblCustomers.Text = "Job Management";
            // 
            // pnlCustomer
            // 
            pnlCustomer.BackColor = Color.Transparent;
            pnlCustomer.Controls.Add(imgProduct);
            pnlCustomer.Controls.Add(lblProduct);
            pnlCustomer.Cursor = Cursors.Hand;
            pnlCustomer.Location = new Point(20, 180);
            pnlCustomer.Name = "pnlCustomer";
            pnlCustomer.Size = new Size(220, 45);
            pnlCustomer.TabIndex = 2;
            // 
            // imgProduct
            // 
            imgProduct.Image = (Image)resources.GetObject("imgProduct.Image");
            imgProduct.Location = new Point(15, 10);
            imgProduct.Name = "imgProduct";
            imgProduct.Size = new Size(24, 24);
            imgProduct.SizeMode = PictureBoxSizeMode.Zoom;
            imgProduct.TabIndex = 1;
            imgProduct.TabStop = false;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProduct.ForeColor = Color.FromArgb(240, 240, 240);
            lblProduct.Location = new Point(55, 12);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(152, 17);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Customer Management";
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.Transparent;
            pnlDashboard.Controls.Add(imgDashboard);
            pnlDashboard.Controls.Add(lblDashboard);
            pnlDashboard.Cursor = Cursors.Hand;
            pnlDashboard.Location = new Point(20, 120);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(220, 45);
            pnlDashboard.TabIndex = 1;
            // 
            // imgDashboard
            // 
            imgDashboard.Image = (Image)resources.GetObject("imgDashboard.Image");
            imgDashboard.Location = new Point(15, 10);
            imgDashboard.Name = "imgDashboard";
            imgDashboard.Size = new Size(24, 24);
            imgDashboard.SizeMode = PictureBoxSizeMode.Zoom;
            imgDashboard.TabIndex = 1;
            imgDashboard.TabStop = false;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboard.ForeColor = Color.FromArgb(240, 240, 240);
            lblDashboard.Location = new Point(55, 12);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(75, 17);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            lblDashboard.Click += lblDashboard_Click;
            // 
            // pnlUser
            // 
            pnlUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlUser.BackColor = Color.Transparent;
            pnlUser.Controls.Add(btnLogout);
            pnlUser.Controls.Add(lblUserName);
            pnlUser.Controls.Add(picUserAvatar);
            pnlUser.Location = new Point(20, 600);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(220, 60);
            pnlUser.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.AutoSize = true;
            btnLogout.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            lblUserName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(60, 12);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 17);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Evano";
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
            lblAppName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            pnlMainContent.Size = new Size(924, 680);
            pnlMainContent.TabIndex = 1;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 680);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(1200, 719);
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "E-Shift - Admin Dashboard";
            Load += AdminDashboardForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlReports.ResumeLayout(false);
            pnlReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgHelp).EndInit();
            pnlProduct.ResumeLayout(false);
            pnlProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgPromote).EndInit();
            pnlVehicle.ResumeLayout(false);
            pnlVehicle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgIncome).EndInit();
            pnlJobs.ResumeLayout(false);
            pnlJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgCustomers).EndInit();
            pnlCustomer.ResumeLayout(false);
            pnlCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgProduct).EndInit();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgDashboard).EndInit();
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
        private System.Windows.Forms.PictureBox picUserAvatar;
        private System.Windows.Forms.Label btnLogout;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.PictureBox imgDashboard;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.PictureBox imgHelp;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.PictureBox imgPromote;
        private System.Windows.Forms.Label lblPromote;
        private System.Windows.Forms.Panel pnlVehicle;
        private System.Windows.Forms.PictureBox imgIncome;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Panel pnlJobs;
        private System.Windows.Forms.PictureBox imgCustomers;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.PictureBox imgProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}