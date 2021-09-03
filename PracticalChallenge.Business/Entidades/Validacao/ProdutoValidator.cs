using FluentValidation;
using PracticalChallenge.Business.Mensagens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticalChallenge.Business.Entidades.Validacao
{
    public class ProdutoValidator: AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage(MensagensValidacao.ME001)
                .Length(3,50).WithMessage(MensagensValidacao.ME002);

            RuleFor(p => p.ValorUnitario)
                .NotEmpty().WithMessage(MensagensValidacao.ME001);

            RuleFor(p => p.Quantidade)
                .NotEmpty().WithMessage(MensagensValidacao.ME001);
        }
    }
}
