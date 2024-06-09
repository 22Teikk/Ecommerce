using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalExamGroup8.model
{
    public class ProductSalesInfo
    {
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
        public string CategoryName { get; set; }

    }
}