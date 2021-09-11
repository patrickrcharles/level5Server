using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models.serialkiller;
using mysql_scaffold_dbcontext_test.Models.SerialKiller;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.serialkiller.Api
{
    [ApiVersion("2")]
    [ApiController]
    [Route("api/serialkiller")]
    public class SerialKillerApiController : Controller
    {
        private readonly database2Context _context;
        public SerialKillerApiController(database2Context context)
        {
            _context = context;
        }

        //--------------------- HTTP GET Killers ---------------------------------------------------
        // GET: /api/serialkiller
        /// <summary>
        /// get all killers
        /// </summary>
        [MapToApiVersion("2")]
        [HttpGet("killers")]
        public async Task<ActionResult<IEnumerable<Killers>>> GetAllKillers()
        {
            //System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Killers.OrderBy(x => x.KillerId).ToListAsync();
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [MapToApiVersion("2")]
        [HttpGet("killers/kid/{killerId}")]
        public async Task<ActionResult<Killers>> GetByKillerId(int killerId)
        {
            return await _context.Killers.FirstOrDefaultAsync(x => x.KillerId == killerId);
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [MapToApiVersion("2")]
        [HttpGet("killers/name/{killerName}")]
        public async Task<ActionResult<Killers>> GetByKillerName(string killerName)
        {
            return await _context.Killers
                .FirstOrDefaultAsync(x => x.FirstName == killerName 
                || x.MiddleName == killerName 
                || x.LastName == killerName);
        }

        //--------------------- HTTP GET Victims ---------------------------------------------------
        [MapToApiVersion("2")]
        [HttpGet("victims")]
        public async Task<ActionResult<IEnumerable<Victims>>> GetAllVictims()
        {
            //System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Victims.OrderBy(x => x.VictimId).ToListAsync();
        }

        [MapToApiVersion("2")]
        [HttpGet("victims/kid/{killerId}")]
        public async Task<ActionResult<IEnumerable<Victims>>> GetVictmsByKillerId(int killerId)
        {
            return await _context.Victims.Where(x => x.KillerId == killerId).ToListAsync();
        }

        [MapToApiVersion("2")]
        [HttpGet("victims/vid/{victimId}")]
        public async Task<ActionResult<Victims>> GetVictimById(int victimId)
        {
            return await _context.Victims
                .FirstOrDefaultAsync(x => x.VictimId == victimId);
        }
    }
}
