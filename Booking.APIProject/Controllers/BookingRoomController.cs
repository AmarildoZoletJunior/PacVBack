using AutoMapper;
using Booking.Application.DTOs.BookingRoomDTO;
using Booking.Application.DTOs.RoomDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.APIProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingRoomController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookingRoomService _bookingRoomService;

        public BookingRoomController(IMapper mapper, IBookingRoomService bookingRoomService)
        {
            _mapper = mapper;
            _bookingRoomService = bookingRoomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookingRoom(BookingRoomRequest response)
        {
            var map = _mapper.Map<BookingRoom>(response);
            var result = await _bookingRoomService.CreateBookingRoom(map);
            if (result.IsValid)
            {
                var mapRoom = _mapper.Map<BookingRoomResponse>(result.Data);
                return Ok(mapRoom);
            }
            return BadRequest(result.MessagesErrors);
        }

        [HttpGet("client/{clientId:int}")]
        public async Task<IActionResult> ListReservesForClientId([Required] int clientId)
        {
            var result = await _bookingRoomService.listBookingForClient(clientId);
            if (result.IsValid)
            {
                var map = _mapper.Map<IEnumerable<BookingRoomResponse>>(result.Data);
                return Ok(map);
            }
            return BadRequest(result.MessagesErrors);
        }

        [HttpGet("room/{roomId:int}")]
        public async Task<IActionResult> ListReserves([Required] int roomId)
        {
            var result = await _bookingRoomService.ListReservedTimes(roomId);
            if (result.IsValid)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MessagesErrors);
        }

        [HttpGet("room/info/{bookinId:int}")]
        public async Task<IActionResult> ListReserveWithRoomAndBookinInfo([Required] int bookinId)
        {
            var result = await _bookingRoomService.BookingRoomWithRoomInfo(bookinId);
            if (result.IsValid)
            {
                var map = _mapper.Map<BookingRoomResponseWithRoomInfo>(result.Data);
                return Ok(map);
            }
            return BadRequest(result.MessagesErrors);
        }
    }
}
