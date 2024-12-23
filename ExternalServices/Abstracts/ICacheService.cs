namespace TabooGameApi.ExternalServices.Abstracts;

public interface ICacheService
{
    Task<T?> Get<T>(string key);
    Task Set<T>(string key, T data, int seconds = 300);
}
