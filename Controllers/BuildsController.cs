﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers
{
    public class BuildsController : Controller
    {
        [Route("[controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
