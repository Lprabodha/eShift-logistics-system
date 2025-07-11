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

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class ProductManagementForm : Form
    {
        private List<Product> _allProducts;

        private readonly IProductService _productService;

        public ProductManagementForm()
        {
            _productService = new ProductService(new ProductRepository());
            InitializeComponent();
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            SetupProductsGrid();
            LoadProductsData();
            btnAddNewProduct.Click += btnAddNewProduct_Click;
            dgvProducts.CellClick += dgvProducts_CellClick;
        }

        private void SetupProductsGrid()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Product Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "DefaultWeight", HeaderText = "Weight (kg)", DataPropertyName = "DefaultWeight", Width = 120 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "DefaultDimensions", HeaderText = "Dimensions", DataPropertyName = "DefaultDimensions", Width = 150 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "IsFragile", HeaderText = "Fragile?", DataPropertyName = "IsFragile", Width = 80 });

            var btnEdit = new DataGridViewButtonColumn { Name = "Edit", HeaderText = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, Width = 80 };
            var btnDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 80 };
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { btnEdit, btnDelete });
        }

        private void LoadProductsData()
        {
            try
            {
                _allProducts = _productService.GetAllProducts();
                BindDataToGrid(_allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load product data: {ex.Message}", "Error");
            }
        }

        private void BindDataToGrid(List<Product> products)
        {
            dgvProducts.DataSource = null;

            if (products == null) return;

            var displayList = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.DefaultWeight,
                p.DefaultDimensions,
                IsFragile = p.IsFragile ? "Yes" : "No"
            }).ToList();

            dgvProducts.DataSource = displayList;
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
                    _productService.DeleteProduct(productId);
                    LoadProductsData();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.Trim().ToLower();
            var filteredList = _allProducts.Where(p => p.Name.ToLower().Contains(searchText)).ToList();
            BindDataToGrid(filteredList);

        }
    }
}
