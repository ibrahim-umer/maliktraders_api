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
    public class ShopAccountsController : ControllerBase
    {
        private readonly MTDbContext _context;

        public ShopAccountsController(MTDbContext context)
        {
            _context = context;
        }

        // GET: api/ShopAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopAccount>>> GetShopAccounts()
        {
            return await _context.ShopAccounts.ToListAsync();
        }

        // GET: api/ShopAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopAccount>> GetShopAccount(int id)
        {
            var shopAccount = await _context.ShopAccounts.FindAsync(id);

            if (shopAccount == null)
            {
                return NotFound();
            }

            return shopAccount;
        }

        // PUT: api/ShopAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopAccount(int id, ShopAccount shopAccount)
        {
            if (id != shopAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(shopAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopAccountExists(id))
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

        // POST: api/ShopAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopAccount>> PostShopAccount(ShopAccount shopAccount)
        {
            _context.ShopAccounts.Add(shopAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopAccount", new { id = shopAccount.Id }, shopAccount);
        }

        // DELETE: api/ShopAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopAccount(int id)
        {
            var shopAccount = await _context.ShopAccounts.FindAsync(id);
            if (shopAccount == null)
            {
                return NotFound();
            }

            _context.ShopAccounts.Remove(shopAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopAccountExists(int id)
        {
            return _context.ShopAccounts.Any(e => e.Id == id);
        }
    }
}
