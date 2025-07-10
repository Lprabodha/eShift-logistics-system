using eShift_Logistics_System.Models;
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
    public partial class AddEditProductForm : Form
    {
        private readonly int? _productId;
        // private readonly IProductService _productService; // In a real app

        public AddEditProductForm(int? productId = null)
        {
            InitializeComponent();
            _productId = productId;
            // _productService = new ProductService(new ProductRepository());
        }

        private void AddEditProductForm_Load(object sender, EventArgs e)
        {
            if (_productId.HasValue)
            {
                lblTitle.Text = "Edit Product";
                LoadProductData();
            }
            else
            {
                lblTitle.Text = "Add New Product";
            }
        }

        private void LoadProductData()
        {
            // var product = _productService.GetProductById(_productId.Value);
            // Using placeholder data for demonstration
            var product = new Product
            {
                Id = _productId.Value,
                Name = "Wooden Crate",
                Size = 1,
                Weight = 25,
                Description = "Heavy-duty crate for fragile items."
            };

            if (product == null)
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Populate form controls
            txtName.Text = product.Name;
            numSize.Value = (decimal)product.Size;
            numWeight.Value = (decimal)product.Weight;
            txtDescription.Text = product.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var product = new Product
            {
                Name = txtName.Text.Trim(),
                Size = (float)numSize.Value,
                Weight = (float)numWeight.Value,
                Description = txtDescription.Text.Trim()
            };

            if (_productId.HasValue)
            {
                product.Id = _productId.Value;
                // _productService.UpdateProduct(product);
                MessageBox.Show("Product updated successfully!", "Success");
            }
            else
            {
                // _productService.AddProduct(product);
                MessageBox.Show("New product added successfully!", "Success");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
