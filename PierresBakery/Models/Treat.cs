using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntries = new HashSet<FlavorTreat>();
    }

    public int TreatId { get; set; }
    public string TreatName { get; set; }

    public ICollection<FlavorTreat> JoinEntries { get; }
  }
}  