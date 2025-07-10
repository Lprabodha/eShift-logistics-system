using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    /// <summary>
    /// Represents a transport unit in the logistics system, which can be a truck with a driver and possibly an assistant.
    /// </summary>
    public class TransportUnit
    {

        public int Id { get; set; }

        public string UnitNumber { get; set; } = string.Empty;

        public int TruckId { get; set; }
        public int DriverId { get; set; }
        public int AssistantId { get; set; }

        public TransportUnitStatus Status { get; set; } = TransportUnitStatus.Free;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public Truck? Truck { get; set; }
        public Driver? Driver { get; set; }
        public Assistant? Assistant { get; set; }

    }
}
