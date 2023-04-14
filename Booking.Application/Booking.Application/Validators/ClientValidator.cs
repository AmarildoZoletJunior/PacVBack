using Booking.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Booking.Application.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo email esta vazio")
                .NotNull().WithMessage("O campo email esta nulo")
                .EmailAddress().WithMessage("Este email é invalido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("O campo password esta vazio")
                .NotNull().WithMessage("O campo password esta nulo");

            RuleFor(x => x.PersonType.Surname)
                .NotEmpty().WithMessage("O campo sobrenome esta vazio")
                .NotNull().WithMessage("O campo sobrenome esta nulo");

            RuleFor(x => x.PersonType.DocumentNumber)
                .Must(x => ValidateCpf(x)).WithName("Numero De Documento").WithMessage("Este cpf esta inválido.");

        }
        private static bool ValidateCpf(string cpf)
        {
            cpf = cpf.Trim();
            if (cpf.Length > 14)
            {
                return false;
            }

            cpf = cpf.Replace(".", "").Replace("-", "");
            if (!Regex.IsMatch(cpf, "^[0-9]*$") || cpf.Length > 11 || cpf.Length < 11)
            {
                return false;
            }
            return true;
        }
    }
}
