using IwasBahaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IwasBahaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RoadStatusUpdate> RoadStatusUpdates => Set<RoadStatusUpdate>();
        public DbSet<RoadStatus> RoadStatuses => Set<RoadStatus>();
        public DbSet<Road> Roads => Set<Road>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoadStatusUpdate>()
                .HasMany(r => r.Statuses)
                .WithOne()
                .HasForeignKey(r => r.RoadStatusUpdateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoadStatus>()
                .HasMany(r => r.Roads)
                .WithOne()
                .HasForeignKey(r => r.RoadStatusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
