using Sistem.Domain.Impl.Interfaces;
using Sistem.Domain.Impl.Services;

namespace SistemaLoja01.Configurations
{
    public class DomainConfg
    {
        public static void AddDomainConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
        }
    }
}
