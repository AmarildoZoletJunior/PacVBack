using Booking.Domain.Entities;
using Booking.Domain.Ports.RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Ports
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> UserExist(int id);
    }
}
