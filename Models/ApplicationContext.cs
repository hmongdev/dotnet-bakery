using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    // ("Bakers") is what DB table will be called!
    // this is _context.Bakers
    // DbSet<Baker> Baker model mapped to database
    public DbSet<Baker> Bakers { get; set; } 

    public DbSet<Bread> Breads { get; set; }
    }
}