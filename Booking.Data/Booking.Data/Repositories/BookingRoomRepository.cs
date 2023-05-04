using Booking.Data.Repositories.RepositoryBase;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Booking.Domain.Ports.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data.Repositories
{
    public class BookingRoomRepository : BaseRepository<BookingRoom>, IBaseRepository<BookingRoom>, IBookingRoomRepository
    {
        public BookingRoomRepository(DbBooking _dbBooking) : base(_dbBooking) { }

        public async Task<bool> BookingRoomExist(int id)
        {
            var result = await _dbBooking.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<BookingRoom>> GetBookingForRoomId(int roomId)
        {
            var result = await _dbBooking.Bookings.Where(x => x.RoomId == roomId && x.Start > DateTime.Now).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BookingRoom>> GetBookingRoomsByCheckInAndCheckOut(BookingRoom room)
        {
            var result = await _dbBooking.Bookings.Where(x => x.RoomId == room.RoomId && (
            (x.Start > room.Start) && (x.End > room.End && room.End > x.Start) ||
            (x.Start < room.Start && room.Start < x.End) && (x.End < room.End) ||
            (x.Start > room.Start) && (x.End < room.End) ||
            (x.Start < room.Start) && (x.End > room.End))).ToListAsync();
            return result;
        }
    }
}
