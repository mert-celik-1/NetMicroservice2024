using Asp.Versioning.Builder;
using NetMicroservice.Catalog.Api.Features.Courses.Create;
using NetMicroservice.Catalog.Api.Features.Courses.Delete;
using NetMicroservice.Catalog.Api.Features.Courses.GetAll;
using NetMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using NetMicroservice.Catalog.Api.Features.Courses.GetById;
using NetMicroservice.Catalog.Api.Features.Courses.Update;

namespace NetMicroservice.Catalog.Api.Features.Courses;

public static class CourseEndpointExt
{
    public static void AddCourseGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses").WithApiVersionSet(apiVersionSet)
            .CreateCourseGroupItemEndpoint()
            .GetAllCourseGroupItemEndpoint()
            .GetByIdCourseGroupItemEndpoint()
            .UpdateCourseGroupItemEndpoint()
            .DeleteCourseGroupItemEndpoint()
            .GetByUserIdCourseGroupItemEndpoint();

    }
}