using Booking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Validators
{
    public class AvaliationValidator : AbstractValidator<Avaliation>
    {
        public AvaliationValidator() 
        {
            RuleFor(x => x.Description).NotNull().WithMessage("O campo descrição esta vazio").NotEmpty().WithMessage("O campo descrição esta nulo");
            RuleFor(x => x.Grade).NotNull().WithMessage("O campo nota esta vazio").NotEmpty().WithMessage("O campo nota esta nulo").GreaterThan(5).WithMessage("O campo nota não pode ser maior que 5").LessThan(1).WithMessage("O campo nota não pode ser menos que 0");
            RuleFor(x => x.RoomId).NotNull().WithMessage("O campo Id do quarto esta vazio").NotEmpty().WithMessage("O campo Id do quarto esta nulo");
            RuleFor(x => x.ClientId).NotNull().WithMessage("O campo Id do cliente esta vazio").NotEmpty().WithMessage("O campo Id do cliente esta nulo");
        }
    }
}
