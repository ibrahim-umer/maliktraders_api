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
    public class SystemNotificationsController : ControllerBase
    {
        private readonly MTDbContext _context;

        public SystemNotificationsController(MTDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemNotifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemNotification>>> GetSystemNotifications()
        {
            return await _context.SystemNotifications.ToListAsync();
        }

        // GET: api/SystemNotifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemNotification>> GetSystemNotification(int id)
        {
            var systemNotification = await _context.SystemNotifications.FindAsync(id);

            if (systemNotification == null)
            {
                return NotFound();
            }

            return systemNotification;
        }

        // PUT: api/SystemNotifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemNotification(int id, SystemNotification systemNotification)
        {
            if (id != systemNotification.id)
            {
                return BadRequest();
            }

            _context.Entry(systemNotification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemNotificationExists(id))
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

        // POST: api/SystemNotifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemNotification>> PostSystemNotification(SystemNotification systemNotification)
        {
            _context.SystemNotifications.Add(systemNotification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemNotification", new { id = systemNotification.id }, systemNotification);
        }

        // DELETE: api/SystemNotifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemNotification(int id)
        {
            var systemNotification = await _context.SystemNotifications.FindAsync(id);
            if (systemNotification == null)
            {
                return NotFound();
            }

            _context.SystemNotifications.Remove(systemNotification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemNotificationExists(int id)
        {
            return _context.SystemNotifications.Any(e => e.id == id);
        }
    }
}
