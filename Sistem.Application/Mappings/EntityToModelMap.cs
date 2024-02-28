using AutoMapper;
using Sistem.Application.Dtos;
using Sistem.Domain.Impl.Etities;

namespace Sistem.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<RegisterProduto, ProdutoDto>();
        }
    }
}
