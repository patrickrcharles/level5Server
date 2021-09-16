using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using mysql_scaffold_dbcontext_test.Models.serialkiller;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.serialkiller
{
    [Route("[controller]")]
    public class SerialKillerController : Controller
    {
        private readonly serialkillerContext _context;

        public SerialKillerController(serialkillerContext context)
        {
            _context = context;
        }

        [Route("add/crime")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AddCrime()
        {
            try
            {
                var crimeViewModel = new CrimeViewModel
                {
                    Killers = _context.Killers,
                    Victims = _context.Victims,
                    Crimes = _context.Crimes
                };
                return View(crimeViewModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("----- ERROR : " + e);
                return NotFound();
            }
        }
        [Route("add/killer")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AddKiller()
        {
            try
            {
                var crimeViewModel = new CrimeViewModel
                {
                    Killers = _context.Killers,
                    Victims = _context.Victims,
                    Crimes = _context.Crimes
                };
                return View(crimeViewModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("----- ERROR : " + e);
                return NotFound();
            }
        }

        [MapToApiVersion("2")]
        [HttpPost("crime")]
        public async Task<ActionResult> PostCrime([FromForm] Crime crime)
        {
            try
            {
                // max description is 15 characters
                string crimeId = Utility.KeyGenerator.GetUniqueKey(30, "crime");
                string victimId = Utility.KeyGenerator.GetUniqueKey(30, "victim"); ;
                string noteId = Utility.KeyGenerator.GetUniqueKey(30, "note");
                string locationId = Utility.KeyGenerator.GetUniqueKey(30, "location");
                string killerId = Request.Form["killerSelected"];
                string crimeType = Request.Form["crimeType"];
                // create datetime
                string month = Request.Form["month"];
                string day = Request.Form["day"];
                string year = Request.Form["year"];
                DateTime fullDate = DateTime.Parse(year + "-" + month + "-" + day);

                System.Diagnostics.Debug.WriteLine("killerName from dropdown : " + killerId);
                System.Diagnostics.Debug.WriteLine("crimeType from dropdown : " + crimeType);
                System.Diagnostics.Debug.WriteLine("month : " + month);
                System.Diagnostics.Debug.WriteLine("day : " + day);
                System.Diagnostics.Debug.WriteLine("year : " + year);
                System.Diagnostics.Debug.WriteLine("full date : " + fullDate.ToString());

                crime.Crimeid = crimeId;
                crime.VictimId = victimId;
                crime.CrimeType = crimeType;
                crime.KillerId = killerId;
                crime.Date = fullDate;


                _context.Crimes.Add(crime);
                await _context.SaveChangesAsync();

                Victim victim = new Victim();
                victim.VictimId = victimId;
                victim.CrimeId = crimeId;
                victim.KillerId = killerId;
                victim.FirstName = crime.FirstName;
                victim.MiddleName = crime.MiddleName;
                victim.LastName = crime.LastName;
                victim.CrimeType = crimeType;
                victim.CrimeDate = fullDate;

                _context.Victims.Add(victim);
                await _context.SaveChangesAsync();

                // add killer location

                // add notes


                return Ok("totally worked");
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }
        [MapToApiVersion("2")]
        [HttpPost("killer")]
        public async Task<ActionResult> PostKiller([FromForm] Killer killer)
        {
            //System.Diagnostics.Debug.WriteLine("-----  name : " + crime.FirstName);
            //System.Diagnostics.Debug.WriteLine("-----  name : " + crime.MiddleName);
            //System.Diagnostics.Debug.WriteLine("-----  name : " + crime.LastName);

            try
            {
                // max description is 15 characters
                //string crimeId = Utility.KeyGenerator.GetUniqueKey(30, "crime");
                //string victimId = Utility.KeyGenerator.GetUniqueKey(30, "victim"); ;
                //string noteId = Utility.KeyGenerator.GetUniqueKey(30, "note");
                //string locationId = Utility.KeyGenerator.GetUniqueKey(30, "location");
                string killerId = Utility.KeyGenerator.GetUniqueKey(30, "killer");
                //string crimeType = Request.Form["crimeType"];
                // create datetime
                string month = Request.Form["month"];
                string day = Request.Form["day"];
                string year = Request.Form["year"];
                DateTime fullDate = DateTime.Parse(year + "-" + month + "-" + day);

                System.Diagnostics.Debug.WriteLine("killerName from dropdown : " + killerId);
                //System.Diagnostics.Debug.WriteLine("crimeType from dropdown : " + crimeType);
                System.Diagnostics.Debug.WriteLine("month : " + month);
                System.Diagnostics.Debug.WriteLine("day : " + day);
                System.Diagnostics.Debug.WriteLine("year : " + year);
                System.Diagnostics.Debug.WriteLine("full date : " + fullDate.ToString());

                killer.KillerId = killerId;
                killer.Born = fullDate;

                _context.Killers.Add(killer);
                await _context.SaveChangesAsync();

                return Ok("totally worked");
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }
    }
}
