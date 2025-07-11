namespace eShift_Logistics_System.Forms.Customer
{

    partial class RequestPickupForm
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
            this.grpLocations = new System.Windows.Forms.GroupBox();
            this.dtpRequestedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeliveryAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPickupAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpProducts = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpShipmentList = new System.Windows.Forms.GroupBox();
            this.dgvShipmentItems = new System.Windows.Forms.DataGridView();
            this.btnSubmitRequest = new System.Windows.Forms.Button();
            this.grpNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.grpLocations.SuspendLayout();
            this.grpProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpShipmentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentItems)).BeginInit();
            this.grpNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Pickup Request";
            // 
            // grpLocations
            // 
            this.grpLocations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLocations.Controls.Add(this.dtpRequestedDate);
            this.grpLocations.Controls.Add(this.label3);
            this.grpLocations.Controls.Add(this.txtDeliveryAddress);
            this.grpLocations.Controls.Add(this.label2);
            this.grpLocations.Controls.Add(this.txtPickupAddress);
            this.grpLocations.Controls.Add(this.label1);
            this.grpLocations.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpLocations.Location = new System.Drawing.Point(30, 70);
            this.grpLocations.Name = "grpLocations";
            this.grpLocations.Size = new System.Drawing.Size(680, 155);
            this.grpLocations.TabIndex = 0;
            this.grpLocations.TabStop = false;
            this.grpLocations.Text = "1. Location and Date";
            // 
            // dtpRequestedDate
            // 
            this.dtpRequestedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpRequestedDate.Location = new System.Drawing.Point(140, 115);
            this.dtpRequestedDate.Name = "dtpRequestedDate";
            this.dtpRequestedDate.Size = new System.Drawing.Size(250, 25);
            this.dtpRequestedDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(20, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Requested Date";
            // 
            // txtDeliveryAddress
            // 
            this.txtDeliveryAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDeliveryAddress.Location = new System.Drawing.Point(470, 30);
            this.txtDeliveryAddress.Multiline = true;
            this.txtDeliveryAddress.Name = "txtDeliveryAddress";
            this.txtDeliveryAddress.Size = new System.Drawing.Size(190, 70);
            this.txtDeliveryAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(355, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Delivery Address";
            // 
            // txtPickupAddress
            // 
            this.txtPickupAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPickupAddress.Location = new System.Drawing.Point(140, 30);
            this.txtPickupAddress.Multiline = true;
            this.txtPickupAddress.Name = "txtPickupAddress";
            this.txtPickupAddress.Size = new System.Drawing.Size(200, 70);
            this.txtPickupAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pickup Address";
            // 
            // grpProducts
            // 
            this.grpProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProducts.Controls.Add(this.btnAddItem);
            this.grpProducts.Controls.Add(this.numQuantity);
            this.grpProducts.Controls.Add(this.label5);
            this.grpProducts.Controls.Add(this.cboProduct);
            this.grpProducts.Controls.Add(this.label4);
            this.grpProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpProducts.Location = new System.Drawing.Point(30, 235);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Size = new System.Drawing.Size(680, 75);
            this.grpProducts.TabIndex = 1;
            this.grpProducts.TabStop = false;
            this.grpProducts.Text = "2. Add Products to Shipment";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(84)))), ((int)(((byte)(241)))));
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(550, 30);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(110, 30);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numQuantity.Location = new System.Drawing.Point(370, 33);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 25);
            this.numQuantity.TabIndex = 1;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(305, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Quantity";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(80, 33);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(210, 25);
            this.cboProduct.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(20, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Product";
            // 
            // grpShipmentList
            // 
            this.grpShipmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpShipmentList.Controls.Add(this.dgvShipmentItems);
            this.grpShipmentList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpShipmentList.Location = new System.Drawing.Point(30, 320);
            this.grpShipmentList.Name = "grpShipmentList";
            this.grpShipmentList.Padding = new System.Windows.Forms.Padding(10);
            this.grpShipmentList.Size = new System.Drawing.Size(680, 140);
            this.grpShipmentList.TabIndex = 2;
            this.grpShipmentList.TabStop = false;
            this.grpShipmentList.Text = "3. Shipment Item List";
            // 
            // dgvShipmentItems
            // 
            this.dgvShipmentItems.AllowUserToAddRows = false;
            this.dgvShipmentItems.AllowUserToDeleteRows = false;
            this.dgvShipmentItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvShipmentItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShipmentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipmentItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShipmentItems.Location = new System.Drawing.Point(10, 28);
            this.dgvShipmentItems.Name = "dgvShipmentItems";
            this.dgvShipmentItems.ReadOnly = true;
            this.dgvShipmentItems.RowHeadersVisible = false;
            this.dgvShipmentItems.Size = new System.Drawing.Size(660, 102);
            this.dgvShipmentItems.TabIndex = 0;
            // 
            // btnSubmitRequest
            // 
            this.btnSubmitRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(84)))), ((int)(((byte)(241)))));
            this.btnSubmitRequest.FlatAppearance.BorderSize = 0;
            this.btnSubmitRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmitRequest.ForeColor = System.Drawing.Color.White;
            this.btnSubmitRequest.Location = new System.Drawing.Point(30, 560);
            this.btnSubmitRequest.Name = "btnSubmitRequest";
            this.btnSubmitRequest.Size = new System.Drawing.Size(680, 50);
            this.btnSubmitRequest.TabIndex = 4;
            this.btnSubmitRequest.Text = "Submit Pickup Request";
            this.btnSubmitRequest.UseVisualStyleBackColor = false;
            // 
            // grpNotes
            // 
            this.grpNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNotes.Controls.Add(this.txtNotes);
            this.grpNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpNotes.Location = new System.Drawing.Point(30, 470);
            this.grpNotes.Name = "grpNotes";
            this.grpNotes.Padding = new System.Windows.Forms.Padding(10);
            this.grpNotes.Size = new System.Drawing.Size(680, 80);
            this.grpNotes.TabIndex = 3;
            this.grpNotes.TabStop = false;
            this.grpNotes.Text = "4. Additional Notes / Description";
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNotes.Location = new System.Drawing.Point(10, 28);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(660, 42);
            this.txtNotes.TabIndex = 0;
            // 
            // RequestPickupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(740, 640);
            this.Controls.Add(this.grpNotes);
            this.Controls.Add(this.btnSubmitRequest);
            this.Controls.Add(this.grpShipmentList);
            this.Controls.Add(this.grpProducts);
            this.Controls.Add(this.grpLocations);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RequestPickupForm";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "RequestPickupForm";
            this.Load += new System.EventHandler(this.RequestPickupForm_Load);
            this.grpLocations.ResumeLayout(false);
            this.grpLocations.PerformLayout();
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpShipmentList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentItems)).EndInit();
            this.grpNotes.ResumeLayout(false);
            this.grpNotes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpLocations;
        private System.Windows.Forms.TextBox txtPickupAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRequestedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeliveryAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpProducts;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpShipmentList;
        private System.Windows.Forms.DataGridView dgvShipmentItems;
        private System.Windows.Forms.Button btnSubmitRequest;
        private System.Windows.Forms.GroupBox grpNotes;
        private System.Windows.Forms.TextBox txtNotes;
    }
}