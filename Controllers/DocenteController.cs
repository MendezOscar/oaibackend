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
    public class DocenteController : ControllerBase
    {
        private readonly oaidbContext _context;

        public DocenteController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/Docente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docente>>> GetDocente()
        {
            return await _context.Docente.ToListAsync();
        }

        // GET: api/Docente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> GetDocente(int id)
        {
            var docente = await _context.Docente.FindAsync(id);

            if (docente == null)
            {
                return NotFound();
            }

            return docente;
        }

        // PUT: api/Docente/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocente(int id, Docente docente)
        {
            if (id != docente.DocenteId)
            {
                return BadRequest();
            }

            _context.Entry(docente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocenteExists(id))
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

        // POST: api/Docente
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Docente>> PostDocente(Docente docente)
        {
            _context.Docente.Add(docente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocente", new { id = docente.DocenteId }, docente);
        }

        // DELETE: api/Docente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Docente>> DeleteDocente(int id)
        {
            var docente = await _context.Docente.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }

            _context.Docente.Remove(docente);
            await _context.SaveChangesAsync();

            return docente;
        }

        private bool DocenteExists(int id)
        {
            return _context.Docente.Any(e => e.DocenteId == id);
        }
    }
}
