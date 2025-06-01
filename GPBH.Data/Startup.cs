using GPBH.Data.Helper;
using GPBH.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace GPBH.Data
{
    public static class Startup
    {
        public static void ConfigureContexts(this IServiceCollection services)
        {
            // Bước này sẽ tự động kiểm tra & cập nhật database nếu có migration mới
            MigrationHelper.EnsureDbMigrated();

            services.AddScoped<AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
