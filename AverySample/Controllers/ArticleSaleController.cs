using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AverySample.Data;
using AverySample.Models;
using NSwag.Annotations;

namespace AverySample.Controllers
{
    [Route("api/v1/sales")]
    [ApiController]
    public class ArticleSaleController : ControllerBase
    {
        private readonly AverySampleContext _context;

        public ArticleSaleController(AverySampleContext context)
        {
            _context = context;
        }

        // GET: api/ArticleSaleDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleSale>> GetArticleSaleData(long id)
        {
            var articleSaleData = await _context.ArticleSaleData.FindAsync(id);

            if (articleSaleData == null)
            {
                return NotFound();
            }

            return articleSaleData;
        }

        // POST: api/v1/ArticleSaleDatas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OpenApiTags("sales")]
        public async Task<ActionResult<ArticleSale>> PostArticleSaleData(ArticleSale articleSaleData)
        {
            _context.ArticleSaleData.Add(articleSaleData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticleSaleData", new { id = articleSaleData.Id }, articleSaleData);
        }

        private bool ArticleSaleDataExists(long id)
        {
            return _context.ArticleSaleData.Any(e => e.Id == id);
        }
    }
}
