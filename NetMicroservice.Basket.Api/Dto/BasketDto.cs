using System.Text.Json.Serialization;

namespace NetMicroservice.Basket.Api.Dto;

public record BasketDto
{
    [JsonIgnore] public Guid UserId { get; init; }

    public List<BasketItemDto> BasketItems { get; set; } = new();

    public BasketDto(Guid userId, List<BasketItemDto> items)
    {
        UserId = userId;
        BasketItems = items;
    }

    public BasketDto()
    {
    }
}