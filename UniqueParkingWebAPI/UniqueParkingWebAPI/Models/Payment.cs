using System;
using System.Collections.Generic;

#nullable disable

namespace UniqueParkingWebAPI.Models
{
    public partial class Payment
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

        public virtual Booking Book { get; set; }
        public virtual AspNetUser IdNavigation { get; set; }
        public virtual Pass Pass { get; set; }
    }
}
