using System;
using System.Collections.Generic;

namespace WebOnlineShopping.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? DeliveryStatusId { get; set; }
        public bool? Active { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentId { get; set; }
        public string? Note { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual DeliveryStatus? DeliveryStatus { get; set; }
    }
}
