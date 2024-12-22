using StackExchange.Redis;
using TabooGameApi.Entities;
using TabooGameApi.Enums;
using TabooGameApi.Exceptions.Commons;
using TabooGameApi.Services.Interfaces;

namespace TabooGameApi.Services.Implements;

public class RedisService : IRedisService
{
    private readonly IDatabase _db;
    public RedisService(IConnectionMultiplexer redis)
    {
        _db =  redis.GetDatabase();
    }

    public async Task<HashEntry[]> GetAllAsync(string hashKey)
    {
        var data = await _db.HashGetAllAsync(hashKey);
        return data;
    }

    public async Task SetAllAsync(string hashkey, Game entity)
    {
        HashEntry[] hashEntry =
            {
                new HashEntry(GameFields.Fail.ToString(), entity.FailCount),
                new HashEntry(GameFields.Skip.ToString(), entity.SkipCount),
                new HashEntry(GameFields.Success.ToString(), entity.SuccessAnswer),
                new HashEntry(GameFields.Wrong.ToString(), entity.WrongAnswer),
                new HashEntry(GameFields.Score.ToString(), entity.Score)
            };

        await _db.HashSetAsync(hashkey, hashEntry);
        await _db.KeyExpireAsync(hashkey, TimeSpan.FromSeconds(entity.TimeSecond));
    }

    public async Task<int> GetValueAsync(string hashkey, GameFields field)
    {
        var val = await _db.HashGetAsync(hashkey, field.ToString());
        if (!val.HasValue) throw new Exception($"Value not found with fieldname {field.ToString()}");

        if (int.TryParse(val, out int num)) return num;
        else throw new Exception($"Value for field {field.ToString()} is not a valid integer.");
    }

    public async Task SetValueAsync(string hashKey, GameFields field, int value)
    {
        string fieldName = field.ToString();
        await _db.HashSetAsync(hashKey, fieldName, value);
    }
}
