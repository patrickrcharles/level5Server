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
        public DateTime BirthDate { get; set; }
        public DateTime DateMurdered { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String note { get; set; }
        public int AgeAtDeath { get; set; }
    }
}
