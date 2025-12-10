using AutoMapper;
using OfficeLunch.Application.DTOs.Shop.Request;
using OfficeLunch.Application.DTOs.Shop.Response;
using OfficeLunch.Domain.Entities.Master;
using OfficeLunch.Domain.Entities.Trade;

namespace OfficeLunch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<SubmitOrderRequest, Order>();
        }
    }
}
