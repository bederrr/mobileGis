using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gis.Models.DB
{
    public partial class webGisContext : DbContext
    {
        public webGisContext()
        {
        }

        public webGisContext(DbContextOptions<webGisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Results20200214163036> Results20200214163036 { get; set; }
        public virtual DbSet<RoadUsChar> RoadUsChar { get; set; }
        public virtual DbSet<RoadsUs> RoadsUs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=BEDERKB\\SQLEXPRESS;Database=webGis;Trusted_Connection=True;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Results20200214163036>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("results-20200214-163036");

                entity.Property(e => e.RoadGeom)
                    .HasColumnName("road_geom")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoadUsChar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("road_us_char");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoadGeom).HasColumnName("road_geom");
            });

            modelBuilder.Entity<RoadsUs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roads_us");

                entity.Property(e => e.RoadGeom).HasColumnName("road_geom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
