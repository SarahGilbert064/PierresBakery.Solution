using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PierresBakery.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.JoinEntries = new HashSet<FlavorTreat>();
        }
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm tt}")]
        public DateTime StartDate { get; set; }
        public int FlavorId { get; set; }

        [DisplayName("Flavor Name")]
        public string FlavorName { get; set; }
        public virtual ICollection<FlavorTreat> JoinEntries { get; set; }
    }
}

