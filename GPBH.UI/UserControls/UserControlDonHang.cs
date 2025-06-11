using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
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
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, originalList);
        }

        public class Person
        {
            public string ID { get; set; }
            public string NameName { get; set; }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            var donHang = ActivatorUtilities.CreateInstance<DonHang>(Program.ServiceProvider);
            donHang.ShowDialog(); // Hiển thị Form1 như một dialog
        }
    }
}
