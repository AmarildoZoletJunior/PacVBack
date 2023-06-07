using Booking.Domain.Entities;

namespace Booking.Domain.Ports
{
    public interface IPaymentRepository
    {
        void CreatePayment(Payment payment);
        void CancelPayment(int paymentId);
        Task UpdateForPayAsync(int paymentId);
        Task<IEnumerable<Payment>> GetPaymentsByClient(int ClientId);
        Task<IEnumerable<Payment>> GetPaymentsByRoomId(int RoomId);
        Task<IEnumerable<Payment>> GetPaymentAll();
        Task<Payment> GetPaymentById(int PaymentId);
    }
}
