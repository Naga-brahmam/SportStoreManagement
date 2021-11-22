using System;
using System.Collections.Generic;

namespace SportshopManagementSystem.Models
{
    public partial class OrderModule
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public int? ItemId { get; set; }
        public DateTime? DelivaryDate { get; set; }
        public string PaymentMode { get; set; }

        public virtual CustomerManagementModule Customer { get; set; }
        public virtual ItemManagementModule Item { get; set; }
    }
}
