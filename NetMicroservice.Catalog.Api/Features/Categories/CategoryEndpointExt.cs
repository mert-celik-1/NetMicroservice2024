using NetMicroservice.Catalog.Api.Features.Categories.Create;
using NetMicroservice.Catalog.Api.Features.Categories.GetAll;
using NetMicroservice.Catalog.Api.Features.Categories.GetById;

namespace NetMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExt
{
    public static void AddCategoryGroupEndpointExt(this WebApplication app)
    {
        app.MapGroup("api/categories")
            .CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint();

    }
}