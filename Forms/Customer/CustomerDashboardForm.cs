using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Business.Services;
using eShift_Logistics_System.Forms.Admin;
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

namespace eShift_Logistics_System.Forms.Customer
{
    public partial class CustomerDashboardForm : Form
    {
        private List<Panel> menuPanels;
        private Panel _selectedMenuPanel;
        private Form activeForm = null;

        private readonly int _customerId;

        // Colors for menu interaction
        private readonly Color _selectedMenuColor = Color.FromArgb(40, 55, 210);
        private readonly Color _hoverColor = Color.FromArgb(50, 70, 225);

        private readonly IUserService _userService;


        /// <summary>
        /// The constructor now requires the customer's ID to be passed in.
        /// </summary>
        /// <param name="customerId">The ID of the logged-in customer.</param>
        public CustomerDashboardForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

            IUserRepository userRepository = new UserRepository();
            _userService = new UserService(userRepository);
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            menuPanels = new List<Panel> { pnlDashboard, pnlMyJobs, pnlMyProfile, pnlRequestPickup };

            foreach (var panel in menuPanels)
            {
                AttachClickAndHoverEvents(panel);
            }

            LoadUserDetails();

            LoadFormIntoPanel(new CustomerDashboardViewForm(_customerId));
            SetSelectedPanel(pnlDashboard);
        }

        private void LoadUserDetails()
        {
            try
            {
                var customer = _userService.GetUserById(_customerId);
                if (customer != null)
                {
                    lblUserName.Text = customer.FirstName;
                }
                else
                {
                    lblUserName.Text = "Customer";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load user details: {ex.Message}", "Error");
                lblUserName.Text = "Error";
            }
        }

        private void AttachClickAndHoverEvents(Panel panel)
        {
            var clickHandler = new EventHandler((s, e) => MenuPanel_Click(s, e));
            var mouseEnterHandler = new EventHandler((s, e) => MenuPanel_MouseEnter(s, e));
            var mouseLeaveHandler = new EventHandler((s, e) => MenuPanel_MouseLeave(s, e));

            panel.Click += clickHandler;
            panel.MouseEnter += mouseEnterHandler;
            panel.MouseLeave += mouseLeaveHandler;

            foreach (Control control in panel.Controls)
            {
                control.Click += clickHandler;
                control.MouseEnter += mouseEnterHandler;
                control.MouseLeave += mouseLeaveHandler;
            }
        }

        /// <summary>
        /// Public method that can be called from child forms to trigger navigation.
        /// </summary>
        public void NavigateToRequestPickup()
        {
            MenuPanel_Click(pnlRequestPickup, EventArgs.Empty);
        }

        private void MenuPanel_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel clickedPanel = (control is Panel) ? (Panel)control : (Panel)control.Parent;
            if (clickedPanel == null) return;

            SetSelectedPanel(clickedPanel);

            if (clickedPanel == pnlDashboard)
                LoadFormIntoPanel(new CustomerDashboardViewForm(_customerId));
            else if (clickedPanel == pnlMyJobs)
                LoadFormIntoPanel(new MyJobsForm(_customerId));
            else if (clickedPanel == pnlRequestPickup)
                LoadFormIntoPanel(new RequestPickupForm(_customerId));
            else if (clickedPanel == pnlMyProfile)
                LoadFormIntoPanel(new MyProfileForm(_customerId));
        }

        private void LoadFormIntoPanel(Form childForm)
        {
            if (activeForm?.GetType() == childForm.GetType())
            {
                childForm.Dispose();
                return;
            }

            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void SetSelectedPanel(Panel panelToSelect)
        {
            if (_selectedMenuPanel != null && _selectedMenuPanel.Name != "pnlRequestPickup")
            {
                _selectedMenuPanel.BackColor = Color.Transparent;
            }

            if (panelToSelect.Name != "pnlRequestPickup")
            {
                panelToSelect.BackColor = _selectedMenuColor;
            }

            _selectedMenuPanel = panelToSelect;
        }

        private void MenuPanel_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel panel = (control is Panel) ? (Panel)control : (Panel)control.Parent;
            if (panel != null && panel != _selectedMenuPanel && panel.Name != "pnlRequestPickup")
            {
                panel.BackColor = _hoverColor;
            }
        }

        private void MenuPanel_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel panel = (control is Panel) ? (Panel)control : (Panel)control.Parent;
            if (panel != null && panel != _selectedMenuPanel && panel.Name != "pnlRequestPickup")
            {
                panel.BackColor = Color.Transparent;
            }
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
