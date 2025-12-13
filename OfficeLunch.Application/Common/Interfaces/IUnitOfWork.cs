namespace OfficeLunch.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Returns the generic repository instance for the specified entity type
        // Ensures all repositories share the same DbContext instance
        IGenericRepository<T> Repository<T>() where T : class;

        // Commits all changes made through repositories to the database
        // Executes a single transaction via the underlying DbContext
        Task<int> SaveChangesAsync();
    }
}
