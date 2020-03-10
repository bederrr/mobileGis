using System;
using Microsoft.EntityFrameworkCore;

namespace Gis.Models
{
    public partial class WebGisContext : DbContext
    {
        public WebGisContext(DbContextOptions<WebGisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Road> Roads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=bederkb\\SQLEXPRESS;Database=webGis;Trusted_Connection=True;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Road>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoadGeom).HasColumnName("road_geom");
            });
        }
    }
}
