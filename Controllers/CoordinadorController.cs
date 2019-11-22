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
    public class CoordinadorController : ControllerBase
    {
        private readonly oaidbContext _context;

        public CoordinadorController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/Coordinador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordinador>>> GetCoordinador()
        {
            return await _context.Coordinador.ToListAsync();
        }

        // GET: api/Coordinador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coordinador>> GetCoordinador(int id)
        {
            var coordinador = await _context.Coordinador.FindAsync(id);

            if (coordinador == null)
            {
                return NotFound();
            }

            return coordinador;
        }

        [HttpGet("{cuenta}/{clave}")]
        public async Task<ActionResult<Coordinador>> GetBitacoryByDate(string cuenta, string clave)
        {
            var bitacory = await _context.Coordinador.SingleOrDefaultAsync(x => x.Cuenta == cuenta && x.Clave == clave);

            if (bitacory == null)
            {
                return NotFound();
            }

            return bitacory;
        }

        // PUT: api/Coordinador/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordinador(int id, Coordinador coordinador)
        {
            if (id != coordinador.CoordinadorId)
            {
                return BadRequest();
            }

            _context.Entry(coordinador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordinadorExists(id))
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

        // POST: api/Coordinador
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Coordinador>> PostCoordinador(Coordinador coordinador)
        {
            _context.Coordinador.Add(coordinador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordinador", new { id = coordinador.CoordinadorId }, coordinador);
        }

        // DELETE: api/Coordinador/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coordinador>> DeleteCoordinador(int id)
        {
            var coordinador = await _context.Coordinador.FindAsync(id);
            if (coordinador == null)
            {
                return NotFound();
            }

            _context.Coordinador.Remove(coordinador);
            await _context.SaveChangesAsync();

            return coordinador;
        }

        private bool CoordinadorExists(int id)
        {
            return _context.Coordinador.Any(e => e.CoordinadorId == id);
        }
    }
}
