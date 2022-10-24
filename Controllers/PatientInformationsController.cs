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
    public class PatientInformationsController : ControllerBase
    {
        private readonly DataContext _context;

        public PatientInformationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PatientInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientInformation>>> GetpatientsInformation()
        {
            return await _context.patientsInformation.ToListAsync();
        }

        // GET: api/PatientInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientInformation>> GetPatientInformation(Guid id)
        {
            var patientInformation = await _context.patientsInformation.FindAsync(id);

            if (patientInformation == null)
            {
                return NotFound();
            }

            return patientInformation;
        }

        // PUT: api/PatientInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientInformation(Guid id, PatientInformation patientInformation)
        {
            if (id != patientInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientInformationExists(id))
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

        // POST: api/PatientInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientInformation>> PostPatientInformation(PatientInformation patientInformation)
        {
            _context.patientsInformation.Add(patientInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientInformation), new { id = patientInformation.Id }, patientInformation);
        }

        // DELETE: api/PatientInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientInformation(Guid id)
        {
            var patientInformation = await _context.patientsInformation.FindAsync(id);
            if (patientInformation == null)
            {
                return NotFound();
            }

            _context.patientsInformation.Remove(patientInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientInformationExists(Guid id)
        {
            return _context.patientsInformation.Any(e => e.Id == id);
        }
    }
}
