using Microsoft.EntityFrameworkCore;
using Sistem.Domain.Impl.Interfaces;
using Sistem.Domain.Interfaces;
using Sistem.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem.Infra.Data.SqlServer.Repository
{
    public class BaseRepository<TEntity, Tkey> : IRepository<TEntity, Tkey>
        where TEntity : class
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //metodo construtor
        protected BaseRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public async virtual Task CreateAsync(TEntity entity)
        {
            _sqlServerContext.Set<TEntity>().Add(entity);
            try
            {
                await _sqlServerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Examine a exceção interna para obter mais detalhes
                Console.WriteLine($"Erro ao salvar entidade: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalhes internos: {ex.InnerException.Message}");
                }
            }
           // await _sqlServerContext.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            await _sqlServerContext.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _sqlServerContext.Set<TEntity>().Remove(entity);
            await _sqlServerContext.SaveChangesAsync();
        }

        public async virtual Task<List<TEntity>> GetAllAsync(int page, int limit)
        => await _sqlServerContext.Set<TEntity>()
            .AsNoTracking()
            .Skip(page)
            .Take(limit)
            .ToListAsync();

        public async virtual Task<TEntity> GetByIdAsync(Tkey id)
        {
            var result = await _sqlServerContext.Set<TEntity>()
                .FindAsync(id);

             _sqlServerContext.Entry(result).State = EntityState.Detached;
            return result;
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
