using Booking.Domain.Entities;
using Booking.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.PaymentDTO
{
    public class PaymentRequest
    {
        public decimal Value { get; set; }
        public int ClienteId { get; set; }
        public int BookingRoomId { get; set; }
    }
}
