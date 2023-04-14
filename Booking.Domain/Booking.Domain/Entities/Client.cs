using Booking.Domain.Entities.Base;
using Booking.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public PersonInfo PersonType { get; set; }
        public ICollection<BookingRoom>? Bookings { get; set; }

    }
}
