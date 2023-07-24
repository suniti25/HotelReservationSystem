using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Entity;



namespace HotelReservationSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReservationController(ApplicationDbContext db)
        {
            _db = db;

        }

        //READ
        public IActionResult ViewReservation() //view
        {
            IEnumerable<Reservation> objReservationList = _db.Reservations;
            return View(objReservationList);
        }

        //CREATE
        public ActionResult Create(int customerId, int roomTypeId)
        {
            var customer = _db.Customers.Find(customerId);
            var reservation = new Reservation
            {
                CustomerId = customerId,
                RoomTypeId = roomTypeId,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(1),
                Customer = customer
               
            };            
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            var roomType = _db.RoomTypes.FirstOrDefault(rt => rt.Id == reservation.RoomTypeId);  
            if(reservation.RoomCount > roomType.RoomCount)
            {
                ModelState.AddModelError("RoomCount", "Number of rooms selected exceeded the available rooms");
            }
            
            
             _db.Reservations.Add(reservation);
             _db.SaveChanges();

             var rooomType = _db.RoomTypes.Find(reservation.RoomTypeId);
             rooomType.RoomCount -= reservation.RoomCount;
             _db.SaveChanges();

             TempData["ReservationSucessMessage"] = "Reservation has been created sucessfully";
             return RedirectToAction("ViewReservation");           
        }

        //UPDATE
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dbfromReservation = _db.Reservations.Find(id);

            if (dbfromReservation == null)
            {
                return NotFound();
            }

            return View(dbfromReservation);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Reservation reservation)
        {               
            _db.Reservations.Update(reservation);
            _db.SaveChanges();
             return RedirectToAction("ViewReservation");
           
        }          

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dbfromReservation = _db.Reservations.Find(id);

            if (dbfromReservation == null)
            {
                return NotFound();
            }

            return View(dbfromReservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Reservation obj)
        {            
                _db.Reservations.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewReservation");
        }
    }
}

