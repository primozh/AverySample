﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AverySample.Models
{
    public class RevenueData
    {
        public decimal TotalRevenue { get; set; }
        public decimal Count { get; set; }
        public Dictionary<string, Dictionary<string, RevenueItem>> Data { get; set; }
    }
}
