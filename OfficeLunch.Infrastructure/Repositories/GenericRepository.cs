using Microsoft.EntityFrameworkCore;
using OfficeLunch.Application.Common.Interfaces;
using OfficeLunch.Application.Common.Wrappers;
using OfficeLunch.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace OfficeLunch.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OfflineLunchDBContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(OfflineLunchDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Retrieves an entity by its primary key
        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Adds a new entity to the DbContext
        // The insert operation is executed when SaveChangesAsync is called
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Marks an entity as modified
        // EF Core will generate an UPDATE statement on SaveChangesAsync
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        // Marks an entity for deletion
        // Ensures the entity is attached to the DbContext before removing
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        // Retrieves a paginated list of entities with optional filtering,
        // sorting, and eager loading
        public async Task<PagedResponse<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            // 1. Performance optimization:
            // Disable change tracking for read-only queries to reduce memory usage
            query = query.AsNoTracking();

            // 2. Apply eager loading (JOINs) using expression-based includes
            // This approach is type-safe and avoids magic strings
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // 3. Apply filtering (WHERE clause)
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // 4. Retrieve total record count
            // Used to calculate pagination metadata
            var totalRecords = await query.CountAsync();

            // 5. Apply sorting (ORDER BY clause)
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // 6. Apply pagination (SKIP / TAKE)
            // Ensure page number is always greater than zero
            var validPage = pageNumber < 1 ? 1 : pageNumber;

            var data = await query
                .Skip((validPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return paginated result along with metadata
            return new PagedResponse<T>(data, validPage, pageSize, totalRecords);
        }
    }
}
