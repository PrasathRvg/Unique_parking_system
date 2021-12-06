using System;
using System.Collections.Generic;

#nullable disable

namespace UParking.Models
{
    public partial class Payment1
    {
        public int Payid { get; set; }
        public string Id { get; set; }
        public int? BookId { get; set; }
        public string Choldername { get; set; }
        public string Cardnumber { get; set; }
        public int? ExpMonth { get; set; }
        public int? ExpYear { get; set; }
        public string UpiApp { get; set; }
        public string UpiId { get; set; }
        public int? PassId { get; set; }
        public string Bank { get; set; }

        public virtual Booking1 Book { get; set; }
        public virtual AspNetUser1 IdNavigation { get; set; }
        public virtual Pass1 Pass { get; set; }
    }
}
