using MediatR;
using Sistem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Application.Commands.ProdutosCommands
{
    public class ProdutoDeleteCommand : IRequest<ProdutoDto>
    {
        public Guid Id { get; set; }
    }
}
