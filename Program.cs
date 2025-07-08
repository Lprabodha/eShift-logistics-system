using eShift_Logistics_System.Forms;
using eShift_Logistics_System.Forms.Admin;

namespace eShift_Logistics_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new AdminDashboardForm());
        }
    }
}