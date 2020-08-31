using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MiAPI.Infrastructure.Repository.Models
{
    public partial class VideoClubContext : DbContext
    {
        public VideoClubContext(){
        }

        public VideoClubContext(DbContextOptions<VideoClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Videos> Videos { get; set; }

        // Unable to generate entity type for table 'dbo.VersionInfo'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

                var connectionString = configuration.GetConnectionString("SqlFormacion");
                if(string.IsNullOrEmpty(connectionString)) {
                    throw new Exception("The connection string has been lost");
                }
                optionsBuilder.UseSqlServer(connectionString);



            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            });
        }
    }
}
