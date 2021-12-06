using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class AspNetUserRole1
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRole1 Role { get; set; }
        public virtual AspNetUser1 User { get; set; }
    }
}
