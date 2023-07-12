using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.AuthDTO
{
    public class AuthResponse
    {
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
