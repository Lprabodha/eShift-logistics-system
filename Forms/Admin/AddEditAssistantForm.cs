using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class AddEditAssistantForm : Form
    {
        private readonly int? _assistantId;
        private readonly IAssistantService _assistantService;

        public AddEditAssistantForm(int? assistantId = null)
        {
            InitializeComponent();
            _assistantId = assistantId;

            // In a real app with Dependency Injection, this would be injected.
            // For now, we create the instances directly.
            IAssistantRepository assistantRepository = new AssistantRepository();
            _assistantService = new AssistantService(assistantRepository);
        }

        private void AddEditAssistantForm_Load(object sender, EventArgs e)
        {
            cboStatus.DataSource = Enum.GetValues(typeof(AssistantStatus));

            if (_assistantId.HasValue)
            {
                lblTitle.Text = "Edit Assistant";
                LoadAssistantData();
            }
            else
            {
                lblTitle.Text = "Add New Assistant";
                cboStatus.SelectedItem = AssistantStatus.Available;
            }
        }

        private void LoadAssistantData()
        {
            var assistant = _assistantService.GetAssistantById(_assistantId.Value);

            if (assistant == null)
            {
                MessageBox.Show("The selected assistant could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = assistant.Name;
            txtPhone.Text = assistant.Phone;
            txtAddress.Text = assistant.Address;
            cboStatus.SelectedItem = assistant.Status;
            chkIsActive.Checked = assistant.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Assistant Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var assistant = new Assistant
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Status = (AssistantStatus)cboStatus.SelectedItem,
                IsActive = chkIsActive.Checked
            };

            try
            {
                if (_assistantId.HasValue)
                {
                    assistant.Id = _assistantId.Value;
                    _assistantService.UpdateAssistant(assistant);
                    MessageBox.Show("Assistant details updated successfully!", "Success");
                }
                else
                {
                    _assistantService.AddAssistant(assistant);
                    MessageBox.Show("New assistant added successfully!", "Success");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
