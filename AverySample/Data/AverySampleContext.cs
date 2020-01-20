using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AverySample.Models;

namespace AverySample.Data
{
    public class AverySampleContext : DbContext
    {
        public AverySampleContext (DbContextOptions<AverySampleContext> options)
            : base(options)
        {
        }

        public DbSet<AverySample.Models.ArticleSaleData> ArticleSaleData { get; set; }
    }
}
