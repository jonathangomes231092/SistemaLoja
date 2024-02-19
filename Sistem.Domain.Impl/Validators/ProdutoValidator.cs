using FluentValidation;
using Sistem.Domain.Impl.Etities;

namespace Sistem.Domain.Impl.Validators
{
    public class ProdutoValidator : AbstractValidator<RegisterProduto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id obrigatório");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome obrigatório")
                .Length(6, 150)
                .WithMessage("Nome deve possuir de 6 a 150 caracteres");

            RuleFor(x => x.Quantidade)
                .NotEmpty()
                .WithMessage("Digite a quantidade");

            RuleFor(x => x.Tipo)
                .NotEmpty()
                .WithMessage("Digite o tipo do produto");

            RuleFor(x => x.Valor)
             .NotEmpty()
             .WithMessage("Digite Valor do produto");
        }
    }
}
