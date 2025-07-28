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

            DataTable dtDisplay = data.Clone();
            dtDisplay.Columns["So_luong"].DataType = typeof(string);
            dtDisplay.Columns["Thanh_tien_vn"].DataType = typeof(string);
            dtDisplay.Columns["Thanh_tien"].DataType = typeof(string);

            foreach (DataRow row in data.Rows)
            {
                var newRow = dtDisplay.NewRow();
                foreach (DataColumn col in data.Columns)
                {
                    if (col.ColumnName == "So_luong" && row["So_luong"] != DBNull.Value)
                    {
                        decimal value;
                        if (decimal.TryParse(row["So_luong"].ToString(), out value))
                            newRow["So_luong"] = value.ToString(formatSoLuong);
                        else
                            newRow["So_luong"] = row["So_luong"];
                    }
                    else if (col.ColumnName == "Thanh_tien_vn" && row["Thanh_tien_vn"] != DBNull.Value)
                    {
                        decimal value;
                        if (decimal.TryParse(row["Thanh_tien_vn"].ToString(), out value))
                            newRow["Thanh_tien_vn"] = value.ToString(formatTien);
                        else
                            newRow["Thanh_tien_vn"] = row["Thanh_tien_vn"];
                    }
                    else if (col.ColumnName == "Thanh_tien" && row["Thanh_tien"] != DBNull.Value)
                    {
                        decimal value;
                        if (decimal.TryParse(row["Thanh_tien"].ToString(), out value))
                            newRow["Thanh_tien"] = value.ToString(formatTienNt);
                        else
                            newRow["Thanh_tien"] = row["Thanh_tien"];
                    }
                    else
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }
                }
                dtDisplay.Rows.Add(newRow);
            }

            // Tạo instance của report
            var report = new BanHangTheoKhachHangReport();

            // Gán dữ liệu cho report
            report.SetDataSource(dtDisplay);

            report.SetParameterValue("TuNgay", tuNgay.ToString("dd/MM/yyyy"));
            report.SetParameterValue("DenNgay", denNgay.ToString("dd/MM/yyyy"));
            report.SetParameterValue("MaNgoaite", maNgoaiTe.ToString());

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
