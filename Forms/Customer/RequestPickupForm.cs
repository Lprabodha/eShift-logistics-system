using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
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

namespace eShift_Logistics_System.Forms.Customer
{
    public partial class RequestPickupForm : Form
    {
        private readonly int _customerId;
        private List<JobProduct> _shipmentItems = new List<JobProduct>();

        private readonly IProductService _productService;
        private readonly IJobService _jobService;

        public RequestPickupForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

            _productService = new ProductService(new ProductRepository());
            _jobService = new JobService(new JobRepository());
        }

        private void RequestPickupForm_Load(object sender, EventArgs e)
        {
            SetupShipmentGrid();
            LoadProductsComboBox();
            dtpRequestedDate.MinDate = DateTime.Today;

            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            this.dgvShipmentItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShipmentItems_CellClick);
            this.btnSubmitRequest.Click += new System.EventHandler(this.btnSubmitRequest_Click);
        }

        private void LoadProductsComboBox()
        {
            try
            {
                var allProducts = _productService.GetAllProducts();
                cboProduct.DataSource = allProducts;
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error");
            }
        }

        private void SetupShipmentGrid()
        {
            dgvShipmentItems.Columns.Clear();
            dgvShipmentItems.AutoGenerateColumns = false;
            dgvShipmentItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductId", DataPropertyName = "ProductId", Visible = false });
            dgvShipmentItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Product", DataPropertyName = "ProductName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvShipmentItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Quantity", DataPropertyName = "Quantity", Width = 80 });
            var btnRemove = new DataGridViewButtonColumn { Name = "Remove", HeaderText = "", Text = "Remove", UseColumnTextForButtonValue = true, Width = 80 };
            dgvShipmentItems.Columns.Add(btnRemove);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = cboProduct.SelectedItem as Product;
            int quantity = (int)numQuantity.Value;

            var existingItem = _shipmentItems.FirstOrDefault(item => item.ProductId == selectedProduct.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _shipmentItems.Add(new JobProduct
                {
                    ProductId = selectedProduct.Id,
                    Quantity = quantity,
                    Product = selectedProduct
                });
            }
            RefreshShipmentGrid();
        }

        private void RefreshShipmentGrid()
        {
            dgvShipmentItems.DataSource = null;
            var displayList = _shipmentItems.Select(item => new {
                item.ProductId,
                ProductName = item.Product.Name,
                item.Quantity
            }).ToList();

            if (displayList.Any())
            {
                dgvShipmentItems.DataSource = displayList;
            }
        }

        private void dgvShipmentItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvShipmentItems.Columns[e.ColumnIndex].Name == "Remove")
            {
                int productIdToRemove = (int)dgvShipmentItems.Rows[e.RowIndex].Cells["ProductId"].Value;
                var itemToRemove = _shipmentItems.FirstOrDefault(item => item.ProductId == productIdToRemove);
                if (itemToRemove != null)
                {
                    _shipmentItems.Remove(itemToRemove);
                    RefreshShipmentGrid();
                }
            }
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPickupAddress.Text) || string.IsNullOrWhiteSpace(txtDeliveryAddress.Text))
            {
                MessageBox.Show("Pickup and Delivery addresses are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_shipmentItems.Any())
            {
                MessageBox.Show("Please add at least one product to the shipment list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newJob = new Job
            {
                CustomerId = _customerId,
                PickupLocation = txtPickupAddress.Text,
                DeliveryLocation = txtDeliveryAddress.Text,
                RequestedDate = dtpRequestedDate.Value,
                JobProducts = _shipmentItems,
                Description = txtNotes.Text.Trim(),
                Status = JobStatus.PendingConfirmation,
            };

            try
            {
                _jobService.CreateNewJob(newJob);

                MessageBox.Show("Your pickup request has been submitted successfully!", "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error submitting your request: {ex.Message}", "Submission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
