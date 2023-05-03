using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.BookingRoomDTO
{
    public class BookingRoomRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public int StatusPermission { get; set; }
    }
}
