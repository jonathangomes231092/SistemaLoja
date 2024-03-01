using AutoMapper;
using FluentValidation;
using MediatR;
using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Application.Dtos;
using Sistem.Domain.Impl.Etities;
using Sistem.Domain.Impl.Interfaces;


namespace Sistem.Application.RequestHandlers
{
    public class ProdutoRequestHandler : IDisposable,
        IRequestHandler<ProdutoCreateCommand, ProdutoDto>,
        IRequestHandler<ProdutoDeleteCommand, ProdutoDto>,
        IRequestHandler<ProdutoUpdateCommand, ProdutoDto>
    {

        private readonly IProdutoDomainService _produtoDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProdutoRequestHandler(IProdutoDomainService produtoDomainService,
            IMediator mediator,
            IMapper mapper)
        {
            _produtoDomainService = produtoDomainService;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<RegisterProduto>(request);


            if (!client.validationResult.IsValid)
                throw new ValidationException(client.validationResult.Errors);

            await _produtoDomainService.CreateAsync(client);

            return _mapper.Map<ProdutoDto>(client);
        }

        public async Task<ProdutoDto> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
        {
            var client = await _produtoDomainService.GetByIdAsync(request.Id);

            await _produtoDomainService.DeleteAsync(client);

            return _mapper.Map<ProdutoDto>(client);
        }

        public async Task<ProdutoDto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            // capiturando dados do cliente
            var client = _mapper.Map<RegisterProduto>(request);

            // executando a validação da entidade cliente
            if (!client.validationResult.IsValid)
                throw new ValidationException(client.validationResult.Errors);

            await _produtoDomainService.UpdateAsync(client);

            return _mapper.Map<ProdutoDto>(client);
        }
        public void Dispose()
        
        {
            _produtoDomainService.Dispose();
        }
    }
}
