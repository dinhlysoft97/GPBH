using GPBH.Business.Dtos;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace GPBH.UI.Helper
{
    public static class ExportHelper
    {
        /// <summary>
        /// Xuất dữ liệu ra file Excel với định dạng động từ danh sách GirdSysDinhDangFormDto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fields"></param>
        /// <param name="sheetName"></param>
        /// <param name="fileName"></param>
        public static void ExportToExcel<T>(IEnumerable<T> data, List<GirdSysDinhDangFormDto> fields, string sheetName = "Report", string fileName = "report.xlsx")
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Chọn nơi lưu file Excel";
                dialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                dialog.FileName = fileName;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu file tại dialog.FileName

                    using (var package = new ExcelPackage())
                    {
                        var ws = package.Workbook.Worksheets.Add(sheetName);

                        // Header
                        for (int i = 0; i < fields.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = fields[i].Field_title;
                            ws.Column(i + 1).Width = fields[i].Field_width;

                            if (!string.IsNullOrEmpty(fields[i].Field_format))
                                ws.Column(i + 1).Style.Numberformat.Format = fields[i].Field_format;
                        }

                        // Data
                        int row = 2;
                        foreach (var item in data)
                        {
                            for (int col = 0; col < fields.Count; col++)
                            {
                                var prop = item.GetType().GetProperty(fields[col].Field_name);
                                ws.Cells[row, col + 1].Value = prop?.GetValue(item);
                            }
                            row++;
                        }

                        // AutoFit nếu muốn (bỏ comment dòng dưới)
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        var fileBytes = package.GetAsByteArray();

                        // Ghi file ra ổ cứng hoặc trả về response file cho client tùy nhu cầu
                        File.WriteAllBytes(dialog.FileName, fileBytes);
                        MessageBox.Show("Đã xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Xuất dữ liệu ra file Excel với định dạng động từ mảng fields.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fields"></param>
        /// <param name="sheetName"></param>
        /// <param name="fileName"></param>
        public static void ExportToExcel<T>(IEnumerable<T> data, dynamic[] fields, string sheetName = "Report", string fileName = "report.xlsx")
        {

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Chọn nơi lưu file Excel";
                dialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                dialog.FileName = fileName;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu file tại dialog.FileName

                    using (var package = new ExcelPackage())
                    {
                        var ws = package.Workbook.Worksheets.Add(sheetName);

                        // Header
                        for (int i = 0; i < fields.Length; i++)
                        {
                            ws.Cells[1, i + 1].Value = fields[i].Header;
                            ws.Column(i + 1).Width = fields[i].Width;

                            if (!string.IsNullOrEmpty(fields[i].Format))
                                ws.Column(i + 1).Style.Numberformat.Format = fields[i].Format;
                        }

                        // Data
                        int row = 2;
                        foreach (var item in data)
                        {
                            for (int col = 0; col < fields.Length; col++)
                            {
                                var prop = item.GetType().GetProperty(fields[col].Property);
                                ws.Cells[row, col + 1].Value = prop?.GetValue(item);
                            }
                            row++;
                        }

                        // AutoFit nếu muốn (bỏ comment dòng dưới)
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        var fileBytes = package.GetAsByteArray();

                        // Ghi file ra ổ cứng hoặc trả về response file cho client tùy nhu cầu
                        File.WriteAllBytes(dialog.FileName, fileBytes);
                        MessageBox.Show("Đã xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
