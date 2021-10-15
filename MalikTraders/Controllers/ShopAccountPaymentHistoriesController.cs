using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MalikTraders.Models;

namespace MalikTraders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopAccountPaymentHistoriesController : ControllerBase
    {
        private readonly MTDbContext _context;

        public ShopAccountPaymentHistoriesController(MTDbContext context)
        {
            _context = context;
        }

        // GET: api/ShopAccountPaymentHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopAccountPaymentHistory>>> GetShopAccountPaymentHistories()
        {
            return await _context.ShopAccountPaymentHistories.ToListAsync();
        }

        // GET: api/ShopAccountPaymentHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopAccountPaymentHistory>> GetShopAccountPaymentHistory(int id)
        {
            var shopAccountPaymentHistory = await _context.ShopAccountPaymentHistories.FindAsync(id);

            if (shopAccountPaymentHistory == null)
            {
                return NotFound();
            }

            return shopAccountPaymentHistory;
        }

        // PUT: api/ShopAccountPaymentHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopAccountPaymentHistory(int id, ShopAccountPaymentHistory shopAccountPaymentHistory)
        {
            if (id != shopAccountPaymentHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(shopAccountPaymentHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopAccountPaymentHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShopAccountPaymentHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopAccountPaymentHistory>> PostShopAccountPaymentHistory(ShopAccountPaymentHistory shopAccountPaymentHistory)
        {
            _context.ShopAccountPaymentHistories.Add(shopAccountPaymentHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopAccountPaymentHistory", new { id = shopAccountPaymentHistory.id }, shopAccountPaymentHistory);
        }

        // DELETE: api/ShopAccountPaymentHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopAccountPaymentHistory(int id)
        {
            var shopAccountPaymentHistory = await _context.ShopAccountPaymentHistories.FindAsync(id);
            if (shopAccountPaymentHistory == null)
            {
                return NotFound();
            }

            _context.ShopAccountPaymentHistories.Remove(shopAccountPaymentHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopAccountPaymentHistoryExists(int id)
        {
            return _context.ShopAccountPaymentHistories.Any(e => e.id == id);
        }
    }
}
