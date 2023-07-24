using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace HotelReservationSystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(10, ErrorMessage ="Phone Number should be 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage ="Phone should be 10 digits")]
        public string Phone { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        

    }
}
