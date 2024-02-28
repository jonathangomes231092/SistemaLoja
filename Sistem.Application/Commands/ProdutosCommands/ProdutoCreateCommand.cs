using MediatR;
using Sistem.Application.Dtos;

namespace Sistem.Application.Commands.ProdutosCommands
{
    public class ProdutoCreateCommand : IRequest<ProdutoDto>
    {
        public string? Nome { get; set; }
        public string? Tipo { get; set; } // Melhorar pra um Enum
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
