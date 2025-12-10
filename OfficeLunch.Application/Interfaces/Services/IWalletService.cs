using OfficeLunch.Application.Common.Wrappers;
using OfficeLunch.Application.DTOs.Wallet;

namespace OfficeLunch.Application.Interfaces.Services
{
    public interface IWalletService
    {
        Task<ApiResponse<bool>> ProcessSePayWebhookAsync(DepositWebhookDto dto);
    }
}
