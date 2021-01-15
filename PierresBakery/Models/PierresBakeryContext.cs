using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierresBakery.Models
{
  public class PierresBakeryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }

    public DbSet<FlavorTreat> FlavorTreat { get; set; }

    public PierresBakeryContext(DbContextOptions options) : base(options) { } 
  }
}