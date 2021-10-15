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
    public class ContactLeadsController : ControllerBase
    {
        private readonly MTDbContext _context;

        public ContactLeadsController(MTDbContext context)
        {
            _context = context;
        }

        // GET: api/ContactLeads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactLeads>>> GetContactLeads()
        {
            return await _context.ContactLeads.ToListAsync();
        }

        // GET: api/ContactLeads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactLeads>> GetContactLeads(int id)
        {
            var contactLeads = await _context.ContactLeads.FindAsync(id);

            if (contactLeads == null)
            {
                return NotFound();
            }

            return contactLeads;
        }

        // PUT: api/ContactLeads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactLeads(int id, ContactLeads contactLeads)
        {
            if (id != contactLeads.id)
            {
                return BadRequest();
            }

            _context.Entry(contactLeads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactLeadsExists(id))
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

        // POST: api/ContactLeads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactLeads>> PostContactLeads(ContactLeads contactLeads)
        {
            _context.ContactLeads.Add(contactLeads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactLeads", new { id = contactLeads.id }, contactLeads);
        }

        // DELETE: api/ContactLeads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactLeads(int id)
        {
            var contactLeads = await _context.ContactLeads.FindAsync(id);
            if (contactLeads == null)
            {
                return NotFound();
            }

            _context.ContactLeads.Remove(contactLeads);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactLeadsExists(int id)
        {
            return _context.ContactLeads.Any(e => e.id == id);
        }
    }
}
