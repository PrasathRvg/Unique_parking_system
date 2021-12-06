using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UParking.Models
{
    public partial class Payment1
    {
        public int Payid { get; set; }
        public string Id { get; set; }
        public int? BookId { get; set; }
        [Requried]
        public string Choldername { get; set; }
        [Requried]
        [MinLength(12)]
        [MaxLength(12)]
        public string Cardnumber { get; set; }
        [Requried]
        [MaxLength(2)]
        public int? ExpMonth { get; set; }
        [Requried]
        [MinLength(4)]
        [MaxLength(4)]
        public int? ExpYear { get; set; }
        [Requried]
        public string UpiApp { get; set; }
        [Requried]
        public string UpiId { get; set; }
        [Requried]
        public int? PassId { get; set; }
        [Requried]
        public string Bank { get; set; }

        public virtual Booking1 Book { get; set; }
        public virtual AspNetUser1 IdNavigation { get; set; }
        public virtual Pass1 Pass { get; set; }
    }
}
