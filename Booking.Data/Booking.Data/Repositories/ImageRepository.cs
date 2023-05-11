using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Booking.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbBooking _dbcontext;
        public ImageRepository(DbBooking dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Image> GetImage(int idImage)
        {
            return await _dbcontext.Images.FirstOrDefaultAsync(x => x.Id == idImage);
        }

        public async Task<IEnumerable<Image>> GetMainImage(int roomId)
        {
            return await _dbcontext.Images.Where(x => x.RoomId == roomId && x.MainImage == true).ToListAsync();
        }

        public void PostImage(Image image)
        {
             _dbcontext.Images.Add(image);
        }

        public void UpdateImageMain(Image image)
        {
            _dbcontext.Images.Update(image);
        }
    }
}
