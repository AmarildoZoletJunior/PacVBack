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
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>, IUserRepository
    {
        public UserRepository(DbBooking _dbBooking) : base(_dbBooking) { }
        public async Task<bool> UserExist(int id)
        {
            var result = await _dbBooking.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null)
            {
                return false;
            }
            return true;
        }
    }
}
