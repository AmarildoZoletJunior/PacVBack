using Booking.Domain.Entities;
using Booking.Domain.Ports.RepositoryGeneric;

namespace Booking.Domain.Ports
{
    public interface IBookingRoomRepository : IBaseRepository<BookingRoom>
    {
        Task<bool> BookingRoomExist(int id);
        Task<IEnumerable<BookingRoom>> GetBookingRoomsByCheckInAndCheckOut(BookingRoom room);
        Task<IEnumerable<BookingRoom>> GetBookingForRoomId(int roomId);
        Task<IEnumerable<BookingRoom>> GetBookingsForClientId(int clientId);
        Task<IEnumerable<BookingRoom>> GetBookingsByClientIdAndRoomId(int clientId, int roomId);

        Task<BookingRoom> GetBookingWithRoomInfo(int bookinId);
    }
}
