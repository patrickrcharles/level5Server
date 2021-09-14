using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public partial class KillerLocation
    {
        public int Id { get; set; }
        public string LocationId { get; set; }
        public string KillerId { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
