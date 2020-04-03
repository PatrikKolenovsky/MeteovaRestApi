using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;

namespace MeteovaRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValintsController : ControllerBase
    {
        private readonly Sg1Context _context;

        public ValintsController(Sg1Context context)
        {
            _context = context;
        }

        // GET: api/Valints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Valint>>> GetValint()
        {
            return await _context.Valint.ToListAsync();
        }

        // GET: api/Valints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Valint>> GetValint(long id)
        {
            var valint = await _context.Valint.FindAsync(id);

            if (valint == null)
            {
                return NotFound();
            }

            return valint;
        }

        // PUT: api/Valints/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValint(long id, Valint valint)
        {
            if (id != valint.ValIntId)
            {
                return BadRequest();
            }

            _context.Entry(valint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValintExists(id))
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

        // POST: api/Valints
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Valint>> PostValint(Valint valint)
        {
            _context.Valint.Add(valint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValint", new { id = valint.ValIntId }, valint);
        }

        // DELETE: api/Valints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Valint>> DeleteValint(long id)
        {
            var valint = await _context.Valint.FindAsync(id);
            if (valint == null)
            {
                return NotFound();
            }

            _context.Valint.Remove(valint);
            await _context.SaveChangesAsync();

            return valint;
        }

        private bool ValintExists(long id)
        {
            return _context.Valint.Any(e => e.ValIntId == id);
        }
    }
}
