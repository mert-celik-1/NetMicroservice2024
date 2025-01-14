using AutoMapper;
using NetMicroservice.Basket.Api.Data;
using NetMicroservice.Basket.Api.Dto;

namespace NetMicroservice.Basket.Api;

public class BasketMapping : Profile
{
    public BasketMapping()
    {
        CreateMap<BasketDto, Data.Basket>().ReverseMap();
        CreateMap<BasketItemDto, BasketItem>().ReverseMap();
    }
}