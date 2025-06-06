using System.Collections.Generic;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public class DataGridViewMultiColumnComboBoxColumn : DataGridViewColumn
    {
        public IEnumerable<object> DataSource { get; set; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public List<MultiColumnComboBox.DisplayColumnCustom> DisplayColumns { get; set; }
        public int[] ColumnWidths { get; set; }

        public DataGridViewMultiColumnComboBoxColumn()
            : base(new DataGridViewMultiColumnComboBoxCell())
        {
            DisplayColumns = new List<MultiColumnComboBox.DisplayColumnCustom>();
        }
    }
}