using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public partial class Crime
    {

        public int Id { get; set; }
        public string Crimeid { get; set; }
        public string KillerId { get; set; }
        public string VictimId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public string CrimeType { get; set; }
    }
}
