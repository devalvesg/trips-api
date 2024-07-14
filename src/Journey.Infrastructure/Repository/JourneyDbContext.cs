using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure.Repository;

public class JourneyDbContext : DbContext
{
    public JourneyDbContext(DbContextOptions<JourneyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=JourneyDB;User Id=sa;Password=sql@1234;TrustServerCertificate=True;");
    }
}
