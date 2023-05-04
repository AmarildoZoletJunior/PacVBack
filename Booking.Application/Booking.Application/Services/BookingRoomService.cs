using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Application.Validators;
using Booking.Data;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using XAct;

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
            var classValidate = new BookingRoomValidator();
            var validate = classValidate.Validate(booking);
            if (!validate.IsValid)
            {
                validate.Errors.ForEach(x => response.AddMessage(x.PropertyName, x.ErrorMessage));
                return response;
            }

            var findRoom = await _roomRepository.GetById(booking.RoomId);
            if (findRoom == null)
            {
                response.AddMessage("Quarto não encontrado", $"O quarto com id:{booking.RoomId} não foi encontrado");
                return response;
            }
            if(!findRoom.Available)
            {
                response.AddMessage("Quarto indisponível", $"O quarto com id:{booking.RoomId} esta indisponível");
                return response;
            }
            var validBooking = await _bookingRoomRepository.GetBookingRoomsByCheckInAndCheckOut(booking);
            if(validBooking.Count() > 0)
            {
                response.AddMessage("Quarto já esta alugado", $"O quarto com id:{booking.RoomId} esta alugados entre a data: {booking.Start} e {booking.End}");
                return response;
            }
            await _bookingRoomRepository.Create(booking);
            await _unitOfWork.CommitAsync();
            return response;
        }

        public async Task<Response<List<DateTime>>> ListReservedTimes(int roomId)
        {
            var response = new Response<List<DateTime>>();
            var findRoom = await _roomRepository.GetById(roomId);
            if(findRoom == null)
            {
                response.AddMessage("Quarto não encontrado", $"O quarto com id:{roomId} não foi encontrado");
                return response;
            }
            var listBookings = await _bookingRoomRepository.GetBookingForRoomId(roomId);
            if (!listBookings.Any())
            {
                response.AddMessage("Quarto sem reservas", $"O quarto com id:{roomId} não tem reservas registradas");
                return response;
            }
            response.Data = new List<DateTime>();
            foreach ( var booking in listBookings) 
            {
               var lista = DateGenerate(booking.Start, booking.End);
                foreach(var list in lista)
                {
                    response.Data.Add(list);
                }
            }
            return response;
        }
        public IEnumerable<DateTime> DateGenerate(DateTime initial, DateTime final)
        {
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
