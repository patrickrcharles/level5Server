﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class Highscores
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Modeid { get; set; }
        public int Characterid { get; set; }
        public int Levelid { get; set; }
        public string Character { get; set; }
        public string Level { get; set; }
        public string Os { get; set; }
        public string Version { get; set; }
        public string Date { get; set; }
        public float Time { get; set; }
        public int TotalPoints { get; set; }
        public float LongestShot { get; set; }
        public float TotalDistance { get; set; }
        public int MaxShotMade { get; set; }
        public int MaxShotAtt { get; set; }
        public int ConsecutiveShots { get; set; }
        public int TrafficEnabled { get; set; }
        public int HardcoreEnabled { get; set; }
        public int EnemiesKilled { get; set; }
        public string Platform { get; set; }
        public string Device { get; set; }
        public string Ipaddress { get; set; }
        public string Scoreid { get; set; }
        public int? TwoMade { get; set; }
        public int? TwoAtt { get; set; }
        public int? ThreeMade { get; set; }
        public int? ThreeAtt { get; set; }
        public int? FourMade { get; set; }
        public int? FourAtt { get; set; }
        public int? SevenMade { get; set; }
        public int? SevenAtt { get; set; }
    }
}
