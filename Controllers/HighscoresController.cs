using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;

namespace mysql_scaffold_dbcontext_test.Controllers
{
    public class HighscoresController : Controller
    {
        private readonly DatabaseContext _context;

        private string previousSearchString;

        public HighscoresController(DatabaseContext context)
        {
            _context = context;
        }

        //// GET: Highscores
        //[Route("[controller]")]
        //public async Task<IActionResult> Index()
        //{
        //    //get last 50 scores
        //    return View(await _context.Highscores.OrderByDescending(x => x.Id).Skip(0).Take(50).ToListAsync());

        //}

        // GET: Highscores
        [Route("[controller]")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["DateSortParm"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["HardcoreSortParm"] = sortOrder == "hardcore_asc" ? "hardcore_desc" : "hardcore_asc";
            ViewData["UsernameSortParm"] = sortOrder == "username_asc" ? "username_desc" : "username_asc";
            ViewData["PlatformSortParm"] = sortOrder == "platform_asc" ? "platform_desc" : "platform_asc";
            ViewData["ModeSortParm"] = sortOrder == "mode_asc" ? "mode_desc" : "mode_asc";
            ViewData["CharacterSortParm"] = sortOrder == "character_asc" ? "character_desc" : "character_asc";
            ViewData["LevelSortParm"] = sortOrder == "level_asc" ? "level_desc" : "level_asc";
            ViewData["VersionSortParm"] = sortOrder == "version_asc" ? "version_desc" : "version_asc";
            ViewData["TimeSortParm"] = sortOrder == "time_asc" ? "time_desc" : "time_asc";
            ViewData["TotalPointsSortParm"] = sortOrder == "totalPoints_asc" ? "totalPoints_desc" : "totalPoints_asc";
            ViewData["LongestShotSortParm"] = sortOrder == "longestShot_asc" ? "longestShot_desc" : "longestShot_asc";
            ViewData["TotalDistanceSortParm"] = sortOrder == "totalDistance_asc" ? "totalDistance_desc" : "totalDistance_asc";
            ViewData["MaxShotMadeSortParm"] = sortOrder == "maxShotMade_asc" ? "maxShotMade_desc" : "maxShotMade_asc";
            ViewData["ConsecutiveShotsSortParm"] = sortOrder == "consecutiveShots_asc" ? "consecutiveShots_desc" : "consecutiveShots_asc";

            ViewData["TwoMadeSortParm"] = sortOrder == "twoMade_asc" ? "twoMade_desc" : "twoMade_asc";
            ViewData["TwoAttSortParm"] = sortOrder == "twoAtt_asc" ? "twoAtt_desc" : "twoAtt_asc";
            ViewData["ThreeMadeSortParm"] = sortOrder == "threeMade_asc" ? "threeMade_desc" : "threeMade_asc";
            ViewData["ThreeAttSortParm"] = sortOrder == "threeAtt_asc" ? "threeAtt_desc" : "threeAtt_asc";
            ViewData["FourMadeSortParm"] = sortOrder == "fourMade_asc" ? "fourMade_desc" : "fourMade_asc";
            ViewData["FourAttSortParm"] = sortOrder == "fourAtt_asc" ? "fourAtt_desc" : "fourAtt_asc";
            ViewData["SevenMadeSortParm"] = sortOrder == "sevenMade_asc" ? "sevenMade_desc" : "sevenMade_asc";
            ViewData["SevenAttSortParm"] = sortOrder == "sevenAtt_asc" ? "sevenAtt_desc" : "sevenAtt_asc";
            ViewData["BonusPointsSortParm"] = sortOrder == "bonusPoints_asc" ? "bonusPoints_desc" : "bonusPoints_asc";
            ViewData["MoneyBallMadeSortParm"] = sortOrder == "moneyBallMade_asc" ? "moneyBallMade_desc" : "moneyBallMade_asc";
            ViewData["MoneyBallAttSortParm"] = sortOrder == "moneyBallAtt_asc" ? "moneyBallAtt_desc" : "moneyBallAtt_asc";
            ViewData["TrafficSortParm"] = sortOrder == "trafficShots_asc" ? "trafficShots_desc" : "trafficShots_asc";
            ViewData["EnemiesSortParm"] = sortOrder == "enemiesShots_asc" ? "enemiesShots_desc" : "enemiesShots_asc";
            ViewData["EnemiesKilledSortParm"] = sortOrder == "enemiesKilledShots_asc" ? "enemiesKilledShots_desc" : "enemiesKilledShots_asc";
            ViewData["SniperSortParm"] = sortOrder == "sniper_asc" ? "sniper_desc" : "sniper_asc";
            ViewData["SniperModeSortParm"] = sortOrder == "sniperMode_asc" ? "sniperMode_desc" : "sniperMode_asc";
            ViewData["SniperModeNameSortParm"] = sortOrder == "sniperModeName_asc" ? "sniperModeName_desc" : "sniperModeName_asc";
            ViewData["SniperHitsSortParm"] = sortOrder == "sniperHits_asc" ? "sniperHits_desc" : "sniperHits_asc";
            ViewData["SniperShotsSortParm"] = sortOrder == "sniperShots_asc" ? "sniperShots_desc" : "sniperShots_asc";


            var highscores = from h in _context.Highscores
                             select h;
            // if no search is submitted
            //if (String.IsNullOrEmpty(searchString))
            //{
            //    previousSearchString = "";
            //}
            // if search term is entered
            if (!String.IsNullOrEmpty(searchString))
            {
                previousSearchString = searchString; // save search in case of sorting
                highscores = highscores.Where
                    (s => s.UserName.Contains(searchString) || s.Platform.Contains(searchString)
                    || s.Character.Contains(searchString) || s.Level.Contains(searchString)
                    || s.Version.Contains(searchString) || s.ModeName.Contains(searchString));
            }
            // if search term is not entered but sort has been clicked
            //if (!String.IsNullOrEmpty(previousSearchString) && !String.IsNullOrEmpty(sortOrder))
            //{
            //    highscores = highscores.Where
            //        (s => s.UserName.Contains(previousSearchString) || s.Platform.Contains(previousSearchString)
            //        || s.Character.Contains(previousSearchString) || s.Level.Contains(previousSearchString)
            //        || s.Version.Contains(previousSearchString));
            //}

            highscores = sortHighscores(sortOrder, highscores);

            return View(await highscores.ToListAsync());
        }

        [Route("[controller]/id/{id?}")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        // GET: Highscores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscores = await _context.Highscores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscores == null)
            {
                return NotFound();
            }

            return View(highscores);
        }

        //[Route("[controller]/create")]
        //// GET: Highscores/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Highscores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Userid,Modeid,Characterid,Levelid,Character,Level,Os,Version,Date,Time,TotalPoints,LongestShot,TotalDistance,MaxShotMade,MaxShotAtt,ConsecutiveShots,TrafficEnabled,HardcoreEnabled,EnemiesKilled,Platform,Device,Ipaddress,Scoreid,threeMade,TwoAtt,ThreeMade,ThreeAtt,FourMade,FourAtt,SevenMade,SevenAtt")] Highscores highscores)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(highscores);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(highscores);
        //}

        // GET: Highscores/Edit/5
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscores = await _context.Highscores.FindAsync(id);
            if (highscores == null)
            {
                return NotFound();
            }
            return View(highscores);
        }

