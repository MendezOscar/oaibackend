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
    public class PlanesController : ControllerBase
    {
        private readonly oaidbContext _context;

        public PlanesController(oaidbContext context)
        {
            _context = context;
        }

        // GET: api/Planes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planes>>> GetPlanes()
        {
            return await _context.Planes.ToListAsync();
        }

        // GET: api/Planes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planes>> GetPlanes(int id)
        {
            var planes = await _context.Planes.FindAsync(id);

            if (planes == null)
            {
                return NotFound();
            }

            return planes;
        }

        // PUT: api/Planes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanes(int id, Planes planes)
        {
            if (id != planes.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(planes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanesExists(id))
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

        // POST: api/Planes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Planes>> PostPlanes(Planes planes)
        {
            _context.Planes.Add(planes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanes", new { id = planes.PlanId }, planes);
        }

        // DELETE: api/Planes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Planes>> DeletePlanes(int id)
        {
            var planes = await _context.Planes.FindAsync(id);
            if (planes == null)
            {
                return NotFound();
            }

            _context.Planes.Remove(planes);
            await _context.SaveChangesAsync();

            return planes;
        }

        private bool PlanesExists(int id)
        {
            return _context.Planes.Any(e => e.PlanId == id);
        }
    }
}
