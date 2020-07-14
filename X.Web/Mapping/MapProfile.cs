using AutoMapper;
using X.Web.DTOs;
using X.Core.Entities;

namespace X.Web.Mapping
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
