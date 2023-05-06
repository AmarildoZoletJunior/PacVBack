using Booking.CrossCutting.Helper;

namespace Booking.Domain.Ports.RepositoryGeneric
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllPaged(PagedParameters paged);
        Task Create(T t);
    }
}
