using DevComponents.DotNetBar.Controls;
using GPBH.UI.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            LoadDataCombox();
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
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}