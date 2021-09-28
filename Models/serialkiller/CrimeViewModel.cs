using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public class CrimeViewModel
    {
        public IEnumerable<Killer> Killers { get; set; }
        public IEnumerable<Victim> Victims { get; set; }
        public IEnumerable<Crime> Crimes { get; set; }
        public IEnumerable<KillerLocation> KillerLocations { get; set; }
        public IEnumerable<Notes> Notes { get; set; }
        public Crime Crime { get; set; }
        public Killer Killer { get; set; }
    }
}
