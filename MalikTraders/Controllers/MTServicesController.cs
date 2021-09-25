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
    public class MTServicesController : ControllerBase
    {
        private readonly MTDbContext _context;

        public MTServicesController(MTDbContext context)
        {
            _context = context;
        }

        // GET: api/MTServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MTServices>>> GetMTServices()
        {
            return await _context.MTServices.ToListAsync();
        }

        // GET: api/MTServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MTServices>> GetMTServices(int id)
        {
            var mTServices = await _context.MTServices.FindAsync(id);

            if (mTServices == null)
            {
                return NotFound();
            }

            return mTServices;
        }

        // PUT: api/MTServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMTServices(int id, MTServices mTServices)
        {
            if (id != mTServices.id)
            {
                return BadRequest();
            }

            _context.Entry(mTServices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MTServicesExists(id))
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

        // POST: api/MTServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MTServices>> PostMTServices(MTServices mTServices)
        {
            _context.MTServices.Add(mTServices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMTServices", new { id = mTServices.id }, mTServices);
        }

        // DELETE: api/MTServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMTServices(int id)
        {
            var mTServices = await _context.MTServices.FindAsync(id);
            if (mTServices == null)
            {
                return NotFound();
            }

            _context.MTServices.Remove(mTServices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MTServicesExists(int id)
        {
            return _context.MTServices.Any(e => e.id == id);
        }
    }
}
