using Booking.Application.DTOs.AuthDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
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
            var clientFind = await _client.AccountIsValid(client.Email, client.Password);
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
                     new Claim("IdUsuario", clientResult.Id.ToString()),
                      new Claim("isAdmin", clientResult.IsAdmin.ToString())
                 }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new AuthResponse
            {
                IsAdmin = clientResult.IsAdmin,
                Token = tokenString,
                ClientId = clientResult.Id,
                ClientName = $"{clientResult.PersonType.Name} {clientResult.PersonType.Surname}"
            };
        }
        public string VerifyToken(string token)
        {
            var tokenValidate = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtToken"]);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };


            try
            {
                var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);
                try
                {
                    tokenValidate.ValidateToken(token, validationParameters, out _);
                    var claim = tokenHandler.Claims.FirstOrDefault(x => x.Type == "IdUsuario").Value;
                    return claim; // Token válido
                }
                catch (Exception)
                {
                    return ""; // Token inválido
                }
            }
            catch (Exception ex)
            {
                return "";
            }


        }

        public bool VerifyTokenAdmin(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var tokenValidate = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtToken"]);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };


            try
            {
                tokenValidate.ValidateToken(token, validationParameters, out _);
                var claimAdmin = tokenHandler.Claims.FirstOrDefault(x => x.Type == "isAdmin").Value;
                if(claimAdmin == "True")
                {
                    return true;
                }
                return false; // Token válido
            }
            catch (Exception)
            {
                return false; // Token inválido
            }
        }

    }
}
