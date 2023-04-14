using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbBooking _dbBooking;

        public UnitOfWork(DbBooking dbBooking)
        {
            _dbBooking = dbBooking;
        }

        public async Task CommitAsync()
        {
            await _dbBooking.SaveChangesAsync();
        }
    }
}
