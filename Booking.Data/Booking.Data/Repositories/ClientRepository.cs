using Booking.CrossCutting.Helper;
using Booking.Data.Repositories.RepositoryBase;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Booking.Domain.Ports.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IBaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DbBooking _dbBooking) : base(_dbBooking) { }

        public async Task<int> AccountIsValid(string email, string password)
        {
            var crypt = CryptoHelper.EncryptPassword(password);
            var result = await _dbBooking.Clients.Where(x => x.Password == crypt).Where(x => x.Email == email).FirstOrDefaultAsync();
            if(result == null)
            {
                return 0;
            }
            return result.Id;
        }

        public async Task<bool> ClientExist(int id)
        {
            var result = await _dbBooking.Clients.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DocumentNumberIsUsed(string documentNumber)
        {
            var result = await _dbBooking.Clients.Where(x => x.PersonType.DocumentNumber == documentNumber).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> EmailIsUsed(string email)
        {
            var result = await _dbBooking.Clients.Where(x => x.Email == email).FirstOrDefaultAsync();
            if(result == null)
            {
                return false;
            }
            return true;
        }

    }
}
