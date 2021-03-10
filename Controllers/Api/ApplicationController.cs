using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mysql_scaffold_dbcontext_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.Api
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly DatabaseContext _context;
        public ApplicationController(DatabaseContext context)
        {
            _context = context;
        }

        //--------------------- HTTP GET ---------------------------------------------------
        // GET: /api/highscores
        // get all highscores
        [HttpGet("version")]
        public ActionResult<Application> GetCurrentVersion()
        {
            var version = _context.Application
                .ToList()
                .LastOrDefault();

            return version;
        }
    }
}
