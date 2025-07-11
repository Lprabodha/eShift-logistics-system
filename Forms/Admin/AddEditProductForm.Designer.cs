namespace eShift_Logistics_System.Forms.Admin
{
    partial class AddEditProductForm
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
            txtName = new TextBox();
            label2 = new Label();
            numWeight = new NumericUpDown();
            txtDimensions = new TextBox();
            label3 = new Label();
            chkIsFragile = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New Product";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 83);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 1;
            label1.Text = "Product Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 80);
            txtName.MaxLength = 256;
            txtName.Name = "txtName";
            txtName.Size = new Size(230, 23);
            txtName.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 118);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 3;
            label2.Text = "Default Weight (kg)";
            // 
            // numWeight
            // 
            numWeight.DecimalPlaces = 2;
            numWeight.Location = new Point(160, 116);
            numWeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numWeight.Name = "numWeight";
            numWeight.Size = new Size(230, 23);
            numWeight.TabIndex = 1;
            // 
            // txtDimensions
            // 
            txtDimensions.Location = new Point(160, 150);
            txtDimensions.MaxLength = 256;
            txtDimensions.Name = "txtDimensions";
            txtDimensions.Size = new Size(230, 23);
            txtDimensions.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 153);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 5;
            label3.Text = "Default Dimensions";
            // 
            // chkIsFragile
            // 
            chkIsFragile.AutoSize = true;
            chkIsFragile.Location = new Point(160, 188);
            chkIsFragile.Name = "chkIsFragile";
            chkIsFragile.Size = new Size(72, 19);
            chkIsFragile.TabIndex = 3;
            chkIsFragile.Text = "Is Fragile";
            chkIsFragile.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(65, 84, 241);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(270, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 4;
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
            btnCancel.Location = new Point(160, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 40);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddEditProductForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(424, 291);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkIsFragile);
            Controls.Add(txtDimensions);
            Controls.Add(label3);
            Controls.Add(numWeight);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product Details";
            Load += AddEditProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.TextBox txtDimensions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsFragile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}