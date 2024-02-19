using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Domain.Impl.Interfaces
{
    public interface IUnitOfWork
    {
        void Begintransaction();
        void CommitTransaction();
        void RollbackTransaction();


        #region Repositórios

        public IProdutoRepository ProdutoRepository { get; }

        #endregion
    }
}
