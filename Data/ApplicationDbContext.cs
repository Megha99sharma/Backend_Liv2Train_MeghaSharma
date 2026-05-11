using Microsoft.EntityFrameworkCore;
using TrainingCenterRegistry.Models;

namespace TrainingCenterRegistry.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TrainingCenter> TrainingCenters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingCenter>()
                .OwnsOne(x => x.Address);

            modelBuilder.Entity<TrainingCenter>()
                .Property(x => x.CoursesOffered)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .ToList()
                );
        }
    }
}
