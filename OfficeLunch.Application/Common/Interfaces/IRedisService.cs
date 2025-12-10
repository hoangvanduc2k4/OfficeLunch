namespace OfficeLunch.Application.Common.Interfaces
{
    public interface IRedisService
    {
        // Atomically decrease a stock value in Redis (used to reduce inventory)
        Task<long> DecrementAsync(string key, int amount);

        // Atomically increase a stock value in Redis (used to rollback inventory)
        Task<long> IncrementAsync(string key, int amount);

        // Add an item to a queue using a Sorted Set (ZSET) — score is usually a timestamp
        Task AddToQueueAsync(string key, string value, double score);

        // Remove an item from the queue
        Task RemoveFromQueueAsync(string key, string value);

        // Save any object to Redis cache with an optional expiration time
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);

        // Get any object from Redis cache (returns null if not found)
        Task<T?> GetAsync<T>(string key);
    }

}
