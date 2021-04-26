using FluentValidation;
using Modelo.Business.Models;

namespace Modelo.Business.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Descricao)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
               .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Valor)
               .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");              
        }
    }
}
