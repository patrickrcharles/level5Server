using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using level5Server.Models.serialkiller;
using System;
using System.Threading.Tasks;

namespace level5Server.Controllers.serialkiller
{
    [Route("[controller]")]
    public class SerialKillerController : Controller
    {
        private readonly serialkillerContext _context;

        public SerialKillerController(serialkillerContext context)
        {
            _context = context;
        }

        [Route("home")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Home()
        {
            return View();
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
                    Crimes = _context.Crimes,
                    KillerLocations = _context.KillerLocations,
                    Notes = _context.Notes
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
                    Crimes = _context.Crimes,
                    KillerLocations = _context.KillerLocations,
                    Notes = _context.Notes
                };
                return View(crimeViewModel);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("----- ERROR : " + e);
                return NotFound();
            }
        }

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
                string killerId = Request.Form["killerSelected"].ToString() ?? "";
                string crimeType = Request.Form["crimeType"].ToString() ?? "";
                string noteText = Request.Form["note"].ToString() ?? "";
                // create datetime
                string month = Request.Form["month"];
                string day = Request.Form["day"];
                string year = Request.Form["year"];
                string state = Request.Form["state"].ToString() ?? "state";
                DateTime fullDate = DateTime.Parse(year + "-" + month + "-" + day);

                crime.Crimeid = crimeId ?? "";
                crime.VictimId = victimId ?? "";
                crime.CrimeType = crimeType ?? "";
                crime.KillerId = killerId ?? "";
                crime.Date = fullDate;
                if (String.IsNullOrEmpty(crime.FirstName)) { crime.FirstName = "";}
                if (String.IsNullOrEmpty(crime.MiddleName)) { crime.MiddleName = "";}
                if (String.IsNullOrEmpty(crime.LastName)) { crime.LastName = "";}
                if (String.IsNullOrEmpty(crime.City)) { crime.City = "";}
                crime.State = state ?? "state";

                _context.Crimes.Add(crime);
                await _context.SaveChangesAsync();

                Victim victim = new Victim();
                victim.VictimId = victimId;
                victim.CrimeId = crimeId;
                victim.KillerId = killerId;
                victim.FirstName = crime.FirstName.ToString() ?? "";
                victim.MiddleName = crime.MiddleName.ToString() ?? "";
                victim.LastName = crime.LastName.ToString() ?? "";
                victim.CrimeType = crimeType;
                victim.CrimeDate = fullDate;

                _context.Victims.Add(victim);
                await _context.SaveChangesAsync();

                // add killer location
                KillerLocation killerLocation = new KillerLocation();
                killerLocation.LocationId = locationId;
                killerLocation.KillerId = killerId;
                killerLocation.Date = crime.Date;
                killerLocation.City = crime.City;
                killerLocation.State = state;

                _context.KillerLocations.Add(killerLocation);
                await _context.SaveChangesAsync();

                // add notes. null check first
                if (!String.IsNullOrEmpty(noteText))
                {
                    Notes note = new Notes();
                    note.NoteId = noteId;
                    note.KillerId = killerId;
                    note.Note = noteText;

                    _context.Notes.Add(note);
                    await _context.SaveChangesAsync();
                }

                //return (ActionResult)AddCrime();
                return Redirect("add/crime");
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }
        [HttpPost("killer")]
        public async Task<ActionResult> PostKiller([FromForm] Killer killer)
        {
            try
            {
                string killerId = Utility.KeyGenerator.GetUniqueKey(30, "killer");
                string noteId = Utility.KeyGenerator.GetUniqueKey(30, "note");
                string locationId = Utility.KeyGenerator.GetUniqueKey(30, "location");
                string noteText = Request.Form["note"];
                if (string.IsNullOrEmpty(noteText)) { noteText = ""; }
                // create datetime
                string month = Request.Form["month"];
                string day = Request.Form["day"];
                string year = Request.Form["year"];
                DateTime fullDate = DateTime.Parse(year + "-" + month + "-" + day);

                killer.KillerId = killerId;
                killer.Born = fullDate;
                if (string.IsNullOrEmpty(killer.FirstName)) { killer.FirstName = ""; }
                if (string.IsNullOrEmpty(killer.MiddleName)) { killer.MiddleName = ""; }
                if (string.IsNullOrEmpty(killer.LastName)) { killer.LastName = ""; }

                _context.Killers.Add(killer);
                await _context.SaveChangesAsync();

                // add notes. null check first
                if (!string.IsNullOrEmpty(noteText))
                {
                    Notes note = new Notes();
                    note.NoteId = noteId;
                    note.KillerId = killerId;
                    note.Note = noteText;

                    _context.Notes.Add(note);
                    await _context.SaveChangesAsync();
                }

                //return Ok("totally worked");
                //return RedirectToAction("AddKiller");
                return Redirect("add/killer");
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }
    }
}
