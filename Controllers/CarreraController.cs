using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oaibackend.Models;

namespace oaibackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly oaidbContext _context;

        public CarreraController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarrera()
        {
            return await _context.Carrera.ToListAsync();
        }

        // GET: api/Carrera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(int id)
        {
            var carrera = await _context.Carrera.FindAsync(id);

            if (carrera == null)
            {
                return NotFound();
            }

            return carrera;
        }

        // PUT: api/Carrera/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, Carrera carrera)
        {
            if (id != carrera.CarreraId)
            {
                return BadRequest();
            }

            _context.Entry(carrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarreraExists(id))
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

        // POST: api/Carrera
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
        {
            _context.Carrera.Add(carrera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrera", new { id = carrera.CarreraId }, carrera);
        }

        // DELETE: api/Carrera/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carrera>> DeleteCarrera(int id)
        {
            var carrera = await _context.Carrera.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }

            _context.Carrera.Remove(carrera);
            await _context.SaveChangesAsync();

            return carrera;
        }

        private bool CarreraExists(int id)
        {
            return _context.Carrera.Any(e => e.CarreraId == id);
        }
    }
}
