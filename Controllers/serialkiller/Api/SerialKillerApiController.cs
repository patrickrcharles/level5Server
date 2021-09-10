using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using mysql_scaffold_dbcontext_test.Models.SerialKiller;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.serialkiller.Api
{

    [Route("api/serialkiller")]
    [ApiController]
    public class SerialKillerApiController : Controller
    {
        private readonly database2Context _context;
        public SerialKillerApiController(database2Context context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<KillerModel>>> GetAllKillers()
        //{ 
        //    //ModePlayedCount(16);
        //    //return await _context.Highscores.OrderByDescending(x => x.Id)
        //    //    .ToListAsync();
        //    var killers = await _context.Killers.OrderByDescending(x => x.id)
        //         .ToListAsync();
        //    return killers;
        //}

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/serialkiller
        /// <summary>
        /// get all killers
        /// </summary>
        [HttpGet("killers")]
        public async Task<ActionResult<IEnumerable<KillerModel>>> GetAllVersions()
        {
            System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Killers.OrderBy(x => x.KillerId).ToListAsync();
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [HttpGet("killers/{killerid}")]
        public async Task<ActionResult<KillerModel>> GetByKillerId(int killerId)
        {
            System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer/{killerid}");
            //return await _context.Killers.Where(x => x.killerId == killerId).FirstOrDefault();
            return await _context.Killers.FirstOrDefaultAsync(x => x.KillerId == killerId);
                                //.FirstOrDefaultAsync(m => m.Userid == userid);
        }
    }
}
