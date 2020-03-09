using Microsoft.EntityFrameworkCore;

namespace Gis.Models.DB
{
    public class WebGisContext : DbContext
    {
        public WebGisContext(DbContextOptions<WebGisContext> options)
            : base(options)
        {
        }
        public virtual DbSet<RoadUsChar> RoadUsChar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BEDERKB\\SQLEXPRESS;Database=webGis;Trusted_Connection=True;",
                    x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoadUsChar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("road_us_char");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoadGeom).HasColumnName("road_geom");
            });
        }
    }
}