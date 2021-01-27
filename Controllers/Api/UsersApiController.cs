using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;

namespace mysql_scaffold_dbcontext_test.Controllers.Api
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : Controller
    {
        private readonly Level5Context _context;

        public UsersApiController(Level5Context context)
        {
            _context = context;
        }

        // GET: /api/users
        // get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{userid}")]
        // GET: Users by userid
        // get user by user id
        public async Task<Users> GetUserDetails(int? userid)
        {
            if (userid == null)
            {
                return null;
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == userid);
            if (users == null)
            {
                return null;
            }

            return users;
        }
        // PUT: api/users/5
        // "insert, replace if already exists"
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.Userid)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Highscores
        // "create new"
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {

            System.Diagnostics.Debug.WriteLine("----- public async Task<ActionResult<Users>> PostUser(Users user)");
            System.Diagnostics.Debug.WriteLine("----- users : " + user);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Userid }, user);
        }

        // POST: api/Highscores
        // "create new"
        //[HttpPost]
        //public async Task<ActionResult<Highscores>> PostHighscores(Highscores highscores)
        //{
        //    System.Diagnostics.Debug.WriteLine("----- highscores : " + highscores);
        //    _context.Highscores.Add(highscores);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetHighscores), new { id = highscores.Id }, highscores);
        //}


        //    // GET: Users/Edit/5
        //    [Route("[controller]/edit/{id}")]
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var users = await _context.Users.FindAsync(id);
        //        if (users == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(users);
        //    }

        //    // POST: Users/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [Route("[controller]/edit/{id}")]
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Userid,Username,Firstname,Lastname,Password,Email,Ipaddress,Signupdate,Lastlogin")] Users users)
        //    {
        //        if (id != users.Userid)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                System.Diagnostics.Debug.WriteLine("----- edit");
        //                _context.Update(users);
        //                System.Diagnostics.Debug.WriteLine("----- _context.Update(users);");
        //                await _context.SaveChangesAsync();
        //                System.Diagnostics.Debug.WriteLine("----- _context.Update(users);");
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!UsersExists(users.Userid))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(users);
        //    }

        //    // GET: Users/Delete/5
        //    [Route("[controller]/delete/{id}")]
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var users = await _context.Users
        //            .FirstOrDefaultAsync(m => m.Userid == id);
        //        if (users == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(users);
        //    }

        //    // POST: Users/Delete/5
        //    [Route("[controller]/delete/{id}")]
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var users = await _context.Users.FindAsync(id);
        //        _context.Users.Remove(users);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Userid == id);
        }
    }
}
