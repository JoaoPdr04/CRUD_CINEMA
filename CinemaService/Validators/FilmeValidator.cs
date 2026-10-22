using CinemaDomain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Validators
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Filme deve ser informado")
                .NotNull().WithMessage("Filme deve ser informado")
                .Length(5, 50).WithMessage("Filme deve conter entre 5 e 50 caracteres");

            RuleFor(f => f.Classificacao)
                .NotEmpty().WithMessage("Classificação deve ser informada")
                .NotNull().WithMessage("Classificação deve ser informada")
                .Length(5, 50).WithMessage("Classificação deve conter entre 5 e 50 caracteres");

            RuleFor(f => f.Duracao)
                .NotEmpty().WithMessage("Duração deve ser informada")
                .NotNull().WithMessage("Duração deve ser informada");

            RuleFor(f => f.Genero)
                .NotEmpty().WithMessage("Gênero deve ser informado")
                .NotNull().WithMessage("Gênero deve ser informado");
        }
    }
}