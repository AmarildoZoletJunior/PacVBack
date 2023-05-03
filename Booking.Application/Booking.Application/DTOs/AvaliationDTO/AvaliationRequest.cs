using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.AvaliationDTO
{
    public class AvaliationRequest
    {
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
    }
}
