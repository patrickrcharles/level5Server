using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.level5.Api
{
    //[ApiVersion("1")]
    [Route("api/userreport")]
    [ApiController]
    public class UserReportApiController : Controller
    {
        private readonly Level5Context _context;

        public UserReportApiController(Level5Context context)
        {
            _context = context;
        }

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/highscores
        // get all users
        /// <summary>
        /// Get all users in database
        /// </summary>
        //[Authorize]
        [MapToApiVersion("1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReport>>> GetAllReports()
        {
            return await _context.UserReports.ToListAsync();
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<ActionResult<Users>> PostUserReport(UserReport userReport)
        {
            //if (UserNameExists(user.Username))
            //{
            //    return BadRequest();
            //}
            userReport.Date = DateTime.UtcNow;
            System.Diagnostics.Debug.WriteLine("userReport.Date : "+ userReport.Date);
            try
            {
                _context.UserReports.Add(userReport);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllReports), new { id = userReport.Id }, User);
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }
    }
}
