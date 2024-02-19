namespace Sistem.Domain.Interfaces
{
    /// <summary>
    /// Interface de repositorio generico para parte de banco de dados
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync(int page, int limit);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
