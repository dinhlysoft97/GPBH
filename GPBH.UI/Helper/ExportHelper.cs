using DevComponents.DotNetBar.Controls;
using GPBH.Business.Dtos;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
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
        public static void ExportToExcel<T>(IEnumerable<T> data, List<GirdSysDinhDangFormDto> fields, string sheetName = "Report", string fileName = "report.xlsx", bool isIgnoreRowFirst = false)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Chọn nơi lưu file Excel";
                dialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                dialog.FileName = fileName;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu file tại dialog.FileName
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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
                        int index = 0;
                        foreach (var item in data)
                        {
                            index++;
                            // isIgnoreRowFirst = true thì bỏ dòng đầu tiên
                            if (isIgnoreRowFirst && index == 1) continue;
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
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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
        /// <summary>
        /// Xuất dữ liệu ra file Excel với định dạng động từ mảng fields.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fields"></param>
        /// <param name="sheetName"></param>
        /// <param name="fileName"></param>
        public static void ExportGridToExcel(DataGridViewX dataGridViewX, string sheetName = "Report", string fileName = "report.xlsx")
        {

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Chọn nơi lưu file Excel";
                dialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                dialog.FileName = fileName;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage())
                    {
                        var ws = package.Workbook.Worksheets.Add(sheetName);

                        // Header
                        for (int i = 0; i < dataGridViewX.ColumnCount; i++)
                        {
                            if (dataGridViewX.Columns[i].Visible)
                            {
                                ws.Cells[1, i + 1].Value = dataGridViewX.Columns[i].HeaderText;

                                if (!string.IsNullOrEmpty(dataGridViewX.Columns[i].DefaultCellStyle.Format))
                                    ws.Column(i + 1).Style.Numberformat.Format = dataGridViewX.Columns[i].DefaultCellStyle.Format;
                            }
                        }

                        // Data
                        int row = 2;
                        foreach (DataGridViewRow item in dataGridViewX.Rows)
                        {
                            if (item.Cells[1].Value != null)
                            {
                                for (int col = 0; col < dataGridViewX.Columns.Count; col++)
                                {
                                    if (!dataGridViewX.Columns[col].Visible) continue;
                                    ws.Cells[row, col + 1].Value = item.Cells[col].Value;
                                }
                                row++;
                            }
                        }

                        // AutoFit nếu muốn (bỏ comment dòng dưới)
                        if (ws.Dimension != null) // tránh NullReference khi sheet còn trống
                        {
                            var end = ws.Dimension.End;
                            ws.Cells[1, 1, end.Row, end.Column].AutoFitColumns(); // ổn định hơn so với dùng Address
                        }
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
