using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cc_turtle_manager.Data;
using cc_turtle_manager_lib.Model;
using cc_turtle_manager_lib.Context;
using cc_turtle_manager.Dtos;

namespace cc_turtle_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurtlesController : ControllerBase
    {
        private readonly IComputerContext _context;

        public TurtlesController(IComputerContext context)
        {
            _context = context;
        }

        // GET: api/Turtles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IComputer>>> GetTurtle() => Ok(await _context.GetComputersAsync());

        // GET: api/Turtles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turtle>> GetTurtle(int id)
        {
            var turtle = await _context.GetComputerAsync(id);

            if (turtle == null)
            {
                return NotFound();
            }

            return Ok(turtle);
        }

        // PUT: api/Turtles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurtle(int id, IComputer computer)
        {
            if (id != computer.ID)
            {
                return BadRequest();
            }
            
            try
            {
                await _context.UpdateComputerAsync(id, computer);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Turtles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IComputer>> PostTurtle([FromBody]CreateComputerDto computer)
        {
            var turtle = new Turtle(){
                ID = computer.ID
            };
            await _context.CreateComputerAsync(turtle);

            return CreatedAtAction(nameof(GetTurtle), new { id = computer.ID }, computer);
        }

        [HttpPut]
        [Route("{id}/inventory")]
        public async Task<ActionResult> UpdateInventory(int id, UpdateInventoryDto inventory)
        {
            var tInv = inventory.Inventory.Select( t=> new InventorySlot(){Name = t.Name, Count = t.Count, Slot = t.Slot});
                
            await _context.UpdateInventoryAsync(id, tInv);
            return NoContent();
        }

        // DELETE: api/Turtles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTurtle(int id)
        {
            await _context.DeleteComputerAsync(id);
            return NoContent();
        }
    }
}
