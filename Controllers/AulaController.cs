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
    public class AulaController : ControllerBase
    {
        private readonly oaidbContext _context;

        public AulaController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/Aula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aula>>> GetAula()
        {
            return await _context.Aula.ToListAsync();
        }

        // GET: api/Aula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aula>> GetAula(int id)
        {
            var aula = await _context.Aula.FindAsync(id);

            if (aula == null)
            {
                return NotFound();
            }

            return aula;
        }

        // PUT: api/Aula/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAula(int id, Aula aula)
        {
            if (id != aula.AulaId)
            {
                return BadRequest();
            }

            _context.Entry(aula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AulaExists(id))
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

        // POST: api/Aula
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Aula>> PostAula(Aula aula)
        {
            _context.Aula.Add(aula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAula", new { id = aula.AulaId }, aula);
        }

        // DELETE: api/Aula/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aula>> DeleteAula(int id)
        {
            var aula = await _context.Aula.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }

            _context.Aula.Remove(aula);
            await _context.SaveChangesAsync();

            return aula;
        }

        private bool AulaExists(int id)
        {
            return _context.Aula.Any(e => e.AulaId == id);
        }
    }
}
