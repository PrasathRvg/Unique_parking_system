using System;
using System.Collections.Generic;

#nullable disable

namespace UniqueParkingWebAPI.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Passes = new HashSet<Pass>();
        }

        public string Id { get; set; }
        public int Vechid { get; set; }
        public string Vechname { get; set; }
        public string Vechno { get; set; }
        public string Vehcolor { get; set; }

        public virtual AspNetUser IdNavigation { get; set; }
        public virtual ICollection<Pass> Passes { get; set; }
    }
}
