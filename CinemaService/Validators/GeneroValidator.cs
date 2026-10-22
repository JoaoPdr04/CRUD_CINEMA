using CinemaDomain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Validators
{
    public class GeneroValidator : AbstractValidator<Genero>
    {
        public GeneroValidator()
        {
            RuleFor(g => g.Nome)
                .NotEmpty().WithMessage("Gênero deve ser informado")
                .NotNull().WithMessage("Gênero deve ser informado")
                .Length(5, 50).WithMessage("Gênero deve conter entre 5 e 50 caracteres");
        }
    }
}
