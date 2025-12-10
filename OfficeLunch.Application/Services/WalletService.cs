using OfficeLunch.Application.Common.Wrappers;
using OfficeLunch.Application.DTOs.Wallet;
using OfficeLunch.Application.Interfaces.Services;

namespace OfficeLunch.Application.Services
{
    public class WalletService : IWalletService
    {
        public Task<ApiResponse<bool>> ProcessSePayWebhookAsync(DepositWebhookDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
