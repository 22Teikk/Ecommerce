using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalExamGroup8.model
{
    public class ShipmentOrder
    {
        public DateTime ShipmentDate { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int OrderId { get; set; }
    }
}