using System;
using System.Collections.Generic;

namespace WebOnlineShopping.Models
{
    public partial class DeliveryStatus
    {
        public DeliveryStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int DeliveryStatusId { get; set; }
        public bool? Status { get; set; }
        public string? Decription { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
