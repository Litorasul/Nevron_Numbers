using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Nevron_Numbers.Data
{
    public class DistributedCasheStorage
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCasheStorage(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        /// <summary>
        /// Adds a List of Integers in the Distributed memory cashe
        /// </summary>
        public async Task SetAsync<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, serializedValue);
        }
        /// <summary>
        /// Gets a value from the Distributed memory cashe
        /// </summary>
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);

            if (value == null)
            {
                if (typeof(T) == typeof(List<int>))
                {
                    return (T)(object)new List<int>();
                }
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(value);
        }
        /// <summary>
        /// Removes a value from the Distributed memory cashe
        /// </summary>
        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }
    }
}
