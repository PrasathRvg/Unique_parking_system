using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class AspNetRole1
    {
        public AspNetRole1()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim1>();
            AspNetUserRoles = new HashSet<AspNetUserRole1>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim1> AspNetRoleClaims { get; set; }
        public virtual ICollection<AspNetUserRole1> AspNetUserRoles { get; set; }
    }
}
