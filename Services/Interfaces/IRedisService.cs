using StackExchange.Redis;
using TabooGameApi.Entities;
using TabooGameApi.Enums;

namespace TabooGameApi.Services.Interfaces;

public interface IRedisService
{
    Task<HashEntry[]> GetAllAsync(string hashKey);
    Task SetAllAsync(string hashKey, Game entity);
    Task<int> GetValueAsync(string hashkey, GameFields field);
    Task SetValueAsync(string hashKey, GameFields field, int value);
}
