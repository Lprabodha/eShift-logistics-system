using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services; // Assuming JobService is here
using eShift_Logistics_System.Models;           // Assuming Job, JobProduct, Product models are here
using eShift_Logistics_System.Repository.Service; // Assuming JobRepository is here
using System;
using System.Collections.Generic;
using System.Linq;           // For .Any() and .Select()
using System.Windows.Forms;  // For Form, MessageBox, DataGridView

namespace eShift_Logistics_System.Forms.Customer
{
    public partial class JobSummaryForm : Form
    {
        private readonly int _jobId;
        private readonly IJobService _jobService;

        public JobSummaryForm(int jobId)
        {
            InitializeComponent();
            _jobId = jobId;
            // In a real application with dependency injection, this would be passed in.
            _jobService = new JobService(new JobRepository());
        }

        private void JobSummaryForm_Load(object sender, EventArgs e)
        {
            SetupProductsGrid();
            SetupLoadsGrid();
            LoadJobSummaryData();
        }

        private void SetupProductsGrid()
        {
            dgvJobProducts.AutoGenerateColumns = false;
            dgvJobProducts.Columns.Clear();
            dgvJobProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Product Name", DataPropertyName = "ProductName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvJobProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Quantity", DataPropertyName = "Quantity", Width = 100 });
        }

        private void SetupLoadsGrid()
        {
            dgvLoads.AutoGenerateColumns = false;
            dgvLoads.Columns.Clear();
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Load Number", DataPropertyName = "LoadNumber", Width = 150 });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", DataPropertyName = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Weight (kg)", DataPropertyName = "Weight", Width = 100 });
            dgvLoads.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Volume (m³)", DataPropertyName = "Volume", Width = 100 });
        }

        private void LoadJobSummaryData()
        {
            try
            {
                // In a real application, you would fetch the data from your service
                // Job job = _jobService.GetJobWithDetailsById(_jobId);

                // Using placeholder data for demonstration
                Job job = GetPlaceholderJobSummary();

                if (job == null)
                {
                    MessageBox.Show("Could not find the specified job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Populate all the read-only text fields
                txtJobNumber.Text = job.JobNumber;
                txtRequestedDate.Text = job.RequestedDate.ToString("yyyy-MM-dd");
                txtStatus.Text = job.Status.ToString();
                txtPickupAddress.Text = job.PickupLocation;
                txtDeliveryAddress.Text = job.DeliveryLocation;
                txtCustomerName.Text = job.Customer?.FullName;
                txtCustomerPhone.Text = job.Customer?.Phone;
                txtCustomerEmail.Text = job.Customer?.Email;
                txtTotalWeight.Text = job.Loads.Sum(l => l.Weight).ToString("N2");
                txtTotalVolume.Text = job.Loads.Sum(l => l.Volume).ToString("N3");
                txtEstimatedCost.Text = job.EstimatedCost.ToString("C");
                txtAssignedUnit.Text = job.TransportUnit?.UnitNumber ?? "Not Yet Assigned";

                // Bind the product and load lists to their respective grids
                BindProductsToGrid(job.JobProducts);
                BindLoadsToGrid(job.Loads);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the job summary: {ex.Message}", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindProductsToGrid(List<JobProduct> products)
        {
            dgvJobProducts.DataSource = null;
            if (products != null && products.Any())
            {
                var displayList = products.Select(p => new
                {
                    ProductName = p.Product?.Name ?? "N/A",
                    p.Quantity
                }).ToList();
                dgvJobProducts.DataSource = displayList;
            }
        }

        private void BindLoadsToGrid(List<Load> loads)
        {
            dgvLoads.DataSource = null;
            if (loads != null && loads.Any())
            {
                dgvLoads.DataSource = loads.ToList();
            }
        }

        private Job GetPlaceholderJobSummary()
        {
            return new Job
            {
                Id = _jobId,
                JobNumber = "JOB-2025-002",
                RequestedDate = new DateTime(2025, 7, 13),
                Status = JobStatus.Accepted,
                PickupLocation = "Galle",
                DeliveryLocation = "Jaffna",
                EstimatedCost = 35000,
                TransportUnitId = 1,
                Customer = new User { FirstName = "Jane", LastName = "Hemas", Email = "jane@hemas.com", Phone = "077-5551234" },
                JobProducts = new List<JobProduct>
                {
                    new JobProduct { Product = new Product { Name = "King Size Bed" }, Quantity = 1 },
                    new JobProduct { Product = new Product { Name = "Wardrobe" }, Quantity = 2 },
                    new JobProduct { Product = new Product { Name = "Standard Box" }, Quantity = 15 }
                },
                Loads = new List<Load>
                {
                    new Load { LoadNumber = "JOB-2025-002-L01", Description = "Master Bedroom Furniture", Weight = 120, Volume = 2.5m },
                    new Load { LoadNumber = "JOB-2025-002-L02", Description = "Kitchenware Boxes", Weight = 80, Volume = 1.0m }
                },
                TransportUnit = new TransportUnit { UnitNumber = "UNIT-2025-004" }
            };
        }
    }
}