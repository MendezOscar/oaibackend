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
    public class PlanDetalleController : ControllerBase
    {
        private readonly oaidbContext _context;

        public PlanDetalleController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/PlanDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanDetalle>>> GetPlanDetalle()
        {
            return await _context.PlanDetalle.ToListAsync();
        }

        // GET: api/PlanDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanDetalle>> GetPlanDetalle(int id)
        {
            var planDetalle = await _context.PlanDetalle.FindAsync(id);

            if (planDetalle == null)
            {
                return NotFound();
            }

            return planDetalle;
        }

        // PUT: api/PlanDetalle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanDetalle(int id, PlanDetalle planDetalle)
        {
            if (id != planDetalle.PlanDetalleId)
            {
                return BadRequest();
            }

            _context.Entry(planDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanDetalleExists(id))
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

        // POST: api/PlanDetalle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlanDetalle>> PostPlanDetalle(PlanDetalle planDetalle)
        {
            _context.PlanDetalle.Add(planDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanDetalle", new { id = planDetalle.PlanDetalleId }, planDetalle);
        }

        // DELETE: api/PlanDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanDetalle>> DeletePlanDetalle(int id)
        {
            var planDetalle = await _context.PlanDetalle.FindAsync(id);
            if (planDetalle == null)
            {
                return NotFound();
            }

            _context.PlanDetalle.Remove(planDetalle);
            await _context.SaveChangesAsync();

            return planDetalle;
        }

        private bool PlanDetalleExists(int id)
        {
            return _context.PlanDetalle.Any(e => e.PlanDetalleId == id);
        }
    }
}
