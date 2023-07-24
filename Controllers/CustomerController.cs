using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Create(int roomTypeId)
        {
            var customer = new Customer
            {
                RoomTypeId = roomTypeId,
            };
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid) {
                _db.Customers.Add(customer);
                _db.SaveChanges();

                return RedirectToAction("Create", "Reservation", new { customerId = customer.Id, roomTypeId = customer.RoomTypeId });
            }

            return View(customer);
        }  
    }
}
