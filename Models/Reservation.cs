using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        
        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }

        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

       

        [Required(ErrorMessage = "Check-in date is required")]
        [Display(Name = "Check in date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [CustomDateRange(ErrorMessage = "Check out date must be from today or later")]
        public DateTime CheckInDate { get; set; }


        [Required(ErrorMessage ="Check-out date is required")]
        [Display(Name = "Check out date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode =true)]
        [CustomDateRange(ErrorMessage = "Check out date must be from today or later")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Number of rooms should be greater than 0")]
        public int RoomCount { get; set; }
    }
}
