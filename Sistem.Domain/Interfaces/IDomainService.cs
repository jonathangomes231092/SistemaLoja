namespace Sistem.Domain.Interfaces
{
    /// <summary>
    /// interface para operações com as entidades
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IDomainService<TEntity, TKey> : IDisposable // para destruir oque foi contruido por enjeção de dependencia
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync(int page, int limit);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
