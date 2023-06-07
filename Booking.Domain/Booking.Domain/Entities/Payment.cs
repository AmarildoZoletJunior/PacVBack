using Booking.Domain.Entities.Base;
using Booking.Domain.Enum;

namespace Booking.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Value { get; set; }
        public StatusPayment Status { get; set; } = StatusPayment.Processing;
        public Client Cliente { get; set; }
        public int ClienteId { get; set; }
        public BookingRoom BookingRoom { get; set; }
        public int BookingRoomId { get; set; }
    }
}
