using System.Net;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using NetMicroservice.Basket.Api.Const;
using NetMicroservice.Basket.Api.Dto;
using NetMicroservice.Shared;
using NetMicroservice.Shared.Services;

namespace NetMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem;

public class DeleteBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService)
    : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
    {
        Guid userId = identityService.GetUserId;
        var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

        var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);

        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);
        }

        var currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

        var basketItemToDelete = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);

        if (basketItemToDelete is null)
        {
            return ServiceResult.Error("Basket item not found", HttpStatusCode.NotFound);
        }

        currentBasket.BasketItems.Remove(basketItemToDelete);

        basketAsString = JsonSerializer.Serialize(currentBasket);
        await distributedCache.SetStringAsync(cacheKey, basketAsString, token: cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}