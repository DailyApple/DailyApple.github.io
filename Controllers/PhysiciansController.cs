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
    public class PhysiciansController : ControllerBase
    {
        private readonly DataContext _context;

        public PhysiciansController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Physicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Physician>>> Getphysicians()
        {
            return await _context.physicians.ToListAsync();
        }

        // GET: api/Physicians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Physician>> GetPhysician(Guid id)
        {
            var physician = await _context.physicians.FindAsync(id);

            if (physician == null)
            {
                return NotFound();
            }

            return physician;
        }

        // PUT: api/Physicians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhysician(Guid id, Physician physician)
        {
            if (id != physician.Id)
            {
                return BadRequest();
            }

            _context.Entry(physician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhysicianExists(id))
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

        // POST: api/Physicians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Physician>> PostPhysician(Physician physician)
        {
            _context.physicians.Add(physician);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhysician), new { id = physician.Id }, physician);
        }

        // DELETE: api/Physicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhysician(Guid id)
        {
            var physician = await _context.physicians.FindAsync(id);
            if (physician == null)
            {
                return NotFound();
            }

            _context.physicians.Remove(physician);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhysicianExists(Guid id)
        {
            return _context.physicians.Any(e => e.Id == id);
        }
    }
}
