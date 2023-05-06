using Booking.Application.DTOs.ResponseDTO;
using Booking.CrossCutting.Helper;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IRoomService
    {
        Task<Response<Room>> GetRoomAsync(int roomId);
        Task<Response<IEnumerable<Room>>> GetRooms(PagedParameters paged);
        Task<Response<Room>> CreateRoom(Room room);
        Task<Response<Room>> UpdateRoom(Room room);
        Task<Response<Room>> DeleteRoom(int id);
        Task<Response<IEnumerable<Room>>> GetRoomsAvailable(PagedParameters paged);
    }
}
