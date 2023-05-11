using Booking.Application.DTOs.ResponseDTO;
using Booking.CrossCutting.Helper;
using Booking.Domain.Entities;

namespace Booking.Application.Interfaces
{
    public interface IRoomService
    {
        Task<Response<Room>> GetRoomById(int roomId);
        Task<Response<IEnumerable<Room>>> GetRooms(PagedParameters paged);
        Task<Response<IEnumerable<Room>>> GetRoomsAvailable(PagedParameters paged);
        Task<Response<Room>> GetRoomWithImages(int id);
        Task<Response<Room>> CreateRoom(Room room);
        Task<Response<Room>> UpdateRoom(Room room);
        Task<Response<Room>> DeleteRoom(int id);

    }
}
