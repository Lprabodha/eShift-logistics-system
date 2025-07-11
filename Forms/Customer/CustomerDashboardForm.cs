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


        // Colors for menu interaction
        private readonly Color _selectedMenuColor = Color.FromArgb(40, 55, 210);
        private readonly Color _hoverColor = Color.FromArgb(50, 70, 225);

        public CustomerDashboardForm()
        {
            InitializeComponent();
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            menuPanels = new List<Panel> { pnlDashboard, pnlMyJobs, pnlMyProfile, pnlRequestPickup };

            foreach (var panel in menuPanels)
            {
                AttachClickAndHoverEvents(panel);
            }

            LoadFormIntoPanel(new CustomerDashboardViewForm());
            SetSelectedPanel(pnlDashboard);
        }

        private void AttachClickAndHoverEvents(Panel panel)
        {
            var clickHandler = new EventHandler((s, e) => MenuPanel_Click(s, e));
            var mouseEnterHandler = new EventHandler((s, e) => MenuPanel_MouseEnter(s, e));
            var mouseLeaveHandler = new EventHandler((s, e) => MenuPanel_MouseLeave(s, e));

            panel.Click += clickHandler;
            panel.MouseEnter += mouseEnterHandler;
            panel.MouseLeave += mouseLeaveHandler;

            // Attach events to all child controls as well
            foreach (Control control in panel.Controls)
            {
                control.Click += clickHandler;
                control.MouseEnter += mouseEnterHandler;
                control.MouseLeave += mouseLeaveHandler;
            }
        }

        private void MenuPanel_Click(object sender, EventArgs e)
        {
            // Determine which panel was clicked
            Control control = sender as Control;
            Panel clickedPanel = (control is Panel) ? (Panel)control : (Panel)control.Parent;
            if (clickedPanel == null) return;

            int customerId = 1;


        SetSelectedPanel(clickedPanel);

            // Load the correct form into the main panel
            if (clickedPanel == pnlDashboard)
                LoadFormIntoPanel(new CustomerDashboardViewForm());
            // else if (clickedPanel == pnlMyJobs)
            //     LoadFormIntoPanel(new MyJobsForm()); 
            // else if (clickedPanel == pnlRequestPickup)
            //     LoadFormIntoPanel(new RequestPickupForm());
            else if (clickedPanel == pnlMyProfile)
                LoadFormIntoPanel(new MyProfileForm(customerId));
        }

        private void LoadFormIntoPanel(Form childForm)
        {
            // Avoid reloading the same form
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
            // Reset the previously selected panel's color, unless it's the special 'Request Pickup' button
            if (_selectedMenuPanel != null && _selectedMenuPanel.Name != "pnlRequestPickup")
            {
                _selectedMenuPanel.BackColor = Color.Transparent;
            }

            // Set the new selected panel's color
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
    }
}
