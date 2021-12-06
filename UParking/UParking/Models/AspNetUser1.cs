using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class AspNetUser1
    {
        public AspNetUser1()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim1>();
            AspNetUserLogins = new HashSet<AspNetUserLogin1>();
            AspNetUserRoles = new HashSet<AspNetUserRole1>();
            AspNetUserTokens = new HashSet<AspNetUserToken1>();
            Bookings = new HashSet<Booking1>();
            Passes = new HashSet<Pass1>();
            Payments = new HashSet<Payment1>();
            Vehicles = new HashSet<Vehicle1>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim1> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin1> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole1> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken1> AspNetUserTokens { get; set; }
        public virtual ICollection<Booking1> Bookings { get; set; }
        public virtual ICollection<Pass1> Passes { get; set; }
        public virtual ICollection<Payment1> Payments { get; set; }
        public virtual ICollection<Vehicle1> Vehicles { get; set; }
    }
}
