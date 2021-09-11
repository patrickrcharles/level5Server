using System.Configuration;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models.SerialKiller;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public partial class database2Context : DbContext
    {
        public database2Context()
        {
            System.Diagnostics.Debug.WriteLine("database2Context()");
        }

        public database2Context(DbContextOptions<database2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Killers> Killers { get; set; }
        public virtual DbSet<Victims> Victims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            System.Diagnostics.Debug.WriteLine("OnConfiguring()");
            System.Diagnostics.Debug.WriteLine("(!optionsBuilder.IsConfigured) : " + (!optionsBuilder.IsConfigured));
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["DefaultConnection2"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Killers>(entity =>
            {
                entity.HasKey(e => e.KillerId)
                .HasName("PRIMARY");

                entity.ToTable("killers");
                entity.HasIndex(e => e.KillerId)
                    .HasName("killerId_UNIQUE")
                    .IsUnique();
                entity.Property(e => e.KillerId).HasColumnName("killerId");
                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.NumberOfVictims)
                    .HasColumnName("numberOfVictims");
                entity.Property(e => e.BirthDate)
                    .HasColumnName("birthDate")
                    .HasColumnType("Date");
            });

            modelBuilder.Entity<Victims>(entity =>
            {
                entity.HasKey(e => e.VictimId)
                .HasName("PRIMARY");

                entity.ToTable("victims");
                entity.HasIndex(e => e.VictimId)
                    .HasName("victimId_UNIQUE")
                    .IsUnique();
                entity.Property(e => e.VictimId).HasColumnName("victimId");
                entity.Property(e => e.KillerId).HasColumnName("killerId");
                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.BirthDate)
                    .HasColumnName("born")
                    .HasColumnType("Date");
                entity.Property(e => e.DateMurdered)
                    .HasColumnName("dateMurdered")
                    .HasColumnType("Date");
                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.note)
                    .HasColumnName("notes")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.AgeAtDeath)
                    .HasColumnName("ageAtDeath");
            });

            //            public int VictimId { get; set; }
            //public int KillerId { get; set; }
            //public string FirstName { get; set; }
            //public string MiddleName { get; set; }
            //public string LastName { get; set; }
            //public DateTime BirthDate { get; set; }
            //public DateTime DateMurdered { get; set; }
            //public String City { get; set; }
            //public String State { get; set; }
            //public String note { get; set; }
            //public int AgeAtDeath { get; set; }

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
