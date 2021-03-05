
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
            return await _context.Highscores.OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        //--------------------- HTTP GET  Platform ---------------------------------------------------
        // GET: /api/highscores/modeid/1
        // highscores by modeid 
        [HttpGet("platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByPlatform(string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        //--------------------- HTTP GET  Modeid by Userid ---------------------------------------------------
        // GET: /api/highscores/modeid/1/userid/1
        // highscores by modeid + userid
        [HttpGet("modeid/{modeid}/userid/{userid}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdUserId(int modeid, int userid)
        {
            var highscores = await _context.Highscores.Where(x => x.Modeid == modeid && x.Userid == userid)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }
        //--------------------- HTTP GET Modeid by Platform ---------------------------------------------------
        // GET: /api/highscores/modeid/1/platform/1
        // highscores by modeid + platform
        [HttpGet("modeid/{modeid}/platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdPlatform(int modeid, string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        //--------------------- HTTP GET  Modeid by Modeid ---------------------------------------------------
        // GET: /api/highscores/modeid/{modeid}?hardcore={int}&traffic={int}&enemies={int}
        // highscores by modeid with optiona; filters by hardcore, traffic, enemies
        [HttpGet("modeid/{modeid}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetHighScoreByModeIdForGameDisplay(int modeid,
            int hardcore,
            int traffic,
            int enemies,
            int page,
            int results)
        {
            ActionResult<IEnumerable<Object>> list = null;
            // totalpoints highscore
            if (modeid == 1 || (modeid > 14 && modeid < 20))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid
                    && x.HardcoreEnabled == hardcore
                    && x.TrafficEnabled == traffic
                    && x.EnemiesEnabled == enemies)
                    .Select(x => new
                    {
                        Score = x.TotalPoints.ToString(),
                        x.Character,
                        x.Level,
                        x.Date,
                        Time = x.Time.ToString(),
                        UserId = x.Userid.ToString(),
                        x.TotalPoints,
                        x.UserName,
                        x.HardcoreEnabled,
                        x.EnemiesEnabled,
                        x.TrafficEnabled,
                        x.EnemiesKilled,
                        x.Platform
                    })
                    .OrderByDescending(x => x.TotalPoints)
                    .Skip(page * 10)
                    .Take(results)
                    .ToListAsync();
                list = highscores;
            }
            // maxshotmade highscore
            if ((modeid > 1 && modeid < 5))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid
                    && x.HardcoreEnabled == hardcore
                    && x.TrafficEnabled == traffic
                    && x.EnemiesEnabled == enemies)
                    .Select(x => new
                    {
                        Score = x.MaxShotMade.ToString(),
                        x.Character,
                        x.Level,
                        x.Date,
                        Time = x.Time.ToString(),
                        UserId = x.Userid.ToString(),
                        x.MaxShotMade,
                        x.UserName,
                        x.HardcoreEnabled,
                        x.EnemiesEnabled,
                        x.TrafficEnabled,
                        x.EnemiesKilled,
                        x.Platform
                    })
                    .OrderByDescending(x => x.MaxShotMade)
                    .Skip(page * 10)
                    .Take(results)
                    .ToListAsync();
                list = highscores;
            }
            // totaldistance highscore
            if (modeid == 6)
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid
                    && x.HardcoreEnabled == hardcore
                    && x.TrafficEnabled == traffic
                    && x.EnemiesEnabled == enemies)
                    .Select(x => new
                    {
                        Score = x.TotalDistance.ToString(),
                        x.Character,
                        x.Level,
                        x.Date,
                        Time = x.Time.ToString(),
                        UserId = x.Userid.ToString(),
                        x.TotalDistance,
                        x.UserName,
                        x.HardcoreEnabled,
                        x.EnemiesEnabled,
                        x.TrafficEnabled,
                        x.EnemiesKilled,
                        x.Platform
                    })
                    .OrderByDescending(x => x.TotalDistance)
                    .Skip(page * 10)
                    .Take(results)
                    .ToListAsync();

                list = highscores;
            }
            // time highscore
            if ((modeid > 6 && modeid < 10))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid
                    && x.HardcoreEnabled == hardcore
                    && x.TrafficEnabled == traffic
                    && x.EnemiesEnabled == enemies)
                    .Select(x => new
                    {
                        Score = x.Time.ToString(),
                        x.Character,
                        x.Level,
                        x.Date,
                        x.Time,
                        UserId = x.Userid.ToString(),
                        x.UserName,
                        x.HardcoreEnabled,
                        x.EnemiesEnabled,
                        x.TrafficEnabled,
                        x.EnemiesKilled,
                        x.Platform
                    })
                    .OrderBy(x => x.Time)
                    .Skip(page * 10)
                    .Take(results)
                    .ToListAsync();
                list = highscores;
            }

            // consecutive shots highscore
            if (modeid == 14)
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid
                    && x.HardcoreEnabled == hardcore
                    && x.TrafficEnabled == traffic
                    && x.EnemiesEnabled == enemies)
                    .Select(x => new
                    {
                        Score = x.ConsecutiveShots.ToString(),
                        x.Character,
                        x.Level,
                        x.Date,
                        Time = x.Time.ToString(),
                        UserId = x.Userid.ToString(),
                        x.ConsecutiveShots,
                        x.UserName,
                        x.EnemiesEnabled,
                        x.HardcoreEnabled,
                        x.TrafficEnabled,
                        x.EnemiesKilled,
                        x.Platform
                    })
                    .OrderByDescending(x => x.ConsecutiveShots)
                    .Skip(page * 10)
                    .Take(results)
                    .ToListAsync();
                list = highscores;
            }

            // enemies killed highscore
            if (modeid == 20)
            {
                var usernames = await _context.Users.Select(x => new { x.Userid, x.Username }).ToListAsync();

                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid
                    && x.HardcoreEnabled == hardcore
                    && x.TrafficEnabled == traffic
                    && x.EnemiesEnabled == enemies)
                    .Select(x => new
                    {
                        Score = x.EnemiesKilled.ToString(),
                        x.Character,
                        x.Level,
                        x.Date,
                        Time = x.Time.ToString(),
                        UserId = x.Userid.ToString(),
                        x.UserName,
                        x.HardcoreEnabled,
                        x.EnemiesEnabled,
                        x.TrafficEnabled,
                        x.EnemiesKilled,
                        x.Platform
                    })
                    .OrderByDescending(x => x.EnemiesKilled)
                    .Skip(page * 10)
                    .Take(results)
                    .ToListAsync();

                list = highscores;
            }
            if (list == null)
            {
                return NotFound();
            }
            return list;
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

        //--------------------- HTTP POST Highscore ---------------------------------------------------
        // POST: api/Highscores
        // "create new"
        [HttpPost]
        public async Task<ActionResult<Highscores>> PostHighscore(Highscores highscores)
        {
            if (string.IsNullOrEmpty(highscores.UserName))
            {
                return BadRequest();
            }
            else
            {
                _context.Highscores.Add(highscores);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllHighscores), new { id = highscores.Id }, highscores);
            }
        }

        //--------------------- HTTP DELETE HighScore ---------------------------------------------------
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


        //--------------------- HTTP GET  Modeid by Modeid ---------------------------------------------------
        // GET: /api/highscores/modeid/{modeid}?hardcore={int}&traffic={int}&enemies={int}
        // highscores by modeid with optiona; filters by hardcore, traffic, enemies
        [HttpGet("modeid/count/{modeid}")]
        public ActionResult<object> GetHighScoreCountByModeId(int modeid,
            int hardcore,
            int traffic,
            int enemies)
        {
            var count = _context.Highscores
                .Where(x => x.Modeid == modeid
                && x.HardcoreEnabled == hardcore
                && x.TrafficEnabled == traffic
                && x.EnemiesEnabled == enemies)
                .Select(x => x.Id)
                .Count();

            return count;
        }
    }
}


