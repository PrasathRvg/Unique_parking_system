using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class Pass1
    {
        public Pass1()
        {
            Payments = new HashSet<Payment1>();
        }

        public int PassId { get; set; }
        public string Id { get; set; }
        public int? Vechid { get; set; }
        public DateTime Startdate { get; set; }
        public string PassType { get; set; }
        public int Cost { get; set; }
        public DateTime BookingDate { get; set; }
        public int Slotno { get; set; }

        public virtual AspNetUser1 IdNavigation { get; set; }
        public virtual Vehicle1 Vech { get; set; }
        public virtual ICollection<Payment1> Payments { get; set; }
    }
}
