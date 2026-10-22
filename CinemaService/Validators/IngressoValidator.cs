using CinemaDomain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaService.Validators
{
    public class IngressoValidator : AbstractValidator<Ingresso>
    {
        public IngressoValidator()
        {
            RuleFor(i => i.Documento)
                .NotEmpty().WithMessage("Documento deve ser informado")
                .NotNull().WithMessage("Documento deve ser informado")
                .Length(5, 50).WithMessage("Documento deve conter entre 5 e 50 caracteres");

            RuleFor(i => i.DataCompra)
                .NotEmpty().WithMessage("Data da compra deve ser informada")
                .NotNull().WithMessage("Data da compra deve ser informada")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data da compra não pode ser no futuro");

            RuleFor(i => i.Sessao)
                .NotNull().WithMessage("Sessão deve ser informada");

            RuleFor(i => i.ValorTotal)
                .NotEmpty().WithMessage("Valor total deve ser informado")
                .NotNull().WithMessage("Valor total deve ser informado")
                .GreaterThanOrEqualTo(0).WithMessage("Valor total deve ser maior ou igual a 0");

            RuleFor(i => i.FormaPagamento)
                .NotEmpty().WithMessage("Forma de pagamento deve ser informada")
                .NotNull().WithMessage("Forma de pagamento deve ser informada")
                .Length(3, 50).WithMessage("Forma de pagamento deve conter entre 3 e 50 caracteres");

            RuleFor(i => i.IngressoItens)
                .NotNull().WithMessage("Itens do ingresso devem ser informados")
                .Must(list => list != null && list.Count > 0).WithMessage("Deve haver ao menos um item no ingresso");
        }
    }
}
