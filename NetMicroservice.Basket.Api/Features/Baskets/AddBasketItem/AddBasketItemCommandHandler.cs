using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using NetMicroservice.Basket.Api.Const;
using NetMicroservice.Basket.Api.Dto;
using NetMicroservice.Shared;
using NetMicroservice.Shared.Services;

namespace NetMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

public class AddBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService)
    : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        //Fast fail


        // TODO : change userId
        Guid userId = identityService.GetUserId;
        var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

        var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);


        BasketDto? currentBasket;

        var newBasketItem = new BasketItemDto(request.CourseId, request.CourseName, request.ImageUrl,
            request.CoursePrice, null);


        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new BasketDto(userId, [newBasketItem]);
            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }

        currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);


        var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);


        if (existingBasketItem is not null)
        {
            currentBasket.BasketItems.Remove(existingBasketItem);
        }

        currentBasket.BasketItems.Add(newBasketItem);

        await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(BasketDto basket, string cacheKey, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);
        await distributedCache.SetStringAsync(cacheKey, basketAsString, token: cancellationToken);
    }
}