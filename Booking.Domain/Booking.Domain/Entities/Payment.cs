using Booking.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Payment
    {
        public PaymentType Type { get; set; }
        public decimal Value { get; set; }
    }
}
