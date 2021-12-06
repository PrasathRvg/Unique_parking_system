using System;
using System.Collections.Generic;

#nullable disable

namespace UParkingWebAPI.Models
{
    public partial class Pass
    {
        public Pass()
        {
            Payments = new HashSet<Payment>();
        }

        public int PassId { get; set; }
        public string Id { get; set; }
        public int? Vechid { get; set; }
        public DateTime Startdate { get; set; }
        public string PassType { get; set; }
        public int Cost { get; set; }
        public DateTime BookingDate { get; set; }
        public int Slotno { get; set; }

        public virtual AspNetUser IdNavigation { get; set; }
        public virtual Vehicle Vech { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
