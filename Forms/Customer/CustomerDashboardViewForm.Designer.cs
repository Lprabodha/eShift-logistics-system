namespace eShift_Logistics_System.Forms.Customer
{
    partial class CustomerDashboardViewForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblWelcome = new Label();
            pnlHeader = new Panel();
            pnlWidgets = new Panel();
            tblWidgetsLayout = new TableLayoutPanel();
            pnlCompletedJobs = new Panel();
            lblCompletedJobsValue = new Label();
            lblCompletedJobsTitle = new Label();
            picCompletedJobs = new PictureBox();
            pnlInTransit = new Panel();
            lblInTransitValue = new Label();
            lblInTransitTitle = new Label();
            picInTransit = new PictureBox();
            pnlTotalJobs = new Panel();
            lblTotalJobsValue = new Label();
            lblTotalJobsTitle = new Label();
            picTotalJobs = new PictureBox();
            pnlRecentJobs = new Panel();
            dgvRecentJobs = new DataGridView();
            lblRecentJobsTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlWidgets.SuspendLayout();
            tblWidgetsLayout.SuspendLayout();
            pnlCompletedJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCompletedJobs).BeginInit();
            pnlInTransit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInTransit).BeginInit();
            pnlTotalJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTotalJobs).BeginInit();
            pnlRecentJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentJobs).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblWelcome.Location = new Point(3, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(302, 40);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Customer!";
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(30, 30);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(680, 50);
            pnlHeader.TabIndex = 1;
            // 
            // pnlWidgets
            // 
            pnlWidgets.BackColor = Color.White;
            pnlWidgets.Controls.Add(tblWidgetsLayout);
            pnlWidgets.Dock = DockStyle.Top;
            pnlWidgets.Location = new Point(30, 80);
            pnlWidgets.Name = "pnlWidgets";
            pnlWidgets.Padding = new Padding(10);
            pnlWidgets.Size = new Size(680, 120);
            pnlWidgets.TabIndex = 2;
            // 
            // tblWidgetsLayout
            // 
            tblWidgetsLayout.ColumnCount = 3;
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblWidgetsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblWidgetsLayout.Controls.Add(pnlCompletedJobs, 2, 0);
            tblWidgetsLayout.Controls.Add(pnlInTransit, 1, 0);
            tblWidgetsLayout.Controls.Add(pnlTotalJobs, 0, 0);
            tblWidgetsLayout.Dock = DockStyle.Fill;
            tblWidgetsLayout.Location = new Point(10, 10);
            tblWidgetsLayout.Name = "tblWidgetsLayout";
            tblWidgetsLayout.RowCount = 1;
            tblWidgetsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblWidgetsLayout.Size = new Size(660, 100);
            tblWidgetsLayout.TabIndex = 0;
            // 
            // pnlCompletedJobs
            // 
            pnlCompletedJobs.Controls.Add(lblCompletedJobsValue);
            pnlCompletedJobs.Controls.Add(lblCompletedJobsTitle);
            pnlCompletedJobs.Controls.Add(picCompletedJobs);
            pnlCompletedJobs.Dock = DockStyle.Fill;
            pnlCompletedJobs.Location = new Point(443, 3);
            pnlCompletedJobs.Name = "pnlCompletedJobs";
            pnlCompletedJobs.Size = new Size(214, 94);
            pnlCompletedJobs.TabIndex = 2;
            // 
            // lblCompletedJobsValue
            // 
            lblCompletedJobsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCompletedJobsValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblCompletedJobsValue.Location = new Point(60, 45);
            lblCompletedJobsValue.Name = "lblCompletedJobsValue";
            lblCompletedJobsValue.Size = new Size(43, 32);
            lblCompletedJobsValue.TabIndex = 2;
            lblCompletedJobsValue.Text = "25";
            // 
            // lblCompletedJobsTitle
            // 
            lblCompletedJobsTitle.ForeColor = Color.Gray;
            lblCompletedJobsTitle.Location = new Point(60, 20);
            lblCompletedJobsTitle.Name = "lblCompletedJobsTitle";
            lblCompletedJobsTitle.Size = new Size(95, 15);
            lblCompletedJobsTitle.TabIndex = 1;
            lblCompletedJobsTitle.Text = "Completed Jobs";
            // 
            // picCompletedJobs
            // 
            picCompletedJobs.Location = new Point(15, 27);
            picCompletedJobs.Name = "picCompletedJobs";
            picCompletedJobs.Size = new Size(40, 40);
            picCompletedJobs.SizeMode = PictureBoxSizeMode.Zoom;
            picCompletedJobs.TabIndex = 0;
            picCompletedJobs.TabStop = false;
            // 
            // pnlInTransit
            // 
            pnlInTransit.Controls.Add(lblInTransitValue);
            pnlInTransit.Controls.Add(lblInTransitTitle);
            pnlInTransit.Controls.Add(picInTransit);
            pnlInTransit.Dock = DockStyle.Fill;
            pnlInTransit.Location = new Point(223, 3);
            pnlInTransit.Name = "pnlInTransit";
            pnlInTransit.Size = new Size(214, 94);
            pnlInTransit.TabIndex = 1;
            // 
            // lblInTransitValue
            // 
            lblInTransitValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblInTransitValue.ForeColor = Color.FromArgb(255, 193, 7);
            lblInTransitValue.Location = new Point(60, 45);
            lblInTransitValue.Name = "lblInTransitValue";
            lblInTransitValue.Size = new Size(29, 32);
            lblInTransitValue.TabIndex = 2;
            lblInTransitValue.Text = "2";
            // 
            // lblInTransitTitle
            // 
            lblInTransitTitle.ForeColor = Color.Gray;
            lblInTransitTitle.Location = new Point(60, 20);
            lblInTransitTitle.Name = "lblInTransitTitle";
            lblInTransitTitle.Size = new Size(81, 15);
            lblInTransitTitle.TabIndex = 1;
            lblInTransitTitle.Text = "Jobs in Transit";
            // 
            // picInTransit
            // 
            picInTransit.Location = new Point(15, 27);
            picInTransit.Name = "picInTransit";
            picInTransit.Size = new Size(40, 40);
            picInTransit.SizeMode = PictureBoxSizeMode.Zoom;
            picInTransit.TabIndex = 0;
            picInTransit.TabStop = false;
            // 
            // pnlTotalJobs
            // 
            pnlTotalJobs.Controls.Add(lblTotalJobsValue);
            pnlTotalJobs.Controls.Add(lblTotalJobsTitle);
            pnlTotalJobs.Controls.Add(picTotalJobs);
            pnlTotalJobs.Dock = DockStyle.Fill;
            pnlTotalJobs.Location = new Point(3, 3);
            pnlTotalJobs.Name = "pnlTotalJobs";
            pnlTotalJobs.Size = new Size(214, 94);
            pnlTotalJobs.TabIndex = 0;
            // 
            // lblTotalJobsValue
            // 
            lblTotalJobsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalJobsValue.ForeColor = Color.FromArgb(65, 84, 241);
            lblTotalJobsValue.Location = new Point(60, 45);
            lblTotalJobsValue.Name = "lblTotalJobsValue";
            lblTotalJobsValue.Size = new Size(43, 32);
            lblTotalJobsValue.TabIndex = 2;
            lblTotalJobsValue.Text = "32";
            // 
            // lblTotalJobsTitle
            // 
            lblTotalJobsTitle.ForeColor = Color.Gray;
            lblTotalJobsTitle.Location = new Point(60, 20);
            lblTotalJobsTitle.Name = "lblTotalJobsTitle";
            lblTotalJobsTitle.Size = new Size(60, 15);
            lblTotalJobsTitle.TabIndex = 1;
            lblTotalJobsTitle.Text = "Total Jobs";
            // 
            // picTotalJobs
            // 
            picTotalJobs.Location = new Point(15, 27);
            picTotalJobs.Name = "picTotalJobs";
            picTotalJobs.Size = new Size(40, 40);
            picTotalJobs.SizeMode = PictureBoxSizeMode.Zoom;
            picTotalJobs.TabIndex = 0;
            picTotalJobs.TabStop = false;
            // 
            // pnlRecentJobs
            // 
            pnlRecentJobs.BackColor = Color.White;
            pnlRecentJobs.Controls.Add(dgvRecentJobs);
            pnlRecentJobs.Controls.Add(lblRecentJobsTitle);
            pnlRecentJobs.Dock = DockStyle.Fill;
            pnlRecentJobs.Location = new Point(30, 200);
            pnlRecentJobs.Margin = new Padding(3, 10, 3, 3);
            pnlRecentJobs.Name = "pnlRecentJobs";
            pnlRecentJobs.Padding = new Padding(15);
            pnlRecentJobs.Size = new Size(680, 370);
            pnlRecentJobs.TabIndex = 3;
            // 
            // dgvRecentJobs
            // 
            dgvRecentJobs.AllowUserToAddRows = false;
            dgvRecentJobs.AllowUserToDeleteRows = false;
            dgvRecentJobs.BackgroundColor = Color.White;
            dgvRecentJobs.BorderStyle = BorderStyle.None;
            dgvRecentJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dgvRecentJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecentJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentJobs.Dock = DockStyle.Fill;
            dgvRecentJobs.EnableHeadersVisualStyles = false;
            dgvRecentJobs.Location = new Point(15, 45);
            dgvRecentJobs.Name = "dgvRecentJobs";
            dgvRecentJobs.ReadOnly = true;
            dgvRecentJobs.RowHeadersVisible = false;
            dgvRecentJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentJobs.Size = new Size(650, 310);
            dgvRecentJobs.TabIndex = 1;
            // 
            // lblRecentJobsTitle
            // 
            lblRecentJobsTitle.AutoSize = true;
            lblRecentJobsTitle.Dock = DockStyle.Top;
            lblRecentJobsTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblRecentJobsTitle.Location = new Point(15, 15);
            lblRecentJobsTitle.Name = "lblRecentJobsTitle";
            lblRecentJobsTitle.Padding = new Padding(0, 0, 0, 5);
            lblRecentJobsTitle.Size = new Size(169, 30);
            lblRecentJobsTitle.TabIndex = 0;
            lblRecentJobsTitle.Text = "Recent Job Status";
            // 
            // CustomerDashboardViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 255);
            ClientSize = new Size(740, 600);
            Controls.Add(pnlRecentJobs);
            Controls.Add(pnlWidgets);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerDashboardViewForm";
            Padding = new Padding(30);
            Text = "CustomerDashboardViewForm";
            Load += CustomerDashboardViewForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlWidgets.ResumeLayout(false);
            tblWidgetsLayout.ResumeLayout(false);
            pnlCompletedJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCompletedJobs).EndInit();
            pnlInTransit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picInTransit).EndInit();
            pnlTotalJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTotalJobs).EndInit();
            pnlRecentJobs.ResumeLayout(false);
            pnlRecentJobs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentJobs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlWidgets;
        private System.Windows.Forms.TableLayoutPanel tblWidgetsLayout;
        private System.Windows.Forms.Panel pnlTotalJobs;
        private System.Windows.Forms.Label lblTotalJobsValue;
        private System.Windows.Forms.Label lblTotalJobsTitle;
        private System.Windows.Forms.PictureBox picTotalJobs;
        private System.Windows.Forms.Panel pnlCompletedJobs;
        private System.Windows.Forms.Label lblCompletedJobsValue;
        private System.Windows.Forms.Label lblCompletedJobsTitle;
        private System.Windows.Forms.PictureBox picCompletedJobs;
        private System.Windows.Forms.Panel pnlInTransit;
        private System.Windows.Forms.Label lblInTransitValue;
        private System.Windows.Forms.Label lblInTransitTitle;
        private System.Windows.Forms.PictureBox picInTransit;
        private System.Windows.Forms.Panel pnlRecentJobs;
        private System.Windows.Forms.Label lblRecentJobsTitle;
        private System.Windows.Forms.DataGridView dgvRecentJobs;
    }
}