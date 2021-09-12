using System;
using System.Collections.Generic;

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public int KillerId { get; set; }
        public int VictimId { get; set; }
        public int CrimeId { get; set; }
        public string Note { get; set; }
    }
}
