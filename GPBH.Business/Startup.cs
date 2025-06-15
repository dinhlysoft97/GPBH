using GPBH.Business.Services;
using GPBH.Data;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace GPBH.Business
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(Startup).Assembly);

            services.ConfigureContexts();

            // ... các DI khác
            services.AddScoped<SysDMNSDService>();
            services.AddScoped<SysMenuService>();
            services.AddScoped<DMKHService>();
            services.AddScoped<DMQGService>();
            services.AddScoped<SysDMCuaHangService>();
            services.AddScoped<DMNTService>();
            services.AddScoped<DMHHService>();
            services.AddScoped<DMTGService>();
            services.AddScoped<SoPhieuGeneratorService>();
            services.AddScoped<DonHangService>();
            services.AddScoped<SysDinh_dang_formService>();
            services.AddScoped<DMcaService>();
        }
    }
}
