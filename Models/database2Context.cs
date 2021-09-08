using System.Configuration;
using Microsoft.EntityFrameworkCore;
using mysql_scaffold_dbcontext_test.Models.SerialKiller;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mysql_scaffold_dbcontext_test.Models
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

        public virtual DbSet<KillerModel> Killers { get; set; }

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
            System.Diagnostics.Debug.WriteLine("create model db2");

            modelBuilder.Entity<KillerModel>(entity =>
            {
                //entity.HasKey(e => e.id)
                //   .HasName("PRIMARY");

                //entity.ToTable("ServerStats");

                //entity.Property(e => e.id).HasColumnName("id");
                //entity.Property(e => e.NumberOfUsers).HasColumnName("NumberOfUsers");
                //entity.Property(e => e.NumberOfTotalTimePlayed).HasColumnName("NumberOfTotalTimePlayed");

                entity.ToTable("killers");

                entity.HasIndex(e => e.Id)
                    .HasName("PRIMARY");

                entity.Property(e => e.KillerId)
                .HasColumnName("killerId");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
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

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
