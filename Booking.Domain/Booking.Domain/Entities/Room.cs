using Booking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Room : BaseEntity
    {
        public bool Available { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        //public Decimal Value { get; set; }
        public ICollection<BookingRoom>? Bookings { get; set; }
        public ICollection<Image>? Images { get; set; }
    }
}
