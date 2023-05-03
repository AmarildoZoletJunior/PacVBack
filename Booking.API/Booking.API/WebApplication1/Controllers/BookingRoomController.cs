using AutoMapper;
using Booking.Application.DTOs.BookingRoomDTO;
using Booking.Application.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
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
            await _bookingRoomService.CreateBookingRoom(map);
            return Ok();
        }
    }
}
