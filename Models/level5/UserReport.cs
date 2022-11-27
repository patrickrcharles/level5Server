using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace level5Server.Models
{
    public partial class UserReport
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Report { get; set; }
        public string Os { get; set; }
        public string Device { get; set; }
        public string DeviceName { get; set; }
        public string Version { get; set; }
        public string IpAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
