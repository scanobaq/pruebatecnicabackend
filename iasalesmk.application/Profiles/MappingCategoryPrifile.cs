using AutoMapper;
using iasalesmk.application.DTOs;
using iasalesmk.domain.Entities;

namespace iasalesmk.application.Profiles;

public class MappingCategoryPrifile : Profile
{

    public MappingCategoryPrifile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }

}
