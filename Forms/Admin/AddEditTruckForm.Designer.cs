namespace eShift_Logistics_System.Forms.Admin
{
    partial class AddEditTruckForm
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
            lblTitle = new Label();
            label1 = new Label();
            txtTruckNumber = new TextBox();
            txtModel = new TextBox();
            label2 = new Label();
            txtLicensePlate = new TextBox();
            label3 = new Label();
            label4 = new Label();
            numCapacity = new NumericUpDown();
            cboStatus = new ComboBox();
            label5 = new Label();
            chkIsActive = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(164, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Truck";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 83);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Truck Number";
            // 
            // txtTruckNumber
            // 
            txtTruckNumber.Location = new Point(140, 80);
            txtTruckNumber.MaxLength = 100;
            txtTruckNumber.Name = "txtTruckNumber";
            txtTruckNumber.Size = new Size(230, 23);
            txtTruckNumber.TabIndex = 0;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(140, 115);
            txtModel.MaxLength = 100;
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(230, 23);
            txtModel.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 118);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 3;
            label2.Text = "Model";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Location = new Point(140, 150);
            txtLicensePlate.MaxLength = 100;
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.Size = new Size(230, 23);
            txtLicensePlate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 153);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 5;
            label3.Text = "License Plate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 188);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 7;
            label4.Text = "Capacity (kg)";
            // 
            // numCapacity
            // 
            numCapacity.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numCapacity.Location = new Point(140, 186);
            numCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(230, 23);
            numCapacity.TabIndex = 3;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(140, 221);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(230, 23);
            cboStatus.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 224);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Status";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Location = new Point(140, 260);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(70, 19);
            chkIsActive.TabIndex = 5;
            chkIsActive.Text = "Is Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(65, 84, 241);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(250, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gainsboro;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(140, 300);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddEditTruckForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(404, 361);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkIsActive);
            Controls.Add(cboStatus);
            Controls.Add(label5);
            Controls.Add(numCapacity);
            Controls.Add(label4);
            Controls.Add(txtLicensePlate);
            Controls.Add(label3);
            Controls.Add(txtModel);
            Controls.Add(label2);
            Controls.Add(txtTruckNumber);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditTruckForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Truck Details";
            Load += AddEditTruckForm_Load;
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTruckNumber;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}