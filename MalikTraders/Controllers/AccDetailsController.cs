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
    public class AccDetailsController : ControllerBase
    {
        private readonly MTDbContext _context;

        public AccDetailsController(MTDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccDetails>>> GetAccDetails()
        {
            return await _context.AccDetails.ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<AccDetails>>> GetTodayEntries()
        {
            return await _context.AccDetails.Where(x=>x.PayingDate.Date==DateTime.Now.Date).ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<IEnumerable<AccDetails>>> GetAccDetailsbyAccountId(int id)
        {
            return await _context.AccDetails.Where(x=>x.AccId==id).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccDetails>> GetAccDetails(int id)
        {
            var accDetails = await _context.AccDetails.FindAsync(id);

            if (accDetails == null)
            {
                return NotFound();
            }

            return accDetails;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccDetails(int id, AccDetails accDetails)
        {
            if (id != accDetails.id)
            {
                return BadRequest();
            }

            _context.Entry(accDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccDetailsExists(id))
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
        public async Task<ActionResult<AccDetails>> PostAccDetails(AccDetails accDetails)
        {
            accDetails.PayingDate = DateTime.Now;
            _context.AccDetails.Add(accDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccDetails", new { id = accDetails.id }, accDetails);
        }
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<AccDetails>> GetAccountDetailsByGivenMonth(int id,DateTime StartDate,DateTime EndDate)
        {
            try
            {
                var AccD = from AD in await _context.AccDetails.ToListAsync()
                           where AD.PayingDate >= StartDate && AD.PayingDate <= EndDate
                           select AD;
                return Ok(AccD);
                           
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccDetails(int id)
        {
            var accDetails = await _context.AccDetails.FindAsync(id);
            if (accDetails == null)
            {
                return NotFound();
            }

            _context.AccDetails.Remove(accDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccDetailsExists(int id)
        {
            return _context.AccDetails.Any(e => e.id == id);
        }
    }
}
