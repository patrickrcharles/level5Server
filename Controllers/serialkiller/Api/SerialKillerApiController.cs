using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using System.Collections;
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
        private readonly serialkillerContext _context;
        public SerialKillerApiController(serialkillerContext context)
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
        public async Task<ActionResult<IEnumerable<Killer>>> GetAllKillers()
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
        public async Task<ActionResult<Killer>> GetByKillerId(int killerId)
        {
            return await _context.Killers.FirstOrDefaultAsync(x => x.KillerId == killerId);
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [MapToApiVersion("2")]
        [HttpGet("killers/name/{killerName}")]
        public async Task<ActionResult<Killer>> GetByKillerName(string killerName)
        {
            return await _context.Killers
                .FirstOrDefaultAsync(x => x.FirstName == killerName
                || x.MiddleName == killerName
                || x.LastName == killerName);
        }

        //--------------------- Victims ---------------------------------------------------
        [MapToApiVersion("2")]
        [HttpGet("Victims")]
        public async Task<ActionResult<IEnumerable<Victim>>> GetAllVictims()
        {
            //System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Victims.OrderBy(x => x.VictimId).ToListAsync();
        }

        [MapToApiVersion("2")]
        [HttpGet("Victims/kid/{killerId}")]
        public async Task<ActionResult<IEnumerable<Victim>>> GetVictmsByKillerId(int killerId)
        {
            return await _context.Victims.Where(x => x.KillerId == killerId).ToListAsync();
        }

        [MapToApiVersion("2")]
        [HttpGet("Victims/vid/{VictimsId}")]
        public async Task<ActionResult<Victim>> GetVictimsById(int VictimsId)
        {
            return await _context.Victims
                .FirstOrDefaultAsync(x => x.VictimId == VictimsId);
        }


        //--------------------- Crime ---------------------------------------------------
        [MapToApiVersion("2")]
        [HttpGet("crimes")]
        public async Task<ActionResult<IEnumerable<Crime>>> GetAllCrimes()
        {
            return await _context.Crime.OrderBy(x => x.KillerId).ToListAsync();
        }
        // post
        [HttpPost("crimes")]
        public async Task<ActionResult<Crime>> PostCrime(Crime crime)
        {
            //bool continueNextMethod = false;
            try
            {
                _context.Crime.Add(crime);
                await _context.SaveChangesAsync();

                //if (await _context.SaveChangesAsync() > 0)
                //{
                //    continueNextMethod = true;
                //}
                //else
                //{
                //    continueNextMethod = false;
                //}

                return CreatedAtAction(nameof(GetAllCrimes), new { vid = crime.VictimId }, crime);
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }

        //--------------------- Killer location ---------------------------------------------------
        [MapToApiVersion("2")]
        [HttpGet("locations")]
        public async Task<ActionResult<IEnumerable<Crime>>> GetAllLocations()
        {
            return await _context.Crime.OrderBy(x => x.KillerId).ToListAsync();
        }
        //--------------------- notes ---------------------------------------------------
        [MapToApiVersion("2")]
        [HttpGet("notes")]
        public async Task<ActionResult<IEnumerable<Crime>>> GetAllNotes()
        {
            return await _context.Crime.OrderBy(x => x.KillerId).ToListAsync();
        }

        private async Task<IEnumerator> SaveCrimeAsync(Crime crime)
        {
            _context.Crime.Add(crime);
            await _context.SaveChangesAsync();

            //await _context.SaveChangesAsync() > 0;

        }
    }
}
