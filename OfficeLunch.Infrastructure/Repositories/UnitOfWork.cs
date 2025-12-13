using OfficeLunch.Application.Common.Interfaces;
using OfficeLunch.Infrastructure.Persistence;

namespace OfficeLunch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OfflineLunchDBContext _context;

        // Cache for created repository instances
        // Key   : Entity type name (e.g. "User", "Product")
        // Value : Corresponding repository instance
        private Dictionary<string, object> _repositories;

        public UnitOfWork(OfflineLunchDBContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            // Initialize the repository cache if it has not been created yet
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            // Use the entity type name as the cache key
            var type = typeof(T).Name;

            // Check whether a repository for this entity type already exists
            if (!_repositories.ContainsKey(type))
            {
                // Create a new generic repository instance
                var repositoryInstance = new GenericRepository<T>(_context);

                // Store it in the cache to reuse the same instance
                // and ensure a shared DbContext across repositories
                _repositories.Add(type, repositoryInstance);
            }

            // Return the cached repository instance
            return (IGenericRepository<T>)_repositories[type];
        }

        public async Task<int> SaveChangesAsync()
        {
            // Persists all tracked changes to the database
            // Executes a single transaction via the DbContext
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // Releases database connections and unmanaged resources
            _context.Dispose();
        }
    }
}
