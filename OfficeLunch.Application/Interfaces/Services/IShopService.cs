using OfficeLunch.Application.Common.Wrappers;
using OfficeLunch.Application.DTOs.Shop.Request;
using OfficeLunch.Application.DTOs.Shop.Response;

namespace OfficeLunch.Application.Interfaces.Services
{
    public interface IShopService
    {
        Task<PagedResponse<ProductResponse>> GetMenuAsync(int pageNumber, int pageSize, string? keyword);
        Task<ApiResponse<bool>> SubmitOrderAsync(SubmitOrderRequest request);
        Task<ApiResponse<bool>> CancelOrderAsync(int orderId);
    }
}
