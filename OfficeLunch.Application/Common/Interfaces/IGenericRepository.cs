using OfficeLunch.Application.Common.Wrappers;
using System.Linq.Expressions;

namespace OfficeLunch.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // 1. Retrieve an entity by its primary key
        Task<T?> GetByIdAsync(object id);

        // 2. Add a new entity to the data store
        Task AddAsync(T entity);

        // 3. Update an existing entity (marks entity as modified)
        void Update(T entity);

        // 4. Delete an entity (marks entity as deleted)
        void Delete(T entity);

        // 5. Generic method for retrieving a paged list
        //    Supports filtering, sorting, pagination, and eager loading
        Task<PagedResponse<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            // Uses expression-based includes for type safety
            // to avoid magic strings and runtime errors
            params Expression<Func<T, object>>[] includes
        );
    }
}
