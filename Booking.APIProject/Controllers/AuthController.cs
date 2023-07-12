using AutoMapper;
using Booking.Application.DTOs.AuthDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.APIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AuthClient(AuthRequest request)
        {
            var map = _mapper.Map<Client>(request);
            var result = await _tokenService.GenerateTokenAsync(map);
            if (result.ClientId > 0)
            {
                return Ok(result);
            }
            return Unauthorized();
        }

        [HttpGet("/Validate")]
        public async Task<IActionResult> ValidateToken([Required]string token)
        {
            string isValid = _tokenService.VerifyToken(token);
            if (isValid != "")
            {
                return Ok(isValid);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("/Validate/Admin")]
        public async Task<IActionResult> ValidateTokenAdmin([Required] string token)
        {
            var isValid = _tokenService.VerifyTokenAdmin(token);
            if (isValid)
            {
                return Ok(isValid);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
