using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Application.Validators;
using Booking.CrossCutting.Helper;
using Booking.Data.Repositories;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Room>> CreateRoom(Room room)
        {
            var response = new Response<Room>();
            var classValidate = new RoomValidator();
            var validate = classValidate.Validate(room);
            if (!validate.IsValid)
            {
                validate.Errors.ForEach(x => response.AddMessage(x.PropertyName, x.ErrorMessage));
                return response;
            }
            var roomNumberIsUsed = await _roomRepository.RoomNumberIsUsed(room.Number);
            if (roomNumberIsUsed)
            {
                response.AddMessage("RoomNumber já esta em uso", $"O RoomNumber:{room.Number} já esta em uso.");
                return response;
            };
            response.AddData(room);
            await _roomRepository.Create(room);
            await _unitOfWork.CommitAsync();
            return response;
        }

        public async Task<Response<Room>> GetRoomAsync(int roomId)
        {
            var response = new Response<Room>();
            var result = await _roomRepository.GetById(roomId);
            if(result != null)
            {
                response.AddData(result);
                return response;
            }
            response.AddMessage("Quarto não encontrado", $"Não foi encontrado nenhum quarto com este id: {roomId}");
            return response;
        }

        public async Task<Response<IEnumerable<Room>>> GetRooms(PagedParameters paged)
        {
            var response = new Response<IEnumerable<Room>>();
            var result =  await _roomRepository.GetAllPaged(paged);
            if (result.Any())
            {
                response.AddData(result);
                return response;
            }
            response.AddMessage("Lista de quarto não disponivel", "Não foi encontrado nenhum quarto cadastrado");
            return response;
        }

        public async Task<Response<Room>> DeleteRoom(int id)
        {
            var response = new Response<Room>();
            var find = await _roomRepository.GetById(id);
            if(find == null)
            {
                response.AddMessage("Quarto não encontrado", $"O quarto com id:{id} não foi encontrado");
                return response;
            }
            _roomRepository.DeleteRoom(find);
            await _unitOfWork.CommitAsync();
            return response;
        }

        public async Task<Response<Room>> UpdateRoom(Room room)
        {
            var response = new Response<Room>();
            var findRoom = await _roomRepository.GetById(room.Id);
            if (findRoom == null)
            {
                response.AddMessage("Quarto não encontrado", $"O Quarto com id: {room.Id} não foi encontrado");
                return response;
            };
            findRoom.Number = room.Number;
            findRoom.Description = room.Description;
            findRoom.Level = room.Level;
            findRoom.Name = room.Name;
            _roomRepository.Update(findRoom);
            await _unitOfWork.CommitAsync();
            response.AddData(findRoom);
            return response;
        }

        public async Task<Response<IEnumerable<Room>>> GetRoomsAvailable(PagedParameters paged)
        {
            var response = new Response<IEnumerable<Room>>();
            var result = await _roomRepository.GetRoomsAvailable(paged);
            if (result.Any())
            {
                response.AddData(result);
                return response;
            }
            response.AddMessage("Lista de quarto não disponivel", "Não foi encontrado nenhum quarto cadastrado");
            return response;
        }
    }
}
