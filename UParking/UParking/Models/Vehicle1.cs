using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class Vehicle1
    {
        public Vehicle1()
        {
            Passes = new HashSet<Pass1>();
        }

        public string Id { get; set; }
        public int Vechid { get; set; }
        public string Vechname { get; set; }
        public string Vechno { get; set; }
        public string Vehcolor { get; set; }

        public virtual AspNetUser1 IdNavigation { get; set; }
        public virtual ICollection<Pass1> Passes { get; set; }
    }
}
