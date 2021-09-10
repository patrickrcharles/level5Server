using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
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

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/serialkiller
        /// <summary>
        /// get all killers
        /// </summary>
        [MapToApiVersion("2")]
        [HttpGet("killers")]
        public async Task<ActionResult<IEnumerable<Killers>>> GetAllVersions()
        {
            //System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Killers.OrderBy(x => x.KillerId).ToListAsync();
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [MapToApiVersion("2")]
        [HttpGet("killers/id/{killerId}")]
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
    }
}
