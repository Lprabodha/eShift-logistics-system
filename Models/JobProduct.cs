using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    public class JobProduct
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Job Job { get; set; }
    }
}
