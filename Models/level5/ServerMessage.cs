using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class ServerMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
