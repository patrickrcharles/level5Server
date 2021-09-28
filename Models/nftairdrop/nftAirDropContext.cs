using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mysql_scaffold_dbcontext_test.Models.nftairdrop
{
    public partial class nftAirDropContext : DbContext
    {
        public nftAirDropContext()
        {
        }

        public nftAirDropContext(DbContextOptions<nftAirDropContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NFT> Nft { get; set; }
        public virtual DbSet<NFTRequest> Nftrequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=database-1.ctnfhe6sfb4k.us-east-2.rds.amazonaws.com;user id=admin;pwd=GREENelk93;database=NFTAirDrop;persistsecurityinfo=True", x => x.ServerVersion("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NFT>(entity =>
            {
                entity.ToTable("NFT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvailableRequests).HasColumnName("availableRequests");
                entity.Property(e => e.MaxRequests).HasColumnName("maxRequests");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TokenId)
                    .HasColumnName("tokenId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<NFTRequest>(entity =>
            {
                entity.ToTable("NFTRequest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RequestAddress)
                    .HasColumnName("requestAddress")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TokenId)
                    .HasColumnName("tokenId")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ipAddress")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("timeStamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Transferred).HasColumnName("transferred");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
