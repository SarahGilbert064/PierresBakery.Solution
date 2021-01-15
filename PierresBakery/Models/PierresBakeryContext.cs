using Microsoft.EntityFrameworkCore;

namespace PierresBakery.Models
{
  public class PierresBakeryContext : DbContext
  {
    public virtual DbSet<Flavor> Flavors { get; set; }
    public DbSet<Child> Childs { get; set; }

    public DbSet<FlavorTreat> FlavorTreat { get; set; }

    public PierresBakeryContext(DbContextOptions options) : base(options) { } 
  }
}