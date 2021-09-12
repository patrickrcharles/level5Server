using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class Crime
    {
        public int CrimeId { get; set; }
        public int KillerId { get; set; }
        public int VictimId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public string CrimeType { get; set; }
    }
}
