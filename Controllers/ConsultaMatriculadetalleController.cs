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
    public class ConsultaMatriculadetalleController : ControllerBase
    {
        private readonly oaidbContext _context;

        public ConsultaMatriculadetalleController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/ConsultaMatriculadetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaMatriculaDetalle>>> GetConsultaMatriculaDetalle()
        {
            return await _context.ConsultaMatriculaDetalle.ToListAsync();
        }

        [HttpGet("{matricula}/{alumno}")]
        public async Task<ActionResult<IEnumerable<ConsultaMatriculaDetalle>>> GetConsultaMatriculaDetalleByMatricula(int matricula, int alumno)
        {
             var bitacory = await _context.ConsultaMatriculaDetalle.Where(x => x.ConsultaMatriculaId == matricula && x.AlumnoId == alumno).ToListAsync();

            if (bitacory == null)
            {
                return NotFound();
            }

            return bitacory;
        }

        // GET: api/ConsultaMatriculadetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaMatriculaDetalle>> GetConsultaMatriculaDetalle(int id)
        {
            var consultaMatriculaDetalle = await _context.ConsultaMatriculaDetalle.FindAsync(id);

            if (consultaMatriculaDetalle == null)
            {
                return NotFound();
            }

            return consultaMatriculaDetalle;
        }

        // PUT: api/ConsultaMatriculadetalle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultaMatriculaDetalle(int id, ConsultaMatriculaDetalle consultaMatriculaDetalle)
        {
            if (id != consultaMatriculaDetalle.ConsultaMatriculaDetalleId)
            {
                return BadRequest();
            }

            _context.Entry(consultaMatriculaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaMatriculaDetalleExists(id))
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

        // POST: api/ConsultaMatriculadetalle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ConsultaMatriculaDetalle>> PostConsultaMatriculaDetalle(ConsultaMatriculaDetalle consultaMatriculaDetalle)
        {
            _context.ConsultaMatriculaDetalle.Add(consultaMatriculaDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultaMatriculaDetalle", new { id = consultaMatriculaDetalle.ConsultaMatriculaDetalleId }, consultaMatriculaDetalle);
        }

        // DELETE: api/ConsultaMatriculadetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsultaMatriculaDetalle>> DeleteConsultaMatriculaDetalle(int id)
        {
            var consultaMatriculaDetalle = await _context.ConsultaMatriculaDetalle.FindAsync(id);
            if (consultaMatriculaDetalle == null)
            {
                return NotFound();
            }

            _context.ConsultaMatriculaDetalle.Remove(consultaMatriculaDetalle);
            await _context.SaveChangesAsync();

            return consultaMatriculaDetalle;
        }

        private bool ConsultaMatriculaDetalleExists(int id)
        {
            return _context.ConsultaMatriculaDetalle.Any(e => e.ConsultaMatriculaDetalleId == id);
        }
    }
}
