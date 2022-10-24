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
    public class PracticesController : ControllerBase
    {
        private readonly DataContext _context;

        public PracticesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Practices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practice>>> Getpractices()
        {
            return await _context.practices.ToListAsync();
        }

        // GET: api/Practices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practice>> GetPractice(Guid id)
        {
            var practice = await _context.practices.FindAsync(id);

            if (practice == null)
            {
                return NotFound();
            }

            return practice;
        }

        // PUT: api/Practices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPractice(Guid id, Practice practice)
        {
            if (id != practice.Id)
            {
                return BadRequest();
            }

            _context.Entry(practice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracticeExists(id))
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

        // POST: api/Practices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Practice>> PostPractice(Practice practice)
        {
            _context.practices.Add(practice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPractice), new { id = practice.Id }, practice);
        }

        // DELETE: api/Practices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePractice(Guid id)
        {
            var practice = await _context.practices.FindAsync(id);
            if (practice == null)
            {
                return NotFound();
            }

            _context.practices.Remove(practice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracticeExists(Guid id)
        {
            return _context.practices.Any(e => e.Id == id);
        }
    }
}
