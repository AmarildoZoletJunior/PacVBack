using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.ImageDTO
{
    public class ImageRequest
    {
        public string ImageBase { get; set; }
        public string FormatImage { get; set; }
        public int RoomId { get; set; }
    }
}
