using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;

namespace Booking.Application.Services
{
    public class BookingRoomService : IBookingRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientRepository _clientRepository;
        private readonly IBookingRoomRepository _bookingRoomRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingRoomService(IUnitOfWork unitOfWork, IClientRepository clientRepository, IBookingRoomRepository bookingRoomRepository, IRoomRepository roomRepository)
        {
            _unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
            _bookingRoomRepository = bookingRoomRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Response<BookingRoom>> CreateBookingRoom(BookingRoom booking)
        {
            var response = new Response<BookingRoom>();
           var findRoom = await _roomRepository.GetById(booking.RoomId);
            if (findRoom == null)
            {
                response.AddMessage("Quarto não encontrado", $"O quarto com id:{booking.RoomId} não foi encontrado");
                return response;
            }
            if(!findRoom.Available)
            {
                response.AddMessage("Quarto indisponível", $"O quarto com id:{booking.RoomId} esta indisponível");
            }
            var validBooking = await _bookingRoomRepository.GetBookingRoomsByCheckInAndCheckOut(booking);

            return response;
        }
        public List<DateTime> DateGenerate(DateTime initial, DateTime final)
        {
            // Subtrair uma da outra
            TimeSpan days = final - initial;
            List<DateTime> list = new List<DateTime>();
            for(var o = 0;o < days.Days + 1; o++)
            {
                var day = initial.Day;
                var year = initial.Year;
                var month = initial.Month;
                list.Add(new DateTime(year, month, day).AddDays(o).AddHours(12));
            }
            return list;
        }
    }
}
