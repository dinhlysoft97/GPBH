using GPBH.Business;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Threading;
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

            // Lấy giá trị dạng config
            GetVauleConfig();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Đăng ký bắt lỗi cho thread UI
            Application.ThreadException += Application_ThreadException;

            // Nếu muốn bắt luôn cả lỗi không bắt được ở thread khác:
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Resolve MainForm từ DI container
            var login = ServiceProvider.GetRequiredService<Demo>();
            Application.Run(login);
        }

        private static void GetVauleConfig()
        {
            string maCH = ConfigurationManager.AppSettings["MaCH"];
            string maQuay = ConfigurationManager.AppSettings["MaQuay"];
            string maKho = ConfigurationManager.AppSettings["MaKho"];

            AppGlobals.MaCH = maCH;
            AppGlobals.MaQuay = maQuay;
            AppGlobals.MaKho = maKho;
        }

        public static void ConfigureForms(this IServiceCollection services)
        {
            services.AddScoped<Demo>();
            services.AddScoped<Login>();
            services.AddScoped<MainForm>();
            services.AddScoped<MainForm>();
        }

        // Bắt lỗi trên thread UI (WinForms)
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionHelper.HandleException(e.Exception);
        }

        // Bắt lỗi trên các thread khác (không phải UI)
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception ?? new Exception("Unknown error");
            ExceptionHelper.HandleException(ex);
        }
    }
}
