using eShift_Logistics_System.Properties;

namespace eShift_Logistics_System.Forms.Admin
{
    partial class CustomersForm
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlSearch = new Panel();
            btnClear = new Button();
            btnSearch = new Button();
            cboFilterStatus = new ComboBox();
            txtSearch = new TextBox();
            statusStrip = new StatusStrip();
            lblTotalCustomers = new ToolStripStatusLabel();
            lblActiveCustomers = new ToolStripStatusLabel();
            lblInactiveCustomers = new ToolStripStatusLabel();
            tabControlDetails = new TabControl();
            tabPageJobHistory = new TabPage();
            dgvJobHistory = new DataGridView();
            tabPageNotes = new TabPage();
            txtNotes = new TextBox();
            dgvCustomers = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            statusStrip.SuspendLayout();
            tabControlDetails.SuspendLayout();
            tabPageJobHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobHistory).BeginInit();
            tabPageNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(960, 50);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTitle.Location = new Point(-7, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(342, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer Management";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnClear);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(cboFilterStatus);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(20, 70);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(960, 60);
            pnlSearch.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.Gainsboro;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.Location = new Point(863, 14);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(85, 30);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.DarkGray;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(772, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new Font("Segoe UI", 12F);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Location = new Point(566, 15);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new Size(200, 29);
            cboFilterStatus.TabIndex = 1;
            cboFilterStatus.SelectedIndexChanged += cboFilterStatus_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(10, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(550, 29);
            txtSearch.TabIndex = 0;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.White;
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTotalCustomers, lblActiveCustomers, lblInactiveCustomers });
            statusStrip.Location = new Point(20, 508);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(960, 22);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(104, 17);
            lblTotalCustomers.Text = "Total Customers: 0";
            // 
            // lblActiveCustomers
            // 
            lblActiveCustomers.Name = "lblActiveCustomers";
            lblActiveCustomers.Size = new Size(52, 17);
            lblActiveCustomers.Text = "Active: 0";
            // 
            // lblInactiveCustomers
            // 
            lblInactiveCustomers.Name = "lblInactiveCustomers";
            lblInactiveCustomers.Size = new Size(60, 17);
            lblInactiveCustomers.Text = "Inactive: 0";
            // 
            // tabControlDetails
            // 
            tabControlDetails.Controls.Add(tabPageJobHistory);
            tabControlDetails.Controls.Add(tabPageNotes);
            tabControlDetails.Dock = DockStyle.Bottom;
            tabControlDetails.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControlDetails.Location = new Point(20, 328);
            tabControlDetails.Name = "tabControlDetails";
            tabControlDetails.SelectedIndex = 0;
            tabControlDetails.Size = new Size(960, 180);
            tabControlDetails.TabIndex = 4;
            // 
            // tabPageJobHistory
            // 
            tabPageJobHistory.Controls.Add(dgvJobHistory);
            tabPageJobHistory.Location = new Point(4, 26);
            tabPageJobHistory.Name = "tabPageJobHistory";
            tabPageJobHistory.Padding = new Padding(3);
            tabPageJobHistory.Size = new Size(952, 150);
            tabPageJobHistory.TabIndex = 0;
            tabPageJobHistory.Text = "Job History";
            tabPageJobHistory.UseVisualStyleBackColor = true;
            // 
            // dgvJobHistory
            // 
            dgvJobHistory.AllowUserToAddRows = false;
            dgvJobHistory.AllowUserToDeleteRows = false;
            dgvJobHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJobHistory.BackgroundColor = Color.White;
            dgvJobHistory.BorderStyle = BorderStyle.None;
            dgvJobHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dgvJobHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvJobHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJobHistory.Dock = DockStyle.Fill;
            dgvJobHistory.EnableHeadersVisualStyles = false;
            dgvJobHistory.Location = new Point(3, 3);
            dgvJobHistory.Name = "dgvJobHistory";
            dgvJobHistory.ReadOnly = true;
            dgvJobHistory.RowHeadersVisible = false;
            dgvJobHistory.Size = new Size(946, 144);
            dgvJobHistory.TabIndex = 0;
            // 
            // tabPageNotes
            // 
            tabPageNotes.Controls.Add(txtNotes);
            tabPageNotes.Location = new Point(4, 26);
            tabPageNotes.Name = "tabPageNotes";
            tabPageNotes.Padding = new Padding(3);
            tabPageNotes.Size = new Size(952, 150);
            tabPageNotes.TabIndex = 1;
            tabPageNotes.Text = "Notes";
            tabPageNotes.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.White;
            txtNotes.BorderStyle = BorderStyle.None;
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Location = new Point(3, 3);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(946, 144);
            txtNotes.TabIndex = 0;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 224, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.GridColor = Color.Gainsboro;
            dgvCustomers.Location = new Point(20, 130);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowTemplate.Height = 35;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(960, 198);
            dgvCustomers.TabIndex = 5;
            // 
            // CustomersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 248, 255);
            ClientSize = new Size(1000, 550);
            Controls.Add(dgvCustomers);
            Controls.Add(tabControlDetails);
            Controls.Add(statusStrip);
            Controls.Add(pnlSearch);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomersForm";
            Padding = new Padding(20);
            Text = "CustomersForm";
            Load += CustomersForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tabControlDetails.ResumeLayout(false);
            tabPageJobHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvJobHistory).EndInit();
            tabPageNotes.ResumeLayout(false);
            tabPageNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalCustomers;
        private System.Windows.Forms.ToolStripStatusLabel lblActiveCustomers;
        private System.Windows.Forms.ToolStripStatusLabel lblInactiveCustomers;
        private System.Windows.Forms.TabControl tabControlDetails;
        private System.Windows.Forms.TabPage tabPageJobHistory;
        private System.Windows.Forms.TabPage tabPageNotes;
        private System.Windows.Forms.DataGridView dgvJobHistory;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}