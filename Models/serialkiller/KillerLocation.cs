using System;
using System.Collections.Generic;

namespace level5Server.Models.serialkiller
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
