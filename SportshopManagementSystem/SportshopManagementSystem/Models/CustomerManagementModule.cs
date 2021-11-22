using System;
using System.Collections.Generic;

namespace SportshopManagementSystem.Models
{
    public partial class CustomerManagementModule
    {
        public CustomerManagementModule()
        {
            OrderModule = new HashSet<OrderModule>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public virtual ICollection<OrderModule> OrderModule { get; set; }
    }
}
