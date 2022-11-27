using System;
using System.Collections.Generic;

namespace level5Server.Models.serialkiller
{
    public partial class Notes
    {
        public int Id { get; set; }
        public string NoteId { get; set; }
        public string KillerId { get; set; }
        public string VictimId { get; set; }
        public string CrimeId { get; set; }
        public string Note { get; set; }
    }
}
