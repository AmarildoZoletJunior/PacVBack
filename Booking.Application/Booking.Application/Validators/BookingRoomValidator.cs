using Booking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Validators
{
    public class BookingRoomValidator : AbstractValidator<BookingRoom>
    {
        public BookingRoomValidator() 
        {
            RuleFor(x => x.Start).LessThan(x => x.End).WithMessage("A data de entrada não pode ser maior que a data de saida").NotNull().WithMessage("O campo data de entrada não pode ser nulo").NotEmpty().WithMessage("O campo data de entrada não pode ser vazio");
            RuleFor(x => x.End).GreaterThan(x => x.Start).WithMessage("A data de saida não pode menor que a data de entrada").NotNull().WithMessage("O campo data de saida não pode ser nulo").NotEmpty().WithMessage("O campo data de saida não pode ser vazio");
            RuleFor(x => x.ClientId).NotNull().WithMessage("O Id do cliente não pode ser nulo").NotEmpty().WithMessage("O Id do cliente não pode ser vazio");
            RuleFor(x => x.RoomId).NotNull().WithMessage("O Id do quarto não pode ser nulo").NotEmpty().WithMessage("O Id do quarto não pode ser vazio");
        }
    }
}
