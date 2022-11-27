using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace level5Server.Models
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Ipaddress { get; set; }
        public string Signupdate { get; set; }
        public string Lastlogin { get; set; }
        public int IsDev { get; set; }

    }
}
