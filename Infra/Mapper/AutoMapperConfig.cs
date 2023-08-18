using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
    //CreateMap<Entity, EntityDto>.ReverseMap();
    }
}
