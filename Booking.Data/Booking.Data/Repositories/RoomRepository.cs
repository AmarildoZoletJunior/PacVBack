using Azure;
using Booking.CrossCutting.Helper;
using Booking.Data.Repositories.RepositoryBase;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Booking.Domain.Ports.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IBaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DbBooking _dbBooking) : base(_dbBooking) { }

        public void DeleteRoom(Room room)
        {
            _dbBooking.Rooms.Remove(room);
        }

        

        public async Task<IEnumerable<Room>> GetRoomsAvailable(PagedParameters paged)
        {
            return await _dbBooking.Rooms.Include(x => x.Images.Where(x => x.MainImage == true)).Where(x => x.Available == true).OrderBy(x => x.Id).Skip((paged.PageNumber - 1) * paged.PageSize).Take(paged.PageSize).ToListAsync();
        }
        public async Task<Room> GetRoomWithImages(int id)
        {
            return await _dbBooking.Rooms.Include(x => x.Images.Where(x => x.RoomId == id)).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> RoomExist(int id)
        {
            var result = await _dbBooking.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RoomNumberIsUsed(int number)
        {
            var result = await _dbBooking.Rooms.Where(x => x.Number == number).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public void Update(Room room)
        {
            _dbBooking.Rooms.Update(room); 
        }

        public async Task<Room> GetRoomByIdWithMainImage(int id)
        {
            return await _dbBooking.Rooms.Include(x => x.Images.Where(x => x.MainImage == true)).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
