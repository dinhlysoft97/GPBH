using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System;
using DevComponents.DotNetBar.Controls;

namespace GPBH.UI.Helper
{
    public static class DataGridViewFilterHelper
    {
        public static void ApplyFillter<T>(DataGridViewX grid, IList<T> data) where T : new()
        {
            var helper = new InternalHelper<T>(grid, data);
            helper.Initialize();
        }

        private class InternalHelper<T> where T : new()
        {
            private readonly DataGridView grid;
            private readonly IList<T> sourceData;
            private bool isFiltering = false;
            private List<string> propertyNames;
            private int lastSortColumn = -1;
            private int[] columnWidths;
            private ListSortDirection lastSortDirection = ListSortDirection.Ascending;

            public InternalHelper(DataGridView grid, IList<T> data)
            {
                this.grid = grid;
                this.sourceData = data;
                this.propertyNames = typeof(T).GetProperties().Select(p => p.Name).ToList();
            }

            public void Initialize()
            {
                SaveColumnWidths();
                grid.DataSource = null;
                RestoreColumnWidths();
                var displayList = new List<T> { new T() }; // filter row
                foreach (var item in sourceData)
                    displayList.Add(item);

                SaveColumnWidths();
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnWidths();

                grid.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                grid.Rows[0].ReadOnly = false;
                for (int i = 1; i < grid.Rows.Count; i++)
                    grid.Rows[i].ReadOnly = true;

                grid.CellValueChanged += Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;

                SetSortGlyph();
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

                    ApplySortOnly();
                }
            }

            private void ApplyFilterAndRestoreSort()
            {
                isFiltering = true;

                var filterValues = new Dictionary<string, string>();
                for (int i = 0; i < propertyNames.Count; i++)
                {
                    var val = grid.Rows[0].Cells[i].Value?.ToString() ?? "";
                    filterValues[propertyNames[i]] = val;
                }

                var filtered = sourceData.Where(item =>
                {
                    foreach (var prop in propertyNames)
                    {
                        var val = typeof(T).GetProperty(prop).GetValue(item)?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(filterValues[prop]) &&
                            val.IndexOf(filterValues[prop], StringComparison.OrdinalIgnoreCase) < 0)
                            return false;
                    }
                    return true;
                }).ToList();

                // Sort lại nếu có thông tin sort
                if (lastSortColumn >= 0)
                {
                    string sortProp = propertyNames[lastSortColumn];
                    filtered = SortList(filtered, sortProp, lastSortDirection);
                }

                var filterRow = new T();
                foreach (var prop in propertyNames)
                {
                    typeof(T).GetProperty(prop).SetValue(filterRow, filterValues[prop]);
                }

                var displayList = new List<T> { filterRow };
                displayList.AddRange(filtered);

                grid.CellValueChanged -= Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged -= Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick;

                SaveColumnWidths();
                grid.DataSource = null;
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnWidths();

                grid.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                grid.Rows[0].ReadOnly = false;
                for (int i = 1; i < grid.Rows.Count; i++)
                    grid.Rows[i].ReadOnly = true;

                grid.CellValueChanged += Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;

                SetSortGlyph();

                isFiltering = false;
            }

            private void ApplySortOnly()
            {
                isFiltering = true;

                var filterValues = new Dictionary<string, string>();
                for (int i = 0; i < propertyNames.Count; i++)
                {
                    var val = grid.Rows[0].Cells[i].Value?.ToString() ?? "";
                    filterValues[propertyNames[i]] = val;
                }

                var filtered = sourceData.Where(item =>
                {
                    foreach (var prop in propertyNames)
                    {
                        var val = typeof(T).GetProperty(prop).GetValue(item)?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(filterValues[prop]) &&
                            val.IndexOf(filterValues[prop], StringComparison.OrdinalIgnoreCase) < 0)
                            return false;
                    }
                    return true;
                }).ToList();

                // Sort mới
                if (lastSortColumn >= 0)
                {
                    string sortProp = propertyNames[lastSortColumn];
                    filtered = SortList(filtered, sortProp, lastSortDirection);
                }

                var filterRow = new T();
                foreach (var prop in propertyNames)
                {
                    typeof(T).GetProperty(prop).SetValue(filterRow, filterValues[prop]);
                }

                var displayList = new List<T> { filterRow };
                displayList.AddRange(filtered);

                grid.CellValueChanged -= Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged -= Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick;

                SaveColumnWidths();
                grid.DataSource = null;
                grid.DataSource = new BindingList<T>(displayList);
                RestoreColumnWidths();

                grid.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                grid.Rows[0].ReadOnly = false;
                for (int i = 1; i < grid.Rows.Count; i++)
                    grid.Rows[i].ReadOnly = true;

                grid.CellValueChanged += Grid_CellValueChanged;
                grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
                grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;

                SetSortGlyph();

                isFiltering = false;
            }

            private List<T> SortList(List<T> list, string propertyName, ListSortDirection direction)
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
                    grid.Columns[lastSortColumn].HeaderCell.SortGlyphDirection =
                        lastSortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
                }
            }

            private void SaveColumnWidths()
            {
                if (grid.Columns.Count == 0) return;
                columnWidths = new int[grid.Columns.Count];
                for (int i = 0; i < grid.Columns.Count; i++)
                    columnWidths[i] = grid.Columns[i].Width;
            }

            private void RestoreColumnWidths()
            {
                if (columnWidths == null) return;
                for (int i = 0; i < Math.Min(grid.Columns.Count, columnWidths.Length); i++)
                    grid.Columns[i].Width = columnWidths[i];
            }
        }
    }
}
