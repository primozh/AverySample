using AverySample.Data;
using AverySample.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AverySample.Services
{
    public class RevenueService : IRevenueService
    {

        private readonly AverySampleContext _context;
        private int _numDays;

        public RevenueService(AverySampleContext context, IConfiguration configuration)
        {
            _context = context;
            _numDays = -Math.Abs(configuration.GetValue<int>("NumberOfDays"));
        }

        public RevenueData RevenueByArticle(DateTime? from, DateTime? to)
        {
            var fromDate = from?.Date ?? DateTime.Now.Date.AddDays(_numDays);
            var toDate = to?.Date ?? DateTime.Now.Date;

            var queryable =
                _context.ArticleSaleData
                // client side querying (inmemory db)
                .AsEnumerable()
                .Where(article => article.Date.Date.CompareTo(fromDate) >= 0 && article.Date.Date.CompareTo(toDate) < 0)
                .GroupBy(a => a.ArticleId, a => a, (k, v) => new { article = k, list = v });

            var dataRange = new Dictionary<string, Dictionary<string, RevenueItem>>();

            var totalCount = 0;
            decimal totalRevenue = 0;

            for (var d = fromDate; d <= toDate; d = d.AddDays(1))
            {
                dataRange.Add(d.ToShortDateString(), new Dictionary<string, RevenueItem>());
            }

            foreach (var article in queryable)
            {
                foreach (var data in article.list)
                {
                    dataRange.TryGetValue(data.Date.ToShortDateString(), out var found);
                    
                    if (found != null)
                    {
                        found.TryGetValue(data.ArticleId, out var foundArticle);

                        if (foundArticle != null)
                        {
                            foundArticle.count++;
                            foundArticle.total += data.Price;
                        } else
                        {
                            found.Add(data.ArticleId, new RevenueItem { count = 1, total = data.Price });
                        }

                        totalCount++;
                        totalRevenue += data.Price;
                    }
                }
            }

            return new RevenueData() { Count = totalCount, TotalRevenue = totalRevenue, Data = dataRange };
        }

        public TotalRevenue totalRevenueByDay(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }
    }
}
