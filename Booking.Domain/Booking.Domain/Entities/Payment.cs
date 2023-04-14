using Booking.Domain.Entities.Base;
using Booking.Domain.Enum;

namespace Booking.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public PaymentType Type { get; set; }
        public decimal Value { get; set; }
        public StatusPayment Status { get; set; }
        public BookingRoom BookingRoom { get; set; }
        public int BookingRoomId { get; set; }

        public void UpdateStatus(Booking.Domain.Enum.Action action)
        {
            this.Status = (this.Status, action) switch
            {
                (StatusPayment.Created, Booking.Domain.Enum.Action.Pay) => StatusPayment.Paid,
                (StatusPayment.Paid, Booking.Domain.Enum.Action.Refound) => StatusPayment.Refounded,
                (StatusPayment.Created, Booking.Domain.Enum.Action.Cancel) => StatusPayment.Canceled,
                (StatusPayment.Paid, Booking.Domain.Enum.Action.Finish) => StatusPayment.Finished,
                _ => this.Status
            };
        }
    }
}