        // POST: Highscores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Userid,Modeid,Characterid,Levelid,Character,Level,Os,Version,Date,Time,TotalPoints,LongestShot,TotalDistance,MaxShotMade,MaxShotAtt,ConsecutiveShots,TrafficEnabled,HardcoreEnabled,EnemiesKilled,Platform,Device,Ipaddress,Scoreid,threeMade,TwoAtt,ThreeMade,ThreeAtt,FourMade,FourAtt,SevenMade,SevenAtt")] Highscores highscores)
        //{
        //    if (id != highscores.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(highscores);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HighscoresExists(highscores.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(highscores);
        //}

        // GET: Highscores/Delete/5
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscores = await _context.Highscores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscores == null)
            {
                return NotFound();
            }

            return View(highscores);
        }

        // POST: Highscores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highscores = await _context.Highscores.FindAsync(id);
            _context.Highscores.Remove(highscores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        internal bool HighscoresExists(int id)
        {
            return _context.Highscores.Any(e => e.Id == id);
        }

        internal static IQueryable<Highscores> sortHighscores(string sortOrder, IQueryable<Highscores> highscores)
        {
            switch (sortOrder)
            {
                case "date_desc":
                    highscores = highscores.OrderBy(s => s.Id);
                    break;
                case "date_asc":
                    highscores = highscores.OrderByDescending(s => s.Id);
                    break;
                case "hardcore_desc":
                    highscores = highscores.OrderBy(s => s.HardcoreEnabled);
                    break;
                case "hardcore_asc":
                    highscores = highscores.OrderByDescending(s => s.HardcoreEnabled);
                    break;
                case "username_desc":
                    highscores = highscores.OrderBy(s => s.UserName);
                    break;
                case "username_asc":
                    highscores = highscores.OrderByDescending(s => s.UserName);
                    break;
                case "platform_desc":
                    highscores = highscores.OrderBy(s => s.Platform);
                    break;
                case "platform_asc":
                    highscores = highscores.OrderByDescending(s => s.Platform);
                    break;
                case "mode_desc":
                    highscores = highscores.OrderBy(s => s.ModeName);
                    break;
                case "mode_asc":
                    highscores = highscores.OrderByDescending(s => s.ModeName);
                    break;
                case "character_desc":
                    highscores = highscores.OrderBy(s => s.Character);
                    break;
                case "character_asc":
                    highscores = highscores.OrderByDescending(s => s.Character);
                    break;
                case "level_desc":
                    highscores = highscores.OrderBy(s => s.Level);
                    break;
                case "level_asc":
                    highscores = highscores.OrderByDescending(s => s.Level);
                    break;
                case "version_desc":
                    highscores = highscores.OrderBy(s => s.Version);
                    break;
                case "version_asc":
                    highscores = highscores.OrderByDescending(s => s.Version);
                    break;
                case "time_desc":
                    highscores = highscores.OrderBy(s => s.Time);
                    break;
                case "time_asc":
                    highscores = highscores.OrderByDescending(s => s.Time);
                    break;
                case "totalPoints_desc":
                    highscores = highscores.OrderBy(s => s.TotalPoints);
                    break;
                case "totalPoints_asc":
                    highscores = highscores.OrderByDescending(s => s.TotalPoints);
                    break;
                case "longestShot_desc":
                    highscores = highscores.OrderBy(s => s.LongestShot);
                    break;
                case "longestShot_asc":
                    highscores = highscores.OrderByDescending(s => s.LongestShot);
                    break;
                case "totalDistance_desc":
                    highscores = highscores.OrderBy(s => s.TotalDistance);
                    break;
                case "totalDistance_asc":
                    highscores = highscores.OrderByDescending(s => s.TotalDistance);
                    break;
                case "maxShotMade_desc":
                    highscores = highscores.OrderBy(s => s.MaxShotMade);
                    break;
                case "maxShotMade_asc":
                    highscores = highscores.OrderByDescending(s => s.MaxShotMade);
                    break;
                case "consecutiveShots_desc":
                    highscores = highscores.OrderBy(s => s.ConsecutiveShots);
                    break;
                case "consecutiveShots_asc":
                    highscores = highscores.OrderByDescending(s => s.ConsecutiveShots);
                    break;
                case "twoMade_desc":
                    highscores = highscores.OrderBy(s => s.TwoMade);
                    break;
                case "twoMade_asc":
                    highscores = highscores.OrderByDescending(s => s.TwoMade);
                    break;
                case "twoAtt_desc":
                    highscores = highscores.OrderBy(s => s.TwoAtt);
                    break;
                case "twoAtt_asc":
                    highscores = highscores.OrderByDescending(s => s.TwoAtt);
                    break;
                case "threeMade_desc":
                    highscores = highscores.OrderBy(s => s.ThreeMade);
                    break;
                case "threeMade_asc":
                    highscores = highscores.OrderByDescending(s => s.ThreeMade);
                    break;
                case "threeAtt_desc":
                    highscores = highscores.OrderBy(s => s.ThreeAtt);
                    break;
                case "threeAtt_asc":
                    highscores = highscores.OrderByDescending(s => s.ThreeAtt);
                    break;
                case "fourMade_desc":
                    highscores = highscores.OrderBy(s => s.FourMade);
                    break;
                case "fourMade_asc":
                    highscores = highscores.OrderByDescending(s => s.FourMade);
                    break;
                case "fourAtt_desc":
                    highscores = highscores.OrderBy(s => s.FourAtt);
                    break;
                case "fourAtt_asc":
                    highscores = highscores.OrderByDescending(s => s.FourAtt);
                    break;
                case "sevenMade_desc":
                    highscores = highscores.OrderBy(s => s.SevenMade);
                    break;
                case "sevenMade_asc":
                    highscores = highscores.OrderByDescending(s => s.SevenMade);
                    break;
                case "sevenAtt_desc":
                    highscores = highscores.OrderBy(s => s.FourAtt);
                    break;
                case "sevenAtt_asc":
                    highscores = highscores.OrderByDescending(s => s.ConsecutiveShots);
                    break;
                case "bonusPoints_desc":
                    highscores = highscores.OrderBy(s => s.BonusPoints);
                    break;
                case "bonusPoints_asc":
                    highscores = highscores.OrderByDescending(s => s.BonusPoints);
                    break;
                case "moneyBallMade_desc":
                    highscores = highscores.OrderBy(s => s.MoneyBallMade);
                    break;
                case "moneyBallMade_asc":
                    highscores = highscores.OrderByDescending(s => s.MoneyBallMade);
                    break;
                case "moneyBallAtt_desc":
                    highscores = highscores.OrderBy(s => s.MoneyBallAtt);
                    break;
                case "moneyBallAtt_asc":
                    highscores = highscores.OrderByDescending(s => s.MoneyBallAtt);
                    break;
                case "traffic_desc":
                    highscores = highscores.OrderBy(s => s.TrafficEnabled);
                    break;
                case "traffic_asc":
                    highscores = highscores.OrderByDescending(s => s.TrafficEnabled);
                    break;
                case "enemies_desc":
                    highscores = highscores.OrderBy(s => s.EnemiesEnabled);
                    break;
                case "enemies_asc":
                    highscores = highscores.OrderByDescending(s => s.EnemiesEnabled);
                    break;
                case "enemieskilled_desc":
                    highscores = highscores.OrderBy(s => s.EnemiesKilled);
                    break;
                case "enemieskilled_asc":
                    highscores = highscores.OrderByDescending(s => s.EnemiesKilled);
                    break;
                case "sniper_desc":
                    highscores = highscores.OrderBy(s => s.SniperEnabled);
                    break;
                case "sniper_asc":
                    highscores = highscores.OrderByDescending(s => s.SniperEnabled);
                    break;
                case "sniperMode_desc":
                    highscores = highscores.OrderBy(s => s.SniperMode);
                    break;
                case "sniperMode_asc":
                    highscores = highscores.OrderByDescending(s => s.SniperMode);
                    break;
                case "sniperModeName_desc":
                    highscores = highscores.OrderBy(s => s.SniperModeName);
                    break;
                case "sniperModeName_asc":
                    highscores = highscores.OrderByDescending(s => s.SniperModeName);
                    break;
                case "sniperHits_desc":
                    highscores = highscores.OrderBy(s => s.SniperHits);
                    break;
                case "sniperHits_asc":
                    highscores = highscores.OrderByDescending(s => s.SniperHits);
                    break;
                case "sniperShots_desc":
                    highscores = highscores.OrderBy(s => s.SniperShots);
                    break;
                case "sniperShots_asc":
                    highscores = highscores.OrderByDescending(s => s.SniperShots);
                    break;
                default:
                    highscores = highscores.OrderBy(x => x.Id).Skip(0).Take(50);
                    break;
            }

            return highscores;
        }
    }
}
