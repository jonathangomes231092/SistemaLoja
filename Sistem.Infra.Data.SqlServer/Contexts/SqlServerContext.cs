using Microsoft.EntityFrameworkCore;
using Sistem.Domain.Impl.Etities;
using Sistem.Infra.Data.SqlServer.Configurations;

namespace Sistem.Infra.Data.SqlServer.Contexts
{
    public class SqlServerContext : DbContext
    {
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {

             optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JB24SF0\MSSQLSERVER01;Initial Catalog=BD_PRODUTO_LOJA;Integrated Security=True");
         }*/

        // construtor da superclasse (DbContext)
       public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions)
                : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        public DbSet<RegisterProduto>? Produtos { get; set; }

    }
}
