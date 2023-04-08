using Booking.CrossCutting.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Ports.RepositoryGeneric
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(PagedParameters paged);
        Task Create(T t);
        void Update(T t);
        void Delete(T t);
    }
}
