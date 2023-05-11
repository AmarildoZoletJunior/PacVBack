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
    public class AvaliationRepository : BaseRepository<Avaliation>, IBaseRepository<Avaliation>, IAvaliationRepository
    {
        public AvaliationRepository(DbBooking _dbBooking) : base(_dbBooking) { }


 
    }
}
