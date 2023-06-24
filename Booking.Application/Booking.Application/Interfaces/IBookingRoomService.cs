using Booking.Application.DTOs.BookingRoomDTO;
using Booking.Application.DTOs.ResponseDTO;
using Booking.Domain.Entities;

namespace Booking.Application.Interfaces
{
    public interface IBookingRoomService
    {
        Task<Response<BookingRoom>> CreateBookingRoom(BookingRoom booking);
        Task<Response<List<DateTime>>> ListReservedTimes(int roomId);
        Task<Response<IEnumerable<BookingRoom>>> listBookingForClient(int clientId);
        Task<Response<BookingRoom>> BookingRoomWithRoomInfo(int bookinId);
    }
}
