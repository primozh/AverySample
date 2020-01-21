using AverySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AverySample.Services
{
    public interface IRevenueService
    {
        TotalRevenue TotalRevenueByDay(DateTime? from, DateTime? to);
        RevenueData RevenueByArticle(DateTime? from, DateTime? to);
    }
}
