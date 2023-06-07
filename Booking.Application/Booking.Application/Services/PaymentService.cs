using Booking.Application.DTOs.ResponseDTO;
using Booking.Application.Interfaces;
using Booking.Application.Validators;
using Booking.Data.UnitOfWork;
using Booking.Domain.Entities;
using Booking.Domain.Ports;

namespace Booking.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientRepository _clientRepository;
        private readonly IBookingRoomRepository _bookroomRepository;

        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IClientRepository clientRepository, IBookingRoomRepository bookroomRepository)
        {
            _paymentRepository = paymentRepository;
            this._unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
            _bookroomRepository = bookroomRepository;
        }

        public async Task<Response<Payment>> CreatePayment(Payment payment)
        {
            var response = new Response<Payment>();
            var validator = new PaymentValidator();
            var validate = validator.Validate(payment);
            if (!validate.IsValid)
            {
                validate.Errors.ForEach(x => response.AddMessage(x.PropertyName, x.ErrorMessage));
                return response;
            }
            var ClientFind = await _clientRepository.GetById(payment.ClienteId);
            if (ClientFind == null) 
            {
                response.AddMessage("Erro no cliente Id", $"Infelizmente, não encontramos este cliente pelo id:{payment.ClienteId}");
                return response;
            }
            var BookingRoomFind = await _bookroomRepository.GetById(payment.BookingRoomId);
            if (BookingRoomFind == null)
            {
                response.AddMessage("Erro no booking Id", $"Infelizmente, não encontramos este aluguel pelo id:{payment.ClienteId}");
                return response;
            }
            _paymentRepository.CreatePayment(payment);
            await _unitOfWork.CommitAsync();
            response.AddData(payment);
            return response;
        }

        public async Task<Response<IEnumerable<Payment>>> GetAllPayment()
        {
            var response = new Response<IEnumerable<Payment>>();
            var findAllPayments = await _paymentRepository.GetPaymentAll();
            if (findAllPayments.Any()) 
            {
                response.AddData(findAllPayments);
                return response;
            }
            response.AddMessage("Não encontrado", "Não foi encontrado nenhum pagamento");
            return response;
        }

        public async Task<Response<IEnumerable<Payment>>> GetAllPaymentsByRoomId(int RoomId)
        {
            var response = new Response<IEnumerable<Payment>>();
            var findAllPaymentsById = await _paymentRepository.GetPaymentsByRoomId(RoomId);
            if (findAllPaymentsById != null)
            {
                response.AddData(findAllPaymentsById);
                return response;
            }
            response.AddMessage("Não encontrado", $"Não foi encontrado nenhum pagamento com o id: {RoomId}");
            return response;
        }

        public async Task<Response<Payment>> GetPaymentById(int PaymentId)
        {
            var response = new Response<Payment>();
            var findAllPayments = await _paymentRepository.GetPaymentById(PaymentId);
            if (findAllPayments != null)
            {
                response.AddData(findAllPayments);
                return response;
            }
            response.AddMessage("Não encontrado", $"Não foi encontrado nenhum pagamento com o id: {PaymentId}");
            return response;
        }

        public async Task<Response<IEnumerable<Payment>>> GetPaymentsByClient(int ClientId)
        {
            var response = new Response<IEnumerable<Payment>>();
            var findAllPayments = await _paymentRepository.GetPaymentsByClient(ClientId);
            if (findAllPayments != null)
            {
                response.AddData(findAllPayments);
                return response;
            }
            response.AddMessage("Não encontrado", $"Não foi encontrado nenhum pagamento com o id: {ClientId}");
            return response;
        }

        public async Task<Response<Payment>> PutStatusForCancel(int PaymentId)
        {
            var response = new Response<Payment>();
            var findPayment = await _paymentRepository.GetPaymentById(PaymentId);
            if (findPayment != null)
            {
                _paymentRepository.CancelPayment(PaymentId);
                await _unitOfWork.CommitAsync();
                response.AddData(findPayment);
            }      
            response.AddMessage("Não encontrado", $"Não foi encontrado nenhum pagamento com o id: {PaymentId}");
            return response;
        }

        public async Task<Response<Payment>> PutStatusForPay(int PaymentId)
        {
            var response = new Response<Payment>();
            var findPayment = await _paymentRepository.GetPaymentById(PaymentId);
            if (findPayment != null)
            {
                await _paymentRepository.UpdateForPayAsync(PaymentId);
                await _unitOfWork.CommitAsync();
                response.AddData(findPayment);
            }
            response.AddMessage("Não encontrado", $"Não foi encontrado nenhum pagamento com o id: {PaymentId}");
            return response;
        }
    }
}
