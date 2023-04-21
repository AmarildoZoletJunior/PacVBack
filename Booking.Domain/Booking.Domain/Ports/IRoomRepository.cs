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
        Task<IEnumerable<Room>> GetByLevel(int Level);
        Task<bool> RoomExist(int id);
        Task<bool> RoomNumberIsUsed(int number);
        void DeleteRoom(Room room);
    }
}
