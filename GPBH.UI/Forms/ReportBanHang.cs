using GPBH.UI.Report;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace GPBH.UI.Forms
{
    public partial class ReportBanHang : Form
    {
        public ReportBanHang(DataTable data, DateTime tuNgay, DateTime denNgay, string maNgoaiTe)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo instance của report
            var report = new BanHangTheoKhachHangReport(); // Tên class report bạn đã tạo

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
