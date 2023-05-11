using AutoMapper;
using Booking.Application.DTOs.RoomDTO;
using Booking.Application.Interfaces;
using Booking.CrossCutting.Helper;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.APIProject.Controllers
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

        [HttpPut("/Room")]
        public async Task<IActionResult> UpdateRoom(RoomUpdateRequest request)
        {
            var map = _mapper.Map<Room>(request);
            var result = await _roomService.UpdateRoom(map);
            if (result.IsValid)
            {
                return NoContent();
            }
            return BadRequest(result.MessagesErrors);
        }


        [HttpGet("/Room/{id:int}")]
        public async Task<IActionResult> GetRoomById([Required] int id)
        {
            var find = await _roomService.GetRoomById(id);
            if (find.IsValid)
            {
                var map = _mapper.Map<RoomResponse>(find.Data);
                return Ok(map);
            }
            return BadRequest(find.MessagesErrors);
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] PagedParameters paged)
        {
            var find = await _roomService.GetRooms(paged);
            if (find.IsValid)
            {
                var map = _mapper.Map<IEnumerable<RoomResponse>>(find.Data);
                return Ok(map);
            }
            return BadRequest(find.MessagesErrors);
        }

        [HttpGet("Availables")]
        public async Task<IActionResult> GetRoomsAvailable([FromQuery] PagedParameters paged)
        {
            var find = await _roomService.GetRoomsAvailable(paged);
            if (find.IsValid)
            {
                var map = _mapper.Map<IEnumerable<RoomResponseWithImage>>(find.Data);
                return Ok(map);
            }
            return BadRequest(find.MessagesErrors);
        }

        [HttpGet("/Room/Images/{id:int}")]
        public async Task<IActionResult> GetRoomWithImages(int id)
        {
            var find = await _roomService.GetRoomWithImages(id);
            if (find.IsValid)
            {
                var map = _mapper.Map<RoomResponseWithImage>(find.Data);
                return Ok(map);
            }
            return BadRequest(find.MessagesErrors);
        }

    }
}
