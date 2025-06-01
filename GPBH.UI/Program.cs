using GPBH.Business;
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
            // Khởi tạo DI container
            var services = new ServiceCollection();

            // Đăng ký các service
            services.ConfigureServices();

            // Đăng ký các form
            services.ConfigureForms();

            // Build ServiceProvider
            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Resolve MainForm từ DI container
            var login = ServiceProvider.GetRequiredService<Login>();
            Application.Run(login);
        }

        public static void ConfigureForms(this IServiceCollection services)
        {
            services.AddScoped<Login>();
        }
    }
}
