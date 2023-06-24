using Booking.Domain.Entities;
using FluentValidation;

namespace Booking.Application.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.ClienteId).NotNull().WithMessage("O campo id do cliente não pode ser nulo.").NotEmpty().WithMessage("O campo id do cliente não pode ser vazio.");
            RuleFor(x => x.Value).NotNull().WithMessage("O campo Valor não pode ser nulo.").NotEmpty().WithMessage("O campo Valor não pode ser vazio.").GreaterThan(20).WithMessage("O campo Valor não pode ser menor que 20.");
            RuleFor(x => x.BookingRoomId).NotNull().WithMessage("O campo BookingRoomId não pode ser nulo.").NotEmpty().WithMessage("O campo BookingRoomId não pode ser vazio.");
        }
    }
}
