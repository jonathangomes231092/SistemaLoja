using FluentValidation.Results;

namespace Sistem.Domain.Interfaces
{
    public interface IValidator
    {
        //metodo para retonar o resultado de uma validação
        ValidationResult validationResult { get; }
    }
}
