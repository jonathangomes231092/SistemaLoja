using Sistem.Domain.Impl.Etities;
using Sistem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Domain.Impl.Interfaces
{
    public interface IProdutoRepository : IRepository<RegisterProduto, int>
    {
        RegisterProduto GetByTipo(string tipo);
        RegisterProduto GetByNome(string Nome);
      //  RegisterProduto GetByQuantidade(string Quantidade);
      //  RegisterProduto GetByValor(string Valor);
    }
}  
