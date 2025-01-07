using NetMicroservice.Catalog.Api.Features.Categories;
using NetMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace NetMicroservice.Catalog.Api.Features.Courses;

public record CourseDto(
    string Id,
    string Name,
    string Description,
    decimal Price,
    string UserId,
    string Picture,
    DateTime CreatedTime,
    FeatureDto Feature,
    CategoryDto Category);