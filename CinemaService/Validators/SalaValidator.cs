using CinemaDomain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Validators
{
    public class SalaValidator : AbstractValidator<Sala>
    {
        public SalaValidator()
        {
            RuleFor(s => s.Capacidade) // da pra fazer uma verificação se está batendo com o número de fileiras e assentos, mas não sei se é necessário
                .NotEmpty().WithMessage("Capacidade da sala deve ser informada")
                .NotNull().WithMessage("Capacidade da sala deve ser informada")
                .InclusiveBetween(1, 1000).WithMessage("Capacidade da sala deve estar entre 1 e 1000");

            RuleFor(s => s.Numero)
                .NotEmpty().WithMessage("Número da sala deve ser informado")
                .NotNull().WithMessage("Número da sala deve ser informado")
                .InclusiveBetween(1, 100).WithMessage("Número da sala deve estar entre 1 e 100");

            RuleFor(s => s.Fileiras)
                .NotEmpty().WithMessage("Fileiras da sala devem ser informadas")
                .NotNull().WithMessage("Fileiras da sala devem ser informadas")
                .InclusiveBetween(1, 10).WithMessage("Fileiras da sala devem estar entre 1 e 10");

            RuleFor(s => s.Assentos)
                .NotEmpty().WithMessage("Assentos da sala devem ser informados")
                .NotNull().WithMessage("Assentos da sala devem ser informados")
                .InclusiveBetween(1, 100).WithMessage("Assentos da sala devem estar entre 1 e 100");
        }
    }
}