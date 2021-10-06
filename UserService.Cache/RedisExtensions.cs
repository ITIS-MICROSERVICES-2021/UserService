using Microsoft.Extensions.DependencyInjection;

namespace UserService.Cache
{
    public static class RedisExtensions
    {
        public static void AddRedis(this IServiceCollection serviceCollection, string connectionString, int database = 0)
        {
            serviceCollection.AddScoped<ICacheService, RedisService>(_ => new RedisService(connectionString, database));
        }
    }
}