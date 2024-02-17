using ElmTask.Application.Common.Interfaces;
using ElmTask.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElmTask.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElmDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                        b => b.MigrationsAssembly(typeof(ElmDbContext).Assembly.FullName));
            });
            services.AddScoped<IElmDbContext>(provider => provider.GetService<ElmDbContext>());
        }
    }
}
