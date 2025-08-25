using DevComponents.DotNetBar.Controls;
using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Extentions
{
    public static class DataGirdViewExtention
    {
        /// <summary>
        /// Liên kết dữ liệu với DataGridViewX.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public static void BindData<T>(this DataGridViewX grid, IList<T> data, bool insertFirstRow = false) where T : new()
        {
            // Kiểm tra xem T có property "Stt" không
            var sttProperty = typeof(T).GetProperty("Stt");
            if (sttProperty != null && sttProperty.CanWrite)
            {
                int stt = 1;
                foreach (var item in data)
                {
                    sttProperty.SetValue(item, stt++);
                }
            }

            // Nếu cần chèn dòng đầu tiên để filter
            if (insertFirstRow)
            {
                data.Insert(0, new T());
            }
            grid.DataSource = new BindingList<T>(data);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grid.Columns[0].Visible = false; // Luôn ân cột đầu tiên (Stt) nếu có
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.HeaderText == "Stt")
                {
                    grid.Columns["Stt"].Visible = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Lấy dữ liệu từ DataGridViewX và chuyển đổi thành danh sách.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static List<T> GetData<T>(this DataGridViewX grid) where T : class, new()
        {
            var data = grid.DataSource as BindingList<T>;
            return data.ToList();
        }

        /// <summary>
        /// Căn chỉnh tiêu đề cột của DataGridViewX.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="alignment"></param>
        public static void SetHeaderAlignment(this DataGridViewX grid, string columnName, DataGridViewContentAlignment alignment)
        {
            if (grid.Columns.Contains(columnName))
                grid.Columns[columnName].HeaderCell.Style.Alignment = alignment;
            else
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Đặt vị trí hiển thị của cột trong DataGridViewX.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="index"></param>
        public static void SetDisplayIndex(this DataGridViewX grid, string columnName, int index)
        {
            if (grid.Columns.Contains(columnName))
                grid.Columns[columnName].DisplayIndex = index;
        }

        /// <summary>
        /// Căn chỉnh nội dung ô của DataGridViewX.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="alignment"></param>
        public static void SetCellAlignment(this DataGridViewX grid, string columnName, DataGridViewContentAlignment alignment)
        {
            if (grid.Columns.Contains(columnName))
                grid.Columns[columnName].DefaultCellStyle.Alignment = alignment;
        }

        /// <summary>
        ///  Đặt định dạng cho cột trong DataGridViewX.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="columnName"></param>
        /// <param name="format"></param>
        public static void SetFormat(this DataGridViewX grid, string columnName, string format)
        {
            if (grid.Columns.Contains(columnName) && !string.IsNullOrEmpty(format))
            {
                grid.Columns[columnName].DefaultCellStyle.Format = format;

                if (grid.Columns.Contains(columnName) && grid.Columns[columnName] is DataGridViewDoubleInputColumn col && !string.IsNullOrEmpty(format))
                {
                    col.DisplayFormat = format;
                }
            }
        }

        /*======================================================================
        ' Display Number of record on data grid
        '======================================================================*/
        public static void SetRowPositionPaint(this DataGridViewX grid, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat drawFormat = new StringFormat();
            // Point drawPoint = new Point(e.RowBounds.Location.X + 25, e.RowBounds.Location.Y + 4);
            Point drawPoint = new Point(e.RowBounds.Location.X + grid.RowHeadersWidth - 2, e.RowBounds.Location.Y + 4);
            int RowNo = e.RowIndex + 1;

            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (SolidBrush b = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(RowNo.ToString().PadLeft(3, ' '), grid.DefaultCellStyle.Font, b, drawPoint, drawFormat);
            }
        }

        public static void SetRowFormat(this DataGridViewRow row, List<string> columnNames, string format = "N0")
        {
            if (!row.IsNewRow)
            {
                foreach (var col in columnNames)
                {
                    row.Cells[col].Style.Format = format;
                }
            }
        }

        /// <summary>
        /// Đặt tất cả các ô của DataGridViewX thành chỉ đọc, ngoại trừ dòng đầu tiên (dòng filter).
        /// </summary>
        /// <param name="grid"></param>
        public static void SetGirdReadOnly(this DataGridViewX grid)
        {
            if (grid.Rows.Count == 0)
                return;

            // Cho phép edit tất cả cell của dòng đầu tiên (filter row)
            for (int j = 0; j < grid.Columns.Count; j++)
                grid.Rows[0].Cells[j].ReadOnly = false;
            grid.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

            // Các dòng còn lại: tất cả cell đều ReadOnly
            for (int i = 1; i < grid.Rows.Count; i++)
                for (int j = 0; j < grid.Columns.Count; j++)
                    grid.Rows[i].Cells[j].ReadOnly = true;

            // Nếu có cột Stt thì riêng cell Stt của dòng filter là chỉ đọc
            if (grid.Columns.Contains("Stt"))
            {
                var sttColumnIndex = grid.Columns["Stt"].Index;
                grid.Rows[0].Cells[sttColumnIndex].ReadOnly = true;
            }
        }

        public static void ApplyColumnConfig(this DataGridViewX grid, List<GirdSysDinhDangFormDto> configs)
        {
            if (configs == null || grid == null)
                return;

            var orderedConfigs = configs.OrderBy(x => x.Field_order).ToList();

            foreach (var config in orderedConfigs)
            {
                DataGridViewColumn col = grid.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.Name == config.Field_name);

                // Nếu chưa có cột, tạo mới
                if (col == null)
                {
                    // Xác định kiểu cột dựa vào Field_type, mặc định là DataGridViewTextBoxColumn
                    col = CreateColumn(config);
                    grid.Columns.Add(col);
                }

                col.Visible = !config.Field_hide;
                col.HeaderText = config.Field_title ?? config.Field_name;
                col.Width = config.Field_width > 0 ? config.Field_width : col.Width;
                col.DisplayIndex = config.Field_order;
                col.Name = config.Field_name;
                col.DataPropertyName = config.Field_name;

                // Field_width
                if (config.Field_width > 0) col.Width = config.Field_width;

                // Format
                if (!string.IsNullOrEmpty(config.Field_format))
                {
                    col.DefaultCellStyle.Format = config.Field_format;
                }
            }

            grid.Refresh();
        }

        /// <summary>
        /// Áp dụng sắp xếp dữ liệu theo cấu hình định dạng cột.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="fields"></param>
        public static List<T> ApplySortSystemDinhDang<T>(this List<T> data, List<GirdSysDinhDangFormDto> fields) where T : class
        {
            // Multi-sort
            if (fields != null && fields.Count > 0)
            {
                IOrderedEnumerable<T> ordered = null;
                for (int i = 0; i < fields.Count; i++)
                {
                    var sort = fields[i];
                    var prop = typeof(T).GetProperty(sort.Field_name);
                    if (prop == null) continue;

                    if (i == 0)
                    {
                        ordered = sort.Default_sort == Sort.Ascending
                            ? data.OrderBy(x => prop.GetValue(x, null))
                            : data.OrderByDescending(x => prop.GetValue(x, null));
                    }
                    else
                    {
                        ordered = sort.Default_sort == Sort.Ascending
                            ? ordered.ThenBy(x => prop.GetValue(x, null))
                            : ordered.ThenByDescending(x => prop.GetValue(x, null));
                    }
                }
                if (ordered != null)
                    data = ordered.ToList();
            }

            return data;
        }

        // Hàm tạo cột mới dựa vào Field_type
        private static DataGridViewColumn CreateColumn(GirdSysDinhDangFormDto config)
        {
            DataGridViewColumn col;
            switch ((config.Field_type ?? "").ToLower())
            {
                case "combobox":
                    col = new DataGridViewDoubleInputColumn();
                    break;
                case "decimal":
                    col = new DataGridViewDoubleInputColumn();
                    break;
                case "bool":
                case "boolean":
                    col = new DataGridViewCheckBoxXColumn();
                    break;
                default:
                    col = new DataGridViewTextBoxColumn();
                    break;
            }
            col.Name = config.Field_name;
            col.DataPropertyName = config.Field_name;
            // Field_width
            if (config.Field_width > 0) col.Width = config.Field_width;
            return col;
        }
    }
}