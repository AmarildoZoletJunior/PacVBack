using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Application.Validators;
using Booking.CrossCutting.Helper;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct.Domain.Repositories;

namespace Booking.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly Data.UnitOfWork.IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, Data.UnitOfWork.IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Client>> CreateClient(Client client)
        {
            var response = new Response<Client>();
            var classValidate = new ClientValidator();
            var validate = classValidate.Validate(client);

            if (!validate.IsValid)
            {
                validate.Errors.ForEach(x => response.AddMessage(x.PropertyName, x.ErrorMessage));
                return response;
            }

            var emailFind = await _clientRepository.EmailIsUsed(client.Email);
            if (emailFind)
            {
                response.AddMessage("Email em uso", "Este email já esta sendo utilizado");
                return response;
            }

            var documentFind = await _clientRepository.DocumentNumberIsUsed(client.PersonType.DocumentNumber);
            if (documentFind)
            {
                response.AddMessage("Numero de documento em uso", "Este número de documento já esta sendo utilizado");
                return response;
            }

            client.Password = CryptoHelper.EncryptPassword(client.Password);
            await _clientRepository.Create(client);
            await  _unitOfWork.CommitAsync();
            response.AddData(client);
            return response;
        }

        public async Task<Response<Client>> GetClient(int id)
        {
            var response = new Response<Client>();
            var result = await _clientRepository.GetById(id);
            if (result != null)
            {
                response.AddData(result);
                return response;    
            }
            response.AddMessage("Cliente não encontrado", $"O cliente com o id:{id} não foi encontrado");
            return response;
        }
    }
}
