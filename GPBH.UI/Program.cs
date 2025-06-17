using GPBH.Business;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
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
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            string settingPath = Path.Combine(exeFolder, "setting.json");

            // Kiểm tra file setting, nếu không có thì yêu cầu nhập lại (hoặc mở form nhập lại)
            if (!File.Exists(settingPath))
            {
                MessageBox.Show("Chưa cấu hình phần mềm. Vui lòng chạy lại cài đặt hoặc nhập cấu hình!");
                // Có thể mở form nhập lại cấu hình
                Application.Exit();
            }
            else
            {
                var setting = JsonConvert.DeserializeObject<Setting>(File.ReadAllText("setting.json"));
                // check isEmty
                if (setting == null || string.IsNullOrEmpty(setting.MaCH) || string.IsNullOrEmpty(setting.MaQuay) || string.IsNullOrEmpty(setting.MaKho))
                {
                    MessageBox.Show("Chưa cấu hình phần mềm. Vui lòng chạy lại cài đặt hoặc nhập cấu hình!");
                    // Có thể mở form nhập lại cấu hình
                    Application.Exit();
                    return;
                }
            }

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
            var login = ServiceProvider.GetRequiredService<Login>();
            Application.Run(login);
        }

        private static void GetVauleConfig()
        {
            string connStr = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
            var  connectionInfo = AppConfigHelper.ParseSqlConnectionString(connStr);
            var setting = JsonConvert.DeserializeObject<Setting>(File.ReadAllText("setting.json"));
            AppGlobals.MaCH = setting.MaCH;
            AppGlobals.MaQuay = setting.MaQuay;
            AppGlobals.MaKho = setting.MaKho;
            AppGlobals.Host = connectionInfo.Host;
            AppGlobals.Port = connectionInfo.Port;
            AppGlobals.Database = connectionInfo.Database;
            AppGlobals.MaCa = "1";
        }

        public static void ConfigureForms(this IServiceCollection services)
        {
            services.AddScoped<Demo>();
            services.AddScoped<Login>();
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
