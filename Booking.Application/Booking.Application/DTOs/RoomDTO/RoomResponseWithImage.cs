using Booking.Application.DTOs.ImageDTO;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.RoomDTO
{
    public class RoomResponseWithImage
    {
        public int Id { get; set; }
        public bool Available { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public ICollection<ImageResponse>? Images { get; set; }
    }
}
