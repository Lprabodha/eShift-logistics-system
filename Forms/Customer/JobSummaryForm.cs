using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Models;  
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;      
using System.Windows.Forms; 

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
                 Job job = _jobService.GetJobWithDetailsById(_jobId);

                if (job == null)
                {
                    MessageBox.Show("Could not find the specified job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

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
        
    }
}