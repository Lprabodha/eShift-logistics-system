namespace eShift_Logistics_System.Forms.Admin
{
    partial class DashboardViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardViewForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlActiveCustomers = new Panel();
            lblActiveCustomersValue = new Label();
            lblActiveCustomersTitle = new Label();
            picActiveCustomers = new PictureBox();
            pnlCompletedJobs = new Panel();
            lblCompletedJobsValue = new Label();
            lblCompletedJobsTitle = new Label();
            picCompletedJobs = new PictureBox();
            pnlPendingJobs = new Panel();
            lblPendingJobsValue = new Label();
            lblPendingJobsTitle = new Label();
            picPendingJobs = new PictureBox();
            pnlTotalJobs = new Panel();
            lblTotalJobsValue = new Label();
            lblTotalJobsTitle = new Label();
            picTotalJobs = new PictureBox();
            lblWelcomeTitle = new Label();
            grpRecentJobs = new GroupBox();
            dgvRecentJobs = new DataGridView();
            grpLoadAssignments = new GroupBox();
            dgvLoadAssignments = new DataGridView();
            grpShortcuts = new GroupBox();
            btnAddJob = new Button();
            btnCreateUnit = new Button();
            tblMainLayout = new TableLayoutPanel();
            tblWidgetsLayout = new TableLayoutPanel();
            tblBottomLayout = new TableLayoutPanel();
            pnlRightColumn = new TableLayoutPanel();
            pnlActiveCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picActiveCustomers).BeginInit();
            pnlCompletedJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCompletedJobs).BeginInit();
            pnlPendingJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPendingJobs).BeginInit();
            pnlTotalJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTotalJobs).BeginInit();
            grpRecentJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentJobs).BeginInit();
            grpLoadAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoadAssignments).BeginInit();
            grpShortcuts.SuspendLayout();
            tblMainLayout.SuspendLayout();
            tblWidgetsLayout.SuspendLayout();
            tblBottomLayout.SuspendLayout();
            pnlRightColumn.SuspendLayout();
            SuspendLayout();
            // 
            // pnlActiveCustomers
            // 
            pnlActiveCustomers.BackColor = Color.White;
            pnlActiveCustomers.Controls.Add(lblActiveCustomersValue);
            pnlActiveCustomers.Controls.Add(lblActiveCustomersTitle);
            pnlActiveCustomers.Controls.Add(picActiveCustomers);
            pnlActiveCustomers.Dock = DockStyle.Fill;
            pnlActiveCustomers.Location = new Point(702, 3);
            pnlActiveCustomers.Name = "pnlActiveCustomers";
            pnlActiveCustomers.Size = new Size(229, 128);
            pnlActiveCustomers.TabIndex = 3;
            // 
            // lblActiveCustomersValue
            // 
            lblActiveCustomersValue.AutoSize = true;
            lblActiveCustomersValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblActiveCustomersValue.ForeColor = Color.FromArgb(65, 84, 241);
            lblActiveCustomersValue.Location = new Point(70, 55);
            lblActiveCustomersValue.Name = "lblActiveCustomersValue";
            lblActiveCustomersValue.Size = new Size(42, 32);
            lblActiveCustomersValue.TabIndex = 2;
            lblActiveCustomersValue.Text = "73";
            // 
            // lblActiveCustomersTitle
            // 
            lblActiveCustomersTitle.AutoSize = true;
            lblActiveCustomersTitle.Font = new Font("Segoe UI", 9.75F);
            lblActiveCustomersTitle.ForeColor = Color.Gray;
            lblActiveCustomersTitle.Location = new Point(70, 30);
            lblActiveCustomersTitle.Name = "lblActiveCustomersTitle";
            lblActiveCustomersTitle.Size = new Size(108, 17);
            lblActiveCustomersTitle.TabIndex = 1;
            lblActiveCustomersTitle.Text = "Active Customers";
            // 
            // picActiveCustomers
            // 
            picActiveCustomers.Image = (Image)resources.GetObject("picActiveCustomers.Image");
            picActiveCustomers.Location = new Point(15, 40);
            picActiveCustomers.Name = "picActiveCustomers";
            picActiveCustomers.Size = new Size(40, 40);
            picActiveCustomers.SizeMode = PictureBoxSizeMode.CenterImage;
            picActiveCustomers.TabIndex = 0;
            picActiveCustomers.TabStop = false;
            // 
            // pnlCompletedJobs
            // 
            pnlCompletedJobs.BackColor = Color.White;
            pnlCompletedJobs.Controls.Add(lblCompletedJobsValue);
            pnlCompletedJobs.Controls.Add(lblCompletedJobsTitle);
            pnlCompletedJobs.Controls.Add(picCompletedJobs);
            pnlCompletedJobs.Dock = DockStyle.Fill;
            pnlCompletedJobs.Location = new Point(469, 3);
            pnlCompletedJobs.Name = "pnlCompletedJobs";
            pnlCompletedJobs.Size = new Size(227, 128);
            pnlCompletedJobs.TabIndex = 2;
            // 
            // lblCompletedJobsValue
            // 
            lblCompletedJobsValue.AutoSize = true;
            lblCompletedJobsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCompletedJobsValue.ForeColor = Color.FromArgb(65, 84, 241);
            lblCompletedJobsValue.Location = new Point(70, 55);
            lblCompletedJobsValue.Name = "lblCompletedJobsValue";
            lblCompletedJobsValue.Size = new Size(56, 32);
            lblCompletedJobsValue.TabIndex = 2;
            lblCompletedJobsValue.Text = "124";
            // 
            // lblCompletedJobsTitle
            // 
            lblCompletedJobsTitle.AutoSize = true;
            lblCompletedJobsTitle.Font = new Font("Segoe UI", 9.75F);
            lblCompletedJobsTitle.ForeColor = Color.Gray;
            lblCompletedJobsTitle.Location = new Point(70, 30);
            lblCompletedJobsTitle.Name = "lblCompletedJobsTitle";
            lblCompletedJobsTitle.Size = new Size(103, 17);
            lblCompletedJobsTitle.TabIndex = 1;
            lblCompletedJobsTitle.Text = "Completed Jobs";
            // 
            // picCompletedJobs
            // 
            picCompletedJobs.Image = (Image)resources.GetObject("picCompletedJobs.Image");
            picCompletedJobs.Location = new Point(15, 40);
            picCompletedJobs.Name = "picCompletedJobs";
            picCompletedJobs.Size = new Size(40, 40);
            picCompletedJobs.SizeMode = PictureBoxSizeMode.CenterImage;
            picCompletedJobs.TabIndex = 0;
            picCompletedJobs.TabStop = false;
            // 
            // pnlPendingJobs
            // 
            pnlPendingJobs.BackColor = Color.White;
            pnlPendingJobs.Controls.Add(lblPendingJobsValue);
            pnlPendingJobs.Controls.Add(lblPendingJobsTitle);
            pnlPendingJobs.Controls.Add(picPendingJobs);
            pnlPendingJobs.Dock = DockStyle.Fill;
            pnlPendingJobs.Location = new Point(236, 3);
            pnlPendingJobs.Name = "pnlPendingJobs";
            pnlPendingJobs.Size = new Size(227, 128);
            pnlPendingJobs.TabIndex = 1;
            // 
            // lblPendingJobsValue
            // 
            lblPendingJobsValue.AutoSize = true;
            lblPendingJobsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPendingJobsValue.ForeColor = Color.FromArgb(65, 84, 241);
            lblPendingJobsValue.Location = new Point(70, 55);
            lblPendingJobsValue.Name = "lblPendingJobsValue";
            lblPendingJobsValue.Size = new Size(28, 32);
            lblPendingJobsValue.TabIndex = 2;
            lblPendingJobsValue.Text = "8";
            // 
            // lblPendingJobsTitle
            // 
            lblPendingJobsTitle.AutoSize = true;
            lblPendingJobsTitle.Font = new Font("Segoe UI", 9.75F);
            lblPendingJobsTitle.ForeColor = Color.Gray;
            lblPendingJobsTitle.Location = new Point(70, 30);
            lblPendingJobsTitle.Name = "lblPendingJobsTitle";
            lblPendingJobsTitle.Size = new Size(86, 17);
            lblPendingJobsTitle.TabIndex = 1;
            lblPendingJobsTitle.Text = "Pending Jobs";
            // 
            // picPendingJobs
            // 
            picPendingJobs.Image = (Image)resources.GetObject("picPendingJobs.Image");
            picPendingJobs.Location = new Point(15, 40);
            picPendingJobs.Name = "picPendingJobs";
            picPendingJobs.Size = new Size(40, 40);
            picPendingJobs.SizeMode = PictureBoxSizeMode.CenterImage;
            picPendingJobs.TabIndex = 0;
            picPendingJobs.TabStop = false;
            // 
            // pnlTotalJobs
            // 
            pnlTotalJobs.BackColor = Color.White;
            pnlTotalJobs.Controls.Add(lblTotalJobsValue);
            pnlTotalJobs.Controls.Add(lblTotalJobsTitle);
            pnlTotalJobs.Controls.Add(picTotalJobs);
            pnlTotalJobs.Dock = DockStyle.Fill;
            pnlTotalJobs.Location = new Point(3, 3);
            pnlTotalJobs.Name = "pnlTotalJobs";
            pnlTotalJobs.Size = new Size(227, 128);
            pnlTotalJobs.TabIndex = 0;
            // 
            // lblTotalJobsValue
            // 
            lblTotalJobsValue.AutoSize = true;
            lblTotalJobsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalJobsValue.ForeColor = Color.FromArgb(65, 84, 241);
            lblTotalJobsValue.Location = new Point(70, 55);
            lblTotalJobsValue.Name = "lblTotalJobsValue";
            lblTotalJobsValue.Size = new Size(56, 32);
            lblTotalJobsValue.TabIndex = 2;
            lblTotalJobsValue.Text = "132";
            // 
            // lblTotalJobsTitle
            // 
            lblTotalJobsTitle.AutoSize = true;
            lblTotalJobsTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalJobsTitle.ForeColor = Color.Gray;
            lblTotalJobsTitle.Location = new Point(70, 30);
            lblTotalJobsTitle.Name = "lblTotalJobsTitle";
            lblTotalJobsTitle.Size = new Size(67, 17);
            lblTotalJobsTitle.TabIndex = 1;
            lblTotalJobsTitle.Text = "Total Jobs";
            // 
            // picTotalJobs
            // 
            picTotalJobs.Image = (Image)resources.GetObject("picTotalJobs.Image");
            picTotalJobs.Location = new Point(15, 40);
            picTotalJobs.Name = "picTotalJobs";
            picTotalJobs.Size = new Size(40, 40);
            picTotalJobs.SizeMode = PictureBoxSizeMode.CenterImage;
            picTotalJobs.TabIndex = 0;
            picTotalJobs.TabStop = false;
            // 
            // lblWelcomeTitle
            // 
            lblWelcomeTitle.AutoSize = true;
            lblWelcomeTitle.Dock = DockStyle.Fill;
            lblWelcomeTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcomeTitle.Location = new Point(0, 0);
            lblWelcomeTitle.Margin = new Padding(0, 0, 0, 10);
            lblWelcomeTitle.Name = "lblWelcomeTitle";
            lblWelcomeTitle.Size = new Size(940, 40);
            lblWelcomeTitle.TabIndex = 0;
            lblWelcomeTitle.Text = "Hello, Evano 👋";
            // 
            // grpRecentJobs
            // 
            grpRecentJobs.Controls.Add(dgvRecentJobs);
            grpRecentJobs.Dock = DockStyle.Fill;
            grpRecentJobs.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpRecentJobs.Location = new Point(3, 3);
            grpRecentJobs.Name = "grpRecentJobs";
            grpRecentJobs.Padding = new Padding(10);
            grpRecentJobs.Size = new Size(461, 288);
            grpRecentJobs.TabIndex = 2;
            grpRecentJobs.TabStop = false;
            grpRecentJobs.Text = "Recent Jobs";
            // 
            // dgvRecentJobs
            // 
            dgvRecentJobs.AllowUserToAddRows = false;
            dgvRecentJobs.AllowUserToDeleteRows = false;
            dgvRecentJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentJobs.BackgroundColor = Color.White;
            dgvRecentJobs.BorderStyle = BorderStyle.None;
            dgvRecentJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRecentJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecentJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentJobs.Dock = DockStyle.Fill;
            dgvRecentJobs.EnableHeadersVisualStyles = false;
            dgvRecentJobs.Location = new Point(10, 28);
            dgvRecentJobs.Name = "dgvRecentJobs";
            dgvRecentJobs.ReadOnly = true;
            dgvRecentJobs.RowHeadersVisible = false;
            dgvRecentJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentJobs.Size = new Size(441, 250);
            dgvRecentJobs.TabIndex = 0;
            // 
            // grpLoadAssignments
            // 
            grpLoadAssignments.Controls.Add(dgvLoadAssignments);
            grpLoadAssignments.Dock = DockStyle.Fill;
            grpLoadAssignments.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpLoadAssignments.Location = new Point(3, 3);
            grpLoadAssignments.Name = "grpLoadAssignments";
            grpLoadAssignments.Padding = new Padding(10);
            grpLoadAssignments.Size = new Size(455, 138);
            grpLoadAssignments.TabIndex = 0;
            grpLoadAssignments.TabStop = false;
            grpLoadAssignments.Text = "Latest Load Assignments";
            // 
            // dgvLoadAssignments
            // 
            dgvLoadAssignments.AllowUserToAddRows = false;
            dgvLoadAssignments.AllowUserToDeleteRows = false;
            dgvLoadAssignments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoadAssignments.BackgroundColor = Color.White;
            dgvLoadAssignments.BorderStyle = BorderStyle.None;
            dgvLoadAssignments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLoadAssignments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLoadAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoadAssignments.Dock = DockStyle.Fill;
            dgvLoadAssignments.EnableHeadersVisualStyles = false;
            dgvLoadAssignments.Location = new Point(10, 28);
            dgvLoadAssignments.Name = "dgvLoadAssignments";
            dgvLoadAssignments.ReadOnly = true;
            dgvLoadAssignments.RowHeadersVisible = false;
            dgvLoadAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoadAssignments.Size = new Size(435, 100);
            dgvLoadAssignments.TabIndex = 0;
            // 
            // grpShortcuts
            // 
            grpShortcuts.Controls.Add(btnAddJob);
            grpShortcuts.Controls.Add(btnCreateUnit);
            grpShortcuts.Dock = DockStyle.Fill;
            grpShortcuts.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpShortcuts.Location = new Point(3, 147);
            grpShortcuts.Name = "grpShortcuts";
            grpShortcuts.Size = new Size(455, 138);
            grpShortcuts.TabIndex = 1;
            grpShortcuts.TabStop = false;
            grpShortcuts.Text = "Quick Actions";
            // 
            // btnAddJob
            // 
            btnAddJob.Anchor = AnchorStyles.None;
            btnAddJob.BackColor = Color.FromArgb(65, 84, 241);
            btnAddJob.FlatAppearance.BorderSize = 0;
            btnAddJob.FlatStyle = FlatStyle.Flat;
            btnAddJob.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddJob.ForeColor = Color.White;
            btnAddJob.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddJob.Location = new Point(239, 44);
            btnAddJob.Name = "btnAddJob";
            btnAddJob.Padding = new Padding(10, 0, 0, 0);
            btnAddJob.Size = new Size(190, 50);
            btnAddJob.TabIndex = 1;
            btnAddJob.Text = "     Add New Job";
            btnAddJob.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddJob.UseVisualStyleBackColor = false;
            // 
            // btnCreateUnit
            // 
            btnCreateUnit.Anchor = AnchorStyles.None;
            btnCreateUnit.BackColor = Color.FromArgb(65, 84, 241);
            btnCreateUnit.FlatAppearance.BorderSize = 0;
            btnCreateUnit.FlatStyle = FlatStyle.Flat;
            btnCreateUnit.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateUnit.ForeColor = Color.White;
            btnCreateUnit.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreateUnit.Location = new Point(25, 44);
            btnCreateUnit.Name = "btnCreateUnit";
            btnCreateUnit.Padding = new Padding(10, 0, 0, 0);
            btnCreateUnit.Size = new Size(190, 50);
            btnCreateUnit.TabIndex = 0;
            btnCreateUnit.Text = "     Create Transport Unit";
            btnCreateUnit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreateUnit.UseVisualStyleBackColor = false;
            btnCreateUnit.Click += btnCreateUnit_Click;
            // 
            // tblMainLayout
            // 
            tblMainLayout.ColumnCount = 1;
            tblMainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMainLayout.Controls.Add(lblWelcomeTitle, 0, 0);
            tblMainLayout.Controls.Add(tblWidgetsLayout, 0, 1);
            tblMainLayout.Controls.Add(tblBottomLayout, 0, 2);
            tblMainLayout.Dock = DockStyle.Fill;
            tblMainLayout.Location = new Point(30, 30);
            tblMainLayout.Name = "tblMainLayout";
            tblMainLayout.RowCount = 3;
            tblMainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tblMainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tblMainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMainLayout.Size = new Size(940, 490);
            tblMainLayout.TabIndex = 5;
            // 
            // tblWidgetsLayout
            // 
            tblWidgetsLayout.ColumnCount = 4;
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblWidgetsLayout.Controls.Add(pnlTotalJobs, 0, 0);
            tblWidgetsLayout.Controls.Add(pnlPendingJobs, 1, 0);
            tblWidgetsLayout.Controls.Add(pnlCompletedJobs, 2, 0);
            tblWidgetsLayout.Controls.Add(pnlActiveCustomers, 3, 0);
            tblWidgetsLayout.Dock = DockStyle.Fill;
            tblWidgetsLayout.Location = new Point(3, 53);
            tblWidgetsLayout.Name = "tblWidgetsLayout";
            tblWidgetsLayout.RowCount = 1;
            tblWidgetsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblWidgetsLayout.Size = new Size(934, 134);
            tblWidgetsLayout.TabIndex = 1;
            // 
            // tblBottomLayout
            // 
            tblBottomLayout.ColumnCount = 2;
            tblBottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblBottomLayout.Controls.Add(grpRecentJobs, 0, 0);
            tblBottomLayout.Controls.Add(pnlRightColumn, 1, 0);
            tblBottomLayout.Dock = DockStyle.Fill;
            tblBottomLayout.Location = new Point(3, 193);
            tblBottomLayout.Name = "tblBottomLayout";
            tblBottomLayout.RowCount = 1;
            tblBottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBottomLayout.Size = new Size(934, 294);
            tblBottomLayout.TabIndex = 2;
            // 
            // pnlRightColumn
            // 
            pnlRightColumn.ColumnCount = 1;
            pnlRightColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlRightColumn.Controls.Add(grpLoadAssignments, 0, 0);
            pnlRightColumn.Controls.Add(grpShortcuts, 0, 1);
            pnlRightColumn.Dock = DockStyle.Fill;
            pnlRightColumn.Location = new Point(470, 3);
            pnlRightColumn.Name = "pnlRightColumn";
            pnlRightColumn.RowCount = 2;
            pnlRightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlRightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlRightColumn.Size = new Size(461, 288);
            pnlRightColumn.TabIndex = 3;
            // 
            // DashboardViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 255);
            ClientSize = new Size(1000, 550);
            Controls.Add(tblMainLayout);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DashboardViewForm";
            Padding = new Padding(30);
            Text = "DashboardViewForm";
            Load += DashboardViewForm_Load;
            pnlActiveCustomers.ResumeLayout(false);
            pnlActiveCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picActiveCustomers).EndInit();
            pnlCompletedJobs.ResumeLayout(false);
            pnlCompletedJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCompletedJobs).EndInit();
            pnlPendingJobs.ResumeLayout(false);
            pnlPendingJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPendingJobs).EndInit();
            pnlTotalJobs.ResumeLayout(false);
            pnlTotalJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picTotalJobs).EndInit();
            grpRecentJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentJobs).EndInit();
            grpLoadAssignments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoadAssignments).EndInit();
            grpShortcuts.ResumeLayout(false);
            tblMainLayout.ResumeLayout(false);
            tblMainLayout.PerformLayout();
            tblWidgetsLayout.ResumeLayout(false);
            tblBottomLayout.ResumeLayout(false);
            pnlRightColumn.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Panel pnlActiveCustomers;
        private System.Windows.Forms.Label lblActiveCustomersValue;
        private System.Windows.Forms.Label lblActiveCustomersTitle;
        private System.Windows.Forms.PictureBox picActiveCustomers;
        private System.Windows.Forms.Panel pnlCompletedJobs;
        private System.Windows.Forms.Label lblCompletedJobsValue;
        private System.Windows.Forms.Label lblCompletedJobsTitle;
        private System.Windows.Forms.PictureBox picCompletedJobs;
        private System.Windows.Forms.Panel pnlPendingJobs;
        private System.Windows.Forms.Label lblPendingJobsValue;
        private System.Windows.Forms.Label lblPendingJobsTitle;
        private System.Windows.Forms.PictureBox picPendingJobs;
        private System.Windows.Forms.Panel pnlTotalJobs;
        private System.Windows.Forms.Label lblTotalJobsValue;
        private System.Windows.Forms.Label lblTotalJobsTitle;
        private System.Windows.Forms.PictureBox picTotalJobs;
        private System.Windows.Forms.GroupBox grpRecentJobs;
        private System.Windows.Forms.DataGridView dgvRecentJobs;
        private System.Windows.Forms.GroupBox grpLoadAssignments;
        private System.Windows.Forms.DataGridView dgvLoadAssignments;
        private System.Windows.Forms.GroupBox grpShortcuts;
        private System.Windows.Forms.Button btnAddJob;
        private System.Windows.Forms.Button btnCreateUnit;
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.TableLayoutPanel tblBottomLayout;
        private System.Windows.Forms.TableLayoutPanel pnlRightColumn;
        private System.Windows.Forms.TableLayoutPanel tblWidgetsLayout;
    }
}