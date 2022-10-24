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
    public class PhysicianPatientsController : ControllerBase
    {
        private readonly DataContext _context;

        public PhysicianPatientsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PhysicianPatients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhysicianPatient>>> GetphysicianPatients()
        {
            return await _context.physicianPatients.ToListAsync();
        }

        // GET: api/PhysicianPatients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhysicianPatient>> GetPhysicianPatient(Guid id)
        {
            var physicianPatient = await _context.physicianPatients.FindAsync(id);

            if (physicianPatient == null)
            {
                return NotFound();
            }

            return physicianPatient;
        }

        // PUT: api/PhysicianPatients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhysicianPatient(Guid id, PhysicianPatient physicianPatient)
        {
            if (id != physicianPatient.Id)
            {
                return BadRequest();
            }

            _context.Entry(physicianPatient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhysicianPatientExists(id))
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

        // POST: api/PhysicianPatients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhysicianPatient>> PostPhysicianPatient(PhysicianPatient physicianPatient)
        {
            _context.physicianPatients.Add(physicianPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhysicianPatient), new { id = physicianPatient.Id }, physicianPatient);
        }

        // DELETE: api/PhysicianPatients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhysicianPatient(Guid id)
        {
            var physicianPatient = await _context.physicianPatients.FindAsync(id);
            if (physicianPatient == null)
            {
                return NotFound();
            }

            _context.physicianPatients.Remove(physicianPatient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhysicianPatientExists(Guid id)
        {
            return _context.physicianPatients.Any(e => e.Id == id);
        }
    }
}
