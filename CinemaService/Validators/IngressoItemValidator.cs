using CinemaDomain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Validators
{
    public class IngressoItemValidator : AbstractValidator<IngressoItem>
    {
        public IngressoItemValidator()
        {
            RuleFor(ii => ii.Assento)
                .NotEmpty().WithMessage("Assento deve ser informado")
                .NotNull().WithMessage("Assento deve ser informado")
                .InclusiveBetween(1, 100).WithMessage("Assento deve estar entre 1 e 100");

            RuleFor(ii => ii.Fileira)
                .NotEmpty().WithMessage("Fileira deve ser informada")
                .NotNull().WithMessage("Fileira deve ser informada")
                .InclusiveBetween(1, 10).WithMessage("Fileira deve estar entre 1 e 10");

            RuleFor(ii => ii.Ingresso)
                .NotNull().WithMessage("Ingresso associado deve ser informado");

            // MeiaEntrada é bool; nenhuma validação adicional necessária aqui
        }
    }
}
