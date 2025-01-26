using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EternalElegance.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public bool Availability { get; set; }
        public string Password { get; set; }

        public int ServiceId { get; set; } // Foreign key to Service
        public virtual Service Service { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }


        public Employee()
        {
            this.Bookings = new List<Booking>();
        }
    }
}