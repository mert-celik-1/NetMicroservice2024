using AutoMapper;
using NetMicroservice.Catalog.Api.Features.Categories.Create;

namespace NetMicroservice.Catalog.Api.Features.Categories;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();

        CreateMap<CategoryDto, Category>().ReverseMap();
    }
}