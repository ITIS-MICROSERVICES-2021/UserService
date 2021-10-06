using System.Threading.Tasks;

namespace UserService.Cache
{
    public interface ICacheService
    {
        Task<bool> AddAsync<T>(string key, T value);
        Task<T> GetAsync<T>(string key);
    }
}