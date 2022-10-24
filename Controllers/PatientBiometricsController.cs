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
    public class PatientBiometricsController : ControllerBase
    {
        private readonly DataContext _context;

        public PatientBiometricsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PatientBiometrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientBiometrics>>> GetpatientBiometrics()
        {
            return await _context.patientBiometrics.ToListAsync();
        }

        // GET: api/PatientBiometrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientBiometrics>> GetPatientBiometrics(Guid id)
        {
            var patientBiometrics = await _context.patientBiometrics.FindAsync(id);

            if (patientBiometrics == null)
            {
                return NotFound();
            }

            return patientBiometrics;
        }

        // PUT: api/PatientBiometrics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientBiometrics(Guid id, PatientBiometrics patientBiometrics)
        {
            if (id != patientBiometrics.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientBiometrics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientBiometricsExists(id))
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

        // POST: api/PatientBiometrics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientBiometrics>> PostPatientBiometrics(PatientBiometrics patientBiometrics)
        {
            _context.patientBiometrics.Add(patientBiometrics);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientBiometrics), new { id = patientBiometrics.Id }, patientBiometrics);
        }

        // DELETE: api/PatientBiometrics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientBiometrics(Guid id)
        {
            var patientBiometrics = await _context.patientBiometrics.FindAsync(id);
            if (patientBiometrics == null)
            {
                return NotFound();
            }

            _context.patientBiometrics.Remove(patientBiometrics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientBiometricsExists(Guid id)
        {
            return _context.patientBiometrics.Any(e => e.Id == id);
        }
    }
}
