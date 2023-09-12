using System;
using System.Collections.Generic;

namespace WebOnlineShopping.Models
{
    public partial class Shipper
    {
        public int ShipperId { get; set; }
        public string? ShipperName { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public DateTime? Shipdate { get; set; }
    }
}
