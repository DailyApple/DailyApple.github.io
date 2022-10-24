using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyAppleAPI.Models;

namespace DailyAppleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public EmergencyContactsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EmergencyContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmergencyContact>>> GetemergencyContacts()
        {
            return await _context.emergencyContacts.ToListAsync();
        }

        // GET: api/EmergencyContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmergencyContact>> GetEmergencyContact(Guid id)
        {
            var emergencyContact = await _context.emergencyContacts.FindAsync(id);

            if (emergencyContact == null)
            {
                return NotFound();
            }

            return emergencyContact;
        }

        // PUT: api/EmergencyContacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergencyContact(Guid id, EmergencyContact emergencyContact)
        {
            if (id != emergencyContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(emergencyContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergencyContactExists(id))
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

        // POST: api/EmergencyContacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmergencyContact>> PostEmergencyContact(EmergencyContact emergencyContact)
        {
            _context.emergencyContacts.Add(emergencyContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmergencyContact), new { id = emergencyContact.Id }, emergencyContact);
        }

        // DELETE: api/EmergencyContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergencyContact(Guid id)
        {
            var emergencyContact = await _context.emergencyContacts.FindAsync(id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            _context.emergencyContacts.Remove(emergencyContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmergencyContactExists(Guid id)
        {
            return _context.emergencyContacts.Any(e => e.Id == id);
        }
    }
}
