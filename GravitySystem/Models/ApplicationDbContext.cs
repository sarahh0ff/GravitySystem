using Microsoft.EntityFrameworkCore;


namespace GravitySystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CelestialBody> CelestialBodies { get; set; }
    }
}
