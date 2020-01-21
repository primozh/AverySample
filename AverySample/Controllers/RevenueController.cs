using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AverySample.Models;
using AverySample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AverySample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {

        private readonly IRevenueService _revenueService;

        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpGet]
        [Route("total")]
        public ActionResult<TotalRevenue> TotalRevenue([FromQuery(Name = "fromDate")]string from, [FromQuery(Name = "toDate")]string to)
        {
            return NoContent();
        }

        [HttpGet]
        [Route("grouped")]
        public ActionResult<RevenueData> RevenueByArticle([FromQuery(Name = "fromDate")]string from, [FromQuery(Name = "toDate")]string to)
        {
            try
            {
                var fromDate = DateTime.Parse(from);
                var toDate = DateTime.Parse(to);

                if (fromDate.CompareTo(toDate) > 0)
                {
                    return BadRequest();
                }
                return _revenueService.RevenueByArticle(fromDate, toDate);
            } 
            catch (ArgumentNullException e)
            {
                if (from == null && to != null || from != null && to == null)
                {
                    return BadRequest();
                }
                return _revenueService.RevenueByArticle(null, null);
            } 
            catch (FormatException e)
            {
                return BadRequest();
            }
        }
    }
}