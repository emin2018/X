using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using X.API.DTOs;
using X.Core.Entities;

namespace X.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
            
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<PersonProductRelation, PersonProductRelationDto>();
            CreateMap<PersonProductRelationDto, PersonProductRelation>();
            CreateMap<PersonProductRelationDto, CreateOrUpdatePersonProductRelationDto>();
            CreateMap<CreateOrUpdatePersonProductRelationDto, PersonProductRelation>();
        }
    }
}
