using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystem.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, HotelName = "Everest Hotel", Location = "Baneshwor"},
                new Hotel { Id = 2, HotelName = "ABC Hotel", Location = "Kathmandu"},
                new Hotel { Id = 3, HotelName = "Annapurna Hotel", Location = "Pokhara" }    
                );

            modelBuilder.Entity<RoomType>().HasData(
                new RoomType { Id = 1, TypeName = "VIP Suite", RoomCount = 10, HotelId = 1, Price= 2000},
                new RoomType { Id = 2, TypeName = "Master Suite", RoomCount = 10, HotelId = 1, Price = 5000},
               

                new RoomType { Id = 5, TypeName = "VIP Lounge", RoomCount = 5, HotelId = 2, Price = 6600 },
                new RoomType { Id = 6, TypeName = "Master Suite", RoomCount = 10, HotelId = 2, Price = 5200 },
                new RoomType { Id = 7, TypeName = "Single BedRoom", RoomCount = 10, HotelId = 2, Price = 3000 },

                new RoomType { Id = 8, TypeName = "Master Suite", RoomCount = 5, HotelId = 3, Price = 7000 },
                new RoomType { Id = 9, TypeName = "Single BedRoom", RoomCount = 10, HotelId = 3 , Price = 2000 },
                new RoomType { Id = 10,TypeName = "Double BedRoom", RoomCount = 15, HotelId = 3 , Price = 1000 }
                );
        }
        

    }
}
