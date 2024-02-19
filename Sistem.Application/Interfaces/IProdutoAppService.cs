using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task<ProdutoDto> Creat(ProdutoCreateCommand command);
        Task<ProdutoDto> Delete(ProdutoDeleteCommand command);
        Task<ProdutoDto> Update(ProdutoUpdateCommand command);
    }
}
