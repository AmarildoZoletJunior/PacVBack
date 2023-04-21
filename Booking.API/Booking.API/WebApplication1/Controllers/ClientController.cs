using AutoMapper;
using Booking.Application.DTOs.ClientDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost("/Client")]
        public async Task<IActionResult> CreateClientAsync([Required] ClientRequest client)
        {
            var map = _mapper.Map<Client>(client);
            var result = await _clientService.CreateClient(map);
            if (result.IsValid)
            {
                return NoContent();
            }
            return BadRequest(result.MessagesErrors);
        }

        [HttpGet("/Client/{id:int}")]

        public async Task<IActionResult> GetClient([Required] int id)
        {
            var result = await _clientService.GetClient(id);
            if (result.IsValid) 
            {
                var map = _mapper.Map<ClientResponse>(result);
                return Ok(map);
            }
            return BadRequest(result.MessagesErrors);    
        }
    }
}
