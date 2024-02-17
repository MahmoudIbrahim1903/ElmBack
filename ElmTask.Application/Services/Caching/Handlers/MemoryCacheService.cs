using CacheManager.Core;
using ElmTask.Application.Services.Caching.Interfaces;

namespace ElmTask.Application.Services.Caching.Handlers
{
    public class MemoryCacheService : ICacheService
    {
        private readonly ICache<object> _cacheRepository;

        public MemoryCacheService(ICache<object> cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public T GetItemsFromCache<T>(string key)
        {
            return _cacheRepository.Get<T>(key);
        }

        public bool SaveItemsToCache<T>(string key, T value)
        {
            if (_cacheRepository.Exists(key))
            {
                _cacheRepository.Put(key, value);
                return true;
            }
            else
            {
                return _cacheRepository.Add(key, value);
            }
        }
    }
}
