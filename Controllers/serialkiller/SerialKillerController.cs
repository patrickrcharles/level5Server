using Microsoft.AspNetCore.Mvc;
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
        private readonly database2Context _context;

        public SerialKillerController(database2Context context)
        {
            _context = context;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Killers = _context.Killers;
            mymodel.Victims = _context.Victims;
            return View(mymodel);
        }

    }
}
