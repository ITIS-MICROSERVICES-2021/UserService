using System.Threading.Tasks;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.MsgPack;

namespace UserService.Cache
{
    public class RedisService : ICacheService
    {
        private readonly IRedisDatabase _db;

        public RedisService(string connectionString, int database)
        {
            var redisConfig = new RedisConfiguration
            {
                ConnectionString = connectionString,
                Database = database
            };
            var poolManager = new RedisCacheConnectionPoolManager(redisConfig);
            var client = new RedisCacheClient(poolManager, new MsgPackObjectSerializer(), redisConfig);
            var db = client.GetDbFromConfiguration();
            _db = db;
        }
        
        public Task<bool> AddAsync<T>(string key, T value)
        {
            return _db.AddAsync(key, value);
        }

        public Task<T> GetAsync<T>(string key)
        {
            return _db.GetAsync<T>(key);
        }
    }
}