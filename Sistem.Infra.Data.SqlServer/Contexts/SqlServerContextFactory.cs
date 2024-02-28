using Microsoft.EntityFrameworkCore.Design;

namespace Sistem.Infra.Data.SqlServer.Contexts
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            //return new SqlServerContext();
            return null;
        }
    }
}
