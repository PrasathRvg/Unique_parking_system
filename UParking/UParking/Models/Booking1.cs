using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class Booking1
    {
        public Booking1()
        {
            Payments = new HashSet<Payment1>();
        }

        public int BookId { get; set; }
        public string Id { get; set; }
        public int Slotno { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public int Amount { get; set; }
        public string CarNo { get; set; }

        public virtual AspNetUser1 IdNavigation { get; set; }
        public virtual ICollection<Payment1> Payments { get; set; }
    }
}
