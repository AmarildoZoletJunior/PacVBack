using Booking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Validators
{
    public class BookingRoomValidator : AbstractValidator<BookingRoom>
    {
        public BookingRoomValidator()
        {
            RuleFor(x => x.Start).NotEmpty().WithMessage("O campo Start não pode ser vazio.").NotNull().WithMessage("O campo start não pode ser nulo");
            RuleFor(x => x.End).NotEmpty().WithMessage("O campo End não pode ser vazio.").NotNull().WithMessage("O campo End não pode ser nulo");
            RuleFor(x => x.End).LessThan(x => x.Start).WithMessage("O campo End não pode ser menor que o campo Start").LessThan(DateTime.Now).WithMessage("O campo End não pode ser menor que a data atual.");
        }
    }
}
