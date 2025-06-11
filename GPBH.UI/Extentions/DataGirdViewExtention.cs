using DevComponents.DotNetBar.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
        }

        /// <summary>
        /// Lấy dữ liệu từ DataGridViewX và chuyển đổi thành danh sách.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static IList<T> GetData<T>(this DataGridViewX grid) where T : class, new()
        {
            var data = grid.DataSource as BindingList<T>;
            return data.ToList();
        }
    }
}
