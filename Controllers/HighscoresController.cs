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

        public HighscoresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Highscores
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            //get last 50 scores
            return View(await _context.Highscores.OrderByDescending(x => x.Id).Skip(0).Take(50).ToListAsync());
                
        }

        // GET: Highscores
        [Route("[controller]/list")]
        public async Task<IActionResult> List()
        {
            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            //var highscores = from h in _context.Highscores
            //               select h;
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        highscores = highscores.OrderByDescending(s => s.TotalPoints);
            //        break;
            //    case "Date":
            //        highscores = highscores.OrderBy(s => s.MaxShotMade);
            //        break;
            //    case "date_desc":
            //        highscores = highscores.OrderByDescending(s => s.MaxShotAtt);
            //        break;
            //    default:
            //        highscores = highscores.OrderBy(s => s.Date);
            //        break;
            //}

            return View(await _context.Highscores.ToListAsync());
        }

        [Route("[controller]/id/{id?}")]
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

        [Route("[controller]/create")]
        // GET: Highscores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Highscores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Userid,Modeid,Characterid,Levelid,Character,Level,Os,Version,Date,Time,TotalPoints,LongestShot,TotalDistance,MaxShotMade,MaxShotAtt,ConsecutiveShots,TrafficEnabled,HardcoreEnabled,EnemiesKilled,Platform,Device,Ipaddress,Scoreid,TwoMade,TwoAtt,ThreeMade,ThreeAtt,FourMade,FourAtt,SevenMade,SevenAtt")] Highscores highscores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highscores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(highscores);
        }

        // GET: Highscores/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Userid,Modeid,Characterid,Levelid,Character,Level,Os,Version,Date,Time,TotalPoints,LongestShot,TotalDistance,MaxShotMade,MaxShotAtt,ConsecutiveShots,TrafficEnabled,HardcoreEnabled,EnemiesKilled,Platform,Device,Ipaddress,Scoreid,TwoMade,TwoAtt,ThreeMade,ThreeAtt,FourMade,FourAtt,SevenMade,SevenAtt")] Highscores highscores)
        {
            if (id != highscores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highscores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighscoresExists(highscores.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(highscores);
        }

        // GET: Highscores/Delete/5
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highscores = await _context.Highscores.FindAsync(id);
            _context.Highscores.Remove(highscores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighscoresExists(int id)
        {
            return _context.Highscores.Any(e => e.Id == id);
        }
    }
}
