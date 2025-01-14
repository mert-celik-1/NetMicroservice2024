using Asp.Versioning.Builder;
using NetMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using NetMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem;

namespace NetMicroservice.Basket.Api.Features.Baskets;

public static class BasketEndpointExt
{
    public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
            .WithApiVersionSet(apiVersionSet)
            .AddBasketItemGroupItemEndpoint()
            .DeleteBasketItemGroupItemEndpoint();
    }
}