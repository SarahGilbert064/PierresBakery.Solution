using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Child
  {
    public Child()
    {
      this.JoinEntries = new HashSet<FlavorChild>();
    }

    public int ChildId { get; set; }
    public string ChildName { get; set; }

    public ICollection<FlavorChild> JoinEntries { get; }
  }
}  