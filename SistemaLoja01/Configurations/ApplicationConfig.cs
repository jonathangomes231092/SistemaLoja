using MediatR;
using Sistem.Application.Interfaces;
using Sistem.Application.Services;

namespace SistemaLoja01.Configurations
{
    public class ApplicationConfig
    {
        public static void AddApplicationConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IProdutoAppService, ProdutoAppService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
