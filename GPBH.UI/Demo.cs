using GPBH.UI.Helper;
using GPBH.UI.UserControls;
using System.Collections.Generic;
using System.Windows.Forms;
using static GPBH.UI.UserControls.MultiColumnComboBox;

namespace GPBH.UI
{
    public partial class Demo : Form
    {
        // Lưu lại dữ liệu mẫu để dùng toàn cục
        private List<City> cities;
        private Dictionary<string, string> columnMap;

        public Demo()
        {
            InitializeComponent();
            // LoadDataCombox();
            LoadDataMutiCombox();
        }

        private void LoadDataCombox()
        {
            // Chuẩn bị dữ liệu mẫu
            cities = new List<City>
            {
                new City { Id = 1, Name = "Hà Nội", Address = "HN" },
                new City { Id = 2, Name = "Hồ Chí Minh", Address = "HCM" },
                new City { Id = 3, Name = "Đà Nẵng", Address = "DN" }
            };

            // Map: key là cột đích, value là property trong City
            columnMap = new Dictionary<string, string>
            {
                { "Column3", "Id" },          // Gán City.Id cho cột Column3
                { "colAddress", "Address" }   // Gán City.Address cho cột colAddress
            };

            // Đăng ký tự động map giá trị khi thay đổi value ở cột combobox
            ComboBoxExUseGirdViewHelper.EnableAutoMapOnComboValueChanged(
                dataGridViewX1,
                "colCity",
                cities,
                "Id",
                columnMap
            );

            // Bind data cho cột combobox
            ComboBoxExUseGirdViewHelper.BindDataToComboBoxColumn(
                dataGridViewX1,
                "colCity",
                cities,
                "Id",
                "Name",
                true
            );

            // Thêm dòng demo
            dataGridViewX1.Rows.Add();
            dataGridViewX1.Rows.Add();
        }

        private void LoadDataMutiCombox()
        {
            // Chuẩn bị dữ liệu mẫu
            cities = new List<City>
            {
                new City { Id = 1, Name = "Hà Nội", Address = "HN" },
                new City { Id = 2, Name = "Hồ Chí Minh", Address = "HCM" },
                new City { Id = 3, Name = "Đà Nẵng", Address = "DN" }
            };

            var displayCols = new List<DisplayColumnCustom>
        {
            new DisplayColumnCustom{ Header="ID", Property="Id", Width=40 },
            new DisplayColumnCustom{ Header="Tên", Property="Name", Width=100 },
            new DisplayColumnCustom{ Header="Địa chỉ", Property="Address", Width=120 }
        };


            MultiColumnComboBoxGridHelper.BindDataToMultiColumnComboBoxColumn(
            dataGridViewX1,
            "colCity",
            cities,
            "Id",
            "Name"
        );


            dataGridViewX1.EditingControlShowing += (s, e) =>
            {
                if (dataGridViewX1.CurrentCell is DataGridViewMultiColumnComboBoxCell &&
                    e.Control is MultiColumnComboBoxEditingControl ctrl)
                {
                    var col = (DataGridViewMultiColumnComboBoxColumn)dataGridViewX1.Columns[dataGridViewX1.CurrentCell.ColumnIndex];
                    ctrl.DisplayColumns = col.DisplayColumns;
                    ctrl.ColumnWidths = col.ColumnWidths;
                    ctrl.DataSource = col.DataSource;
                    ctrl.ValueMember = col.ValueMember;
                    ctrl.DisplayMember = col.DisplayMember;
                }
            };

            // Mapping value sang cột khác
            dataGridViewX1.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && dataGridViewX1.Columns[e.ColumnIndex].Name == "colCity")
                {
                    var val = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    var city = cities.Find(x => x.Name.Equals(val));
                    if (city != null)
                        dataGridViewX1.Rows[e.RowIndex].Cells["colAddress"].Value = city.Address;
                }
            };

            // Handle DataError để tránh crash khi nhập sai kiểu
            dataGridViewX1.DataError += (s, e) =>
            {
                MessageBox.Show(e.Exception.Message, "DataError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false;
            };
        }

        // Hàm này có thể bỏ nếu đã dùng EnableAutoMapOnComboValueChanged
        private void dataGridViewX1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu cần xử lý thêm ngoài auto map, viết ở đây
            // Nếu chỉ dùng auto map thì có thể để trống hoặc xóa
        }
    }
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
