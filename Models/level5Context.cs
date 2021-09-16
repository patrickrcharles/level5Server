using System.Configuration;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Controllers.level5;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class Level5Context : DbContext
    {
        public Level5Context()
        {
        }

        public Level5Context(DbContextOptions<Level5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Highscores> Highscores { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ServerStats> ServerStats { get; set; }
        public virtual DbSet<UserReport> UserReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Highscores>(entity =>
            {
                entity.ToTable("highscores");
                entity.HasIndex(e => e.Id)
                    .HasName("scoreid_UNIQUE")
                    .IsUnique();
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Character)
                    .IsRequired()
                    .HasColumnName("character")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.Characterid).HasColumnName("characterid");
                entity.Property(e => e.ConsecutiveShots).HasColumnName("consecutiveShots");
                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasColumnName("device")
                    .HasColumnType("varchar(45)")
                    .HasComment("what specific device being used")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.EnemiesKilled).HasColumnName("enemiesKilled");

                entity.Property(e => e.FourAtt).HasColumnName("fourAtt");

                entity.Property(e => e.FourMade).HasColumnName("fourMade");

                entity.Property(e => e.HardcoreEnabled).HasColumnName("hardcoreEnabled");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("ipaddress")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnName("level")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Levelid).HasColumnName("levelid");

                entity.Property(e => e.LongestShot).HasColumnName("longestShot");

                entity.Property(e => e.MaxShotAtt).HasColumnName("maxShotAtt");

                entity.Property(e => e.MaxShotMade).HasColumnName("maxShotMade");

                entity.Property(e => e.Modeid).HasColumnName("modeid");

                entity.Property(e => e.ModeName)
                    .HasColumnName("modeName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("os")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasColumnName("platform")
                    .HasColumnType("varchar(45)")
                    .HasComment("if desktop/mobile")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Scoreid)
                    .IsRequired()
                    .HasColumnName("scoreid")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SevenAtt).HasColumnName("sevenAtt");

                entity.Property(e => e.SevenMade).HasColumnName("sevenMade");

                entity.Property(e => e.ThreeAtt).HasColumnName("threeAtt");

                entity.Property(e => e.ThreeMade).HasColumnName("threeMade");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TotalDistance).HasColumnName("totalDistance");

                entity.Property(e => e.TotalPoints).HasColumnName("totalPoints");

                entity.Property(e => e.TrafficEnabled).HasColumnName("trafficEnabled");

                entity.Property(e => e.TwoAtt).HasColumnName("twoAtt");

                entity.Property(e => e.TwoMade).HasColumnName("twoMade");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.BonusPoints).HasColumnName("bonusPoints");

                entity.Property(e => e.MoneyBallMade).HasColumnName("moneyBallMade");

                entity.Property(e => e.MoneyBallAtt).HasColumnName("moneyBallAtt");

                entity.Property(e => e.SniperEnabled).HasColumnName("sniperEnabled");

                entity.Property(e => e.SniperMode).HasColumnName("sniperMode");

                entity.Property(e => e.SniperModeName)
                    .HasColumnName("sniperModeName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SniperHits).HasColumnName("sniperHits");

                entity.Property(e => e.SniperShots).HasColumnName("sniperShots");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Userid)
                    .HasName("iduser_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("ipaddress")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Lastlogin)
                    .HasColumnName("lastlogin")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Signupdate)
                    .HasColumnName("signupdate")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("PRIMARY");
                entity.ToTable("Application");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.CurrentVersion)
                    .HasColumnName("currentVersion")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");


            });

            modelBuilder.Entity<ServerStats>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("ServerStats");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.NumberOfUsers).HasColumnName("NumberOfUsers");
                entity.Property(e => e.NumberOfTotalTimePlayed).HasColumnName("NumberOfTotalTimePlayed");
                entity.Property(e => e.NumberOfGamesPlayed).HasColumnName("NumberOfGamesPlayed");
                entity.Property(e => e.NumberOfGamesPlayedHardcore).HasColumnName("NumberOfGamesPlayedHardcore");
                entity.Property(e => e.NumberofGamesPlayedTraffic).HasColumnName("NumberofGamesPlayedTraffic");
                entity.Property(e => e.NumberofGamesPlayedEnemies).HasColumnName("NumberofGamesPlayedEnemies");
                entity.Property(e => e.NumberofGamesPlayedSniper).HasColumnName("NumberofGamesPlayedSniper");
                
                entity.Property(e => e.NumberOfTotal2ShotsMade).HasColumnName("NumberOfTotal2ShotsMade");
                entity.Property(e => e.NumberOfTotal2ShotsAtt).HasColumnName("NumberOfTotal2ShotsAtt");

                entity.Property(e => e.NumberOfTotal3ShotsMade).HasColumnName("NumberOfTotal3ShotsMade");
                entity.Property(e => e.NumberOfTotal3ShotsAtt).HasColumnName("NumberOfTotal3ShotsAtt");
            
                entity.Property(e => e.NumberOfTotal4ShotsMade).HasColumnName("NumberOfTotal4ShotsMade");
                entity.Property(e => e.NumberOfTotal4ShotsAtt).HasColumnName("NumberOfTotal4ShotsAtt");

                entity.Property(e => e.NumberOfTotal7ShotsMade).HasColumnName("NumberOfTotal7ShotsMade");
                entity.Property(e => e.NumberOfTotal7ShotsAtt).HasColumnName("NumberOfTotal7ShotsAtt");

                entity.Property(e => e.NumberOfTotalMoneyShotsMade).HasColumnName("NumberOfTotalMoneyShotsMade");
                entity.Property(e => e.NumberOfTotalMoneyShotsAtt).HasColumnName("NumberOfTotalMoneyShotsAtt");

                entity.Property(e => e.NumberOfTotalShotsMade).HasColumnName("NumberOfTotalTotalShotsMade");
                entity.Property(e => e.NumberOfTotalShotsAtt).HasColumnName("NumberOfTotalTotalShotsAtt");
                entity.Property(e => e.NumberOfTotalPointsScored).HasColumnName("NumberOfTotalTotalPointsScored");
                entity.Property(e => e.NumberOfTotalEnemiesKilled).HasColumnName("NumberOfTotalEnemiesKilled");
                entity.Property(e => e.MostPlayedCharacter).HasColumnName("MostPlayedCharacter");
                entity.Property(e => e.MostPlayedLevel).HasColumnName("MostPlayedLevel");
                entity.Property(e => e.MostConsecutiveShots).HasColumnName("MostConsecutiveShots");
                entity.Property(e => e.MostConsecutiveShotsUsername).HasColumnName("MostConsecutiveShotsUsername");
                entity.Property(e => e.LongestShot).HasColumnName("LongestShot");
                entity.Property(e => e.LongestShotUsername).HasColumnName("LongestShotUsername");
            });

            modelBuilder.Entity<UserReport>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");
                entity.ToTable("UserReport");
                entity.Property(e => e.UserId).HasColumnName("userid");
                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.IpAddress)
                    .HasColumnName("ipaddress")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
