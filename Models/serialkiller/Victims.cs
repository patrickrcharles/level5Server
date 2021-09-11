using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public partial class Victims
    {
        public int VictimId { get; set; }
        public int KillerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public DateTime Died { get; set; }
        public String CauseOfDeath { get; set; }
    }
}
