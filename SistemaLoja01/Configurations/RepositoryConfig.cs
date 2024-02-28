using Microsoft.EntityFrameworkCore;
using Sistem.Domain.Impl.Interfaces;
using Sistem.Infra.Data.SqlServer.Contexts;
using Sistem.Infra.Data.SqlServer.Repository;

namespace SistemaLoja01.Configurations
{
    public class RepositoryConfig
    {
        public static void AddRepositoryConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var connectionString = builder.Configuration.GetConnectionString("BD_PRODUTO_LOJA");
            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));
        }
    }
}
