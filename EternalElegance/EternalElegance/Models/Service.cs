using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EternalElegance.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public Service()
        {
            this.Bookings = new List<Booking>();
            this.Employees = new List<Employee>();
        }
    }
}