using Booking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string ImageBase { get; set; }
        public string FormatImage { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public bool MainImage { get; set; }
    }
}
