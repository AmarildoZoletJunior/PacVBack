using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.ClientDTO
{
    public class ClientPasswordRequest
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
