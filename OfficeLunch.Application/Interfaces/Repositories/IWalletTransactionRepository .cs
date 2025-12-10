using OfficeLunch.Application.Common.Interfaces;
using OfficeLunch.Domain.Entities.Finance;

namespace OfficeLunch.Application.Interfaces.Repositories
{
    public interface IWalletTransactionRepository : IGenericRepository<WalletTransaction>
    {
        Task<bool> ExistsByReferenceCodeAsync(string refCode);
    }
}
