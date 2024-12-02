using AutoMapper;
using iasalesmk.application.DTOs;
using iasalesmk.domain.Entities;

namespace iasalesmk.application.Profiles;

public class MappingProductProfile : Profile
{
    public MappingProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}
