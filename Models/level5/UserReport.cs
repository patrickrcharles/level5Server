using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Controllers.level5
{
    public partial class UserReport
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Report { get; set; }
        public string IpAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
