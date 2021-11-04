using Microsoft.AspNetCore.Mvc;

namespace mysql_scaffold_dbcontext_test.Controllers
{
    public class ChangeLogController : Controller
    {
        [Route("[controller]")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
