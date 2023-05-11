using Booking.Application.DTOs.ResponseDTO;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IImageService
    {
        Task<Response<Image>> UpdateOrPostMainImage(IFormFile file, int roomId);
        Task<Response<Image>> PostImage(IFormFile file,int roomId);
    }
}
