using Booking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator() 
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("O campo Description não pode ser nulo.")
                .NotNull().WithMessage("O campo Description não pode ser vazio.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo Name não pode ser nulo.")
                .NotNull().WithMessage("O campo Name não pode ser vazio.");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("O campo Level não pode ser nulo.")
                .NotNull().WithMessage("O campo Level não pode ser vazio.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O campo Number não pode ser nulo.")
                .NotNull().WithMessage("O campo Number não pode ser vazio.");
        }
    }
}
