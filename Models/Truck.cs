using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    /// <summary>
    /// Represents a truck in the logistics system, which can be used for transporting goods.
    /// </summary>
    public class Truck
    {
        public int Id { get; set; }

        public string TruckNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }

        public string? LicensePlate { get; set; }

        public TruckStatus Status { get; set; } = TruckStatus.Available;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
