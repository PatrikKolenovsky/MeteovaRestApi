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
    public class VariablesController : ControllerBase
    {
        private readonly Sg1Context _context;

        public VariablesController(Sg1Context context)
        {
            _context = context;
        }

        // GET: api/Variables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variable>>> GetVariable()
        {
            return await _context.Variable.ToListAsync();
        }

        // GET: api/Variables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Variable>> GetVariable(int id)
        {
            var variable = await _context.Variable.FindAsync(id);

            if (variable == null)
            {
                return NotFound();
            }

            return variable;
        }

        // PUT: api/Variables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariable(int id, Variable variable)
        {
            if (id != variable.VariableId)
            {
                return BadRequest();
            }

            _context.Entry(variable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariableExists(id))
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

        // POST: api/Variables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Variable>> PostVariable(Variable variable)
        {
            _context.Variable.Add(variable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariable", new { id = variable.VariableId }, variable);
        }

        // DELETE: api/Variables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Variable>> DeleteVariable(int id)
        {
            var variable = await _context.Variable.FindAsync(id);
            if (variable == null)
            {
                return NotFound();
            }

            _context.Variable.Remove(variable);
            await _context.SaveChangesAsync();

            return variable;
        }

        private bool VariableExists(int id)
        {
            return _context.Variable.Any(e => e.VariableId == id);
        }
    }
}
