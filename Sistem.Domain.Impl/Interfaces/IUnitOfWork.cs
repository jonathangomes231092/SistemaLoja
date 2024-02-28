namespace Sistem.Domain.Impl.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Begintransaction();
        void CommitTransaction();
        void RollbackTransaction();


        #region Repositórios

        public IProdutoRepository ProdutoRepository { get; }

        #endregion
    }
}
