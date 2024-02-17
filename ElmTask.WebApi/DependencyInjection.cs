using ElmTask.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ElmTask.WebApi
{
    public static class DependencyInjection
    {
        public static void MigrateDatabase(this IServiceProvider services)
        {
            services.CreateScope().ServiceProvider.GetRequiredService<ElmDbContext>().Database.Migrate();
        }
        public static void SerializeNamingPolicy(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        }
    }
}
