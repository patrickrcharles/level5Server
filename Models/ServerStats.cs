using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class ServerStats
    {
        int NumberOfUsers { get; set; }
        float NumberOfTotalTimePlayed { get; set; }
        int NumberOfGamesPlayed { get; set; }
        int NumberOfGamesPlayedHardCore { get; set; }
        int NumberOfGamesPlayedTraffic { get; set; }
        int NumberOfGamesPlayedEnemies { get; set; }
        int NumberOfGamesPlayedSniper { get; set; }
        int NumberOfTotal2ShotsMade { get; set; }
        int NumberOfTotal2ShotsAttempted { get; set; }
        int NumberOfTotal3ShotsMade { get; set; }
        int NumberOfTotal3ShotsAttempted { get; set; }
        int NumberOfTotal4ShotsMade { get; set; }
        int NumberOfTotal4ShotsAttempted { get; set; }
        int NumberOfTotal7ShotsMade { get; set; }
        int NumberOfTotal7ShotsAttempted { get; set; }
        int NumberOfTotalMoneyShotsMade { get; set; }
        int NumberOfTotalMoneyShotsAttempted { get; set; }
        int NumberOfTotalShotsMade { get; set; }
        int NumberOfTotalShotsAttempted { get; set; }
        int NumberOfTotalPointsScored { get; set; }
        int NumberOfTotalEnemiesKilled { get; set; }
        int NumberOfSniperShots { get; set; }
        int NumberOfSniperHits { get; set; }

        string MostPlayedCharacter { get; set; }
        string MostPlayedLevel { get; set; }

        string MostConsecutiveShots { get; set; }
        string MostConsecutiveShotsUsername { get; set; }
        float LongestShot { get; set; }
        string LongestShotUsername { get; set; }
    }
}
