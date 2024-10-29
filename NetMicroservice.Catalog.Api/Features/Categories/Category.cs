using NetMicroservice.Catalog.Api.Features.Courses;
using NetMicroservice.Catalog.Api.Repositories;

namespace NetMicroservice.Catalog.Api.Features.Categories;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<Course>? Courses { get; set; }
}