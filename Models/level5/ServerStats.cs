﻿using System;
using System.Collections.Generic;

namespace level5Server.Models
{
    public partial class ServerStats
    {
        public int Id { get; set; }
        public int? NumberOfUsers { get; set; }
        public float? NumberOfTotalTimePlayed { get; set; }
        public int? NumberOfGamesPlayed { get; set; }
        public int? NumberOfGamesPlayedHardcore { get; set; }
        public int? NumberofGamesPlayedTraffic { get; set; }
        public int? NumberofGamesPlayedEnemies { get; set; }
        public int? NumberofGamesPlayedSniper { get; set; }
        public int? NumberOfTotal2ShotsMade { get; set; }
        public int? NumberOfTotal2ShotsAtt { get; set; }
        public int? NumberOfTotal3ShotsMade { get; set; }
        public int? NumberOfTotal3ShotsAtt { get; set; }
        public int? NumberOfTotal4ShotsMade { get; set; }
        public int? NumberOfTotal4ShotsAtt { get; set; }
        public int? NumberOfTotal7ShotsMade { get; set; }
        public int? NumberOfTotal7ShotsAtt { get; set; }
        public int? NumberOfTotalMoneyShotsMade { get; set; }
        public int? NumberOfTotalMoneyShotsAtt { get; set; }
        public int? NumberOfTotalShotsMade { get; set; }
        public int? NumberOfTotalShotsAtt { get; set; }
        public int? NumberOfTotalPointsScored { get; set; }
        public int? NumberOfTotalEnemiesKilled { get; set; }
        public string MostPlayedCharacter { get; set; }
        public string MostPlayedLevel { get; set; }
        public int? MostConsecutiveShots { get; set; }
        public string MostConsecutiveShotsUsername { get; set; }
        public float? LongestShot { get; set; }
        public string LongestShotUsername { get; set; }

    }
}
