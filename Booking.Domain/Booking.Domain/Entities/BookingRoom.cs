using Booking.Domain.Entities.Base;
using Booking.Domain.Enum;
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
        public StatusPayment Status { get; set; }


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
