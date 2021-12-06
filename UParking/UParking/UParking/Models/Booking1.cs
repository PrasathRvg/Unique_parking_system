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
        [Requried]
        public int Slotno { get; set; }
        [Requried]
        public DateTime Startdate { get; set; }
        [Requried]
        public DateTime? Enddate { get; set; }
        [Requried]
        public DateTime Starttime { get; set; }
        [Requried]
        public DateTime Endtime { get; set; }
        public int Amount { get; set; }
        [Requried]
        public string CarNo { get; set; }

        public virtual AspNetUser1 IdNavigation { get; set; }
        public virtual ICollection<Payment1> Payments { get; set; }
    }
}
