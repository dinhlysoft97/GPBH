using GPBH.UI.UserControls;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Helper
{
    public static class MultiColumnComboBoxGridHelper
    {
        /// <summary>
        /// Bind dữ liệu cho cột MultiColumnComboBox trong DataGridView.
        /// </summary>
        public static void BindDataToMultiColumnComboBoxColumn<T>(
            DataGridView grid,
            string columnName,
            IList<T> dataSrc,
            string valueMember,
            string displayMember
        )
        {
            var col = grid.Columns[columnName] as DataGridViewMultiColumnComboBoxColumn;
            if (col == null) return;

            // Nếu DataSource là IEnumerable<object>
            col.DataSource = dataSrc.Cast<object>().ToList();
            col.ValueMember = valueMember;
            col.DisplayMember = displayMember;

            // Đặt ValueType đúng kiểu property valueMember
            var prop = typeof(T).GetProperty(valueMember);
            if (prop != null)
                col.ValueType = prop.PropertyType;
        }
    }
}