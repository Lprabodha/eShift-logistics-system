using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    public class JobStatusLog
    {

        public int Id { get; set; }

        public int JobId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation
        public Job Job { get; set; }
    }
}
