using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPBH.UI.Helper
{
    public class ComboBoxExUseGirdViewHelper
    {
        /// <summary>
        /// Bind data for DataGridViewComboBoxExColumn in DataGridViewX by column name.
        /// </summary>
        public static void BindDataToComboBoxColumn<T>(
            DataGridViewX grid,
            string columnName,
            IList<T> datasrc,
            string valueMember,
            string displayMember,
            bool enableAutoComplete)
        {
            if (grid == null || string.IsNullOrEmpty(columnName) || datasrc == null)
                return;

            var comboCol = grid.Columns[columnName] as DataGridViewComboBoxExColumn;
            if (comboCol != null)
            {
                comboCol.DataSource = datasrc;
                comboCol.ValueMember = valueMember;
                comboCol.DisplayMember = displayMember;

                if (enableAutoComplete)
                {
                    comboCol.DropDownStyle = ComboBoxStyle.DropDown;
                    comboCol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboCol.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }

        /// <summary>
        /// Map values from object datasource to DataGridViewX row cells by mapping dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid">DataGridViewX</param>
        /// <param name="rowIndex">Dòng cần map</param>
        /// <param name="selectedObj">Object source</param>
        /// <param name="columnFieldMap">Dictionary: key là tên cột trên lưới, value là property trong object</param>
        public static void MapRowValues<T>(
            DataGridViewX grid,
            int rowIndex,
            T selectedObj,
            Dictionary<string, string> columnFieldMap)
        {
            if (selectedObj == null || columnFieldMap == null) return;

            foreach (var entry in columnFieldMap)
            {
                var colTarget = entry.Key;
                var propSource = entry.Value;

                var propVal = selectedObj.GetType().GetProperty(propSource)?.GetValue(selectedObj, null);
                if (grid.Columns.Contains(colTarget))
                {
                    grid.Rows[rowIndex].Cells[colTarget].Value = propVal;
                }
            }
        }

        /// <summary>
        /// Đăng ký tự động map giá trị khi thay đổi value ở cột combobox
        /// </summary>
        public static void EnableAutoMapOnComboValueChanged<T>(
            DataGridViewX grid,
            string comboColName,
            IList<T> datasrc,
            string valueMember,
            Dictionary<string, string> columnFieldMap)
        {
            // Gắn sự kiện (xoá trước tránh double)
            grid.CellValueChanged -= (s, e) => CellValueChangedHandler(grid, comboColName, datasrc, valueMember, columnFieldMap);
            grid.CellValueChanged += (s, e) => CellValueChangedHandler(grid, comboColName, datasrc, valueMember, columnFieldMap);
        }

        private static void CellValueChangedHandler<T>(
            DataGridViewX grid,
            string comboColName,
            IList<T> datasrc,
            string valueMember,
            Dictionary<string, string> columnFieldMap)
        {
            if (grid.CurrentCell == null) return;
            var e = new System.Windows.Forms.DataGridViewCellEventArgs(grid.CurrentCell.ColumnIndex, grid.CurrentCell.RowIndex);

            if (grid.Columns[e.ColumnIndex].Name == comboColName)
            {
                var selectedValue = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Tìm object từ datasource dựa theo valueMember
                var selectedObj = default(T);
                foreach (var item in datasrc)
                {
                    var val = item.GetType().GetProperty(valueMember)?.GetValue(item, null);
                    if (val != null && val.Equals(selectedValue))
                    {
                        selectedObj = item;
                        break;
                    }
                }

                // Map sang các cột khác
                MapRowValues(grid, e.RowIndex, selectedObj, columnFieldMap);
            }
        }
    }
}
