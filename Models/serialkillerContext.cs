using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mysql_scaffold_dbcontext_test.Models
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

        public virtual DbSet<Crime> Crime { get; set; }
        public virtual DbSet<KillerLocation> KillerLocation { get; set; }
        public virtual DbSet<Killer> Killers { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Victim> Victims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=database-1.ctnfhe6sfb4k.us-east-2.rds.amazonaws.com;user id=admin;pwd=GREENelk93;database=serialkiller;persistsecurityinfo=True", x => x.ServerVersion("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crime>(entity =>
            {
                entity.HasKey(e => e.KillerId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CrimeId)
                    .HasName("crimeid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.KillerId)
                    .HasColumnName("killerId")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.CrimeId)
                    .HasColumnName("crimeid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.VictimId).HasColumnName("victimId");
            });

            modelBuilder.Entity<KillerLocation>(entity =>
            {
                entity.HasKey(e => e.KillerId)
                    .HasName("PRIMARY");

                entity.Property(e => e.KillerId)
                    .HasColumnName("killerId")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Killer>(entity =>
            {
                entity.HasKey(e => e.KillerId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.KillerId)
                    .HasName("killerId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.KillerId).HasColumnName("killerId");

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
                entity.HasNoKey();

                entity.HasIndex(e => e.NoteId)
                    .HasName("noteId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CrimeId).HasColumnName("crimeId");

                entity.Property(e => e.KillerId).HasColumnName("killerId");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NoteId)
                    .HasColumnName("noteId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VictimId).HasColumnName("victimId");
            });

            modelBuilder.Entity<Victim>(entity =>
            {
                entity.HasKey(e => e.VictimId)
                    .HasName("PRIMARY");

                entity.Property(e => e.VictimId).HasColumnName("victimId");
                entity.Property(e => e.CrimeId).HasColumnName("crimeId");

                entity.Property(e => e.Born)
                    .HasColumnName("born")
                    .HasColumnType("datetime");

                entity.Property(e => e.CrimeType)
                    .IsRequired()
                    .HasColumnName("crimeType")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Died)
                    .HasColumnName("died")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.KillerId).HasColumnName("killerId");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
