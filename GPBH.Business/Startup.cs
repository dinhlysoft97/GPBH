using GPBH.Business.Services;
using GPBH.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GPBH.Business
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureContexts();

            // ... các DI khác
            services.AddScoped<SysDMNSDService>();
            services.AddScoped<SysMenuService>();
        }
    }
}
