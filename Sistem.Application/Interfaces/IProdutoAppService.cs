using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Application.Dtos;

namespace Sistem.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task<ProdutoDto> Creat(ProdutoCreateCommand command);
        Task<ProdutoDto> Delete(ProdutoDeleteCommand command);
        Task<ProdutoDto> Update(ProdutoUpdateCommand command);
    }
}
