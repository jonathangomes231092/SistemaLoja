using Microsoft.EntityFrameworkCore.Storage;
using Sistem.Domain.Impl.Interfaces;
using Sistem.Infra.Data.SqlServer.Contexts;

namespace Sistem.Infra.Data.SqlServer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        private IDbContextTransaction _dbContextTransaction;


        public void Begintransaction()
        {
            _dbContextTransaction = _sqlServerContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            _dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }

        public IProdutoRepository ProdutoRepository => new ProdutoRepositoy(_sqlServerContext);

    }
}
