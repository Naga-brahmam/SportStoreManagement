using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportshopManagementSystem.Models
{
    public class ItemModule
    {
        public string Name { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
    }
}
