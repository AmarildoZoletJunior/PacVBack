using Booking.Application.DTOs.RoomDTO;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.BookingRoomDTO
{
    public class BookingRoomResponseWithRoomInfo
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public RoomResponseWithImage Room { get; set; }
        public int ClientId { get; set; }

    }
}
