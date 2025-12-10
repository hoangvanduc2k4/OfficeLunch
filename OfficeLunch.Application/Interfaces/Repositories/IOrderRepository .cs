using OfficeLunch.Application.Common.Interfaces;
using OfficeLunch.Domain.Entities.Trade;

namespace OfficeLunch.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetByUserIdAsync(int userId);
    }
}
