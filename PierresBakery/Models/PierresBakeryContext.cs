using Microsoft.EntityFrameworkCore;
//Identifying the Database Schema

namespace PierresBakery.Models
{
  public class PierresBakeryContext : DbContext
  {
    public virtual DbSet<Parent> Parents { get; set; } //DBSets are new tables being created. 
    public DbSet<Child> Childs { get; set; }

    public DbSet<ParentChild> ParentChild { get; set; }

    public PierresBakeryContext(DbContextOptions options) : base(options) { } 
  }
}