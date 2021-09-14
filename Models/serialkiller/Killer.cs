using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public partial class Killer
    {
        public int Id { get; set; }
        public string KillerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public DateTime Died { get; set; }
    }
}
