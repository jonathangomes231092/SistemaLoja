using Microsoft.EntityFrameworkCore;
using Sistem.Domain.Impl.Etities;
using Sistem.Domain.Impl.Interfaces;
using Sistem.Infra.Data.SqlServer.Contexts;

namespace Sistem.Infra.Data.SqlServer.Repository
{
    public class ProdutoRepositoy : BaseRepository<RegisterProduto, Guid>, IProdutoRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public ProdutoRepositoy(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public RegisterProduto GetByNome(string Nome)
         => _sqlServerContext.Produtos
            .AsNoTracking()
            .FirstOrDefault(x => x.Nome.Equals(Nome));


        public RegisterProduto GetByTipo(string tipo)
         => _sqlServerContext.Produtos
            .AsNoTracking()
            .FirstOrDefault(x => x.Tipo.Equals(tipo));

    }
}
