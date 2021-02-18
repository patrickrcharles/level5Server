
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace mysql_scaffold_dbcontext_test.Controllers
{
    //[Authorize]
    [Route("api/highscores")]
    [ApiController]
    public class HighscoresApiController : Controller
    {
        private readonly DatabaseContext _context;

        public HighscoresApiController(DatabaseContext context)
        {
            _context = context;
        }

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/highscores
        // get all highscores
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetAllHighscores()
        {
            return await _context.Highscores.ToListAsync();
        }

        //--------------------- HTTP GET  Platform ---------------------------------------------------
        // GET: /api/highscores/modeid/1
        // highscores by modeid 
        [HttpGet("platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByPlatform(string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }
        public IEnumerable<string> GetColumn(List<Highscores> items, string columnName)
        {
            var values = items.Select(x => x.GetType().GetProperty(columnName).GetValue(x).ToString());
            return values;
        }

        //--------------------- HTTP GET  Modeid ---------------------------------------------------
        // GET: /api/highscores/modeid/1
        // highscores by modeid 
        [HttpGet("modeid/{modeid}/{field}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetHighScoreByModeId(int modeid, string field)
        {
            ActionResult<IEnumerable<Object>> list = null;

            // totalpoints highscore
            if (modeid == 1 || (modeid > 14 && modeid < 20))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid)
                    .Select(x => new { x.TotalPoints, x.Character, x.Level, x.Date, x.Time })
                    .OrderByDescending(x => x.TotalPoints)
                    .ToListAsync();
                list = highscores;
            }
            // maxshotmade highscore
            if ((modeid > 1 && modeid < 5))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid)
                    .Select(x => new { x.MaxShotMade, x.Character, x.Level, x.Date, x.Time })
                    .OrderByDescending(x => x.MaxShotMade)
                    .ToListAsync();
                list = highscores;
            }
            // totaldistance highscore
            if (modeid == 6)
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid)
                    .Select(x => new
                    {
                        x.TotalDistance,
                        x.Character,
                        x.Level,
                        x.Date,
                        x.Time
                    })
                    .OrderByDescending(x => x.TotalDistance)
                    .ToListAsync();

                list = highscores;
            }
            if ((modeid > 6 && modeid < 10))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid)
                    .Select(x => new
                    {
                        x.Time,
                        x.Character,
                        x.Level,
                        x.Date
                    })
                    .OrderBy(field, "DESC")
                    .ToListAsync();

                list = highscores;
            }
            if (list == null)
            {
                return NotFound();
            }
            return list;
        }


        // GET: /api/highscores/modeid/1/userid/1
        // highscores by modeid + userid
        [HttpGet("modeid/{modeid}/userid/{userid}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdUserId(int modeid, int userid)
        {
            var highscores = await _context.Highscores.Where(x => x.Modeid == modeid && x.Userid == userid).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }
        // GET: /api/highscores/modeid/1/platform/1
        // highscores by modeid + platform
        [HttpGet("modeid/{modeid}/platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdPlatform(int modeid, string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        // GET: /api/highscores/modeid/1/platform/1
        // all highscores by modeid + platform
        [HttpGet("modeid/{modeid}/hardcore/{hardcore}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdHardcore(int modeid, int hardcore)
        {
            var highscores = await _context.Highscores.Where(x => x.HardcoreEnabled == hardcore).ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        //--------------------- HTTP GET  Scoreid ---------------------------------------------------
        // GET: /api/highscores/scoreid/{scoreid}
        // all highscores by unique scoreid
        [HttpGet("scoreid/{scoreid}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByScoreId(string scoreid)
        {
            System.Diagnostics.Debug.WriteLine("---------- scoreid : " + scoreid);
            var highscores = await _context.Highscores.Where(x => x.Scoreid == scoreid).ToListAsync();

            if (!ScoreIdExists(scoreid))
            {
                System.Diagnostics.Debug.WriteLine("---------- scoreid NOT FOUND: " + scoreid);
                return NotFound();
            }

            return highscores;
        }

        //--------------------- HTTP PUT ---------------------------------------------------
        // PUT: api/Highscores/scoreid/5
        // "insert, replace if already exists"
        [HttpPut("scoreid/{scoreid}")]
        public async Task<IActionResult> PutHighscore(string scoreid, Highscores highscores)
        {
            System.Diagnostics.Debug.WriteLine("----- scoreid : " + scoreid);
            System.Diagnostics.Debug.WriteLine("----- highscores.Scoreid : " + highscores.Scoreid);
            //highscores.Id = GetDatabaseIdByScoreId(scoreid);

            System.Diagnostics.Debug.WriteLine("----- highscores.Id : " + highscores.Id);

            if (scoreid != highscores.Scoreid)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : BAD REQUEST : \n" +
                    scoreid + " NOT EQUAL to " + highscores.Scoreid);
                return BadRequest();
            }

            _context.Entry(highscores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                System.Diagnostics.Debug.WriteLine("----- SERVER : scoreid modified : " + scoreid);
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : ERROR : " + e);
                //System.Diagnostics.Debug.WriteLine("----- SERVER : scoreid not found : " + scoreid);
                if (!ScoreIdExists(scoreid))
                {
                    System.Diagnostics.Debug.WriteLine("----- SERVER : scoreid not found : " + scoreid);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //--------------------- HTTP POST ---------------------------------------------------
        // POST: api/Highscores
        // "create new"
        [HttpPost]
        public async Task<ActionResult<Highscores>> PostHighscore(Highscores highscores)
        {
            System.Diagnostics.Debug.WriteLine("----- highscores : " + highscores);
            System.Diagnostics.Debug.WriteLine("----- bonus : " + highscores.BonusPoints);
            System.Diagnostics.Debug.WriteLine("----- MBmade : " + highscores.MoneyBallMade);
            System.Diagnostics.Debug.WriteLine("----- MBatt : " + highscores.MoneyBallAtt);

            _context.Highscores.Add(highscores);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllHighscores), new { id = highscores.Id }, highscores);
        }

        //--------------------- HTTP DELETE ---------------------------------------------------
        // DELETE: api/Highscores1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Highscores>> DeleteHighscore(int id)
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

        //--------------------- UTILITY FUNCTIONS ---------------------------------------------------
        //private bool HighscoreExists(string scoreid)
        //{
        //    return _context.Highscores.Any(e => e.Scoreid == scoreid);
        //}

        private int GetDatabaseIdByScoreId(string scoreid)
        {
            int id = _context.Highscores.Where(e => e.Scoreid == scoreid).FirstOrDefault().Id;
            System.Diagnostics.Debug.WriteLine("----- GetDatabaseIdByScoreId : " + id);

            return id;
        }

        private bool ScoreIdExists(string scoreid)
        {
            return _context.Highscores.Any(e => e.Scoreid == scoreid);
        }


        private bool PlatformExists(string platform)
        {
            return _context.Highscores.Any(e => e.Platform == platform);
        }
    }
}
