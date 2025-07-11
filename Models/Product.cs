using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal? DefaultWeight { get; set; }
        public string? DefaultDimensions { get; set; }
        public bool IsFragile { get; set; }
    }
}
