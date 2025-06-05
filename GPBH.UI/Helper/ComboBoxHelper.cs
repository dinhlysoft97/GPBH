using System.Collections.Generic;
using System.Windows.Forms;

namespace GPBH.UI.Helper
{
    public static class ComboBoxHelper
    {
        /// <summary>
        /// Bind data to a ComboBox (or ComboBoxEx).
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu object</typeparam>
        /// <param name="comboBox">ComboBox control</param>
        /// <param name="data">Danh sách dữ liệu</param>
        /// <param name="displayMember">Tên thuộc tính hiển thị</param>
        /// <param name="valueMember">Tên thuộc tính giá trị</param>
        /// <param name="enableAutoComplete">Có bật AutoComplete không</param>
        public static void BindData<T>(
            ComboBox comboBox,
            List<T> data,
            string displayMember,
            string valueMember,
            bool enableAutoComplete = true)
        {
            comboBox.DataSource = null; // Reset
            comboBox.DataSource = data;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            if (enableAutoComplete)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
    }
}
