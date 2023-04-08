using Booking.Data.Mapping;
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Booking.Data
{
    public class DbBooking : DbContext
    {
        public DbBooking(DbContextOptions<DbBooking> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BookingRoom> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomMapping());
            modelBuilder.ApplyConfiguration(new ClientMapping());
            modelBuilder.ApplyConfiguration(new BookingRoomMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

    }
}