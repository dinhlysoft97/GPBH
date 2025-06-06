using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public class MultiColumnComboBoxEditingControl : MultiColumnComboBox, IDataGridViewEditingControl
    {
        public DataGridView EditingControlDataGridView { get; set; }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }
        public Cursor EditingPanelCursor => Cursors.Default;
        public bool RepositionEditingControlOnValueChange => false;

        public MultiColumnComboBoxEditingControl()
        {
            SelectedValueChanged += (s, e) =>
            {
                EditingControlValueChanged = true;
                EditingControlDataGridView?.NotifyCurrentCellDirty(true);
            };
        }

        public object EditingControlFormattedValue
        {
            get
            {
                var columnType = EditingControlDataGridView?.CurrentCell?.OwningColumn?.ValueType;
                var value = SelectedValue;
                if (value == null) return DBNull.Value;

                // Debug xem kiểu thực tế là gì
                System.Diagnostics.Debug.WriteLine($"SelectedValue: {value}, Type: {value.GetType()}");

                if (columnType == typeof(int))
                {
                    if (value is int) return value;
                    if (int.TryParse(value.ToString(), out int i)) return i;
                    return DBNull.Value;
                }
                if (columnType == typeof(string))
                {
                    return value.ToString();
                }
                if (columnType == typeof(long))
                {
                    if (value is long) return value;
                    if (long.TryParse(value.ToString(), out long l)) return l;
                    return DBNull.Value;
                }
                return value;
            }
            set
            {
                SetSelectedValue(value);
            }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll) TxtInput.SelectAll();
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                case Keys.Enter:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void DetachEditingControl() { }

        private void SetSelectedValue(object value)
        {
            if (DataSource == null || string.IsNullOrEmpty(ValueMember)) return;
            foreach (var item in DataSource)
            {
                var prop = item.GetType().GetProperty(ValueMember);
                if (prop != null)
                {
                    var itemValue = prop.GetValue(item, null);
                    if (itemValue == null || value == null) continue;
                    // So sánh đúng kiểu dữ liệu
                    if (itemValue.Equals(value)
                        || itemValue.ToString().Equals(value.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        SelectedItem = item;
                        if (!string.IsNullOrEmpty(DisplayMember))
                        {
                            var propDisp = item.GetType().GetProperty(DisplayMember);
                            TxtInput.Text = propDisp?.GetValue(item, null)?.ToString() ?? "";
                        }
                        else
                        {
                            TxtInput.Text = item.ToString();
                        }
                        break;
                    }
                }
            }
        }
    }
}