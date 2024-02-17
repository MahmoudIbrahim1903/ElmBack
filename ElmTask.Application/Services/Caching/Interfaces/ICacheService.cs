namespace ElmTask.Application.Services.Caching.Interfaces
{
    public interface ICacheService
    {
        bool SaveItemsToCache<T>(string key, T Value);
        T GetItemsFromCache<T>(string key);
    }
}
