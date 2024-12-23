using TabooGameApi.ExternalServices.Abstracts;

namespace TabooGameApi.ExternalServices.Concretes;

public class LocalCacheService : ICacheService
{
    public Task<T?> Get<T>(string key)
    {
        throw new NotImplementedException();
    }

    public Task Set<T>(string key, T data, int seconds = 300)
    {
        throw new NotImplementedException();
    }
}
