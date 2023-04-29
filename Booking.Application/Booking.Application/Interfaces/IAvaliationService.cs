using Booking.Application.DTOs.ResponseDTO;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IAvaliationService
    {
        Task<Response<IEnumerable<Avaliation>>> GetAvaliationsByRoomId(int id);
        Task<Response<Avaliation>> CreateAvaliation(Avaliation avaliation);

    }
}
