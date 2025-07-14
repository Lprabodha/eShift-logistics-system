namespace eShift_Logistics_System.Forms.Admin
{
    partial class AdminReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlReportControls = new System.Windows.Forms.Panel();
            this.grpReportFilters = new System.Windows.Forms.GroupBox();
            this.cmbTransportUnit = new System.Windows.Forms.ComboBox();
            this.lblTransportUnit = new System.Windows.Forms.Label();
            this.cmbDriver = new System.Windows.Forms.ComboBox();
            this.lblDriver = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbJobStatus = new System.Windows.Forms.ComboBox();
            this.lblJobStatus = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dgvReportResults = new System.Windows.Forms.DataGridView();
            this.pnlReportControls.SuspendLayout();
            this.grpReportFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportResults)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(117, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reports";
            //
            // pnlReportControls
            //
            this.pnlReportControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReportControls.Controls.Add(this.grpReportFilters);
            this.pnlReportControls.Location = new System.Drawing.Point(30, 75);
            this.pnlReportControls.Name = "pnlReportControls";
            this.pnlReportControls.Size = new System.Drawing.Size(740, 240);
            this.pnlReportControls.TabIndex = 1;
            //
            // grpReportFilters
            //
            this.grpReportFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReportFilters.Controls.Add(this.cmbTransportUnit);
            this.grpReportFilters.Controls.Add(this.lblTransportUnit);
            this.grpReportFilters.Controls.Add(this.cmbDriver);
            this.grpReportFilters.Controls.Add(this.lblDriver);
            this.grpReportFilters.Controls.Add(this.btnGenerateReport);
            this.grpReportFilters.Controls.Add(this.btnExport);
            this.grpReportFilters.Controls.Add(this.cmbUser);
            this.grpReportFilters.Controls.Add(this.lblUser);
            this.grpReportFilters.Controls.Add(this.cmbJobStatus);
            this.grpReportFilters.Controls.Add(this.lblJobStatus);
            this.grpReportFilters.Controls.Add(this.dtpEndDate);
            this.grpReportFilters.Controls.Add(this.lblEndDate);
            this.grpReportFilters.Controls.Add(this.dtpStartDate);
            this.grpReportFilters.Controls.Add(this.lblStartDate);
            this.grpReportFilters.Controls.Add(this.cmbReportType);
            this.grpReportFilters.Controls.Add(this.lblReportType);
            this.grpReportFilters.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportFilters.Location = new System.Drawing.Point(0, 0);
            this.grpReportFilters.Name = "grpReportFilters";
            this.grpReportFilters.Padding = new System.Windows.Forms.Padding(10);
            this.grpReportFilters.Size = new System.Drawing.Size(740, 240);
            this.grpReportFilters.TabIndex = 0;
            this.grpReportFilters.TabStop = false;
            this.grpReportFilters.Text = "Report Options";
            //
            // cmbTransportUnit
            //
            this.cmbTransportUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransportUnit.FormattingEnabled = true;
            this.cmbTransportUnit.Location = new System.Drawing.Point(470, 110);
            this.cmbTransportUnit.Name = "cmbTransportUnit";
            this.cmbTransportUnit.Size = new System.Drawing.Size(250, 23);
            this.cmbTransportUnit.TabIndex = 15;
            this.cmbTransportUnit.Visible = false;
            //
            // lblTransportUnit
            //
            this.lblTransportUnit.AutoSize = true;
            this.lblTransportUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransportUnit.Location = new System.Drawing.Point(380, 113);
            this.lblTransportUnit.Name = "lblTransportUnit";
            this.lblTransportUnit.Size = new System.Drawing.Size(86, 15);
            this.lblTransportUnit.TabIndex = 14;
            this.lblTransportUnit.Text = "Transport Unit:";
            this.lblTransportUnit.Visible = false;
            //
            // cmbDriver
            //
            this.cmbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDriver.FormattingEnabled = true;
            this.cmbDriver.Location = new System.Drawing.Point(130, 150);
            this.cmbDriver.Name = "cmbDriver";
            this.cmbDriver.Size = new System.Drawing.Size(200, 23);
            this.cmbDriver.TabIndex = 13;
            this.cmbDriver.Visible = false;
            //
            // lblDriver
            //
            this.lblDriver.AutoSize = true;
            this.lblDriver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriver.Location = new System.Drawing.Point(20, 153);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(42, 15);
            this.lblDriver.TabIndex = 12;
            this.lblDriver.Text = "Driver:";
            this.lblDriver.Visible = false;
            //
            // btnGenerateReport
            //
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(510, 190);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(100, 35);
            this.btnGenerateReport.TabIndex = 11;
            this.btnGenerateReport.Text = "Generate";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            //
            // btnExport
            //
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(620, 190);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // cmbUser
            //
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(470, 70);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(250, 23);
            this.cmbUser.TabIndex = 9;
            //
            // lblUser
            //
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(380, 73);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 15);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "User:";
            //
            // cmbJobStatus
            //
            this.cmbJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJobStatus.FormattingEnabled = true;
            this.cmbJobStatus.Location = new System.Drawing.Point(130, 110);
            this.cmbJobStatus.Name = "cmbJobStatus";
            this.cmbJobStatus.Size = new System.Drawing.Size(200, 23);
            this.cmbJobStatus.TabIndex = 7;
            //
            // lblJobStatus
            //
            this.lblJobStatus.AutoSize = true;
            this.lblJobStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobStatus.Location = new System.Drawing.Point(20, 113);
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(63, 15);
            this.lblJobStatus.TabIndex = 6;
            this.lblJobStatus.Text = "Job Status:";
            //
            // dtpEndDate
            //
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(470, 30);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 5;
            //
            // lblEndDate
            //
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(380, 33);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(60, 15);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "End Date:";
            //
            // dtpStartDate
            //
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(130, 70);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 3;
            //
            // lblStartDate
            //
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(20, 73);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(64, 15);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date:";
            //
            // cmbReportType
            //
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(130, 30);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(200, 23);
            this.cmbReportType.TabIndex = 1;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            //
            // lblReportType
            //
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(20, 33);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(73, 15);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "Report Type:";
            //
            // dgvReportResults
            //
            this.dgvReportResults.AllowUserToAddRows = false;
            this.dgvReportResults.AllowUserToDeleteRows = false;
            this.dgvReportResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReportResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvReportResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReportResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReportResults.ColumnHeadersHeight = 35;
            this.dgvReportResults.EnableHeadersVisualStyles = false;
            this.dgvReportResults.Location = new System.Drawing.Point(30, 325);
            this.dgvReportResults.MultiSelect = false;
            this.dgvReportResults.Name = "dgvReportResults";
            this.dgvReportResults.ReadOnly = true;
            this.dgvReportResults.RowHeadersVisible = false;
            this.dgvReportResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportResults.Size = new System.Drawing.Size(740, 260);
            this.dgvReportResults.TabIndex = 2;
            //
            // AdminReportForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvReportResults);
            this.Controls.Add(this.pnlReportControls);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminReportForm";
            this.Padding = new System.Windows.Forms.Padding(30, 30, 30, 20);
            this.Text = "AdminReportForm";
            this.Load += new System.EventHandler(this.AdminReportForm_Load);
            this.pnlReportControls.ResumeLayout(false);
            this.grpReportFilters.ResumeLayout(false);
            this.grpReportFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlReportControls;
        private System.Windows.Forms.GroupBox grpReportFilters;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbJobStatus;
        private System.Windows.Forms.Label lblJobStatus;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvReportResults;
        private System.Windows.Forms.ComboBox cmbTransportUnit;
        private System.Windows.Forms.Label lblTransportUnit;
        private System.Windows.Forms.ComboBox cmbDriver;
        private System.Windows.Forms.Label lblDriver;
    }
}