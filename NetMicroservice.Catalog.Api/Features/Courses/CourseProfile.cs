using AutoMapper;
using NetMicroservice.Catalog.Api.Features.Courses.Create;
using NetMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace NetMicroservice.Catalog.Api.Features.Courses;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();
    }
}