using Booking.Application.DTOs.AuthDTO;
using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface ITokenService
    {
        Task<AuthResponse> GenerateTokenAsync(Client client);
        public string VerifyToken(string token);
        public bool VerifyTokenAdmin(string token);
    }
}
