using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }   
        
        public int RoomCount { get; set; }

        public int Price { get; set; }

        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
