using System;
using System.IO;
using System.Windows.Forms;

namespace GPBH.UI.Helper
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Bắt và xử lý exception, log ra file và hiện thông báo cho user.
        /// </summary>
        /// <param name="ex">Exception bị bắt</param>
        /// <param name="showMessageBox">Có hiện MessageBox không</param>
        /// <param name="logFilePath">Đường dẫn file log. Nếu null sẽ log ra "error.log" cùng thư mục exe.</param>
        public static void HandleException(Exception ex, bool showMessageBox = true, string logFilePath = null)
        {
            try
            {
                string logPath = logFilePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
                string errorMsg = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex}\r\n";
                File.AppendAllText(logPath, errorMsg);

                if (showMessageBox)
                {
                    MessageBox.Show(
                        "Có lỗi xảy ra:\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception)
            {
                // Nếu lỗi trong quá trình log, không làm gì thêm để tránh crash
            }
        }
    }
}
