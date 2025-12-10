using OfficeLunch.Application.Common.Wrappers;
using System.Linq.Expressions;

namespace OfficeLunch.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Find an entity by its primary key
        Task<T?> GetByIdAsync(object id);

        // Get all entities of this type
        Task<List<T>> GetAllAsync();

        // Insert a new entity into the database
        Task AddAsync(T entity);

        // Update an existing entity
        Task UpdateAsync(T entity);

        // Delete an existing entity
        Task DeleteAsync(T entity);

        // Get entities with pagination, filtering, sorting, and optional includes
        Task<PagedResponse<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,                 // Optional WHERE condition
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, // Optional ORDER BY
            string includeProperties = ""                              // Comma-separated list of navigation properties
        );
    }
}
