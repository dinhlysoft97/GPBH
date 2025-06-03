using System;
using System.Data;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlDonHang : UserControl
    {
        public UserControlDonHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            dataGridViewX1.SelectionChanged += dataGridViewX1_SelectionChanged;

            LoadData();
        }

        private void LoadData()
        {
            // 1. Tạo dữ liệu mẫu
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Namea", typeof(string));

            // Thêm vài dòng dữ liệu
            dt.Rows.Add(1, "Nguyen Van A");
            dt.Rows.Add(2, "Tran Thi B");
            dt.Rows.Add(3, "Le Van C");

            // 2. Đổ dữ liệu vào DataGridViewX
            dataGridViewX1.DataSource = dt;

            // 3. Thêm 1 dòng mới lên đầu
            DataRow newRow = dt.NewRow();
            newRow["ID"] = DBNull.Value; // hoặc giá trị mặc định (ví dụ: 0)
            newRow["Namea"] = "Dòng mới thêm";
            dt.Rows.InsertAt(newRow, 0);

            // 4. Chọn dòng đầu tiên
            if (dataGridViewX1.Rows.Count > 0)
            {
                dataGridViewX1.CurrentCell = dataGridViewX1.Rows[0].Cells[0];
            }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow != null && dataGridViewX1.CurrentRow.IsNewRow)
            {
                var a = dataGridViewX1.CurrentRow.Cells["ID"].Value?.ToString();
                var b = dataGridViewX1.CurrentRow.Cells["Namea"].Value?.ToString();
            }
        }
    }
}
