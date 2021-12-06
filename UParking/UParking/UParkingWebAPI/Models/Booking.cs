using System;
using System.Collections.Generic;

#nullable disable

namespace UParkingWebAPI.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
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

        public virtual AspNetUser IdNavigation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
