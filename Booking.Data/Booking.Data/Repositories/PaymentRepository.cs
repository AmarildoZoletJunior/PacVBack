using Booking.Domain.Entities;
using Booking.Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DbBooking _DbBooking;
        public PaymentRepository(DbBooking _dbBooking) 
        {
            this._DbBooking = _dbBooking;
        }
        public async void CancelPayment(int paymentId)
        {
            var Payment = await GetPaymentById(paymentId);
            Payment.Status = Domain.Enum.StatusPayment.Canceled;
        }

        public void CreatePayment(Payment payment)
        {
            _DbBooking.Payments.Add(payment);
        }

        public async Task<IEnumerable<Payment>> GetPaymentAll()
        {
            var payment = await _DbBooking.Payments.ToListAsync();
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByClient(int ClientId)
        {
            var payment = await _DbBooking.Payments.Where(x => x.ClienteId == ClientId).ToListAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentById(int PaymentId)
        {
            var payment = await _DbBooking.Payments.FirstOrDefaultAsync(x => x.Id == PaymentId);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByRoomId(int RoomId)
        {
            var payment = await _DbBooking.Payments.Where(x => x.BookingRoom.RoomId == RoomId).Include(x => x.BookingRoom).ToListAsync();
            return payment;
        }

        public async Task UpdateForPayAsync(int paymentId)
        {
            var Payment = await GetPaymentById(paymentId);
            Payment.Status = Domain.Enum.StatusPayment.Confirmed;
        }
    }
}
