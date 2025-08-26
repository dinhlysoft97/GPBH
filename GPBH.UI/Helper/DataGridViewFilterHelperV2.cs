using DevComponents.DotNetBar.Controls;
using GPBH.Business.Dtos;
using GPBH.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Helper
{
    public static class DataGridViewFilterHelperV2
    {
        /// <summary>
        /// Applies a filter row to the DataGridViewX and allows filtering of data based on the properties of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <param name="data"></param>
        public static void ApplyFilter<T>(DataGridViewX grid, IList<T> data, List<GirdSysDinhDangFormDto> sortColumns = null) where T : new()
        {
            var helper = new InternalHelper<T>(grid, data, sortColumns);
            helper.Initialize();
        }

        /// <summary>
        /// Internal helper class to manage filtering and sorting for DataGridViewX.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        sealed class InternalHelper<T> where T : new()
        {
            private readonly DataGridView grid;
            private readonly IList<T> sourceData;
            private bool isFiltering = false;
            private readonly List<string> propertyNames;
            private Dictionary<string, ColumnState> states = new Dictionary<string, ColumnState>();
            private readonly List<GirdSysDinhDangFormDto> initialSortColumns;
            private List<GirdSysDinhDangFormDto> sortColumns; // Danh sách cột & chiều sort hiện tại

            public InternalHelper(DataGridView grid, IList<T> data, List<GirdSysDinhDangFormDto> sortColumns)
            {
                this.grid = grid;
                var sttProperty = typeof(T).GetProperty("Stt");
                if (sttProperty != null && sttProperty.CanWrite)
                {
                    int stt = 1;
                    foreach (var item in data)
                    {
                        sttProperty.SetValue(item, stt++);
                    }
                }

                this.sourceData = data;
                this.propertyNames = typeof(T).GetProperties().Select(p => p.Name).ToList();
                this.sortColumns = sortColumns != null ? new List<GirdSysDinhDangFormDto>(sortColumns).OrderBy(z => z.Field_order).ToList() : new List<GirdSysDinhDangFormDto>();
            }

            public void Initialize()
            {
                grid.CellValueChanged -= Grid_CellValueChanged;
                grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick;

                SaveColumnStates();
                var displayList = new List<T> { new T() }; // filter row
                foreach (var item in sourceData)
                    displayList.Add(item);

                RestoreColumnStates();
                SaveColumnStates();
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnStates();
                SetGirdReadOnly();
                SetSortGlyph();

                grid.CellValueChanged += Grid_CellValueChanged;
                grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
            }
            private void SetGirdReadOnly()
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
                    // Lấy đúng property theo cột hiện tại (nên dùng DataPropertyName nếu Field_name là tên property)
                    string prop = grid.Columns[e.ColumnIndex].DataPropertyName;

                    var exist = sortColumns.FirstOrDefault(x => x.Field_name == prop);
                    if (exist != null)
                    {
                        if (exist.Default_sort == Sort.Ascending)
                            exist.Default_sort = Sort.Descending;
                        else if (exist.Default_sort == Sort.Descending)
                            exist.Default_sort = Sort.None;
                        else if (exist.Default_sort == Sort.None)
                            exist.Default_sort = Sort.Ascending;

                        var index = sortColumns.IndexOf(exist);
                        sortColumns.Remove(exist);
                        sortColumns.Insert(index, exist);
                    }
                    else
                    {
                        // Nếu chưa có, thêm mới vào sortColumns (tùy logic bạn muốn)
                        sortColumns.Add(new GirdSysDinhDangFormDto { Field_name = prop, Default_sort = Sort.Ascending });
                    }

                    sortColumns = sortColumns.OrderBy(z => z.Field_order).ToList();
                    ApplyFilterAndRestoreSort();
                }
            }

            private void ApplyFilterAndRestoreSort()
            {
                isFiltering = true;

                var filterValues = new Dictionary<string, object>();
                // Lặp theo từng cột thật sự trên grid
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    var col = grid.Columns[i];
                    // Nên dùng DataPropertyName để map đúng property model (nếu bạn để Name thì đổi lại cho đồng bộ)
                    string propName = col.DataPropertyName;
                    if (string.IsNullOrEmpty(propName))
                        continue;

                    // Cột ẩn thì bỏ qua nếu muốn
                    // if (!col.Visible) continue;

                    var val = grid.Rows[0].Cells[col.Index].Value;
                    filterValues[propName] = val ?? "";
                }

                List<T> filtered;
                T filterRow;
                HandleFilter(filterValues, out filtered, out filterRow);
                var displayList = new List<T> { filterRow };
                displayList.AddRange(filtered);
                SaveColumnStates();
                grid.DataSource = null;
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnStates();

                SetGirdReadOnly();
                SetSortGlyph();
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

                // Multi-sort
                if (sortColumns != null && sortColumns.Count > 0)
                {
                    // Lọc ra những cột cần sort (Default_sort khác Sort.None)
                    var realSortColumns = sortColumns.Where(z => z.Default_sort != Sort.None).ToList();
                    IOrderedEnumerable<T> ordered = null;
                    foreach (var sort in realSortColumns)
                    {
                        var prop = typeof(T).GetProperty(sort.Field_name);
                        if (prop == null) continue;

                        Func<T, object> keySelector = x => prop.GetValue(x, null);

                        if (ordered == null)
                        {
                            ordered = (sort.Default_sort == Sort.Ascending)
                                ? filtered.OrderBy(keySelector)
                                : filtered.OrderByDescending(keySelector);
                        }
                        else
                        {
                            ordered = (sort.Default_sort == Sort.Ascending)
                                ? ordered.ThenBy(keySelector)
                                : ordered.ThenByDescending(keySelector);
                        }
                    }
                    if (ordered != null)
                        filtered = ordered.ToList();
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

            private void SetSortGlyph()
            {
                foreach (DataGridViewColumn col in grid.Columns)
                    col.HeaderCell.SortGlyphDirection = SortOrder.None;

                if (sortColumns != null)
                {
                    for (int i = 0; i < sortColumns.Count; i++)
                    {
                        var sort = sortColumns[i];
                        var col = grid.Columns[sort.Field_name];
                        if (col == null) continue;
                        if (col.SortMode != DataGridViewColumnSortMode.NotSortable)
                        {
                            if (sort.Default_sort == Sort.Ascending)
                                col.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                            else if (sort.Default_sort == Sort.Descending)
                                col.HeaderCell.SortGlyphDirection = SortOrder.Descending;

                            // Optionally: bạn có thể custom vẽ thêm thứ tự (1,2,3) lên header nếu muốn!
                        }
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
                        col.SortMode = col.SortMode != DataGridViewColumnSortMode.NotSortable ? state.SortMode : DataGridViewColumnSortMode.NotSortable;
                        col.DefaultCellStyle.Format = state.Format;
                        col.HeaderText = state.HeaderText;
                    }
                }
            }
        }
    }
}
