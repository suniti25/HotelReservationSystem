using HotelReservationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace HotelReservationSystem.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoomTypeController(ApplicationDbContext db)
        {
            _db = db;
        }   

        public IActionResult Index(int hotelId)
        {
            var roomTypes = _db.RoomTypes
                .Where(rt=> rt.HotelId == hotelId)
                .Include(rt=> rt.Hotel)
                .ToList();
            return View(roomTypes);
        }
    }
}
