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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopAccountPaymentHistory>>> GetShopAccountPaymentHistories()
        {
            return await _context.ShopAccountPaymentHistory.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ShopAccountPaymentHistory>> GetShopAccountPaymentHistory(int id)
        {
            var shopAccountPaymentHistory = await _context.ShopAccountPaymentHistory.FindAsync(id);

            if (shopAccountPaymentHistory == null)
            {
                return NotFound();
            }

            return shopAccountPaymentHistory;
        }
        [HttpGet("[action]/{id}")]
        public  ActionResult<ShopAccountPaymentHistory> GetShopAccountPaymentHistorybuUserId(int id)
        {
            try
            {
                ShopAccount getShopAcc = _context.ShopAccount.FirstOrDefault(x => x.UserId == id)!= null? 
                    _context.ShopAccount.FirstOrDefault(x => x.UserId == id): new ShopAccount();
                if (getShopAcc.AccountNo == null)
                {
                    return NotFound();
                }
                var shopAccountPaymentHistory = _context.ShopAccountPaymentHistory.Where(x => x.ShopAccountId == getShopAcc.Id).ToList();

                if (shopAccountPaymentHistory == null)
                {
                    return NotFound();
                }

                return Ok(shopAccountPaymentHistory);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]/{id}")]
        public ActionResult<ShopAccountPaymentHistory> SearchShopAccountPaymentHistorybuUserId(int id,DateTime StartDate,DateTime EndDate)
        {
            try
            {
                ShopAccount getShopAcc = _context.ShopAccount.FirstOrDefault(x => x.UserId == id) != null ?
                    _context.ShopAccount.FirstOrDefault(x => x.UserId == id) : new ShopAccount();
                if (getShopAcc.AccountNo == null)
                {
                    return NotFound();
                }
                var shopAccountPaymentHistory = _context.ShopAccountPaymentHistory.Where(x => x.ShopAccountId == getShopAcc.Id && x.TransectionDate >= StartDate && x.TransectionDate <= EndDate).ToList();

                if (shopAccountPaymentHistory == null)
                {
                    return NotFound();
                }

                return Ok(shopAccountPaymentHistory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
            if (shopAccountPaymentHistory.AmountPaid == 0)
            {
                using(MTDbContext mTDbContext = new MTDbContext())
                {
                    ShopAccount shopAccount = mTDbContext.ShopAccount.Find(shopAccountPaymentHistory.ShopAccountId);
                    mTDbContext.ShopAccount.Attach(shopAccount);
                    shopAccount.CurrentPayment += shopAccountPaymentHistory.AmountRecived;
                    if (mTDbContext.SaveChanges() < 1)
                        return BadRequest("Sorry! Data not Saved");
                }
            }
            else if (shopAccountPaymentHistory.AmountRecived == 0)
            {
                using (MTDbContext mTDbContext = new MTDbContext())
                {
                    ShopAccount shopAccount = mTDbContext.ShopAccount.Find(shopAccountPaymentHistory.ShopAccountId);
                    mTDbContext.ShopAccount.Attach(shopAccount);
                    shopAccount.CurrentPayment -= shopAccountPaymentHistory.AmountPaid;
                    if (mTDbContext.SaveChanges() < 1)
                        return BadRequest("Sorry! Data not Saved");
                }
            }
            _context.ShopAccountPaymentHistory.Add(shopAccountPaymentHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopAccountPaymentHistory", new { id = shopAccountPaymentHistory.id }, shopAccountPaymentHistory);
        }

        // DELETE: api/ShopAccountPaymentHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopAccountPaymentHistory(int id)
        {
            var shopAccountPaymentHistory = await _context.ShopAccountPaymentHistory.FindAsync(id);
            if (shopAccountPaymentHistory == null)
            {
                return NotFound();
            }

            _context.ShopAccountPaymentHistory.Remove(shopAccountPaymentHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopAccountPaymentHistoryExists(int id)
        {
            return _context.ShopAccountPaymentHistory.Any(e => e.id == id);
        }
    }
}
