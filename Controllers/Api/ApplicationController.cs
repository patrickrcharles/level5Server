using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.Api
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly DatabaseContext _context;
        public ApplicationController(DatabaseContext context)
        {
            _context = context;
        }

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/highscores
        // get all highscores
        [HttpGet("version")]
        public async Task<ActionResult<IEnumerable<Application>>> GetAllVersions()
        {
            return await _context.Application.OrderByDescending(x => x.id)
                .ToListAsync();

        }

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/highscores
        // get all highscores
        [HttpGet("version/current")]
        public ActionResult<object> GetCurrentVersion()
        {
            var version = _context.Application
                .Select(x => x.CurrentVersion)
                .ToList()
                .LastOrDefault();

            return version;
        }

        //--------------------- HTTP POST new application version ---------------------------------------------------
        // POST: api/Highscores
        // "create new"
        [Route("version")]
        [HttpPost]
        public async Task<ActionResult<Application>> PostHighscore(Application application)
        {
            //_context.Users.Where(e => e.Userid == highscores.Userid).Any();
            // if empty username  or userid NOT in user table
            if (string.IsNullOrEmpty(application.CurrentVersion)
                || _context.Application.Where(e => e.CurrentVersion == application.CurrentVersion).Any())
            {
                return BadRequest();
            }
            else
            {
                _context.Application.Add(application);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllVersions), new { id = application.id }, application);
            }
        }

        ////--------------------- HTTP GET  Modeid by Modeid ---------------------------------------------------
        //// GET: /api/highscores/modeid/{modeid}?hardcore={int}&traffic={int}&enemies={int}
        //// highscores by modeid with optiona; filters by hardcore, traffic, enemies
        //[HttpGet("modeid/count/{modeid}")]
        //public ActionResult<object> GetHighScoreCountByModeId(int modeid,
        //    int hardcore,
        //    int traffic,
        //    int enemies)
        //{
        //    var count = _context.Highscores
        //        .Where(x => x.Modeid == modeid
        //        && x.HardcoreEnabled == hardcore
        //        && x.TrafficEnabled == traffic
        //        && x.EnemiesEnabled == enemies)
        //        .Select(x => x.Id)
        //        .Count();

        //    return count;
        //}
    }
}

