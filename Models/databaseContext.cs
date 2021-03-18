using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mysql_scaffold_dbcontext_test.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Highscores> Highscores { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Application> Application { get; set; }

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

                entity.Property(e => e.SniperEnabled).HasColumnName("sniperHits");

                entity.Property(e => e.SniperMode).HasColumnName("sniperShots");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
