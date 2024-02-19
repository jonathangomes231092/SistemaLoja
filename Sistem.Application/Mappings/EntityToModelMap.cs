using AutoMapper;
using Sistem.Application.Dtos;
using Sistem.Domain.Impl.Etities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
