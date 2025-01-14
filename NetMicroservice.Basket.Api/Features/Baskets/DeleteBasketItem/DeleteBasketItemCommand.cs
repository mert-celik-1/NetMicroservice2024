using NetMicroservice.Shared;

namespace NetMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem;

public record DeleteBasketItemCommand(Guid CourseId) : IRequestByServiceResult;
