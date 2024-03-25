﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using level5Server.Models;
using level5Server.Models.level5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace level5Server.Controllers.level5.Api
{
    //[ApiVersion("1")]
    [Route("api/userreport")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReport>>> GetAllReports()
        {
            return await _context.UserReports.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostUserReport(UserReport userReport)
        {
            // empty text
            if (String.IsNullOrEmpty(userReport.Report))
            {
                return BadRequest();
            }
            // text exists
            if (ReportTextExists(userReport.Report))
            {
                return Conflict();
            }

            userReport.Date = DateTime.UtcNow;
            //System.Diagnostics.Debug.WriteLine("userReport.Date : "+ userReport.Date);
            try
            {
                _context.UserReports.Add(userReport);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllReports), new { id = userReport.Id }, userReport);
            }
            catch (DbUpdateConcurrencyException e)
            {
                System.Diagnostics.Debug.WriteLine("----- SERVER : DbUpdateConcurrencyException : " + e);
                return BadRequest();
            }
        }

        private bool ReportTextExists(string report)
        {
            return _context.UserReports.Where(e => e.Report.Equals(report)).Any();
        }
    }
}
