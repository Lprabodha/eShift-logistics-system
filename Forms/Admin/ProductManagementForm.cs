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
    public partial class ProductManagementForm : Form
    {
        private List<Product> _allProducts;

        public ProductManagementForm()
        {
            InitializeComponent();
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            SetupProductsGrid();
            LoadProductsData();
            // Attach event handlers
            btnAddNewProduct.Click += btnAddNewProduct_Click;
            dgvProducts.CellClick += dgvProducts_CellClick;
        }

        private void SetupProductsGrid()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Product Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Size", HeaderText = "Size (m³)", DataPropertyName = "Size", Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Weight", HeaderText = "Weight (kg)", DataPropertyName = "Weight", Width = 120 });

            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 };
            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 };
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { btnEdit, btnDelete });
        }

        private void LoadProductsData()
        {
            // In a real app, load this from a service/repository
            _allProducts = new List<Product> {
                new Product { Id = 1, Name = "Standard Box", Size = 0.125f, Weight = 5 },
                new Product { Id = 2, Name = "Wooden Crate", Size = 1, Weight = 25 },
                new Product { Id = 3, Name = "Document Envelope", Size = 0.001f, Weight = 0.5f }
            };
            dgvProducts.DataSource = _allProducts;
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadProductsData();
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Id"].Value);

            if (dgvProducts.Columns[e.ColumnIndex].Name == "Edit")
            {
                var editForm = new AddEditProductForm(productId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProductsData();
                }
            }
            else if (dgvProducts.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // _productService.Delete(productId);
                    LoadProductsData();
                }
            }
        }
    }
}
