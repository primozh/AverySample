using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AverySample.Data;
using AverySample.Models;

namespace AverySample.Controllers
{
    [Route("api/v1/sales")]
    [ApiController]
    public class ArticleSaleDatasController : ControllerBase
    {
        private readonly AverySampleContext _context;

        public ArticleSaleDatasController(AverySampleContext context)
        {
            _context = context;
        }

        // GET: api/ArticleSaleDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleSaleData>>> GetArticleSaleData()
        {
            return await _context.ArticleSaleData.ToListAsync();
        }

        // GET: api/ArticleSaleDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleSaleData>> GetArticleSaleData(long id)
        {
            var articleSaleData = await _context.ArticleSaleData.FindAsync(id);

            if (articleSaleData == null)
            {
                return NotFound();
            }

            return articleSaleData;
        }

        // POST: api/ArticleSaleDatas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ArticleSaleData>> PostArticleSaleData(ArticleSaleData articleSaleData)
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
