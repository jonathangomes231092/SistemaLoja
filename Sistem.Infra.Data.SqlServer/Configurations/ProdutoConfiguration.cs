using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistem.Domain.Impl.Etities;

namespace Sistem.Infra.Data.SqlServer.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<RegisterProduto>
    {

        public void Configure(EntityTypeBuilder<RegisterProduto> builder)
        {
            builder.HasIndex(x => x.Nome).IsUnique();
            builder.HasIndex(x => x.Tipo);
            builder.HasIndex(x => x.Quantidade);
            builder.HasIndex(x => x.Valor);

        }
    }
}
