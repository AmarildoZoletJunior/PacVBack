using Booking.Data.Repositories.RepositoryBase;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Booking.Domain.Ports.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data.Repositories
{
    public class RoomRepository : BaseRepository<Room>,IBaseRepository<Room>,IRoomRepository
    {
        public RoomRepository(DbBooking _dbBooking) : base(_dbBooking) { }

        public async Task<IEnumerable<Room>> GetByLevel(int Level)
        {
            return await _dbBooking.Rooms.Where(x => x.Level == Level).ToListAsync();
        }

        public async Task<bool> RoomExist(int id)
        {
            var result = await _dbBooking.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null)
            {
                return false;
            }
            return true;
        }
    }
}
