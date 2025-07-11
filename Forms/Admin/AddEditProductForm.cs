using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Service;
using eShift_Logistics_System.Validators;
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
         private readonly IProductService _productService; 

        public AddEditProductForm(int? productId = null)
        {
            InitializeComponent();
            _productId = productId;
            _productService = new ProductService(new ProductRepository());
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
             var product = _productService.GetProductById(_productId.Value);

            if (product == null)
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Populate form controls
            txtName.Text = product.Name;
            numWeight.Value = product.DefaultWeight ?? 0;
            txtDimensions.Text = product.DefaultDimensions;
            chkIsFragile.Checked = product.IsFragile;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = txtName.Text.Trim(),
                DefaultWeight = numWeight.Value > 0 ? numWeight.Value : (decimal?)null,
                DefaultDimensions = txtDimensions.Text.Trim(),
                IsFragile = chkIsFragile.Checked
            };

            if (_productId.HasValue)
            {
                product.Id = _productId.Value;
            }

            var validator = new ProductValidator(new ProductRepository());
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
            {
                string allErrors = string.Join("\n", validationResult.Errors.Select(failure => failure.ErrorMessage));
                MessageBox.Show(allErrors, "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_productId.HasValue)
            {
                _productService.UpdateProduct(product);
                MessageBox.Show("Product updated successfully!", "Success");
            }
            else
            {
                _productService.AddProduct(product);
                MessageBox.Show("New product added successfully!", "Success");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
