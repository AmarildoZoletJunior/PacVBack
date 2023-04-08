using Booking.CrossCutting.Helper;
using Booking.Domain.Entities.Base;
using Booking.Domain.Ports.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Repositories.RepositoryBase
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly DbBooking _dbBooking;
        public BaseRepository(DbBooking dbBooking)
        {
            _dbBooking = dbBooking;
        }

        public async Task Create(T t)
        {
            await _dbBooking.Set<T>().AddAsync(t);
        }

        public void Delete(T t)
        {
            _dbBooking.Set<T>().Remove(t);
        }

        public async Task<IEnumerable<T>> GetAll(PagedParameters paged)
        {
            return await _dbBooking.Set<T>().OrderBy(x => x.Id).Skip((paged.NumberPage - 1) * paged.PageSize).Take(paged.PageSize).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbBooking.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T t)
        {
            _dbBooking.Set<T>().Update(t);
        }
    }
}
