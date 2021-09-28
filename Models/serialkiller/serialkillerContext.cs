using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mysql_scaffold_dbcontext_test.Models.serialkiller
{
    public partial class serialkillerContext : DbContext
    {
        public serialkillerContext()
        {
        }

        public serialkillerContext(DbContextOptions<serialkillerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crime> Crimes { get; set; }
        public virtual DbSet<KillerLocation> KillerLocations { get; set; }
        public virtual DbSet<Killer> Killers { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Victim> Victims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=database-1.ctnfhe6sfb4k.us-east-2.rds.amazonaws.com;user id=admin;pwd=GREENelk93;database=serialkiller;persistsecurityinfo=True", x => x.ServerVersion("8.0.23-mysql"));
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crime>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CrimeType)
                    .IsRequired()
                    .HasColumnName("crimeType")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Crimeid)
                    .IsRequired()
                    .HasColumnName("crimeid")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.KillerId)
                    .IsRequired()
                    .HasColumnName("killerId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middleName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VictimId)
                    .IsRequired()
                    .HasColumnName("victimId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<KillerLocation>(entity =>
            {
                entity.HasIndex(e => e.LocationId)
                    .HasName("locationId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KillerId)
                    .IsRequired()
                    .HasColumnName("killerId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Killer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Born)
                    .HasColumnName("born")
                    .HasColumnType("datetime");

                entity.Property(e => e.Died)
                    .HasColumnName("died")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.KillerId)
                    .HasColumnName("killerId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middleName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasIndex(e => e.NoteId)
                    .HasName("noteId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CrimeId)
                    .IsRequired()
                    .HasColumnName("crimeId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.KillerId)
                    .IsRequired()
                    .HasColumnName("killerId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Note)
                    //.IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NoteId)
                    .HasColumnName("noteId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VictimId)
                    .IsRequired()
                    .HasColumnName("victimId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Victim>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Born)
                    .HasColumnName("born")
                    .HasColumnType("datetime");

                entity.Property(e => e.CrimeId)
                    .IsRequired()
                    .HasColumnName("crimeId")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CrimeType)
                    .IsRequired()
                    .HasColumnName("crimeType")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CrimeDate)
                    .HasColumnName("crimeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.KillerId)
                    .IsRequired()
                    .HasColumnName("killerId")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middleName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VictimId)
                    .IsRequired()
                    .HasColumnName("victimId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
