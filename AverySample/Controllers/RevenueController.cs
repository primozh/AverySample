using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AverySample.Models;
using AverySample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OpenApiTags("revenue")]
        public ActionResult<TotalRevenue> TotalRevenue([FromQuery(Name = "fromDate")]string from, [FromQuery(Name = "toDate")]string to)
        {
            return Execute(from, to, _revenueService.TotalRevenueByDay);
        }

        [HttpGet]
        [Route("grouped")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OpenApiTags("revenue")]
        public ActionResult<RevenueData> RevenueByArticle([FromQuery(Name = "fromDate")]string from, [FromQuery(Name = "toDate")]string to)
        {
            return Execute(from, to, _revenueService.RevenueByArticle);
        }

        private ActionResult<T> Execute<T>(string from, string to, Func<DateTime?, DateTime?, T> function)
        {
            try
            {
                var fromDate = DateTime.Parse(from);
                var toDate = DateTime.Parse(to);

                if (fromDate.CompareTo(toDate) > 0)
                {
                    return BadRequest();
                }
                return function(fromDate, toDate);
            }
            catch (ArgumentNullException e)
            {
                if (from == null && to != null || from != null && to == null)
                {
                    return BadRequest();
                }
                return function(null, null);
            }
            catch (FormatException e)
            {
                return BadRequest();
            }
        }
    }
}