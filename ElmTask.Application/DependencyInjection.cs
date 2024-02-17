using ElmTask.Application.Services.Books.Handlers;
using ElmTask.Application.Services.Books.Interfaces;
using ElmTask.Application.Services.Caching.Interfaces;
using ElmTask.Application.Services.Caching.Handlers;
using Microsoft.Extensions.DependencyInjection;
using CacheManager.Core;

namespace ElmTask.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICacheManagerConfiguration),
                      new ConfigurationBuilder()
                     .WithJsonSerializer()
                     .WithMicrosoftMemoryCacheHandle()
                     .Build());

            services.AddSingleton(typeof(ICache<>), typeof(BaseCacheManager<>));
            services.AddScoped(typeof(ICacheService), typeof(MemoryCacheService));


            //services.AddScoped<ICacheService, MemoryCacheService>();
            services.AddScoped<IBookService, BookService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
