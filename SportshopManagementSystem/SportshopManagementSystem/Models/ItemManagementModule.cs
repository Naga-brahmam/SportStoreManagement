using System;
using System.Collections.Generic;

namespace SportshopManagementSystem.Models
{
    public partial class ItemManagementModule
    {
        public ItemManagementModule()
        {
            OrderModule = new HashSet<OrderModule>();
        }

        public string Name { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderModule> OrderModule { get; set; }
    }
}
