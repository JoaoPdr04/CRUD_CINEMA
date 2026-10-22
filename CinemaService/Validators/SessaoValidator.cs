using CinemaDomain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Validators
{
    public class SessaoValidator : AbstractValidator<Sessao>
    {
        public SessaoValidator()
        {
            RuleFor(s => s.Horario)
                .NotEmpty().WithMessage("Horário da sessão deve ser informado")
                .NotNull().WithMessage("Horário da sessão deve ser informado");

            RuleFor(s => s.Sala)
                .NotNull().WithMessage("Sala da sessão deve ser informada");

            RuleFor(s => s.Filme)
                .NotNull().WithMessage("Filme da sessão deve ser informado");
        }
    }
}