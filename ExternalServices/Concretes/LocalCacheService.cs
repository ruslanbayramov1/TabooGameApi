using Microsoft.Extensions.Caching.Memory;
using TabooGameApi.ExternalServices.Abstracts;

namespace TabooGameApi.ExternalServices.Concretes;

public class LocalCacheService(IMemoryCache _cache) : ICacheService
{
    public async Task<T?> Get<T>(string key)
    {
        T? value = default(T);
        await Task.Run(() =>
        {
            _cache.TryGetValue<T>(key, out value);
        });
        return value;
    }

    public async Task Set<T>(string key, T data, int seconds = 300)
    {
        await Task.Run(() =>
        {
            _cache.Set<T>(key, data, DateTime.Now.AddSeconds(seconds));
        });
    }
}
