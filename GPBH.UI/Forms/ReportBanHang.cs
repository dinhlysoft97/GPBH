using DevComponents.DotNetBar;
using GPBH.Business.Dtos;
using GPBH.UI.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class ReportBanHang : Office2007Form
    {
        private List<GirdSysDinhDangFormDto> SysDinhDangs = new List<GirdSysDinhDangFormDto>();
        public ReportBanHang(DataTable data, DateTime tuNgay, DateTime denNgay, string maNgoaiTe, List<GirdSysDinhDangFormDto> sysDinhDangs)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (sysDinhDangs != null)
                SysDinhDangs = sysDinhDangs;

            var formatTien = GetFormat("Format_tien");
            var formatTienNt = GetFormat("Format_tien_nt");
            var formatSoLuong = GetFormat("Format_so_luong");

            // Tạo instance của report
            var report = new BanHangTheoKhachHangReport();

            // Gán dữ liệu cho report
            report.SetDataSource(data);

            report.SetParameterValue("TuNgay", tuNgay.ToString("dd/MM/yyyy"));
            report.SetParameterValue("DenNgay", denNgay.ToString("dd/MM/yyyy"));
            report.SetParameterValue("MaNgoaite", maNgoaiTe.ToString());
            report.SetParameterValue("FormatTien", formatTien);
            report.SetParameterValue("FormatTienNt", formatTienNt);
            report.SetParameterValue("FormatSoLuong", formatSoLuong);

            // Gán report cho viewer
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }

        private string GetFormat(string column)
        {
            if (SysDinhDangs == null)
                return string.Empty;
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }
    }
}
