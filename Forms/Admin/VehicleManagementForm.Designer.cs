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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            lblTitle = new Label();
            tabMain = new TabControl();
            tabPageTrucks = new TabPage();
            dgvTrucks = new DataGridView();
            pnlTruckSearch = new Panel();
            btnTruckSearch = new Button();
            txtTruckSearch = new TextBox();
            label2 = new Label();
            pnlTruckHeader = new Panel();
            btnAddNewTruck = new Button();
            label1 = new Label();
            tabPageDrivers = new TabPage();
            dgvDrivers = new DataGridView();
            pnlDriverSearch = new Panel();
            btnDriverSearch = new Button();
            txtDriverSearch = new TextBox();
            label6 = new Label();
            pnlDriverHeader = new Panel();
            btnAddNewDriver = new Button();
            label3 = new Label();
            tabPageAssistants = new TabPage();
            dgvAssistants = new DataGridView();
            pnlAssistantSearch = new Panel();
            btnAssistantSearch = new Button();
            txtAssistantSearch = new TextBox();
            label7 = new Label();
            pnlAssistantHeader = new Panel();
            btnAddNewAssistant = new Button();
            label4 = new Label();
            tabPageUnits = new TabPage();
            dgvUnits = new DataGridView();
            pnlUnitSearch = new Panel();
            btnUnitSearch = new Button();
            txtUnitSearch = new TextBox();
            label8 = new Label();
            pnlUnitHeader = new Panel();
            btnAddNewUnit = new Button();
            label5 = new Label();
            tabMain.SuspendLayout();
            tabPageTrucks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrucks).BeginInit();
            pnlTruckSearch.SuspendLayout();
            pnlTruckHeader.SuspendLayout();
            tabPageDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).BeginInit();
            pnlDriverSearch.SuspendLayout();
            pnlDriverHeader.SuspendLayout();
            tabPageAssistants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssistants).BeginInit();
            pnlAssistantSearch.SuspendLayout();
            pnlAssistantHeader.SuspendLayout();
            tabPageUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnits).BeginInit();
            pnlUnitSearch.SuspendLayout();
            pnlUnitHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(446, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Vehicle and Asset Management";
            lblTitle.Click += lblTitle_Click;
            // 
            // tabMain
            // 
            tabMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabMain.Controls.Add(tabPageTrucks);
            tabMain.Controls.Add(tabPageDrivers);
            tabMain.Controls.Add(tabPageAssistants);
            tabMain.Controls.Add(tabPageUnits);
            tabMain.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            tabMain.Location = new Point(30, 75);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(940, 445);
            tabMain.TabIndex = 1;
            // 
            // tabPageTrucks
            // 
            tabPageTrucks.Controls.Add(dgvTrucks);
            tabPageTrucks.Controls.Add(pnlTruckSearch);
            tabPageTrucks.Controls.Add(pnlTruckHeader);
            tabPageTrucks.Font = new Font("Segoe UI", 9.75F);
            tabPageTrucks.Location = new Point(4, 29);
            tabPageTrucks.Name = "tabPageTrucks";
            tabPageTrucks.Padding = new Padding(10);
            tabPageTrucks.Size = new Size(932, 412);
            tabPageTrucks.TabIndex = 0;
            tabPageTrucks.Text = "Truck Management";
            tabPageTrucks.UseVisualStyleBackColor = true;
            // 
            // dgvTrucks
            // 
            dgvTrucks.AllowUserToAddRows = false;
            dgvTrucks.AllowUserToDeleteRows = false;
            dgvTrucks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrucks.BackgroundColor = Color.White;
            dgvTrucks.BorderStyle = BorderStyle.None;
            dgvTrucks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dgvTrucks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTrucks.ColumnHeadersHeight = 35;
            dgvTrucks.Dock = DockStyle.Fill;
            dgvTrucks.EnableHeadersVisualStyles = false;
            dgvTrucks.Location = new Point(10, 115);
            dgvTrucks.Name = "dgvTrucks";
            dgvTrucks.ReadOnly = true;
            dgvTrucks.RowHeadersVisible = false;
            dgvTrucks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrucks.Size = new Size(912, 287);
            dgvTrucks.TabIndex = 2;
            // 
            // pnlTruckSearch
            // 
            pnlTruckSearch.Controls.Add(btnTruckSearch);
            pnlTruckSearch.Controls.Add(txtTruckSearch);
            pnlTruckSearch.Controls.Add(label2);
            pnlTruckSearch.Dock = DockStyle.Top;
            pnlTruckSearch.Location = new Point(10, 70);
            pnlTruckSearch.Name = "pnlTruckSearch";
            pnlTruckSearch.Size = new Size(912, 45);
            pnlTruckSearch.TabIndex = 1;
            // 
            // btnTruckSearch
            // 
            btnTruckSearch.BackColor = Color.DarkGray;
            btnTruckSearch.FlatAppearance.BorderSize = 0;
            btnTruckSearch.FlatStyle = FlatStyle.Flat;
            btnTruckSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTruckSearch.ForeColor = Color.White;
            btnTruckSearch.Location = new Point(365, 8);
            btnTruckSearch.Name = "btnTruckSearch";
            btnTruckSearch.Size = new Size(85, 29);
            btnTruckSearch.TabIndex = 2;
            btnTruckSearch.Text = "Search";
            btnTruckSearch.UseVisualStyleBackColor = false;
            // 
            // txtTruckSearch
            // 
            txtTruckSearch.Location = new Point(62, 10);
            txtTruckSearch.Name = "txtTruckSearch";
            txtTruckSearch.Size = new Size(297, 25);
            txtTruckSearch.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 13);
            label2.Name = "label2";
            label2.Size = new Size(50, 17);
            label2.TabIndex = 0;
            label2.Text = "Search:";
            // 
            // pnlTruckHeader
            // 
            pnlTruckHeader.Controls.Add(btnAddNewTruck);
            pnlTruckHeader.Controls.Add(label1);
            pnlTruckHeader.Dock = DockStyle.Top;
            pnlTruckHeader.Location = new Point(10, 10);
            pnlTruckHeader.Name = "pnlTruckHeader";
            pnlTruckHeader.Size = new Size(912, 60);
            pnlTruckHeader.TabIndex = 0;
            // 
            // btnAddNewTruck
            // 
            btnAddNewTruck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewTruck.BackColor = Color.FromArgb(65, 84, 241);
            btnAddNewTruck.FlatAppearance.BorderSize = 0;
            btnAddNewTruck.FlatStyle = FlatStyle.Flat;
            btnAddNewTruck.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAddNewTruck.ForeColor = Color.White;
            btnAddNewTruck.Location = new Point(759, 10);
            btnAddNewTruck.Name = "btnAddNewTruck";
            btnAddNewTruck.Size = new Size(150, 40);
            btnAddNewTruck.TabIndex = 1;
            btnAddNewTruck.Text = "+ Add New Truck";
            btnAddNewTruck.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label1.Location = new Point(3, 16);
            label1.Name = "label1";
            label1.Size = new Size(147, 25);
            label1.TabIndex = 0;
            label1.Text = "Manage Trucks";
            // 
            // tabPageDrivers
            // 
            tabPageDrivers.Controls.Add(dgvDrivers);
            tabPageDrivers.Controls.Add(pnlDriverSearch);
            tabPageDrivers.Controls.Add(pnlDriverHeader);
            tabPageDrivers.Font = new Font("Segoe UI", 9.75F);
            tabPageDrivers.Location = new Point(4, 29);
            tabPageDrivers.Name = "tabPageDrivers";
            tabPageDrivers.Padding = new Padding(10);
            tabPageDrivers.Size = new Size(932, 412);
            tabPageDrivers.TabIndex = 1;
            tabPageDrivers.Text = "Driver Management";
            tabPageDrivers.UseVisualStyleBackColor = true;
            // 
            // dgvDrivers
            // 
            dgvDrivers.AllowUserToAddRows = false;
            dgvDrivers.AllowUserToDeleteRows = false;
            dgvDrivers.BackgroundColor = Color.White;
            dgvDrivers.BorderStyle = BorderStyle.None;
            dgvDrivers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dgvDrivers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDrivers.ColumnHeadersHeight = 35;
            dgvDrivers.Dock = DockStyle.Fill;
            dgvDrivers.EnableHeadersVisualStyles = false;
            dgvDrivers.Location = new Point(10, 115);
            dgvDrivers.Name = "dgvDrivers";
            dgvDrivers.ReadOnly = true;
            dgvDrivers.RowHeadersVisible = false;
            dgvDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrivers.Size = new Size(912, 287);
            dgvDrivers.TabIndex = 2;
            // 
            // pnlDriverSearch
            // 
            pnlDriverSearch.Controls.Add(btnDriverSearch);
            pnlDriverSearch.Controls.Add(txtDriverSearch);
            pnlDriverSearch.Controls.Add(label6);
            pnlDriverSearch.Dock = DockStyle.Top;
            pnlDriverSearch.Location = new Point(10, 70);
            pnlDriverSearch.Name = "pnlDriverSearch";
            pnlDriverSearch.Size = new Size(912, 45);
            pnlDriverSearch.TabIndex = 3;
            // 
            // btnDriverSearch
            // 
            btnDriverSearch.BackColor = Color.DarkGray;
            btnDriverSearch.FlatAppearance.BorderSize = 0;
            btnDriverSearch.FlatStyle = FlatStyle.Flat;
            btnDriverSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDriverSearch.ForeColor = Color.White;
            btnDriverSearch.Location = new Point(365, 8);
            btnDriverSearch.Name = "btnDriverSearch";
            btnDriverSearch.Size = new Size(85, 29);
            btnDriverSearch.TabIndex = 2;
            btnDriverSearch.Text = "Search";
            btnDriverSearch.UseVisualStyleBackColor = false;
            // 
            // txtDriverSearch
            // 
            txtDriverSearch.Location = new Point(62, 10);
            txtDriverSearch.Name = "txtDriverSearch";
            txtDriverSearch.Size = new Size(297, 25);
            txtDriverSearch.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 13);
            label6.Name = "label6";
            label6.Size = new Size(50, 17);
            label6.TabIndex = 0;
            label6.Text = "Search:";
            // 
            // pnlDriverHeader
            // 
            pnlDriverHeader.Controls.Add(btnAddNewDriver);
            pnlDriverHeader.Controls.Add(label3);
            pnlDriverHeader.Dock = DockStyle.Top;
            pnlDriverHeader.Location = new Point(10, 10);
            pnlDriverHeader.Name = "pnlDriverHeader";
            pnlDriverHeader.Size = new Size(912, 60);
            pnlDriverHeader.TabIndex = 1;
            // 
            // btnAddNewDriver
            // 
            btnAddNewDriver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewDriver.BackColor = Color.FromArgb(65, 84, 241);
            btnAddNewDriver.FlatAppearance.BorderSize = 0;
            btnAddNewDriver.FlatStyle = FlatStyle.Flat;
            btnAddNewDriver.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAddNewDriver.ForeColor = Color.White;
            btnAddNewDriver.Location = new Point(759, 10);
            btnAddNewDriver.Name = "btnAddNewDriver";
            btnAddNewDriver.Size = new Size(150, 40);
            btnAddNewDriver.TabIndex = 1;
            btnAddNewDriver.Text = "+ Add New Driver";
            btnAddNewDriver.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label3.Location = new Point(3, 16);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 0;
            label3.Text = "Manage Drivers";
            // 
            // tabPageAssistants
            // 
            tabPageAssistants.Controls.Add(dgvAssistants);
            tabPageAssistants.Controls.Add(pnlAssistantSearch);
            tabPageAssistants.Controls.Add(pnlAssistantHeader);
            tabPageAssistants.Location = new Point(4, 29);
            tabPageAssistants.Name = "tabPageAssistants";
            tabPageAssistants.Padding = new Padding(10);
            tabPageAssistants.Size = new Size(932, 412);
            tabPageAssistants.TabIndex = 2;
            tabPageAssistants.Text = "Assistant Management";
            tabPageAssistants.UseVisualStyleBackColor = true;
            // 
            // dgvAssistants
            // 
            dgvAssistants.AllowUserToAddRows = false;
            dgvAssistants.AllowUserToDeleteRows = false;
            dgvAssistants.BackgroundColor = Color.White;
            dgvAssistants.BorderStyle = BorderStyle.None;
            dgvAssistants.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dgvAssistants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAssistants.ColumnHeadersHeight = 35;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAssistants.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAssistants.Dock = DockStyle.Fill;
            dgvAssistants.EnableHeadersVisualStyles = false;
            dgvAssistants.Location = new Point(10, 115);
            dgvAssistants.Name = "dgvAssistants";
            dgvAssistants.ReadOnly = true;
            dgvAssistants.RowHeadersVisible = false;
            dgvAssistants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssistants.Size = new Size(912, 287);
            dgvAssistants.TabIndex = 3;
            // 
            // pnlAssistantSearch
            // 
            pnlAssistantSearch.Controls.Add(btnAssistantSearch);
            pnlAssistantSearch.Controls.Add(txtAssistantSearch);
            pnlAssistantSearch.Controls.Add(label7);
            pnlAssistantSearch.Dock = DockStyle.Top;
            pnlAssistantSearch.Location = new Point(10, 70);
            pnlAssistantSearch.Name = "pnlAssistantSearch";
            pnlAssistantSearch.Size = new Size(912, 45);
            pnlAssistantSearch.TabIndex = 4;
            // 
            // btnAssistantSearch
            // 
            btnAssistantSearch.BackColor = Color.DarkGray;
            btnAssistantSearch.FlatAppearance.BorderSize = 0;
            btnAssistantSearch.FlatStyle = FlatStyle.Flat;
            btnAssistantSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAssistantSearch.ForeColor = Color.White;
            btnAssistantSearch.Location = new Point(365, 8);
            btnAssistantSearch.Name = "btnAssistantSearch";
            btnAssistantSearch.Size = new Size(85, 29);
            btnAssistantSearch.TabIndex = 2;
            btnAssistantSearch.Text = "Search";
            btnAssistantSearch.UseVisualStyleBackColor = false;
            // 
            // txtAssistantSearch
            // 
            txtAssistantSearch.Location = new Point(62, 10);
            txtAssistantSearch.Name = "txtAssistantSearch";
            txtAssistantSearch.Size = new Size(297, 27);
            txtAssistantSearch.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.Location = new Point(7, 13);
            label7.Name = "label7";
            label7.Size = new Size(50, 17);
            label7.TabIndex = 0;
            label7.Text = "Search:";
            // 
            // pnlAssistantHeader
            // 
            pnlAssistantHeader.Controls.Add(btnAddNewAssistant);
            pnlAssistantHeader.Controls.Add(label4);
            pnlAssistantHeader.Dock = DockStyle.Top;
            pnlAssistantHeader.Location = new Point(10, 10);
            pnlAssistantHeader.Name = "pnlAssistantHeader";
            pnlAssistantHeader.Size = new Size(912, 60);
            pnlAssistantHeader.TabIndex = 2;
            // 
            // btnAddNewAssistant
            // 
            btnAddNewAssistant.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewAssistant.BackColor = Color.FromArgb(65, 84, 241);
            btnAddNewAssistant.FlatAppearance.BorderSize = 0;
            btnAddNewAssistant.FlatStyle = FlatStyle.Flat;
            btnAddNewAssistant.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAddNewAssistant.ForeColor = Color.White;
            btnAddNewAssistant.Location = new Point(759, 10);
            btnAddNewAssistant.Name = "btnAddNewAssistant";
            btnAddNewAssistant.Size = new Size(150, 40);
            btnAddNewAssistant.TabIndex = 1;
            btnAddNewAssistant.Text = "+ Add New Assistant";
            btnAddNewAssistant.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label4.Location = new Point(3, 16);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 0;
            label4.Text = "Manage Assistants";
            // 
            // tabPageUnits
            // 
            tabPageUnits.Controls.Add(dgvUnits);
            tabPageUnits.Controls.Add(pnlUnitSearch);
            tabPageUnits.Controls.Add(pnlUnitHeader);
            tabPageUnits.Location = new Point(4, 29);
            tabPageUnits.Name = "tabPageUnits";
            tabPageUnits.Padding = new Padding(10);
            tabPageUnits.Size = new Size(932, 412);
            tabPageUnits.TabIndex = 3;
            tabPageUnits.Text = "Transport Units";
            tabPageUnits.UseVisualStyleBackColor = true;
            // 
            // dgvUnits
            // 
            dgvUnits.AllowUserToAddRows = false;
            dgvUnits.AllowUserToDeleteRows = false;
            dgvUnits.BackgroundColor = Color.White;
            dgvUnits.BorderStyle = BorderStyle.None;
            dgvUnits.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(45, 52, 54);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dgvUnits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvUnits.ColumnHeadersHeight = 35;
            dgvUnits.Dock = DockStyle.Fill;
            dgvUnits.EnableHeadersVisualStyles = false;
            dgvUnits.Location = new Point(10, 115);
            dgvUnits.Name = "dgvUnits";
            dgvUnits.ReadOnly = true;
            dgvUnits.RowHeadersVisible = false;
            dgvUnits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnits.Size = new Size(912, 287);
            dgvUnits.TabIndex = 4;
            dgvUnits.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);

            // 
            // pnlUnitSearch
            // 
            pnlUnitSearch.Controls.Add(btnUnitSearch);
            pnlUnitSearch.Controls.Add(txtUnitSearch);
            pnlUnitSearch.Controls.Add(label8);
            pnlUnitSearch.Dock = DockStyle.Top;
            pnlUnitSearch.Location = new Point(10, 70);
            pnlUnitSearch.Name = "pnlUnitSearch";
            pnlUnitSearch.Size = new Size(912, 45);
            pnlUnitSearch.TabIndex = 5;
            // 
            // btnUnitSearch
            // 
            btnUnitSearch.BackColor = Color.DarkGray;
            btnUnitSearch.FlatAppearance.BorderSize = 0;
            btnUnitSearch.FlatStyle = FlatStyle.Flat;
            btnUnitSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUnitSearch.ForeColor = Color.White;
            btnUnitSearch.Location = new Point(365, 8);
            btnUnitSearch.Name = "btnUnitSearch";
            btnUnitSearch.Size = new Size(85, 29);
            btnUnitSearch.TabIndex = 2;
            btnUnitSearch.Text = "Search";
            btnUnitSearch.UseVisualStyleBackColor = false;
            // 
            // txtUnitSearch
            // 
            txtUnitSearch.Location = new Point(62, 10);
            txtUnitSearch.Name = "txtUnitSearch";
            txtUnitSearch.Size = new Size(297, 27);
            txtUnitSearch.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F);
            label8.Location = new Point(7, 13);
            label8.Name = "label8";
            label8.Size = new Size(50, 17);
            label8.TabIndex = 0;
            label8.Text = "Search:";
            // 
            // pnlUnitHeader
            // 
            pnlUnitHeader.Controls.Add(btnAddNewUnit);
            pnlUnitHeader.Controls.Add(label5);
            pnlUnitHeader.Dock = DockStyle.Top;
            pnlUnitHeader.Location = new Point(10, 10);
            pnlUnitHeader.Name = "pnlUnitHeader";
            pnlUnitHeader.Size = new Size(912, 60);
            pnlUnitHeader.TabIndex = 3;
            // 
            // btnAddNewUnit
            // 
            btnAddNewUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewUnit.BackColor = Color.FromArgb(65, 84, 241);
            btnAddNewUnit.FlatAppearance.BorderSize = 0;
            btnAddNewUnit.FlatStyle = FlatStyle.Flat;
            btnAddNewUnit.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAddNewUnit.ForeColor = Color.White;
            btnAddNewUnit.Location = new Point(759, 10);
            btnAddNewUnit.Name = "btnAddNewUnit";
            btnAddNewUnit.Size = new Size(150, 40);
            btnAddNewUnit.TabIndex = 1;
            btnAddNewUnit.Text = "+ Add New Unit";
            btnAddNewUnit.UseVisualStyleBackColor = false;
            btnAddNewUnit.Click += btnAddNewUnit_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label5.Location = new Point(3, 16);
            label5.Name = "label5";
            label5.Size = new Size(228, 25);
            label5.TabIndex = 0;
            label5.Text = "Manage Transport Units";
            // 
            // VehicleManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 255);
            ClientSize = new Size(1000, 550);
            Controls.Add(tabMain);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VehicleManagementForm";
            Padding = new Padding(30);
            Text = "VehicleManagementForm";
            Load += VehicleManagementForm_Load;
            tabMain.ResumeLayout(false);
            tabPageTrucks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrucks).EndInit();
            pnlTruckSearch.ResumeLayout(false);
            pnlTruckSearch.PerformLayout();
            pnlTruckHeader.ResumeLayout(false);
            pnlTruckHeader.PerformLayout();
            tabPageDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDrivers).EndInit();
            pnlDriverSearch.ResumeLayout(false);
            pnlDriverSearch.PerformLayout();
            pnlDriverHeader.ResumeLayout(false);
            pnlDriverHeader.PerformLayout();
            tabPageAssistants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssistants).EndInit();
            pnlAssistantSearch.ResumeLayout(false);
            pnlAssistantSearch.PerformLayout();
            pnlAssistantHeader.ResumeLayout(false);
            pnlAssistantHeader.PerformLayout();
            tabPageUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUnits).EndInit();
            pnlUnitSearch.ResumeLayout(false);
            pnlUnitSearch.PerformLayout();
            pnlUnitHeader.ResumeLayout(false);
            pnlUnitHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvDrivers;
        private System.Windows.Forms.Panel pnlDriverHeader;
        private System.Windows.Forms.Button btnAddNewDriver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAssistants;
        private System.Windows.Forms.Panel pnlAssistantHeader;
        private System.Windows.Forms.Button btnAddNewAssistant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.Panel pnlUnitHeader;
        private System.Windows.Forms.Button btnAddNewUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlDriverSearch;
        private System.Windows.Forms.Button btnDriverSearch;
        private System.Windows.Forms.TextBox txtDriverSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlAssistantSearch;
        private System.Windows.Forms.Button btnAssistantSearch;
        private System.Windows.Forms.TextBox txtAssistantSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlUnitSearch;
        private System.Windows.Forms.Button btnUnitSearch;
        private System.Windows.Forms.TextBox txtUnitSearch;
        private System.Windows.Forms.Label label8;
    }
}