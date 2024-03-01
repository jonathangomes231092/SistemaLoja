using AutoMapper;
using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Domain.Impl.Etities;

namespace Sistem.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<ProdutoCreateCommand, RegisterProduto>()
                .AfterMap((Command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                });

            CreateMap<ProdutoUpdateCommand, RegisterProduto>()
              .AfterMap((Command, entity) =>
              {
                  entity.UpdatedAt = DateTime.Now;
              });
        }
    }
}
