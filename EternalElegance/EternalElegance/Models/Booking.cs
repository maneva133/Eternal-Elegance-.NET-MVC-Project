using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EternalElegance.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public string Status { get; set; } 

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
    }

}