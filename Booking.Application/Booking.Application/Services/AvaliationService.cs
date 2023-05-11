using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Application.Validators;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;


namespace Booking.Application.Services
{
    public class AvaliationService
    {
        private readonly IAvaliationRepository _avaliationRepository;
        private readonly IBookingRoomRepository _bookroomRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AvaliationService(IAvaliationRepository avaliationRepository, IBookingRoomRepository bookroomRepository, IRoomRepository roomRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _avaliationRepository = avaliationRepository;
            _bookroomRepository = bookroomRepository;
            _roomRepository = roomRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        //public async Task<Response<Avaliation>> CreateAvaliation(Avaliation avaliation)
        //{
        //    var response = new Response<Avaliation>();
        //    var classValidate = new AvaliationValidator();
        //    var validate = classValidate.Validate(avaliation);
        //    if (!validate.IsValid)
        //    {
        //        validate.Errors.ForEach(x => response.AddMessage(x.PropertyName, x.ErrorMessage));
        //        return response;
        //    };
        //    var roomFind = await _roomRepository.GetById(avaliation.RoomId);
        //    if(roomFind == null)
        //    {
        //        response.AddMessage("Quarto não encontrado", $"Não foi encontrado nenhum quarto com o id {avaliation.RoomId}");
        //    };
        //    var clientFind = _clientRepository.GetById(avaliation.ClientId);
        //    if (clientFind == null)
        //    {
        //        response.AddMessage("Cliente não encontrado", $"Não foi encontrado nenhum cliente com o id {avaliation.ClientId}");
        //    };
        //    await _avaliationRepository.Create(avaliation);
        //    response.AddData(avaliation);
        //    await _unitOfWork.CommitAsync();
        //    return response;
        //}

        //public async Task<bool> ClientCanComment(int clientId,int roomId)
        //{
        //    var result = await _bookroomRepository.GetBookingsByClientIdAndRoomId(clientId, roomId);
        //    if(!result.Any())
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public async Task<Response<IEnumerable<Avaliation>>> GetAvaliationsByRoomId(int id)
        //{
        //    Response<IEnumerable<Avaliation>> response = new Response<IEnumerable<Avaliation>>();
        //    var result = await _avaliationRepository.GetByRoomId(id);
        //    if (result.Any())
        //    {
        //        response.AddData(result);
        //        return response;
        //    }
        //    response.AddMessage("Não foi encontrado nenhuma avaliação", $"Não foi encontrado nenhuma avaliação para o quarto {id}");
        //    return response;
        //}
    }
}
