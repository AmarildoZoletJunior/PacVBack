using Booking.Domain.Entities;
using Booking.Domain.Ports.RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Ports
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<bool> EmailIsUsed(string email);
        Task<bool> DocumentNumberIsUsed(string documentNumber);
        Task<int> AccountIsValid(string email,string password);
        void Update(Client client);

    }
}
