using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    /// <summary>
    /// Represents a driver in the logistics system.
    /// </summary>
    public class Driver
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LicenseNumber { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public DriverStatus Status { get; set; } = DriverStatus.Available;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

    }
}
