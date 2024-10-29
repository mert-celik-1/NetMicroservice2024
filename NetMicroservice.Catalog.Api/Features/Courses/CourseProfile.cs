using AutoMapper;

namespace NetMicroservice.Catalog.Api.Features.Courses;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>().ReverseMap();

        CreateMap<Feature, FeatureDto>().ReverseMap();
    }
}