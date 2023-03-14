using Booking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class BookingRoom : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
