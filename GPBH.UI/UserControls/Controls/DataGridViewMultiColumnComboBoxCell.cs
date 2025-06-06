using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public class DataGridViewMultiColumnComboBoxCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(MultiColumnComboBoxEditingControl);

        public override Type ValueType
        {
            get
            {
                // Lấy trực tiếp từ column nếu có
                if (this.OwningColumn is DataGridViewMultiColumnComboBoxColumn col && col.ValueType != null)
                    return col.ValueType;
                return base.ValueType ?? typeof(int); // default là int
            }
        }

        public override object DefaultNewRowValue => null;

        public override object ParseFormattedValue(object formattedValue,
            DataGridViewCellStyle cellStyle,
            TypeConverter formattedValueTypeConverter,
            TypeConverter valueTypeConverter)
        {
            // Ép kiểu đúng với ValueType
            var type = this.ValueType;
            if (formattedValue == null || formattedValue == DBNull.Value) return null;
            if (type == typeof(int))
            {
                if (formattedValue is int) return formattedValue;
                if (int.TryParse(formattedValue.ToString(), out int i)) return i;
                throw new FormatException("Cannot convert value to int");
            }
            if (type == typeof(string))
            {
                return formattedValue.ToString();
            }
            // Thêm các kiểu khác nếu cần
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
    }
}