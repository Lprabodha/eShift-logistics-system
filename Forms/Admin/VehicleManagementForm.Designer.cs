namespace eShift_Logistics_System.Forms.Admin
{
    partial class VehicleManagementForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageTrucks = new System.Windows.Forms.TabPage();
            this.dgvTrucks = new System.Windows.Forms.DataGridView();
            this.pnlTruckSearch = new System.Windows.Forms.Panel();
            this.btnTruckSearch = new System.Windows.Forms.Button();
            this.txtTruckSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTruckHeader = new System.Windows.Forms.Panel();
            this.btnAddNewTruck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageDrivers = new System.Windows.Forms.TabPage();
            this.tabPageAssistants = new System.Windows.Forms.TabPage();
            this.tabPageUnits = new System.Windows.Forms.TabPage();
            this.tabMain.SuspendLayout();
            this.tabPageTrucks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrucks)).BeginInit();
            this.pnlTruckSearch.SuspendLayout();
            this.pnlTruckHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(412, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vehicle and Asset Management";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPageTrucks);
            this.tabMain.Controls.Add(this.tabPageDrivers);
            this.tabMain.Controls.Add(this.tabPageAssistants);
            this.tabMain.Controls.Add(this.tabPageUnits);
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabMain.Location = new System.Drawing.Point(30, 75);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(940, 445);
            this.tabMain.TabIndex = 1;
            // 
            // tabPageTrucks
            // 
            this.tabPageTrucks.Controls.Add(this.dgvTrucks);
            this.tabPageTrucks.Controls.Add(this.pnlTruckSearch);
            this.tabPageTrucks.Controls.Add(this.pnlTruckHeader);
            this.tabPageTrucks.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tabPageTrucks.Location = new System.Drawing.Point(4, 29);
            this.tabPageTrucks.Name = "tabPageTrucks";
            this.tabPageTrucks.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageTrucks.Size = new System.Drawing.Size(932, 412);
            this.tabPageTrucks.TabIndex = 0;
            this.tabPageTrucks.Text = "Truck Management";
            this.tabPageTrucks.UseVisualStyleBackColor = true;
            // 
            // dgvTrucks
            // 
            this.dgvTrucks.AllowUserToAddRows = false;
            this.dgvTrucks.AllowUserToDeleteRows = false;
            this.dgvTrucks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrucks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrucks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrucks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrucks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTrucks.ColumnHeadersHeight = 35;
            this.dgvTrucks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrucks.EnableHeadersVisualStyles = false;
            this.dgvTrucks.Location = new System.Drawing.Point(10, 115);
            this.dgvTrucks.Name = "dgvTrucks";
            this.dgvTrucks.ReadOnly = true;
            this.dgvTrucks.RowHeadersVisible = false;
            this.dgvTrucks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrucks.Size = new System.Drawing.Size(912, 287);
            this.dgvTrucks.TabIndex = 2;
            // 
            // pnlTruckSearch
            // 
            this.pnlTruckSearch.Controls.Add(this.btnTruckSearch);
            this.pnlTruckSearch.Controls.Add(this.txtTruckSearch);
            this.pnlTruckSearch.Controls.Add(this.label2);
            this.pnlTruckSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTruckSearch.Location = new System.Drawing.Point(10, 70);
            this.pnlTruckSearch.Name = "pnlTruckSearch";
            this.pnlTruckSearch.Size = new System.Drawing.Size(912, 45);
            this.pnlTruckSearch.TabIndex = 1;
            // 
            // btnTruckSearch
            // 
            this.btnTruckSearch.BackColor = System.Drawing.Color.DarkGray;
            this.btnTruckSearch.FlatAppearance.BorderSize = 0;
            this.btnTruckSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruckSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTruckSearch.ForeColor = System.Drawing.Color.White;
            this.btnTruckSearch.Location = new System.Drawing.Point(365, 8);
            this.btnTruckSearch.Name = "btnTruckSearch";
            this.btnTruckSearch.Size = new System.Drawing.Size(85, 29);
            this.btnTruckSearch.TabIndex = 2;
            this.btnTruckSearch.Text = "Search";
            this.btnTruckSearch.UseVisualStyleBackColor = false;
            // 
            // txtTruckSearch
            // 
            this.txtTruckSearch.Location = new System.Drawing.Point(62, 10);
            this.txtTruckSearch.Name = "txtTruckSearch";
            this.txtTruckSearch.Size = new System.Drawing.Size(297, 25);
            this.txtTruckSearch.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search:";
            // 
            // pnlTruckHeader
            // 
            this.pnlTruckHeader.Controls.Add(this.btnAddNewTruck);
            this.pnlTruckHeader.Controls.Add(this.label1);
            this.pnlTruckHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTruckHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlTruckHeader.Name = "pnlTruckHeader";
            this.pnlTruckHeader.Size = new System.Drawing.Size(912, 60);
            this.pnlTruckHeader.TabIndex = 0;
            // 
            // btnAddNewTruck
            // 
            this.btnAddNewTruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(84)))), ((int)(((byte)(241)))));
            this.btnAddNewTruck.FlatAppearance.BorderSize = 0;
            this.btnAddNewTruck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTruck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNewTruck.ForeColor = System.Drawing.Color.White;
            this.btnAddNewTruck.Location = new System.Drawing.Point(759, 10);
            this.btnAddNewTruck.Name = "btnAddNewTruck";
            this.btnAddNewTruck.Size = new System.Drawing.Size(150, 40);
            this.btnAddNewTruck.TabIndex = 1;
            this.btnAddNewTruck.Text = "+ Add New Truck";
            this.btnAddNewTruck.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Trucks";
            // 
            // tabPageDrivers
            // 
            this.tabPageDrivers.Location = new System.Drawing.Point(4, 29);
            this.tabPageDrivers.Name = "tabPageDrivers";
            this.tabPageDrivers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDrivers.Size = new System.Drawing.Size(932, 412);
            this.tabPageDrivers.TabIndex = 1;
            this.tabPageDrivers.Text = "Driver Management";
            this.tabPageDrivers.UseVisualStyleBackColor = true;
            // 
            // tabPageAssistants
            // 
            this.tabPageAssistants.Location = new System.Drawing.Point(4, 29);
            this.tabPageAssistants.Name = "tabPageAssistants";
            this.tabPageAssistants.Size = new System.Drawing.Size(932, 412);
            this.tabPageAssistants.TabIndex = 2;
            this.tabPageAssistants.Text = "Assistant Management";
            this.tabPageAssistants.UseVisualStyleBackColor = true;
            // 
            // tabPageUnits
            // 
            this.tabPageUnits.Location = new System.Drawing.Point(4, 29);
            this.tabPageUnits.Name = "tabPageUnits";
            this.tabPageUnits.Size = new System.Drawing.Size(932, 412);
            this.tabPageUnits.TabIndex = 3;
            this.tabPageUnits.Text = "Transport Units";
            this.tabPageUnits.UseVisualStyleBackColor = true;
            // 
            // VehicleManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VehicleManagementForm";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "VehicleManagementForm";
            this.Load += new System.EventHandler(this.VehicleManagementForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPageTrucks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrucks)).EndInit();
            this.pnlTruckSearch.ResumeLayout(false);
            this.pnlTruckSearch.PerformLayout();
            this.pnlTruckHeader.ResumeLayout(false);
            this.pnlTruckHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageTrucks;
        private System.Windows.Forms.TabPage tabPageDrivers;
        private System.Windows.Forms.Panel pnlTruckHeader;
        private System.Windows.Forms.Button btnAddNewTruck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTrucks;
        private System.Windows.Forms.TabPage tabPageAssistants;
        private System.Windows.Forms.TabPage tabPageUnits;
        private System.Windows.Forms.Panel pnlTruckSearch;
        private System.Windows.Forms.Button btnTruckSearch;
        private System.Windows.Forms.TextBox txtTruckSearch;
        private System.Windows.Forms.Label label2;
    }
}