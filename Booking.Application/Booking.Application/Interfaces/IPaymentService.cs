using Booking.Application.DTOs.ResponseDTO;
using Booking.Domain.Entities;

namespace Booking.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<Response<Payment>> CreatePayment(Payment payment);
        Task<Response<Payment>> PutStatusForCancel(int PaymentId);
        Task<Response<Payment>> PutStatusForPay(int PaymentId);
        Task<Response<IEnumerable<Payment>>> GetAllPayment();
        Task<Response<IEnumerable<Payment>>> GetPaymentsByClient(int ClientId);
        Task<Response<IEnumerable<Payment>>> GetAllPaymentsByRoomId(int RoomId);
        Task<Response<Payment>> GetPaymentById(int PaymentId);
    }
}
