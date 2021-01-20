using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.JoinEntries = new HashSet<FlavorTreat>();
        }

        public int FlavorId { get; set; }
        public string FlavorName { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ICollection<FlavorTreat> JoinEntries { get; }

    }
}

