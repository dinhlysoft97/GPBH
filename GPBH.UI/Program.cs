using GPBH.Business;
using GPBH.Data;
using GPBH.Data.Helper;
using GPBH.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace GPBH.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Bước này sẽ tự động kiểm tra & cập nhật database nếu có migration mới
            MigrationHelper.EnsureDbMigrated();

            // Khởi tạo DI container
            var services = new ServiceCollection();

            // Đăng ký các service
            ConfigureServices(services);

            // Đăng ký các form
            ConfigureForms(services);

            // Build ServiceProvider
            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Resolve MainForm từ DI container
            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // ... các DI khác
            services.AddScoped<ProductService>();
        }

        public static void ConfigureForms(IServiceCollection services)
        {
            services.AddScoped<MainForm>();
        }
    }
}
