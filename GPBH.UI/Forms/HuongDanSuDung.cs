using DevComponents.DotNetBar;
using System.Windows.Forms;
using System;

namespace GPBH.UI.Forms
{
    public partial class HuongDanSuDung : Office2007Form
    {
        public HuongDanSuDung()
        {
            InitializeComponent();

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "hdsd.pdf");
            if (System.IO.File.Exists(path))
            { 
                webView21.Source = new Uri($"file:///{path.Replace("\\", "/")}");
            }
            else
            {
                MessageBox.Show("File hướng dẫn sử dụng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
