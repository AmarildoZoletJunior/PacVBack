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
    public class ClientRepository : BaseRepository<Client>, IBaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DbBooking _dbBooking) : base(_dbBooking) { }
        public async Task<bool> ClientExist(int id)
        {
            var result = await _dbBooking.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Client> GetClientByCPF(string CPF)
        {
          return await _dbBooking.Clients.FirstOrDefaultAsync(x => x.PersonType.DocumentNumber == CPF);
        }
    }
}
