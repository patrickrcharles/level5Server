using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;

namespace mysql_scaffold_dbcontext_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Highscores1Controller : ControllerBase
    {
        private readonly Level5Context _context;

        public Highscores1Controller(Level5Context context)
        {
            _context = context;
        }

        // GET: api/Highscores1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighscores()
        {
            return await _context.Highscores.ToListAsync();
        }

        // GET: api/Highscores1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Highscores>> GetHighscores(int id)
        {
            var highscores = await _context.Highscores.FindAsync(id);

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        // PUT: api/Highscores1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighscores(int id, Highscores highscores)
        {
            if (id != highscores.Id)
            {
                return BadRequest();
            }

            _context.Entry(highscores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighscoresExists(id))
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

        // POST: api/Highscores1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Highscores>> PostHighscores(Highscores highscores)
        {
            System.Diagnostics.Debug.WriteLine("----- highscores : " + highscores);
            _context.Highscores.Add(highscores);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHighscores), new { id = highscores.Id }, highscores);
        }

        // DELETE: api/Highscores1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Highscores>> DeleteHighscores(int id)
        {
            var highscores = await _context.Highscores.FindAsync(id);
            if (highscores == null)
            {
                return NotFound();
            }

            _context.Highscores.Remove(highscores);
            await _context.SaveChangesAsync();

            return highscores;
        }

        private bool HighscoresExists(int id)
        {
            return _context.Highscores.Any(e => e.Id == id);
        }
    }
}
