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

        // GET: api/AccDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccDetails>>> GetAccDetails()
        {
            return await _context.AccDetails.ToListAsync();
        }

        // GET: api/AccDetails/5
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

        // PUT: api/AccDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/AccDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccDetails>> PostAccDetails(AccDetails accDetails)
        {
            _context.AccDetails.Add(accDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccDetails", new { id = accDetails.id }, accDetails);
        }

        // DELETE: api/AccDetails/5
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
