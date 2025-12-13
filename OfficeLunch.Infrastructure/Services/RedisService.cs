using OfficeLunch.Application.Common.Interfaces;

namespace OfficeLunch.Infrastructure.Services
{
    public class RedisService : IRedisService
    {
        public Task AddToQueueAsync(string key, string value, double score)
        {
            throw new NotImplementedException();
        }

        public Task<long> DecrementAsync(string key, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<long> IncrementAsync(string key, int amount)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromQueueAsync(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            throw new NotImplementedException();
        }
    }
}
