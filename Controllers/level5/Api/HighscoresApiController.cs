
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
using System.Net;

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
        /// <summary>
        /// Get all high scores
        /// </summary>
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetAllHighscores()
        {

            //ModePlayedCount(16);
            //return await _context.Highscores.OrderByDescending(x => x.Id)
            //    .ToListAsync();
           var highscores = await _context.Highscores.OrderByDescending(x => x.Id)
                .ToListAsync();
            HideHighScoreDetails(highscores);

            return highscores;
        }

        //--------------------- HTTP GET  Platform ---------------------------------------------------
        // GET: /api/highscores/modeid/1
        /// <summary>
        /// Get high scores by platfoem. [handheld, desktop]
        /// </summary>
        [HttpGet("platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByPlatform(string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
            HideHighScoreDetails(highscores);

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }

        //--------------------- HTTP GET  Modeid by Userid ---------------------------------------------------
        // GET: /api/highscores/modeid/1/userid/1
        /// <summary>
        /// Get high scores by mode id and user id. 
        /// </summary>
        [HttpGet("modeid/{modeid}/userid/{userid}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdUserId(int modeid, int userid)
        {
            var highscores = await _context.Highscores.Where(x => x.Modeid == modeid && x.Userid == userid)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            HideHighScoreDetails(highscores);

            if (highscores == null)
            {
                return NotFound();
            }

            return highscores;
        }
        //--------------------- HTTP GET Modeid by Platform ---------------------------------------------------
        // GET: /api/highscores/modeid/1/platform/1
        /// <summary>
        /// Get high scores by mode id and platform. 
        /// </summary>
        [HttpGet("modeid/{modeid}/platform/{platform}")]
        public async Task<ActionResult<IEnumerable<Highscores>>> GetHighScoreByModeIdPlatform(int modeid, string platform)
        {
            var highscores = await _context.Highscores.Where(x => x.Platform == platform)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            HideHighScoreDetails(highscores);

            if (highscores == null)
            {
                return NotFound();
            }


            return highscores;
        }

        //--------------------- HTTP GET  Modeid by Modeid - Filtered  ---------------------------------------------------
        // GET: /api/highscores/modeid/{modeid}?hardcore={int}&traffic={int}&enemies={int}
        /// <summary>
        /// Get high scores by mode id and optional filters. [hardcoreEnabled, trafficEnabled, enemiesEnabled, sniperEnabled] 
        /// </summary>
        [HttpGet("modeid/filter/{modeid}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetHighScoreByModeIdForGameDisplayFiltered(int modeid,
            int hardcore,
            int traffic,
            int enemies,
            int sniper,
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
                    && x.SniperEnabled == sniper
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
                    && x.SniperEnabled == sniper
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
                    && x.SniperEnabled == sniper
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
                    && x.SniperEnabled == sniper
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
                    && x.SniperEnabled == sniper
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
                    && x.SniperEnabled == sniper
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

        //--------------------- HTTP GET  Modeid by Modeid - All  ---------------------------------------------------
        // GET: /api/highscores/modeid/{modeid}?hardcore={int}&traffic={int}&enemies={int}
        /// <summary>
        /// Get all high scores for specific game mode by mode id
        /// </summary>
        [HttpGet("modeid/all/{modeid}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetHighScoreByModeIdForGameDisplayAll(int modeid,
            int page,
            int results)
        {
            ActionResult<IEnumerable<Object>> list = null;
            // totalpoints highscore
            if (modeid == 1 || (modeid > 14 && modeid < 20))
            {
                var highscores = await _context.Highscores
                    .Where(x => x.Modeid == modeid)
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
                    .Where(x => x.Modeid == modeid)
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
                    .Where(x => x.Modeid == modeid)
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
                    .Where(x => x.Modeid == modeid)
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
                    .Where(x => x.Modeid == modeid)
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
                    .Where(x => x.Modeid == modeid)
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
        /// <summary>
        /// Insert high score or replace if already exists
        /// </summary>
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
        /// <summary>
        /// Create new high score
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Highscores>> PostHighscore(Highscores highscores)
        {
            // check if unique scoreid already exists in database
            if (_context.Highscores.Where(e => e.Scoreid == highscores.Scoreid).Any())
            {
                //System.Diagnostics.Debug.WriteLine("-------------------scoreid already exists in database");
                return Conflict();
                //thrownewHttpResponseException(HttpStatusCode.NotFound);
                //return Content(codeNotDefined, "message to be sent in response body");
            }
            //_context.Users.Where(e => e.Userid == highscores.Userid).Any();
            // if empty username  or userid NOT in user table
            if (string.IsNullOrEmpty(highscores.UserName) || !_context.Users.Where(e => e.Userid == highscores.Userid).Any())
            {
                return BadRequest();
            }
            else
            {
                upDateModeName(highscores);
                _context.Highscores.Add(highscores);
                await _context.SaveChangesAsync();

                // update serverstats
                ServerStatsController server = new ServerStatsController(_context);
                server.getServerStats();

                return CreatedAtAction(nameof(GetAllHighscores), new { id = highscores.Id }, highscores);
            }
        }

        //--------------------- HTTP DELETE HighScore ---------------------------------------------------
        /// <summary>
        /// Delete high score by score id
        /// </summary>
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

        //public bool isDev(string username)
        //{
        //    // find any user that matches username + isDev = 1;
        //    // this means, the username is a dev account username
        //    var isDev = _context.Users.Any(e => e.Username == username && e.IsDev == 1);
        //    return isDev;
        //}

        /// <summary>
        /// Get # high scores for game mode by mode id
        /// </summary>
        [HttpGet("modeid/count")]
        public async Task<ActionResult<IEnumerable<Object>>> ModePlayedCount(int modeid)
        {
            var modeidList = _context.Highscores
                .GroupBy(e => e.Modeid)
                .Select(e => new { Modeid = e.Key, Count = e.Count() }).ToListAsync();
            return await modeidList;
        }

        //--------------------- HTTP GET  Modeid by Modeid ---------------------------------------------------
        // GET: /api/highscores/modeid/{modeid}?hardcore={int}&traffic={int}&enemies={int}
        /// <summary>
        /// Get # high scores for game mode by mode id with optional filters
        /// </summary>
        [HttpGet("modeid/count/{modeid}")]
        public ActionResult<object> GetHighScoreCountByModeId(int modeid,
            int hardcore,
            int traffic,
            int sniper,
            int enemies)
        {
            var count = _context.Highscores
                .Where(x => x.Modeid == modeid
                && x.HardcoreEnabled == hardcore
                && x.TrafficEnabled == traffic
                && x.SniperEnabled == sniper
                && x.EnemiesEnabled == enemies)
                .Select(x => x.Id)
                .Count();

            return count;
        }

        private void upDateModeName(Highscores highscores)
        {
            System.Diagnostics.Debug.WriteLine("upDateModeName()");
            //foreach (Highscores h in highscores)

            // if modename is null, insert based on modeid
            if (String.IsNullOrEmpty(highscores.ModeName))
            {
                {
                    System.Diagnostics.Debug.WriteLine("highscores.Modeid : " + highscores.Modeid);
                    switch (highscores.Modeid)
                    {
                        case 1:
                            highscores.ModeName = "Total Points";
                            break;
                        case 2:
                            highscores.ModeName = "Total 3 Pointers";
                            break;
                        case 3:
                            highscores.ModeName = "Total 4 Pointers";
                            break;
                        case 4:
                            highscores.ModeName = "Total 7 Pointers";
                            break;
                        case 6:
                            highscores.ModeName = "Total Distance";
                            break;
                        case 7:
                            highscores.ModeName = "Spot up some 3s";
                            break;
                        case 8:
                            highscores.ModeName = "Spot up some 4s";
                            break;
                        case 9:
                            highscores.ModeName = "Spot up some All";
                            break;
                        case 10:
                            highscores.ModeName = "Moneyball 3s";
                            break;
                        case 11:
                            highscores.ModeName = "Moneyball 4s";
                            break;
                        case 12:
                            highscores.ModeName = "Moneyball All";
                            break;
                        case 14:
                            highscores.ModeName = "Consecutive Shots";
                            break;
                        case 15:
                            highscores.ModeName = "In the Pocket";
                            break;
                        case 16:
                            highscores.ModeName = "3 point Contest";
                            break;
                        case 17:
                            highscores.ModeName = "4 point Contest";
                            break;
                        case 18:
                            highscores.ModeName = "All point Contest";
                            break;
                        case 19:
                            highscores.ModeName = "Points by Distance";
                            break;
                        case 20:
                            highscores.ModeName = "Bash up some Nerds";
                            break;
                        case 98:
                            highscores.ModeName = "Arcade";
                            break;
                        case 99:
                            highscores.ModeName = "Free Play";
                            break;
                        default:
                            highscores.ModeName = "none";
                            break;
                    }
                    System.Diagnostics.Debug.WriteLine("highscores.ModeName : " + highscores.ModeName);
                }
                _context.SaveChanges();
            }
        }

        private static void HideHighScoreDetails(List<Highscores> highscores)
        {
            foreach (Highscores h in highscores)
            {
                h.Os = "*************";
                h.Scoreid = "*************";
                h.Device = "*************";
                h.Ipaddress = "*************";
            }
        }
    }
}


