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
    public class OfertaAcademicaController : ControllerBase
    {
        private readonly oaidbContext _context;

        public OfertaAcademicaController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/OfertaAcademica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaAcademica>>> GetOfertaAcademica()
        {
            return await _context.OfertaAcademica.ToListAsync();
        }

        // GET: api/OfertaAcademica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaAcademica>> GetOfertaAcademica(int id)
        {
            var ofertaAcademica = await _context.OfertaAcademica.FindAsync(id);

            if (ofertaAcademica == null)
            {
                return NotFound();
            }

            return ofertaAcademica;
        }

        // PUT: api/OfertaAcademica/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfertaAcademica(int id, OfertaAcademica ofertaAcademica)
        {
            if (id != ofertaAcademica.OfertaId)
            {
                return BadRequest();
            }

            _context.Entry(ofertaAcademica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaAcademicaExists(id))
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

        // POST: api/OfertaAcademica
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OfertaAcademica>> PostOfertaAcademica(OfertaAcademica ofertaAcademica)
        {
            _context.OfertaAcademica.Add(ofertaAcademica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfertaAcademica", new { id = ofertaAcademica.OfertaId }, ofertaAcademica);
        }

        // DELETE: api/OfertaAcademica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfertaAcademica>> DeleteOfertaAcademica(int id)
        {
            var ofertaAcademica = await _context.OfertaAcademica.FindAsync(id);
            if (ofertaAcademica == null)
            {
                return NotFound();
            }

            _context.OfertaAcademica.Remove(ofertaAcademica);
            await _context.SaveChangesAsync();

            return ofertaAcademica;
        }

        private bool OfertaAcademicaExists(int id)
        {
            return _context.OfertaAcademica.Any(e => e.OfertaId == id);
        }
    }
}
