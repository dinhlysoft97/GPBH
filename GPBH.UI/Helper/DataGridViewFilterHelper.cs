using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System;
using DevComponents.DotNetBar.Controls;
using DevComponents.AdvTree;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;

namespace GPBH.UI.Helper
{
    public static class DataGridViewFilterHelper
    {
        public static void ApplyFilter<T>(DataGridViewX grid, IList<T> data) where T : new()
        {
            var helper = new InternalHelper<T>(grid, data);
            helper.Initialize();
        }

        sealed class InternalHelper<T> where T : new()
        {
            private readonly DataGridView grid;
            private readonly IList<T> sourceData;
            private bool isFiltering = false;
            private readonly List<string> propertyNames;
            private int lastSortColumn = -1;
            private ListSortDirection lastSortDirection = ListSortDirection.Ascending;
            private Dictionary<string, ColumnState> states = new Dictionary<string, ColumnState>();

            public InternalHelper(DataGridView grid, IList<T> data)
            {
                this.grid = grid;
                this.sourceData = data;
                this.propertyNames = typeof(T).GetProperties().Select(p => p.Name).ToList();
            }

            public void Initialize()
            {
                SaveColumnStates();
                var displayList = new List<T> { new T() }; // filter row
                foreach (var item in sourceData)
                    displayList.Add(item);

                grid.CellValueChanged += Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
                RestoreColumnStates();

                SaveColumnStates();
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnStates();
                SetGirdReadOnly();
                SetSortGlyph();
            }

            private void SetGirdReadOnly()
            {
                grid.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                grid.Rows[0].ReadOnly = false;
                for (int j = 0; j < grid.Columns.Count; j++)
                    grid.Rows[0].Cells[0].ReadOnly = false;

                for (int i = 1; i < grid.Rows.Count; i++)
                    for (int j = 0; j < grid.Columns.Count; j++)
                        grid.Rows[i].Cells[j].ReadOnly = true;

                // Đặt riêng cell Stt của dòng filter là chỉ đọc
                if (grid.Columns.Contains("Stt"))
                {
                    var sttColumnIndex = grid.Columns["Stt"].Index;
                    grid.Rows[0].Cells[sttColumnIndex].ReadOnly = true;
                }
            }

            private void Grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                if (grid.CurrentCell.RowIndex == 0 && grid.IsCurrentCellDirty)
                {
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }

            private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (!isFiltering && e.RowIndex == 0)
                {
                    ApplyFilterAndRestoreSort();
                }
            }

