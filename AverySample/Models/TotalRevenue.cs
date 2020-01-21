using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AverySample.Models
{
    public class TotalRevenue
    {
        public decimal Total { get; set; }
        public List<TotalRevenueItem> Revenue { get; set; }

        public TotalRevenue()
        {
            Revenue = new List<TotalRevenueItem>();
        }
    }
}
