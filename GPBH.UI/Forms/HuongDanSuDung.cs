using DevComponents.DotNetBar;
using System;
using System.Windows.Forms;

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
                var pdfViewer = new PdfiumViewer.PdfViewer();
                pdfViewer.Document = PdfiumViewer.PdfDocument.Load(path);
                this.Controls.Add(pdfViewer);
                pdfViewer.Dock = DockStyle.Fill;
            }
            else
            {
                MessageBox.Show("File hướng dẫn sử dụng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
