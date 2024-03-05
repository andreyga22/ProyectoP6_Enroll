using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoP6_Enroll.Models;

namespace ProyectoP6_Enroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayementsController : ControllerBase
    {
        private readonly Proyectop62024Context _context;

        public PayementsController(Proyectop62024Context context)
        {
            _context = context;
        }

        // GET: api/Payements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payement>>> GetPayements()
        {
            return await _context.Payements.ToListAsync();
        }

        // GET: api/Payements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payement>> GetPayement(int id)
        {
            var payement = await _context.Payements.FindAsync(id);

            if (payement == null)
            {
                return NotFound();
            }

            return payement;
        }
        // prueba #2 

        // PUT: api/Payements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayement(int id, Payement payement)
        {
            if (id != payement.Id)
            {
                return BadRequest();
            }

            _context.Entry(payement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayementExists(id))
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

        // POST: api/Payements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payement>> PostPayement(Payement payement)
        {
            _context.Payements.Add(payement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayement", new { id = payement.Id }, payement);
        }

        // DELETE: api/Payements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayement(int id)
        {
            var payement = await _context.Payements.FindAsync(id);
            if (payement == null)
            {
                return NotFound();
            }

            _context.Payements.Remove(payement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayementExists(int id)
        {
            return _context.Payements.Any(e => e.Id == id);
        }
    }
}