            private void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.ColumnIndex >= 0)
                {
                    // Toggle direction nếu click lại cùng cột
                    if (lastSortColumn == e.ColumnIndex)
                        lastSortDirection = lastSortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
                    else
                        lastSortDirection = ListSortDirection.Ascending;

                    lastSortColumn = e.ColumnIndex;

                    ApplyFilterAndRestoreSort();
                }
            }

            private void ApplyFilterAndRestoreSort()
            {
                isFiltering = true;

                var filterValues = new Dictionary<string, object>();
                for (int i = 0; i < propertyNames.Count; i++)
                {
                    var val = grid.Rows[0].Cells[i].Value;
                    filterValues[propertyNames[i]] = val ?? "";
                }

                List<T> filtered;
                T filterRow;
                HandleFilter(filterValues, out filtered, out filterRow);
                var displayList = new List<T> { filterRow };
                displayList.AddRange(filtered);

                grid.CellValueChanged -= Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged -= Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick;

                SaveColumnStates();
                grid.DataSource = null;
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnStates();
                grid.CellValueChanged += Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;

                SetSortGlyph();
                SetGirdReadOnly();
                isFiltering = false;
            }

            private void HandleFilter(Dictionary<string, object> filterValues, out List<T> filtered, out T filterRow)
            {
                filtered = sourceData.Where(item =>
                {
                    foreach (var prop in propertyNames)
                    {
                        if (prop == "Stt")
                            continue;

                        var propertyInfo = typeof(T).GetProperty(prop);
                        if (propertyInfo == null) continue;

                        var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                        // Loại bỏ property kiểu Image, Bitmap, byte[]
                        if (type == typeof(Image) || type == typeof(Bitmap) || type == typeof(byte[]) || type == typeof(bool))
                            continue;

                        var filterVal = filterValues[prop];
                        if (filterVal == null || string.IsNullOrWhiteSpace(filterVal.ToString()))
                            continue;

                        var itemVal = propertyInfo.GetValue(item);
                        if (itemVal == null)
                            return false;

                        // enum
                        if (type.IsEnum)
                        {
                            try
                            {
                                var filterEnum = Enum.Parse(type, filterVal.ToString(), true);
                                if (!itemVal.Equals(filterEnum))
                                    return false;
                            }
                            catch { continue; }
                        }
                        // DateTime, DateTime?
                        else if (type == typeof(DateTime))
                        {
                            if (!DateTime.TryParse(filterVal.ToString(), out var filterDate))
                                continue;
                            DateTime itemDate = (DateTime)itemVal;
                            if (itemDate.Date != filterDate.Date)
                                return false;
                        }
                        // bool, bool?
                        else if (type == typeof(bool))
                        {
                            if (!bool.TryParse(filterVal.ToString(), out var filterBool))
                                continue;
                            if ((bool)itemVal != filterBool)
                                return false;
                        }
                        // int, int?
                        else if (type == typeof(int))
                        {
                            if (!int.TryParse(filterVal.ToString(), out var filterInt))
                                continue;
                            if ((int)itemVal != filterInt)
                                return false;
                        }
                        // double, float, decimal...
                        else if (type == typeof(double))
                        {
                            if (!double.TryParse(filterVal.ToString(), out var filterDouble))
                                continue;
                            if (Math.Abs((double)itemVal - filterDouble) > 0.00001)
                                return false;
                        }
                        else if (type == typeof(float))
                        {
                            if (!float.TryParse(filterVal.ToString(), out var filterFloat))
                                continue;
                            if (Math.Abs((float)itemVal - filterFloat) > 0.00001f)
                                return false;
                        }
                        else if (type == typeof(decimal))
                        {
                            if (!decimal.TryParse(filterVal.ToString(), out var filterDecimal))
                                continue;
                            if ((decimal)itemVal != filterDecimal)
                                return false;
                        }
                        // Chuỗi: so sánh chứa, ignore case
                        else
                        {
                            if (!itemVal.ToString().ToLower().Contains(filterVal.ToString().ToLower()))
                                return false;
                        }
                    }
                    return true;
                }).ToList();

                // Sort lại nếu có thông tin sort
                if (lastSortColumn >= 0)
                {
                    string sortProp = propertyNames[lastSortColumn];
                    filtered = SortList(filtered, sortProp, lastSortDirection);
                }

                // Khởi tạo filter row, loại bỏ property kiểu Image, Bitmap, byte[]
                filterRow = new T();
                foreach (var prop in propertyNames)
                {
                    if (prop == "Stt")
                        continue;

                    var propertyInfo = typeof(T).GetProperty(prop);
                    if (propertyInfo == null) continue;

                    var value = filterValues[prop];
                    var propType = propertyInfo.PropertyType;
                    var targetType = Nullable.GetUnderlyingType(propType) ?? propType;

                    // Loại bỏ property kiểu Image, Bitmap, byte[]
                    if (targetType == typeof(Image) || targetType == typeof(Bitmap) || targetType == typeof(byte[]) || targetType == typeof(bool))
                        continue;

                    try
                    {

                        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                        {
                            value = Nullable.GetUnderlyingType(propType) != null
                                ? null
                                : (propType.IsValueType ? Activator.CreateInstance(propType) : null);
                        }
                        else if (targetType.IsEnum)
                        {
                            value = Enum.Parse(targetType, value.ToString(), true);
                        }
                        else if (targetType == typeof(DateTime))
                        {
                            if (DateTime.TryParse(value.ToString(), out var dt))
                                value = dt;
                            else
                                value = Nullable.GetUnderlyingType(propType) != null
                                    ? null
                                    : Activator.CreateInstance(propType);
                        }
                        else if (targetType == typeof(bool) || targetType == typeof(bool?))
                        {
                            bool isNullable = Nullable.GetUnderlyingType(propType) != null;
                            bool b;
                            if (value == null || value == DBNull.Value)
                            {
                                if (isNullable)
                                    value = null;
                                else
                                    value = false;
                            }
                            else if (bool.TryParse(value.ToString(), out b))
                            {
                                value = b;
                            }
                            else
                            {
                                if (isNullable)
                                    value = null;
                                else
                                    value = false;
                            }
                        }
                        else if (targetType == typeof(double))
                        {
                            if (double.TryParse(value.ToString(), out var d))
                                value = d;
                            else
                                value = 0;
                        }
                        else if (targetType == typeof(float))
                        {
                            if (float.TryParse(value.ToString(), out var f))
                                value = f;
                            else
                                value = 0;
                        }
                        else if (targetType == typeof(decimal))
                        {
                            if (decimal.TryParse(value.ToString(), out var dc))
                                value = dc;
                            else
                                value = 0;
                        }
                        else
                        {
                            value = Convert.ChangeType(value, targetType);
                        }
                    }
                    catch
                    {
                        value = Nullable.GetUnderlyingType(propType) != null
                            ? null
                            : (propType.IsValueType ? Activator.CreateInstance(propType) : null);
                    }

                    propertyInfo.SetValue(filterRow, value);
                }
            }


            private static List<T> SortList(List<T> list, string propertyName, ListSortDirection direction)
            {
                var prop = typeof(T).GetProperty(propertyName);
                if (direction == ListSortDirection.Ascending)
                    return list.OrderBy(x => prop.GetValue(x)).ToList();
                else
                    return list.OrderByDescending(x => prop.GetValue(x)).ToList();
            }

            private void SetSortGlyph()
            {
                foreach (DataGridViewColumn col in grid.Columns)
                    col.HeaderCell.SortGlyphDirection = SortOrder.None;

                if (lastSortColumn >= 0 && lastSortColumn < grid.Columns.Count)
                {
                    var col = grid.Columns[lastSortColumn];

                    // Chỉ set SortGlyph nếu SortMode cho phép
                    if (col.SortMode != DataGridViewColumnSortMode.NotSortable)
                    {
                        // Kiểm tra kiểu dữ liệu như các hướng dẫn trước (nếu cần)
                        col.HeaderCell.SortGlyphDirection =
                            lastSortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
                    }
                }
            }

            void SaveColumnStates()
            {
                states = new Dictionary<string, ColumnState>();
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    states.Add(
                        grid.Columns[col.Index].Name, new ColumnState
                        {
                            DefaultCellStyle = col.DefaultCellStyle.Clone(),
                            HeaderCellStyle = col.HeaderCell.Style.Clone(),
                            Width = col.Width,
                            Visible = col.Visible,
                            ReadOnly = col.ReadOnly,
                            DisplayIndex = col.DisplayIndex,
                            SortMode = col.SortMode,
                            Format = col.DefaultCellStyle.Format,
                            HeaderText = col.HeaderText // Lưu lại HeaderText
                        });
                }
            }

            void RestoreColumnStates()
            {
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (states.TryGetValue(col.Name, out var state))
                    {
                        col.DefaultCellStyle = state.DefaultCellStyle.Clone();
                        col.HeaderCell.Style = state.HeaderCellStyle.Clone();
                        col.Width = state.Width;
                        col.Visible = state.Visible;
                        col.ReadOnly = state.ReadOnly;
                        col.DisplayIndex = state.DisplayIndex;
                        col.SortMode = col.SortMode != DataGridViewColumnSortMode.NotSortable ? state.SortMode  : DataGridViewColumnSortMode.NotSortable;
                        col.DefaultCellStyle.Format = state.Format;
                        col.HeaderText = state.HeaderText;
                    }
                }
            }
        }
    }

    public class ColumnState
    {
        public DataGridViewCellStyle DefaultCellStyle { get; set; }
        public DataGridViewCellStyle HeaderCellStyle { get; set; }
        public int Width { get; set; }
        public bool Visible { get; set; }
        public bool ReadOnly { get; set; }
        public int DisplayIndex { get; set; }
        public DataGridViewColumnSortMode SortMode { get; set; }
        public string Format { get; set; }
        public string HeaderText { get; set; }
    }
}
