using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    /// <summary>
    /// Represents a load in the logistics system, which is part of a job.
    /// </summary>
    public class Load
    {
        public int Id { get; set; }

        public string LoadNumber { get; set; } = string.Empty;
        public int JobId { get; set; }

        public string Description { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }

        public string? SpecialInstructions { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Job? Job { get; set; }
    }
}
