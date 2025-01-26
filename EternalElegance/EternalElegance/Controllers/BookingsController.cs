using System.Collections.Generic;
using System;
using System.Linq;
using System.Web.Mvc;
using EternalElegance.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using EternalElegance.Attributes;

namespace EternalElegance.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetBookings()
        {
            var bookings = db.Bookings
                .Select(b => new
                {
                    b.Service.Name,
                    b.BookingDateTime,
                    b.Status
                })
                .ToList() 
                .Select(b => new
                {
                    title = b.Name, 
                    start = b.BookingDateTime.ToString("yyyy-MM-ddTHH:mm:ss"), 
                    end = b.BookingDateTime.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ss"), 
                    status = b.Status 
                });

            return Json(bookings, JsonRequestBehavior.AllowGet);
        }





        public ActionResult Create()
        {
            var services = new List<SelectListItem>
    {
         new SelectListItem { Value = "1", Text = "Manicure" },
         new SelectListItem { Value = "2", Text = "Pedicure" },
         new SelectListItem { Value = "3", Text = "Makeup" },
         new SelectListItem { Value = "4", Text = "Haircut" },
         new SelectListItem { Value = "5", Text = "Haircolor" },
         new SelectListItem { Value = "6", Text = "Wax" }  
            };

            ViewBag.Services = services;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                Console.Write(userId);

                var customer = db.Customers.SingleOrDefault(c => c.UserId == userId);
                
                if (customer == null)
                {
                    ModelState.AddModelError("", "Customer not found.");
                    ViewBag.Services = new List<SelectListItem>
    {
                new SelectListItem { Value = "1", Text = "Manicure" },
                new SelectListItem { Value = "2", Text = "Pedicure" },
                new SelectListItem { Value = "3", Text = "Makeup" },
                new SelectListItem { Value = "4", Text = "Haircut" },
                new SelectListItem { Value = "5", Text = "Haircolor" },
                new SelectListItem { Value = "6", Text = "Wax" }


    };

                    return View(model);
                }

                var employees = db.Employees.ToList();

                if (employees.Any())
                {
                    var random = new Random();
                    var randomEmployee = employees[random.Next(employees.Count)];

                    model.EmployeeId = randomEmployee.EmployeeId;
                }

                var booking = new Booking
                {
                    CustomerId = customer.CustomerId,  
                    EmployeeId = model.EmployeeId,
                    ServiceId = model.ServiceId,
                    BookingDateTime = model.BookingDateTime,
                    Status = "Pending"
                };

                db.Bookings.Add(booking);
                db.SaveChanges();

                return RedirectToAction("Index", "Home"); 
            }

            ViewBag.Services = new List<SelectListItem>
    {
            new SelectListItem { Value = "1", Text = "Manicure" },
            new SelectListItem { Value = "2", Text = "Pedicure" },
            new SelectListItem { Value = "3", Text = "Makeup" },
            new SelectListItem { Value = "4", Text = "Haircut" },
            new SelectListItem { Value = "5", Text = "Haircolor" },
            new SelectListItem { Value = "6", Text = "Wax" }        
    };

            return View(model);
        }

        public JsonResult GetAvailableTimes(DateTime selectedDate)
        {
            var availableTimes = new List<string> { "10:00 AM", "11:00 AM", "12:00 PM" };

            return Json(availableTimes);
        }


        public JsonResult CheckAvailability(DateTime date, int employeeId, int serviceId)
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            TimeSpan slotDuration = new TimeSpan(1, 0, 0);

            var bookings = db.Bookings
                .Where(b => DbFunctions.TruncateTime(b.BookingDateTime) == DbFunctions.TruncateTime(date)
                            && b.EmployeeId == employeeId
                            && b.ServiceId == serviceId)
                .Select(b => b.BookingDateTime)
                .ToList();

            var bookedTimes = bookings.Select(b => b.TimeOfDay).ToList();

            List<string> availableSlots = new List<string>();
            for (TimeSpan time = startTime; time < endTime; time += slotDuration)
            {
                if (!bookedTimes.Contains(time))
                {
                    availableSlots.Add(DateTime.Today.Add(time).ToString("HH:mm"));
                }
            }

            return Json(availableSlots, JsonRequestBehavior.AllowGet);
        }





    }
}
