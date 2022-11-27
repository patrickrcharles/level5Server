using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using level5Server.Models.serialkiller;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace level5Server.Controllers.serialkiller.Api
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        [HttpGet("killers")]
        public async Task<ActionResult<IEnumerable<Killer>>> GetAllKillers()
        {
            //System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Killers.OrderBy(x => x.Id).ToListAsync();
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [HttpGet("killers/kid/{killerId}")]
        public async Task<ActionResult<Killer>> GetByKillerId(string killerId)
        {
            return await _context.Killers.FirstOrDefaultAsync(x => x.KillerId == killerId);
        }

        // GET: /api/serialkiller/{killerId}
        /// <summary>
        /// get killer details by id
        /// </summary>
        [HttpGet("killers/name/{killerName}")]
        public async Task<ActionResult<Killer>> GetByKillerName(string killerName)
        {
            return await _context.Killers
                .FirstOrDefaultAsync(x => x.FirstName == killerName
                || x.MiddleName == killerName
                || x.LastName == killerName);
        }

        //--------------------- Victims ---------------------------------------------------
        [HttpGet("victims")]
        public async Task<ActionResult<IEnumerable<Victim>>> GetAllVictims()
        {
            //System.Diagnostics.Debug.WriteLine("/api/serialkiller/killer");
            return await _context.Victims.OrderBy(x => x.VictimId).ToListAsync();
        }

        [HttpGet("victims/kid/{killerId}")]
        public async Task<ActionResult<IEnumerable<Victim>>> GetVictmsByKillerId(string killerId)
        {
            return await _context.Victims.Where(x => x.KillerId == killerId).ToListAsync();
        }

        [HttpGet("victims/vid/{victimsId}")]
        public async Task<ActionResult<Victim>> GetVictimsById(string victimsId)
        {
            return await _context.Victims
                .FirstOrDefaultAsync(x => x.VictimId == victimsId);
        }


        //--------------------- Crime ---------------------------------------------------
        [HttpGet("crimes")]
        public async Task<ActionResult<IEnumerable<Crime>>> GetAllCrimes()
        {
            return await _context.Crimes.OrderBy(x => x.KillerId).ToListAsync();
        }

        // *NOTE API POST is not needed. going to use forms
        // post
        //[MapToApiVersion("2")]
        //[HttpPost("crimes")]
        //public async Task<ActionResult<Crime>> PostCrime( Crime crime)
        //{
        //    System.Diagnostics.Debug.WriteLine("-----  name : " + crime.FirstName);
        //    System.Diagnostics.Debug.WriteLine("-----  name : " + crime.MiddleName);
        //    System.Diagnostics.Debug.WriteLine("-----  name : " + crime.LastName);

        //    try
        //    {
        //        // max description is 15 characters
        //        string crimeId = Utility.KeyGenerator.GetUniqueKey(30, "crime");
        //        string victimId = Utility.KeyGenerator.GetUniqueKey(30, "victim"); ;
        //        string noteId = Utility.KeyGenerator.GetUniqueKey(30, "note");
        //        string locationId = Utility.KeyGenerator.GetUniqueKey(30, "location");

        //        crime.Crimeid = crimeId;
        //        crime.VictimId = victimId;

        //        _context.Crimes.Add(crime);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetAllCrimes), new { vid = crime.VictimId }, crime);
        //    }
        //    catch (DbUpdateConcurrencyException e)
        //    {
        //        System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
        //        return BadRequest();
        //    }
        //}

        //--------------------- Killer location ---------------------------------------------------
        [HttpGet("locations")]
        public async Task<ActionResult<IEnumerable<Crime>>> GetAllLocations()
        {
            return await _context.Crimes.OrderBy(x => x.KillerId).ToListAsync();
        }
        //--------------------- notes ---------------------------------------------------
        [HttpGet("notes")]
        public async Task<ActionResult<IEnumerable<Crime>>> GetAllNotes()
        {
            return await _context.Crimes.OrderBy(x => x.KillerId).ToListAsync();
        }
    }
}
