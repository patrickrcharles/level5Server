using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace level5Server.Models
{
    public partial class ServerMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
    }
}
