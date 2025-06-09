using DevComponents.DotNetBar.Controls;
using GPBH.Business.DTO;
using GPBH.Business.Services;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlKhachHang : UserControl
    {
        private readonly DMKHService _dmkhService;
        private readonly DMQGService _dmqgService;
        public UserControlKhachHang(DMKHService dmkhService, DMQGService dmqgService)
        {
            InitializeComponent();
            _dmkhService = dmkhService;
            _dmqgService = dmqgService;
            LoadData();
        }

        public void LoadData()
        {

            var khList = _dmkhService.GetAllKhachHang();
            dataGridViewX2.DataSource = khList;
            DataGridViewFilterHelper.ApplyFillter(dataGridViewX2, khList);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            using (var form = new FormAddDMKH(_dmqgService))
            {
                if (form.ShowDialog() == DialogResult.OK && form.NewKH != null)
                {
                    _dmkhService.AddKH(form.NewKH);

                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.CurrentRow == null || dataGridViewX2.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var passport = dataGridViewX2.CurrentRow.Cells["Passport"].Value?.ToString();
            var tenKH = dataGridViewX2.CurrentRow.Cells["colHoTen"].Value?.ToString();

            if (string.IsNullOrEmpty(passport))
            {
                MessageBox.Show("Không xác định được mã khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{tenKH}' (Passport: {passport}) không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var dto = new DMKHDto { Passport = passport };
            _dmkhService.DeleteKH(passport);

            LoadData();
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewX2.Rows[e.RowIndex];
            var oldPassport = row.Cells["Passport"].Value?.ToString();
            var hoTen = row.Cells["colHoTen"].Value?.ToString() ?? "";

            // Tách họ, tên đệm, tên từ HoTen (giả sử cách nhau bởi dấu cách)
            string ho = "", tenDem = "", ten = "";
            var parts = hoTen.Trim().Split(' ');
            if (parts.Length > 0)
            {
                ho = parts[0];
                if (parts.Length > 2)
                {
                    ten = parts[parts.Length - 1];
                    tenDem = string.Join(" ", parts, 1, parts.Length - 2);
                }
                else if (parts.Length == 2)
                {
                    ten = parts[1];
                }
                else
                {
                    ten = ho;
                    ho = "";
                }
            }

            var dto = new DMKHDto
            {
                Passport = oldPassport,
                Ho = ho,
                Ten_dem = tenDem,
                Ten = ten,
                Ngay_cap = row.Cells["Ngay_cap"].Value as DateTime?,
                Ngay_hh = row.Cells["Ngay_hh"].Value as DateTime?,
                Quoc_gia = row.Cells["Quoc_gia"].Value?.ToString(),
                Gioi_tinh = row.Cells["Gioi_tinh"].Value?.ToString(),
                Ngay_sinh = row.Cells["Ngay_sinh"].Value as DateTime?,
                Dia_chi = row.Cells["Dia_chi"].Value?.ToString(),
                Dien_thoai = row.Cells["Dien_thoai"].Value?.ToString(),
                Di_dong = row.Cells["Di_dong"].Value?.ToString(),
                Email = row.Cells["Email"].Value?.ToString()
            };

            using (var form = new FormAddDMKH(_dmqgService, dto))
            {
                if (form.ShowDialog() == DialogResult.OK && form.NewKH != null)
                {
                    _dmkhService.EditKH(oldPassport, form.NewKH);
                    LoadData();
                }
            }
        }


    }
}

