using DevComponents.DotNetBar;
using GPBH.UI.Report;
using System;
using System.Data;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class ReportBanHang : Office2007Form
    {
        public ReportBanHang(DataTable data, DateTime tuNgay, DateTime denNgay, string maNgoaiTe)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo instance của report
            var report = new BanHangTheoKhachHangReport(); 

            // Gán dữ liệu cho report
            report.SetDataSource(data);

            report.SetParameterValue("TuNgay", tuNgay.ToString("dd/MM/yyyy"));
            report.SetParameterValue("DenNgay", denNgay.ToString("dd/MM/yyyy"));
            report.SetParameterValue("MaNgoaite", maNgoaiTe.ToString());


            // Gán report cho viewer
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
