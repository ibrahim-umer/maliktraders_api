
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopAccount>>> GetShopAccounts()
        {
            return await _context.ShopAccount.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult ShopAccountExistsByUserId(int id)
        {
            return Ok(_context.ShopAccount.Any(e => e.UserId == id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopAccount>> GetShopAccount(int id)
        {
            var shopAccount = await _context.ShopAccount.FindAsync(id);

            if (shopAccount == null)
            {
                return NotFound();
            }

            return shopAccount;
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ShopAccount>> GetShopAccountByUserId(int id)
        {
            var shopAccount = await _context.ShopAccount.FirstOrDefaultAsync(x=>x.UserId == id);

            if (shopAccount == null)
            {
                return NotFound();
            }

            return shopAccount;
        }

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

        [HttpPost]
        public async Task<ActionResult<ShopAccount>> PostShopAccount(ShopAccount shopAccount)
        {
            _context.ShopAccount.Add(shopAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopAccount", new { id = shopAccount.Id }, shopAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopAccount(int id)
        {
            var shopAccount = await _context.ShopAccount.FindAsync(id);
            if (shopAccount == null)
            {
                return NotFound();
            }

            _context.ShopAccount.Remove(shopAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ShopAccountExists(int id)
        {
            return _context.ShopAccount.Any(e => e.Id == id);
        }
        
    }
}
