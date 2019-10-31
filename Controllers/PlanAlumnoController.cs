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
    public class PlanAlumnoController : ControllerBase
    {
        private readonly oaidbContext _context;

        public PlanAlumnoController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/PlanAlumno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanAlumno>>> GetPlanAlumno()
        {
            return await _context.PlanAlumno.ToListAsync();
        }

        // GET: api/PlanAlumno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanAlumno>> GetPlanAlumno(int id)
        {
            var planAlumno = await _context.PlanAlumno.FindAsync(id);

            if (planAlumno == null)
            {
                return NotFound();
            }

            return planAlumno;
        }

        // PUT: api/PlanAlumno/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanAlumno(int id, PlanAlumno planAlumno)
        {
            if (id != planAlumno.PlanAlumnoId)
            {
                return BadRequest();
            }

            _context.Entry(planAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanAlumnoExists(id))
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

        // POST: api/PlanAlumno
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlanAlumno>> PostPlanAlumno(PlanAlumno planAlumno)
        {
            _context.PlanAlumno.Add(planAlumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanAlumno", new { id = planAlumno.PlanAlumnoId }, planAlumno);
        }

        // DELETE: api/PlanAlumno/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanAlumno>> DeletePlanAlumno(int id)
        {
            var planAlumno = await _context.PlanAlumno.FindAsync(id);
            if (planAlumno == null)
            {
                return NotFound();
            }

            _context.PlanAlumno.Remove(planAlumno);
            await _context.SaveChangesAsync();

            return planAlumno;
        }

        private bool PlanAlumnoExists(int id)
        {
            return _context.PlanAlumno.Any(e => e.PlanAlumnoId == id);
        }
    }
}
