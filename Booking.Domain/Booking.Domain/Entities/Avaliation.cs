using Booking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Avaliation : BaseEntity
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public BookingRoom BookingRoom { get; set; }
        public int BookingRoomId { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
    }
}
