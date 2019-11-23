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
    public class OfertaAcademicaDetalleController : ControllerBase
    {
        private readonly oaidbContext _context;

        public OfertaAcademicaDetalleController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/OfertaAcademicaDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaAcademicaDetalle>>> GetOfertaAcademicaDetalle()
        {
            return await _context.OfertaAcademicaDetalle.ToListAsync();
        }

        [HttpGet("get-by-oferta{oferta}")]
        public async Task<ActionResult<IEnumerable<OfertaAcademicaDetalle>>> GetConsultaMatriculaDetalleByMatricula(int oferta)
        {
             var bitacory = await _context.OfertaAcademicaDetalle.Where(x => x.OfertaAcademicaId == oferta).ToListAsync();

            if (bitacory == null)
            {
                return NotFound();
            }

            return bitacory;
        }

        // GET: api/OfertaAcademicaDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaAcademicaDetalle>> GetOfertaAcademicaDetalle(int id)
        {
            var ofertaAcademicaDetalle = await _context.OfertaAcademicaDetalle.FindAsync(id);

            if (ofertaAcademicaDetalle == null)
            {
                return NotFound();
            }

            return ofertaAcademicaDetalle;
        }

        // PUT: api/OfertaAcademicaDetalle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfertaAcademicaDetalle(int id, OfertaAcademicaDetalle ofertaAcademicaDetalle)
        {
            if (id != ofertaAcademicaDetalle.OfertaAcademicaDetalleId)
            {
                return BadRequest();
            }

            _context.Entry(ofertaAcademicaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaAcademicaDetalleExists(id))
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

        // POST: api/OfertaAcademicaDetalle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OfertaAcademicaDetalle>> PostOfertaAcademicaDetalle(OfertaAcademicaDetalle ofertaAcademicaDetalle)
        {
            _context.OfertaAcademicaDetalle.Add(ofertaAcademicaDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfertaAcademicaDetalle", new { id = ofertaAcademicaDetalle.OfertaAcademicaDetalleId }, ofertaAcademicaDetalle);
        }

        // DELETE: api/OfertaAcademicaDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OfertaAcademicaDetalle>> DeleteOfertaAcademicaDetalle(int id)
        {
            var ofertaAcademicaDetalle = await _context.OfertaAcademicaDetalle.FindAsync(id);
            if (ofertaAcademicaDetalle == null)
            {
                return NotFound();
            }

            _context.OfertaAcademicaDetalle.Remove(ofertaAcademicaDetalle);
            await _context.SaveChangesAsync();

            return ofertaAcademicaDetalle;
        }

        private bool OfertaAcademicaDetalleExists(int id)
        {
            return _context.OfertaAcademicaDetalle.Any(e => e.OfertaAcademicaDetalleId == id);
        }
    }
}
