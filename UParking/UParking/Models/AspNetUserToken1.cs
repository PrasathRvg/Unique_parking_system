using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class AspNetUserToken1
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual AspNetUser1 User { get; set; }
    }
}
