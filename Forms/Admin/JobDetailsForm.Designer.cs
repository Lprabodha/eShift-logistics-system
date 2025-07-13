namespace eShift_Logistics_System.Forms.Admin
{
    partial class JobDetailsForm
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
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpLocations = new System.Windows.Forms.GroupBox();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPickupAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpJobInfo = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRequestedDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpLoads = new System.Windows.Forms.GroupBox();
            this.dgvLoads = new System.Windows.Forms.DataGridView();
            this.pnlAddLoad = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAddLoad = new System.Windows.Forms.Button();
            this.numLoadVolume = new System.Windows.Forms.NumericUpDown();
            this.numLoadWeight = new System.Windows.Forms.NumericUpDown();
            this.txtLoadDescription = new System.Windows.Forms.TextBox();
            this.grpCosting = new System.Windows.Forms.GroupBox();
            this.btnAssignAndSave = new System.Windows.Forms.Button();
            this.cboTransportUnit = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalVolume = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tblMainLayout.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.grpLocations.SuspendLayout();
            this.grpJobInfo.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpLoads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.pnlAddLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadWeight)).BeginInit();
            this.grpCosting.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Job Details";
            // 
            // tblMainLayout
            // 
            this.tblMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMainLayout.ColumnCount = 2;
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblMainLayout.Controls.Add(this.pnlLeft, 0, 0);
            this.tblMainLayout.Controls.Add(this.pnlRight, 1, 0);
            this.tblMainLayout.Location = new System.Drawing.Point(30, 75);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.RowCount = 1;
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainLayout.Size = new System.Drawing.Size(940, 543);
            this.tblMainLayout.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpCustomer);
            this.pnlLeft.Controls.Add(this.grpLocations);
            this.pnlLeft.Controls.Add(this.grpJobInfo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(323, 537);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.txtCustomerEmail);
            this.grpCustomer.Controls.Add(this.label5);
            this.grpCustomer.Controls.Add(this.txtCustomerPhone);
            this.grpCustomer.Controls.Add(this.label4);
            this.grpCustomer.Controls.Add(this.txtCustomerName);
            this.grpCustomer.Controls.Add(this.label1);
            this.grpCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCustomer.Location = new System.Drawing.Point(0, 310);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(10);
            this.grpCustomer.Size = new System.Drawing.Size(323, 130);
            this.grpCustomer.TabIndex = 2;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Customer Details";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCustomerEmail.Location = new System.Drawing.Point(110, 90);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(200, 18);
            this.txtCustomerEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(13, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerPhone.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(110, 60);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(200, 18);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(13, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phone:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCustomerName.Location = new System.Drawing.Point(110, 30);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(200, 18);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // grpLocations
            // 
            this.grpLocations.Controls.Add(this.txtDeliveryAddress);
            this.grpLocations.Controls.Add(this.label7);
            this.grpLocations.Controls.Add(this.txtPickupAddress);
            this.grpLocations.Controls.Add(this.label6);
            this.grpLocations.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLocations.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpLocations.Location = new System.Drawing.Point(0, 140);
            this.grpLocations.Name = "grpLocations";
            this.grpLocations.Padding = new System.Windows.Forms.Padding(10);
            this.grpLocations.Size = new System.Drawing.Size(323, 170);
            this.grpLocations.TabIndex = 1;
            this.grpLocations.TabStop = false;
            this.grpLocations.Text = "Location Details";
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeliveryAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeliveryAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDeliveryAddress.Location = new System.Drawing.Point(13, 115);
            this.txtDeliveryAddress.Multiline = true;
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.ReadOnly = true;
            this.txtDeliveryAddress.Size = new System.Drawing.Size(297, 40);
            this.txtDeliveryAddress.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.Location = new System.Drawing.Point(13, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Delivery Address:";
            // 
            // txtPickupAddress
            // 
            this.txtPickupAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPickupAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtPickupAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPickupAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPickupAddress.Location = new System.Drawing.Point(13, 45);
            this.txtPickupAddress.Multiline = true;
            this.txtPickupAddress.Name = "txtPickupAddress";
            this.txtPickupAddress.ReadOnly = true;
            this.txtPickupAddress.Size = new System.Drawing.Size(297, 40);
            this.txtPickupAddress.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.Location = new System.Drawing.Point(13, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pickup Address:";
            // 
            // grpJobInfo
            // 
            this.grpJobInfo.Controls.Add(this.txtStatus);
            this.grpJobInfo.Controls.Add(this.label10);
            this.grpJobInfo.Controls.Add(this.txtRequestedDate);
            this.grpJobInfo.Controls.Add(this.label9);
            this.grpJobInfo.Controls.Add(this.txtJobNumber);
            this.grpJobInfo.Controls.Add(this.label8);
            this.grpJobInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpJobInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpJobInfo.Location = new System.Drawing.Point(0, 0);
            this.grpJobInfo.Name = "grpJobInfo";
            this.grpJobInfo.Padding = new System.Windows.Forms.Padding(10);
            this.grpJobInfo.Size = new System.Drawing.Size(323, 140);
            this.grpJobInfo.TabIndex = 0;
            this.grpJobInfo.TabStop = false;
            this.grpJobInfo.Text = "Job Information";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtStatus.Location = new System.Drawing.Point(110, 90);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(200, 18);
            this.txtStatus.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label10.Location = new System.Drawing.Point(13, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Status:";
            // 
            // txtRequestedDate
            // 
            this.txtRequestedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestedDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtRequestedDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRequestedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRequestedDate.Location = new System.Drawing.Point(110, 60);
            this.txtRequestedDate.Name = "txtRequestedDate";
            this.txtRequestedDate.ReadOnly = true;
            this.txtRequestedDate.Size = new System.Drawing.Size(200, 18);
            this.txtRequestedDate.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label9.Location = new System.Drawing.Point(13, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Req. Date:";
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtJobNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtJobNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtJobNumber.Location = new System.Drawing.Point(110, 30);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.ReadOnly = true;
            this.txtJobNumber.Size = new System.Drawing.Size(200, 18);
            this.txtJobNumber.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label8.Location = new System.Drawing.Point(13, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Job #:";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpLoads);
            this.pnlRight.Controls.Add(this.grpCosting);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(332, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(605, 537);
            this.pnlRight.TabIndex = 1;
            // 
            // grpLoads
            // 
            this.grpLoads.Controls.Add(this.dgvLoads);
            this.grpLoads.Controls.Add(this.pnlAddLoad);
            this.grpLoads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLoads.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpLoads.Location = new System.Drawing.Point(0, 0);
            this.grpLoads.Name = "grpLoads";
            this.grpLoads.Padding = new System.Windows.Forms.Padding(10);
            this.grpLoads.Size = new System.Drawing.Size(605, 293);
            this.grpLoads.TabIndex = 0;
            this.grpLoads.TabStop = false;
            this.grpLoads.Text = "Manage Loads";
            // 
            // dgvLoads
            // 
            this.dgvLoads.AllowUserToAddRows = false;
            this.dgvLoads.AllowUserToDeleteRows = false;
            this.dgvLoads.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLoads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoads.Location = new System.Drawing.Point(10, 100);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.ReadOnly = true;
            this.dgvLoads.RowHeadersVisible = false;
            this.dgvLoads.Size = new System.Drawing.Size(585, 183);
            this.dgvLoads.TabIndex = 1;
            // 
            // pnlAddLoad
            // 
            this.pnlAddLoad.Controls.Add(this.label16);
            this.pnlAddLoad.Controls.Add(this.label17);
            this.pnlAddLoad.Controls.Add(this.label18);
            this.pnlAddLoad.Controls.Add(this.btnAddLoad);
            this.pnlAddLoad.Controls.Add(this.numLoadVolume);
            this.pnlAddLoad.Controls.Add(this.numLoadWeight);
            this.pnlAddLoad.Controls.Add(this.txtLoadDescription);
            this.pnlAddLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddLoad.Location = new System.Drawing.Point(10, 28);
            this.pnlAddLoad.Name = "pnlAddLoad";
            this.pnlAddLoad.Size = new System.Drawing.Size(585, 72);
            this.pnlAddLoad.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.TabIndex = 5;
            this.label16.Text = "Description";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.Location = new System.Drawing.Point(234, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "Weight (kg)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label18.Location = new System.Drawing.Point(361, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 15);
            this.label18.TabIndex = 7;
            this.label18.Text = "Volume (m³)";
            // 
            // btnAddLoad
            // 
            this.btnAddLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLoad.BackColor = System.Drawing.Color.DarkGray;
            this.btnAddLoad.FlatAppearance.BorderSize = 0;
            this.btnAddLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddLoad.ForeColor = System.Drawing.Color.White;
            this.btnAddLoad.Location = new System.Drawing.Point(480, 35);
            this.btnAddLoad.Name = "btnAddLoad";
            this.btnAddLoad.Size = new System.Drawing.Size(100, 30);
            this.btnAddLoad.TabIndex = 4;
            this.btnAddLoad.Text = "Add Load";
            this.btnAddLoad.UseVisualStyleBackColor = false;
            // 
            // numLoadVolume
            // 
            this.numLoadVolume.DecimalPlaces = 3;
            this.numLoadVolume.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numLoadVolume.Location = new System.Drawing.Point(358, 38);
            this.numLoadVolume.Name = "numLoadVolume";
            this.numLoadVolume.Size = new System.Drawing.Size(116, 25);
            this.numLoadVolume.TabIndex = 3;
            // 
            // numLoadWeight
            // 
            this.numLoadWeight.DecimalPlaces = 2;
            this.numLoadWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numLoadWeight.Location = new System.Drawing.Point(234, 38);
            this.numLoadWeight.Name = "numLoadWeight";
            this.numLoadWeight.Size = new System.Drawing.Size(118, 25);
            this.numLoadWeight.TabIndex = 2;
            // 
            // txtLoadDescription
            // 
            this.txtLoadDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoadDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtLoadDescription.Location = new System.Drawing.Point(10, 38);
            this.txtLoadDescription.Name = "txtLoadDescription";
            this.txtLoadDescription.Size = new System.Drawing.Size(218, 25);
            this.txtLoadDescription.TabIndex = 1;
            // 
            // grpCosting
            // 
            this.grpCosting.Controls.Add(this.btnAssignAndSave);
            this.grpCosting.Controls.Add(this.cboTransportUnit);
            this.grpCosting.Controls.Add(this.label15);
            this.grpCosting.Controls.Add(this.txtEstimatedCost);
            this.grpCosting.Controls.Add(this.label14);
            this.grpCosting.Controls.Add(this.txtTotalVolume);
            this.grpCosting.Controls.Add(this.label13);
            this.grpCosting.Controls.Add(this.txtTotalWeight);
            this.grpCosting.Controls.Add(this.label12);
            this.grpCosting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCosting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCosting.Location = new System.Drawing.Point(0, 299);
            this.grpCosting.Name = "grpCosting";
            this.grpCosting.Padding = new System.Windows.Forms.Padding(10);
            this.grpCosting.Size = new System.Drawing.Size(605, 245);
            this.grpCosting.TabIndex = 1;
            this.grpCosting.TabStop = false;
            this.grpCosting.Text = "Costing and Assignment";
            // 
            // btnAssignAndSave
            // 
            this.btnAssignAndSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignAndSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAssignAndSave.FlatAppearance.BorderSize = 0;
            this.btnAssignAndSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignAndSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAssignAndSave.ForeColor = System.Drawing.Color.White;
            this.btnAssignAndSave.Location = new System.Drawing.Point(13, 185);
            this.btnAssignAndSave.Name = "btnAssignAndSave";
            this.btnAssignAndSave.Size = new System.Drawing.Size(579, 45);
            this.btnAssignAndSave.TabIndex = 8;
            this.btnAssignAndSave.Text = "Assign Unit and Finalize Job";
            this.btnAssignAndSave.UseVisualStyleBackColor = false;
            // 
            // cboTransportUnit
            // 
            this.cboTransportUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTransportUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransportUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboTransportUnit.FormattingEnabled = true;
            this.cboTransportUnit.Location = new System.Drawing.Point(150, 145);
            this.cboTransportUnit.Name = "cboTransportUnit";
            this.cboTransportUnit.Size = new System.Drawing.Size(442, 25);
            this.cboTransportUnit.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label15.Location = new System.Drawing.Point(13, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "Assign Transport Unit:";
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstimatedCost.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstimatedCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtEstimatedCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.txtEstimatedCost.Location = new System.Drawing.Point(150, 100);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.ReadOnly = true;
            this.txtEstimatedCost.Size = new System.Drawing.Size(442, 28);
            this.txtEstimatedCost.TabIndex = 5;
            this.txtEstimatedCost.Text = "LKR 0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label14.Location = new System.Drawing.Point(13, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Estimated Cost:";
            // 
            // txtTotalVolume
            // 
            this.txtTotalVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalVolume.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalVolume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalVolume.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalVolume.Location = new System.Drawing.Point(150, 65);
            this.txtTotalVolume.Name = "txtTotalVolume";
            this.txtTotalVolume.ReadOnly = true;
            this.txtTotalVolume.Size = new System.Drawing.Size(442, 18);
            this.txtTotalVolume.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label13.Location = new System.Drawing.Point(13, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Total Volume (m³):";
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalWeight.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalWeight.Location = new System.Drawing.Point(150, 30);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.ReadOnly = true;
            this.txtTotalWeight.Size = new System.Drawing.Size(442, 18);
            this.txtTotalWeight.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label12.Location = new System.Drawing.Point(13, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Total Weight (kg):";
            // 
            // JobDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.tblMainLayout);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1016, 689);
            this.Name = "JobDetailsForm";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job Details";
            this.Load += new System.EventHandler(this.JobDetailsForm_Load);
            this.tblMainLayout.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpLocations.ResumeLayout(false);
            this.grpLocations.PerformLayout();
            this.grpJobInfo.ResumeLayout(false);
            this.grpJobInfo.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.grpLoads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).EndInit();
            this.pnlAddLoad.ResumeLayout(false);
            this.pnlAddLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoadWeight)).EndInit();
            this.grpCosting.ResumeLayout(false);
            this.grpCosting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tblMainLayout;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpJobInfo;
        private System.Windows.Forms.GroupBox grpLocations;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.GroupBox grpLoads;
        private System.Windows.Forms.GroupBox grpCosting;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRequestedDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPickupAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlAddLoad;
        private System.Windows.Forms.DataGridView dgvLoads;
        private System.Windows.Forms.Button btnAddLoad;
        private System.Windows.Forms.NumericUpDown numLoadVolume;
        private System.Windows.Forms.NumericUpDown numLoadWeight;
        private System.Windows.Forms.TextBox txtLoadDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.TextBox txtTotalVolume;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboTransportUnit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAssignAndSave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}