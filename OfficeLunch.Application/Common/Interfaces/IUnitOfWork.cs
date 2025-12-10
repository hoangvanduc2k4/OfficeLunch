namespace OfficeLunch.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Save all pending changes to the database
        Task<int> SaveChangesAsync();

        // Begin a new database transaction
        Task BeginTransactionAsync();

        // Commit the current transaction (make all changes permanent)
        Task CommitTransactionAsync();

        // Roll back the current transaction (undo all changes)
        Task RollbackTransactionAsync();
    }
}
