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
    [Route("api/highscores")]
    [ApiController]
    public class HighscoresApiController : ControllerBase
    {
        private readonly Level5Context _context;

        public HighscoresApiController(Level5Context context)
        {
            _context = context;
        }

        // GET: /api/highscores
        // get all highscores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighscores()
        {
            return await _context.Highscores.ToListAsync();
        }

        // GET: /api/highscores/modeid/1
        // highscores by modeid 
        [HttpGet("modeid/{modeid}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetByModeId(int modeid)
        {
            var highscores = await _context.Highscores.Where(x => x.Modeid == modeid).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        // GET: /api/highscores/modeid/1/userid/1
        // highscores by modeid + userid
        [HttpGet("modeid/{modeid}/userid/{userid}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetByModeIdUserId(int modeid, int userid)
        {
            var highscores = await _context.Highscores.Where(x => x.Modeid == modeid && x.Userid == userid ).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }
        // GET: /api/highscores/modeid/1/platform/1
        // highscores by modeid + platform
        [HttpGet("modeid/{modeid}/platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetByModeIdPlatform(int modeid, string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        // GET: /api/highscores/modeid/1/platform/1
        // highscores by modeid + platform
        [HttpGet("modeid/{modeid}/hardcore/{hardcore}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetByModeIdHardcore(int modeid, int hardcore)
        {
            var highscores = await _context.Highscores.Where(x => x.HardcoreEnabled == hardcore).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        // PUT: api/Highscores1/5
        // "insert, replace if already exists"
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

        // POST: api/Highscores
        // "create new"
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
