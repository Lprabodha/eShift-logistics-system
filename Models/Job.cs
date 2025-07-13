using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    /// <summary>
    /// Represents a job in the logistics system.
    /// </summary>
    public class Job
    {

        public int Id { get; set; }

        public string JobNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }

        public string PickupLocation { get; set; } = string.Empty;
        public string DeliveryLocation { get; set; } = string.Empty;

        public DateTime RequestedDate { get; set; }
        public DateTime? DispatchDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public string? Description { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }

        public JobStatus Status { get; set; } = JobStatus.PendingConfirmation;

        public int? TransportUnitId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        public User? Customer { get; set; }
        public TransportUnit? TransportUnit { get; set; }
        public List<Load> Loads { get; set; } = new();
        public List<JobProduct> JobProducts { get; set; } = new List<JobProduct>();
    }
}
