using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class Victim
    {
        public int VictimId { get; set; }
        public int CrimeId { get; set; }
        public int KillerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public DateTime Died { get; set; }
        public string CrimeType { get; set; }
    }
}
