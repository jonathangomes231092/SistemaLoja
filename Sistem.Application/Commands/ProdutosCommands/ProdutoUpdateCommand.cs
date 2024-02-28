using MediatR;
using Sistem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Application.Commands.ProdutosCommands
{
    public class ProdutoUpdateCommand : IRequest<ProdutoDto>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; } // Melhorar pra um Enum
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
