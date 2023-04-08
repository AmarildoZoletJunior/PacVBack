using Booking.CrossCutting.Helper;
using Booking.Data.Repositories.RepositoryBase;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Booking.Domain.Ports.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Repositories
{
    public class BookingRoomRepository : BaseRepository<BookingRoom>,IBaseRepository<BookingRoom>, IBookingRoomRepository
    {
        public BookingRoomRepository(DbBooking _dbBooking) : base(_dbBooking) { }

        public async Task<bool> BookingRoomExist(int id)
        {
            var result = await _dbBooking.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null)
            {
                return false;
            }
            return true;
        }
    }
}
