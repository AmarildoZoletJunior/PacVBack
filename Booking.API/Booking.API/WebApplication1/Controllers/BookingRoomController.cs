using AutoMapper;
using Booking.Application.DTOs.BookingRoomDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Booking.API.Controllers
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
                return NoContent();
            }
            return BadRequest(result.MessagesErrors);
        }

        [HttpGet("{roomId:int}")]
        public async Task<IActionResult> ListReserves([Required] int roomId)
        {
            var result = await _bookingRoomService.ListReservedTimes(roomId);
            if (result.IsValid){
                return Ok(result.Data);
            }
            return BadRequest(result.MessagesErrors);
        }
    }
}
