namespace eShift_Logistics_System.Forms.Customer
{
    partial class JobSummaryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblMainLayout = new System.Windows.Forms.TableLayoutPanel(); // Now a single column layout
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
            this.grpProductsRequested = new System.Windows.Forms.GroupBox();
            this.dgvJobProducts = new System.Windows.Forms.DataGridView();
            this.grpAssignedUnit = new System.Windows.Forms.GroupBox();
            this.txtAssignedUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpCosting = new System.Windows.Forms.GroupBox();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalVolume = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button(); // Button to close the form
            this.tblMainLayout.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.grpLocations.SuspendLayout();
            this.grpJobInfo.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpLoads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.grpProductsRequested.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobProducts)).BeginInit();
            this.grpAssignedUnit.SuspendLayout();
            this.grpCosting.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Job Summary";
            //
            // tblMainLayout
            //
            this.tblMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMainLayout.ColumnCount = 1; // Changed to 1 column
            this.tblMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Full width
            this.tblMainLayout.Controls.Add(this.pnlLeft, 0, 0);
            this.tblMainLayout.Controls.Add(this.pnlRight, 0, 1); // Stack pnlRight below pnlLeft
            this.tblMainLayout.Location = new System.Drawing.Point(30, 75);
            this.tblMainLayout.Name = "tblMainLayout";
            this.tblMainLayout.RowCount = 2; // Changed to 2 rows
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F)); // Adjust height percentages as needed
            this.tblMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMainLayout.Size = new System.Drawing.Size(680, 420); // Adjusted size for the new form size (740-2*30 width, 550-75-20 height)
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
            this.pnlLeft.Size = new System.Drawing.Size(674, 204); // Fill its allocated row space
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
            this.grpCustomer.Location = new System.Drawing.Point(0, 310); // This position will need adjustment in code based on fill
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(10);
            this.grpCustomer.Size = new System.Drawing.Size(674, 130); // Adjusted to fill new PnlLeft width
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
            this.txtCustomerEmail.Size = new System.Drawing.Size(554, 18); // Adjusted size
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
            this.txtCustomerPhone.Size = new System.Drawing.Size(554, 18); // Adjusted size
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
            this.txtCustomerName.Size = new System.Drawing.Size(554, 18); // Adjusted size
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
            this.grpLocations.Location = new System.Drawing.Point(0, 140); // This position will need adjustment in code based on fill
            this.grpLocations.Name = "grpLocations";
            this.grpLocations.Padding = new System.Windows.Forms.Padding(10);
            this.grpLocations.Size = new System.Drawing.Size(674, 170); // Adjusted to fill new PnlLeft width
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
            this.txtDeliveryAddress.Size = new System.Drawing.Size(650, 40); // Adjusted size
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
            this.txtPickupAddress.Size = new System.Drawing.Size(650, 40); // Adjusted size
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
            this.grpJobInfo.Size = new System.Drawing.Size(674, 140); // Adjusted to fill new PnlLeft width
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
            this.txtStatus.Size = new System.Drawing.Size(554, 18); // Adjusted size
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
            this.txtRequestedDate.Size = new System.Drawing.Size(554, 18); // Adjusted size
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
            this.txtJobNumber.Size = new System.Drawing.Size(554, 18); // Adjusted size
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
            this.pnlRight.Controls.Add(this.grpProductsRequested);
            this.pnlRight.Controls.Add(this.grpAssignedUnit);
            this.pnlRight.Controls.Add(this.grpCosting);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(3, 213); // Stacked below pnlLeft
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(674, 204); // Fill its allocated row space
            this.pnlRight.TabIndex = 1;
            //
            // grpLoads
            //
            this.grpLoads.Controls.Add(this.dgvLoads);
            this.grpLoads.Dock = System.Windows.Forms.DockStyle.Top; // Adjusted to Top, will fill remaining height
            this.grpLoads.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpLoads.Location = new System.Drawing.Point(0, 130); // Position below grpProductsRequested
            this.grpLoads.Name = "grpLoads";
            this.grpLoads.Padding = new System.Windows.Forms.Padding(10);
            this.grpLoads.Size = new System.Drawing.Size(674, 100); // Adjusted height
            this.grpLoads.TabIndex = 1;
            this.grpLoads.TabStop = false;
            this.grpLoads.Text = "Defined Loads";
            //
            // dgvLoads
            //
            this.dgvLoads.AllowUserToAddRows = false;
            this.dgvLoads.AllowUserToDeleteRows = false;
            this.dgvLoads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Fill columns
            this.dgvLoads.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLoads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1; // Apply professional style
            this.dgvLoads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoads.Location = new System.Drawing.Point(10, 28);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.ReadOnly = true;
            this.dgvLoads.RowHeadersVisible = false;
            this.dgvLoads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoads.Size = new System.Drawing.Size(654, 62); // Adjusted size
            this.dgvLoads.TabIndex = 0;
            //
            // grpProductsRequested
            //
            this.grpProductsRequested.Controls.Add(this.dgvJobProducts);
            this.grpProductsRequested.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProductsRequested.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpProductsRequested.Location = new System.Drawing.Point(0, 0);
            this.grpProductsRequested.Name = "grpProductsRequested";
            this.grpProductsRequested.Padding = new System.Windows.Forms.Padding(10);
            this.grpProductsRequested.Size = new System.Drawing.Size(674, 130); // Adjusted to fill new PnlRight width
            this.grpProductsRequested.TabIndex = 2;
            this.grpProductsRequested.TabStop = false;
            this.grpProductsRequested.Text = "Products Requested by Customer";
            //
            // dgvJobProducts
            //
            this.dgvJobProducts.AllowUserToAddRows = false;
            this.dgvJobProducts.AllowUserToDeleteRows = false;
            this.dgvJobProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJobProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvJobProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJobProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2; // Apply professional style
            this.dgvJobProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJobProducts.Location = new System.Drawing.Point(10, 28);
            this.dgvJobProducts.Name = "dgvJobProducts";
            this.dgvJobProducts.ReadOnly = true;
            this.dgvJobProducts.RowHeadersVisible = false;
            this.dgvJobProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJobProducts.Size = new System.Drawing.Size(654, 92);
            this.dgvJobProducts.TabIndex = 0;
            //
            // grpAssignedUnit
            //
            this.grpAssignedUnit.Controls.Add(this.txtAssignedUnit);
            this.grpAssignedUnit.Controls.Add(this.label2);
            this.grpAssignedUnit.Dock = System.Windows.Forms.DockStyle.Bottom; // Stacked at bottom
            this.grpAssignedUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpAssignedUnit.Location = new System.Drawing.Point(0, 297); // Position will be adjusted by Costing GB
            this.grpAssignedUnit.Name = "grpAssignedUnit";
            this.grpAssignedUnit.Padding = new System.Windows.Forms.Padding(10);
            this.grpAssignedUnit.Size = new System.Drawing.Size(674, 70); // Adjusted to fill new PnlRight width
            this.grpAssignedUnit.TabIndex = 3;
            this.grpAssignedUnit.TabStop = false;
            this.grpAssignedUnit.Text = "Assigned Unit";
            //
            // txtAssignedUnit
            //
            this.txtAssignedUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssignedUnit.BackColor = System.Drawing.SystemColors.Control;
            this.txtAssignedUnit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssignedUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtAssignedUnit.Location = new System.Drawing.Point(150, 30);
            this.txtAssignedUnit.Name = "txtAssignedUnit";
            this.txtAssignedUnit.ReadOnly = true;
            this.txtAssignedUnit.Size = new System.Drawing.Size(514, 18); // Adjusted size
            this.txtAssignedUnit.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Transport Unit:";
            //
            // grpCosting
            //
            this.grpCosting.Controls.Add(this.txtEstimatedCost);
            this.grpCosting.Controls.Add(this.label14);
            this.grpCosting.Controls.Add(this.txtTotalVolume);
            this.grpCosting.Controls.Add(this.label13);
            this.grpCosting.Controls.Add(this.txtTotalWeight);
            this.grpCosting.Controls.Add(this.label12);
            this.grpCosting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCosting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpCosting.Location = new System.Drawing.Point(0, 367); // Stacked at bottom, adjusting position
            this.grpCosting.Name = "grpCosting";
            this.grpCosting.Padding = new System.Windows.Forms.Padding(10);
            this.grpCosting.Size = new System.Drawing.Size(674, 99); // Adjusted to fill new PnlRight width
            this.grpCosting.TabIndex = 1;
            this.grpCosting.TabStop = false;
            this.grpCosting.Text = "Costing Details";
            //
            // txtEstimatedCost
            //
            this.txtEstimatedCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstimatedCost.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstimatedCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtEstimatedCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.txtEstimatedCost.Location = new System.Drawing.Point(150, 60);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.ReadOnly = true;
            this.txtEstimatedCost.Size = new System.Drawing.Size(514, 28); // Adjusted size
            this.txtEstimatedCost.TabIndex = 5;
            this.txtEstimatedCost.Text = "LKR 0.00";
            //
            // label14
            //
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label14.Location = new System.Drawing.Point(13, 68);
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
            this.txtTotalVolume.Location = new System.Drawing.Point(400, 30);
            this.txtTotalVolume.Name = "txtTotalVolume";
            this.txtTotalVolume.ReadOnly = true;
            this.txtTotalVolume.Size = new System.Drawing.Size(264, 18); // Adjusted size
            this.txtTotalVolume.TabIndex = 3;
            //
            // label13
            //
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label13.Location = new System.Drawing.Point(280, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Total Volume (m³):";
            //
            // txtTotalWeight
            //
            this.txtTotalWeight.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTotalWeight.Location = new System.Drawing.Point(150, 30);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.ReadOnly = true;
            this.txtTotalWeight.Size = new System.Drawing.Size(120, 18);
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
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(600, 500); // Adjusted position for new form size
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 35);
            this.btnClose.TabIndex = 2; // Adjusted TabIndex
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // JobSummaryForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(740, 550); // Set new ClientSize
            this.Controls.Add(this.btnClose); // Ensure button is on top
            this.Controls.Add(this.tblMainLayout); // Main layout panel
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Kept as FixedDialog
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobSummaryForm";
            this.Padding = new System.Windows.Forms.Padding(30, 30, 30, 20); // Keep padding
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job Summary";
            this.Load += new System.EventHandler(this.JobSummaryForm_Load);
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
            this.grpProductsRequested.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobProducts)).EndInit();
            this.grpAssignedUnit.ResumeLayout(false);
            this.grpAssignedUnit.PerformLayout();
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
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRequestedDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpLocations;
        private System.Windows.Forms.TextBox txtPickupAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpProductsRequested;
        private System.Windows.Forms.DataGridView dgvJobProducts;
        private System.Windows.Forms.GroupBox grpLoads;
        private System.Windows.Forms.DataGridView dgvLoads;
        private System.Windows.Forms.GroupBox grpAssignedUnit;
        private System.Windows.Forms.TextBox txtAssignedUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpCosting;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalVolume;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
    }
}