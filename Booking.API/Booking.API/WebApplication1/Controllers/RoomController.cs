using AutoMapper;
using Booking.Application.DTOs.RoomDTO;
using Booking.Application.Interfaces;
using Booking.CrossCutting.Helper;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRoom([Required] RoomRequest room)
        {
            var map = _mapper.Map<Room>(room);
            var find = await _roomService.CreateRoom(map);
            if (find.IsValid)
            {
                return NoContent();
            }
            return BadRequest(find.MessagesErrors);
        }

        [Authorize]
        [HttpGet("/Room/{id:int}")]
        public async Task<IActionResult> GetRoom([Required] int id)
        {
            var find = await _roomService.GetRoomAsync(id);
            if (find.IsValid)
            {
                return Ok(find.Data);
            }
            return BadRequest(find.MessagesErrors);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] PagedParameters paged)
        {
            var find = await _roomService.GetRooms(paged);
            if (find.IsValid)
            {
                return Ok(find.Data);
            }
            return BadRequest(find.MessagesErrors);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoom([Required] int id)
        {
            var find = await _roomService.DeleteRoom(id);
            if (find.IsValid)
            {
                return NoContent();
            }
            return BadRequest(find.MessagesErrors);
        }
    }
}
