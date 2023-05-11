using Booking.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Booking.Domain.Ports
{
    public interface IImageRepository
    {
        void PostImage(Image image);
        Task<Image> GetImage(int idImage);
        Task<IEnumerable<Image>> GetMainImage(int roomId);
        void UpdateImageMain(Image image);
    }
}
