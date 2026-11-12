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
                .Length(2, 50).WithMessage("Gênero deve conter entre 2 e 50 caracteres");
        }
    }
}
