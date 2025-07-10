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
        public string Name { get; set; }  
        public float Size { get; set; }
        public float Weight { get; set; } 
        public string Description { get; set; }
    }
}
