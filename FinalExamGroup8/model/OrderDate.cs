using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalExamGroup8.model
{
    public class OrderDate
    {
        public string FormattedDate { get; set; }  
        public int? Year { get; set; }            
        public int? Month { get; set; }          
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}