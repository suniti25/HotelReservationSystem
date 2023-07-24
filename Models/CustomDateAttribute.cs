using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute()
           : base(typeof(DateTime), DateTime.Now.ToShortDateString(), "2023-12-31")
        {

        }
        
       
    }
}
