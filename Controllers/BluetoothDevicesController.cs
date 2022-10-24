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
    public class BluetoothDevicesController : ControllerBase
    {
        private readonly DataContext _context;

        public BluetoothDevicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BluetoothDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BluetoothDevice>>> GetbluetoothDevices()
        {
            return await _context.bluetoothDevices.ToListAsync();
        }

        // GET: api/BluetoothDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BluetoothDevice>> GetBluetoothDevice(Guid id)
        {
            var bluetoothDevice = await _context.bluetoothDevices.FindAsync(id);

            if (bluetoothDevice == null)
            {
                return NotFound();
            }

            return bluetoothDevice;
        }

        // PUT: api/BluetoothDevices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBluetoothDevice(Guid id, BluetoothDevice bluetoothDevice)
        {
            if (id != bluetoothDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(bluetoothDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BluetoothDeviceExists(id))
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

        // POST: api/BluetoothDevices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BluetoothDevice>> PostBluetoothDevice(BluetoothDevice bluetoothDevice)
        {
            _context.bluetoothDevices.Add(bluetoothDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBluetoothDevice), new { id = bluetoothDevice.Id }, bluetoothDevice);
        }

        // DELETE: api/BluetoothDevices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBluetoothDevice(Guid id)
        {
            var bluetoothDevice = await _context.bluetoothDevices.FindAsync(id);
            if (bluetoothDevice == null)
            {
                return NotFound();
            }

            _context.bluetoothDevices.Remove(bluetoothDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BluetoothDeviceExists(Guid id)
        {
            return _context.bluetoothDevices.Any(e => e.Id == id);
        }
    }
}
