using Microsoft.EntityFrameworkCore;


namespace GravitySystem.Models//tengo que poner un cometario a ver que tal
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
