using GPBH.UI.Helper;
using GPBH.UI.UserControls.DonHang;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlDonHang : UserControl
    {
        List<Person> originalList = new List<Person>
        {
            new Person { ID = "1", NameName = "Alice" },
            new Person { ID = "2", NameName = "Bob" },
            new Person { ID = "3", NameName = "Charlie" },
            new Person { ID = "4", NameName = "David" }
        };

        public UserControlDonHang()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            dtTu.Value = DateTime.Now;
            dtDen.Value = DateTime.Now;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataGridViewFilterHelper.ApplyFillter(dataGridViewX1, originalList);
        }

        public class Person
        {
            public string ID { get; set; }
            public string NameName { get; set; }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            // Lấy Form cha
            var mainForm = this.FindForm() as MainForm;
            if (mainForm != null)
            {
                // Tạo instance UserControlThemDonHang
                var uc2 = new UserControlThemDonHang();
                // Gọi hàm mở tab
                mainForm.OpenTab(nameof(UserControlThemDonHang), "Tạo đơn hàng", uc2);
            }
        }
    }
}
