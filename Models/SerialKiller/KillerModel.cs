using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Models.SerialKiller
{
    public partial class KillerModel
    {
        public int Id { get; set; }
        public int KillerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfVictims { get; set; }
    }
}
