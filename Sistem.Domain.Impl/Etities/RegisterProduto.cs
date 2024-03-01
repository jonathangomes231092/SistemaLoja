using Sistem.Domain.Impl.Validators;
using Sistem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Sistem.Domain.Impl.Etities
{
    public class RegisterProduto : IEntity
    {    
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //propriedades
        public string? Nome { get; set; }
        public string? Tipo { get; set; } // Melhorar pra um Enum
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }


        public ValidationResult validationResult
            => new ProdutoValidator().Validate(this);
    }
}
