using OfficeLunch.Application.Common.Interfaces;
using OfficeLunch.Domain.Entities.Identity;

namespace OfficeLunch.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}
