using System;
using System.Collections.Generic;

namespace level5Server.Models.serialkiller
{
    public partial class Victim
    {
        public int Id { get; set; }
        public string VictimId { get; set; }
        public string KillerId { get; set; }
        public string CrimeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public DateTime CrimeDate { get; set; }
        public string CrimeType { get; set; }
    }
}
