using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_tarefas.Contextos;
using api_tarefas.Model;

namespace api_tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasItemsController : ControllerBase
    {
        private readonly TarefaContexto _context;

        public TarefasItemsController(TarefaContexto context)
        {
            _context = context;
        }

        // GET: api/TarefasItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefasItem>>> GetTarefas()
        {
          if (_context.Tarefas == null)
          {
              return NotFound();
          }
            return await _context.Tarefas.ToListAsync();
        }

        // GET: api/TarefasItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefasItem>> GetTarefasItem(long id)
        {
          if (_context.Tarefas == null)
          {
              return NotFound();
          }
            var tarefasItem = await _context.Tarefas.FindAsync(id);

            if (tarefasItem == null)
            {
                return NotFound();
            }

            return tarefasItem;
        }

        // PUT: api/TarefasItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefasItem(long id, TarefasItem tarefasItem)
        {
            if (id != tarefasItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefasItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefasItemExists(id))
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

        // POST: api/TarefasItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TarefasItem>> PostTarefasItem(TarefasItem tarefasItem)
        {
          if (_context.Tarefas == null)
          {
              return Problem("Entity set 'TarefaContexto.Tarefas'  is null.");
          }
            _context.Tarefas.Add(tarefasItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefasItem", new { id = tarefasItem.Id }, tarefasItem);
        }

        // DELETE: api/TarefasItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefasItem(long id)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefasItem = await _context.Tarefas.FindAsync(id);
            if (tarefasItem == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefasItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefasItemExists(long id)
        {
            return (_context.Tarefas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
