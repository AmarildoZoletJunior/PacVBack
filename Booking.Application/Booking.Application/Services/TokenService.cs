using Booking.Application.DTOs.AuthDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Booking.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientRepository _client;

        public TokenService(IConfiguration configuration, IClientRepository client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<AuthResponse> GenerateTokenAsync(Client client)
        {
            var clientFind = await _client.AccountIsValid(client.Email,client.Password);
            if (clientFind == 0)
            {
                return new AuthResponse();
            }
            var clientResult = await _client.GetById(clientFind);
            

            var key = Encoding.ASCII.GetBytes(_configuration["JwtToken"]);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.Name, clientResult.Id.ToString()),
                      new Claim(ClaimTypes.Name, clientResult.PersonType.Name)
                 }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new AuthResponse
            {
                Token = tokenString,
                ClientId = clientResult.Id,
                 ClientName = $"{clientResult.PersonType.Name} {clientResult.PersonType.Surname}" 
            };
        }
    }
}
