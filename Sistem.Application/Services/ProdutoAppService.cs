using MediatR;
using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Application.Dtos;
using Sistem.Application.Interfaces;

namespace Sistem.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMediator _mediator;

        public ProdutoAppService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ProdutoDto> Creat(ProdutoCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProdutoDto> Delete(ProdutoDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProdutoDto> Update(ProdutoUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
