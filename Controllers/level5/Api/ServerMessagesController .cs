﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models;
using mysql_scaffold_dbcontext_test.Models.level5;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers
{
    [Route("api/servermessages")]
    [ApiController]
    public class ServerMessagesApi : Controller
    {
        private readonly Level5Context _context;
        public ServerMessagesApi(Level5Context context)
        {
            _context = context;
        }

        //--------------------- HTTP GET ---------------------------------------------------

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<IEnumerable<ServerMessage>>> GetAllVersions()
        {
            return await _context.ServerMessages.OrderByDescending(x => x.Id).ToListAsync();
        }  
    }
}

