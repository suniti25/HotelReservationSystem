using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<RoomType> RoomTypes { get; set; } 

 
    }
}
