namespace eShift_Logistics_System.Forms.Customer
{
    partial class MyJobsForm
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
            this.dgvMyJobs = new System.Windows.Forms.DataGridView();
            this.grpJobTracker = new System.Windows.Forms.GroupBox();
            this.pnlTracker = new System.Windows.Forms.Panel();
            this.lblStatusCompleted = new System.Windows.Forms.Label();
            this.lblStatusOnJob = new System.Windows.Forms.Label();
            this.lblStatusAssigned = new System.Windows.Forms.Label();
            this.lblStatusAccepted = new System.Windows.Forms.Label();
            this.lblStatusPending = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyJobs)).BeginInit();
            this.grpJobTracker.SuspendLayout();
            this.pnlTracker.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(133, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Jobs";
            // 
            // dgvMyJobs
            // 
            this.dgvMyJobs.AllowUserToAddRows = false;
            this.dgvMyJobs.AllowUserToDeleteRows = false;
            this.dgvMyJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMyJobs.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyJobs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMyJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMyJobs.ColumnHeadersHeight = 35;
            this.dgvMyJobs.EnableHeadersVisualStyles = false;
            this.dgvMyJobs.Location = new System.Drawing.Point(30, 80);
            this.dgvMyJobs.MultiSelect = false;
            this.dgvMyJobs.Name = "dgvMyJobs";
            this.dgvMyJobs.ReadOnly = true;
            this.dgvMyJobs.RowHeadersVisible = false;
            this.dgvMyJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyJobs.Size = new System.Drawing.Size(680, 250);
            this.dgvMyJobs.TabIndex = 1;
            // 
            // grpJobTracker
            // 
            this.grpJobTracker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpJobTracker.Controls.Add(this.pnlTracker);
            this.grpJobTracker.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpJobTracker.Location = new System.Drawing.Point(30, 350);
            this.grpJobTracker.Name = "grpJobTracker";
            this.grpJobTracker.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.grpJobTracker.Size = new System.Drawing.Size(680, 120);
            this.grpJobTracker.TabIndex = 2;
            this.grpJobTracker.TabStop = false;
            this.grpJobTracker.Text = "Job Status Tracker";
            // 
            // pnlTracker
            // 
            this.pnlTracker.Controls.Add(this.lblStatusCompleted);
            this.pnlTracker.Controls.Add(this.lblStatusOnJob);
            this.pnlTracker.Controls.Add(this.lblStatusAssigned);
            this.pnlTracker.Controls.Add(this.lblStatusAccepted);
            this.pnlTracker.Controls.Add(this.lblStatusPending);
            this.pnlTracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTracker.Location = new System.Drawing.Point(10, 23);
            this.pnlTracker.Name = "pnlTracker";
            this.pnlTracker.Size = new System.Drawing.Size(660, 87);
            this.pnlTracker.TabIndex = 0;
            this.pnlTracker.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTracker_Paint);
            // 
            // lblStatusCompleted
            // 
            this.lblStatusCompleted.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatusCompleted.AutoSize = true;
            this.lblStatusCompleted.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusCompleted.Location = new System.Drawing.Point(540, 60);
            this.lblStatusCompleted.Name = "lblStatusCompleted";
            this.lblStatusCompleted.Size = new System.Drawing.Size(68, 15);
            this.lblStatusCompleted.TabIndex = 4;
            this.lblStatusCompleted.Text = "Completed";
            // 
            // lblStatusOnJob
            // 
            this.lblStatusOnJob.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatusOnJob.AutoSize = true;
            this.lblStatusOnJob.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusOnJob.Location = new System.Drawing.Point(410, 60);
            this.lblStatusOnJob.Name = "lblStatusOnJob";
            this.lblStatusOnJob.Size = new System.Drawing.Size(44, 15);
            this.lblStatusOnJob.TabIndex = 3;
            this.lblStatusOnJob.Text = "On Job";
            // 
            // lblStatusAssigned
            // 
            this.lblStatusAssigned.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatusAssigned.AutoSize = true;
            this.lblStatusAssigned.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusAssigned.Location = new System.Drawing.Point(280, 60);
            this.lblStatusAssigned.Name = "lblStatusAssigned";
            this.lblStatusAssigned.Size = new System.Drawing.Size(55, 15);
            this.lblStatusAssigned.TabIndex = 2;
            this.lblStatusAssigned.Text = "Assigned";
            // 
            // lblStatusAccepted
            // 
            this.lblStatusAccepted.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatusAccepted.AutoSize = true;
            this.lblStatusAccepted.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusAccepted.Location = new System.Drawing.Point(150, 60);
            this.lblStatusAccepted.Name = "lblStatusAccepted";
            this.lblStatusAccepted.Size = new System.Drawing.Size(58, 15);
            this.lblStatusAccepted.TabIndex = 1;
            this.lblStatusAccepted.Text = "Accepted";
            // 
            // lblStatusPending
            // 
            this.lblStatusPending.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatusPending.AutoSize = true;
            this.lblStatusPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPending.Location = new System.Drawing.Point(20, 60);
            this.lblStatusPending.Name = "lblStatusPending";
            this.lblStatusPending.Size = new System.Drawing.Size(50, 15);
            this.lblStatusPending.TabIndex = 0;
            this.lblStatusPending.Text = "Pending";
            // 
            // MyJobsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(740, 500);
            this.Controls.Add(this.grpJobTracker);
            this.Controls.Add(this.dgvMyJobs);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyJobsForm";
            this.Padding = new System.Windows.Forms.Padding(30, 30, 30, 20);
            this.Text = "MyJobsForm";
            this.Load += new System.EventHandler(this.MyJobsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyJobs)).EndInit();
            this.grpJobTracker.ResumeLayout(false);
            this.pnlTracker.ResumeLayout(false);
            this.pnlTracker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvMyJobs;
        private System.Windows.Forms.GroupBox grpJobTracker;
        private System.Windows.Forms.Panel pnlTracker;
        private System.Windows.Forms.Label lblStatusPending;
        private System.Windows.Forms.Label lblStatusAccepted;
        private System.Windows.Forms.Label lblStatusAssigned;
        private System.Windows.Forms.Label lblStatusOnJob;
        private System.Windows.Forms.Label lblStatusCompleted;
    }
}