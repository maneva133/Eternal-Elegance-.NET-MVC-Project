using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EternalElegance.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public Customer()
        {
            this.Bookings = new List<Booking>();
        }

    }
}