using OfficeLunch.Application.Common.Wrappers;
using OfficeLunch.Application.DTOs.Shop.Request;
using OfficeLunch.Application.DTOs.Shop.Response;
using OfficeLunch.Application.Interfaces.Services;

namespace OfficeLunch.Application.Services
{
    public class ShopService : IShopService
    {
        public Task<ApiResponse<bool>> CancelOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<ProductResponse>> GetMenuAsync(int pageNumber, int pageSize, string? keyword)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<bool>> SubmitOrderAsync(SubmitOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
