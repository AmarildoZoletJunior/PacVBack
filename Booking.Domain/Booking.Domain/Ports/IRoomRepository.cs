using Booking.CrossCutting.Helper;
using Booking.Domain.Entities;
using Booking.Domain.Ports.RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Ports
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room> GetRoomWithImages(int id);
        Task<IEnumerable<Room>> GetRoomsAvailable(PagedParameters paged);
        void DeleteRoom(Room room);
        void Update(Room room);
        Task<bool> RoomExist(int id);
        Task<bool> RoomNumberIsUsed(int number);
    }
}
