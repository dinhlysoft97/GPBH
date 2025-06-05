using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.UI.Helper;
using GPBH.UI.UserControls;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GPBH.UI.UserControls.MultiColumnComboBox;

namespace GPBH.UI.Forms
{
    public partial class DonHang : Office2007Form
    {
        public DonHang()
        {
            InitializeComponent();
            LoadDataCombox();
            dataGridViewX1.CellValueChanged += dataGridViewX1_CellValueChanged;
        }

        private void LoadDataCombox()
        {
            // Chuẩn bị dữ liệu mẫu
            List<City> cities = new List<City>
        {
            new City { Id = 1, Name = "Hà Nội" },
            new City { Id = 2, Name = "Hồ Chí Minh" },
            new City { Id = 3, Name = "Đà Nẵng" }
        };

            // Lấy ra cột combo vừa add từ designer
            var comboCol = dataGridViewX1.Columns["colCity"] as DataGridViewComboBoxColumn;
            if (comboCol != null)
            {
                comboCol.DataSource = cities;
                comboCol.DisplayMember = "Name";
                comboCol.ValueMember = "Id";
            }

            // Thêm dòng demo
            dataGridViewX1.Rows.Add();
            dataGridViewX1.Rows.Add();
        }
        private void dataGridViewX1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.Columns[e.ColumnIndex].Name == "colCity")
            {
                var cell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var selectedValue = cell.Value; // Sẽ là "Id" của City
                                                // Nếu cần lấy object City, bạn có thể truy ngược từ List<City> nếu cần
               
                // Gán giá trị cột "colArea" trên cùng dòng
                dataGridViewX1.Rows[e.RowIndex].Cells["Column3"].Value = selectedValue;
            }
        }

    }


    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } // Thêm filed địa chỉ
    }
}
