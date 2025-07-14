using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eShift_Logistics_System.Forms.Admin
{
    public partial class AdminDashboardForm : Form
    {
        private List<Panel> menuPanels;
        private Panel _selectedMenuPanel;
        private Form activeForm = null;

        // Color settings for menu interactions
        private readonly Color _sidebarBackColor = Color.FromArgb(65, 84, 241);
        private readonly Color _selectedMenuColor = Color.FromArgb(40, 55, 210);
        private readonly Color _hoverColor = Color.FromArgb(50, 70, 225);
        private readonly Color _unselectedForeColor = Color.FromArgb(240, 240, 240);
        private readonly Color _selectedForeColor = Color.White;

        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load event: initializes sidebar menu and loads default dashboard.
        /// </summary>
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            menuPanels = new List<Panel>
            {
                pnlDashboard, pnlCustomer, pnlJobs, pnlVehicle, pnlProduct, pnlReports
            };

            // Assign event handlers for panel and their child controls
            foreach (var panel in menuPanels)
            {
                AttachPanelEvents(panel);
            }

            // Load default view
            LoadFormIntoPanel(new DashboardViewForm());
            SetSelectedPanel(pnlDashboard);
        }

        /// <summary>
        /// Attaches click and hover event handlers to a menu panel and its child controls.
        /// </summary>
        private void AttachPanelEvents(Panel panel)
        {
            panel.Click += (s, ev) => MenuPanel_Click(panel, ev);
            panel.MouseEnter += (s, ev) => MenuPanel_MouseEnter(panel, ev);
            panel.MouseLeave += (s, ev) => MenuPanel_MouseLeave(panel, ev);

            foreach (Control control in panel.Controls)
            {
                control.Click += (s, ev) => MenuPanel_Click(panel, ev);
                control.MouseEnter += (s, ev) => MenuPanel_MouseEnter(panel, ev);
                control.MouseLeave += (s, ev) => MenuPanel_MouseLeave(panel, ev);
            }
        }

        /// <summary>
        /// Loads a child form into the main content panel.
        /// </summary>
        private void LoadFormIntoPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close(); // Dispose the previous form

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMainContent.Controls.Clear(); // Ensure no stacking
            pnlMainContent.Controls.Add(childForm);
            pnlMainContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        // --- Event Handlers for Menu Interactivity ---

        private void MenuPanel_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel != _selectedMenuPanel)
                panel.BackColor = _hoverColor;
        }

        private void MenuPanel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel != _selectedMenuPanel)
                panel.BackColor = Color.Transparent;
        }

        private void MenuPanel_Click(object sender, EventArgs e)
        {
            // Identify clicked panel
            Panel clickedPanel = sender as Panel ?? ((Control)sender).Parent as Panel;
            if (clickedPanel == null) return;

            SetSelectedPanel(clickedPanel);

            // Load appropriate form based on the panel clicked
            if (clickedPanel == pnlDashboard)
                LoadFormIntoPanel(new DashboardViewForm());
            else if (clickedPanel == pnlJobs)
                LoadFormIntoPanel(new JobManagementForm());
            else if (clickedPanel == pnlCustomer)
                LoadFormIntoPanel(new CustomersForm());
            else if (clickedPanel == pnlVehicle)
                LoadFormIntoPanel(new VehicleManagementForm());
            else if (clickedPanel == pnlProduct)
                LoadFormIntoPanel(new ProductManagementForm());
            else if (clickedPanel == pnlReports)
                LoadFormIntoPanel(new AdminReportForm());
        }

        /// <summary>
        /// Highlights the currently selected menu panel and resets the previous one.
        /// </summary>
        private void SetSelectedPanel(Panel panelToSelect)
        {
            if (_selectedMenuPanel != null)
                _selectedMenuPanel.BackColor = Color.Transparent;

            if (panelToSelect != null)
                panelToSelect.BackColor = _selectedMenuColor;

            _selectedMenuPanel = panelToSelect;
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {

        }

        private void lblUserRole_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm(); 
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }
    }

}
