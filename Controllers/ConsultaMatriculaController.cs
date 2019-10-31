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
    public class ConsultaMatriculaController : ControllerBase
    {
        private readonly oaidbContext _context;

        public ConsultaMatriculaController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/ConsultaMatricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaMatricula>>> GetConsultaMatricula()
        {
            return await _context.ConsultaMatricula.ToListAsync();
        }

        // GET: api/ConsultaMatricula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaMatricula>> GetConsultaMatricula(int id)
        {
            var consultaMatricula = await _context.ConsultaMatricula.FindAsync(id);

            if (consultaMatricula == null)
            {
                return NotFound();
            }

            return consultaMatricula;
        }

        // PUT: api/ConsultaMatricula/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultaMatricula(int id, ConsultaMatricula consultaMatricula)
        {
            if (id != consultaMatricula.ConsultaMatriculaId)
            {
                return BadRequest();
            }

            _context.Entry(consultaMatricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaMatriculaExists(id))
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

        // POST: api/ConsultaMatricula
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ConsultaMatricula>> PostConsultaMatricula(ConsultaMatricula consultaMatricula)
        {
            _context.ConsultaMatricula.Add(consultaMatricula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultaMatricula", new { id = consultaMatricula.ConsultaMatriculaId }, consultaMatricula);
        }

        // DELETE: api/ConsultaMatricula/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsultaMatricula>> DeleteConsultaMatricula(int id)
        {
            var consultaMatricula = await _context.ConsultaMatricula.FindAsync(id);
            if (consultaMatricula == null)
            {
                return NotFound();
            }

            _context.ConsultaMatricula.Remove(consultaMatricula);
            await _context.SaveChangesAsync();

            return consultaMatricula;
        }

        private bool ConsultaMatriculaExists(int id)
        {
            return _context.ConsultaMatricula.Any(e => e.ConsultaMatriculaId == id);
        }
    }
}
