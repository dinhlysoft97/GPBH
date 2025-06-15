using DevComponents.DotNetBar.Controls;
using GPBH.Business.Services;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlKhachHang : UserControl
    {
        private readonly DMKHService _dmKHService;
        public UserControlKhachHang(DMKHService dMKHService)
        {
            InitializeComponent();
            _dmKHService = dMKHService;
            dataGridViewX1.CellFormatting += dataGridViewX1_CellFormatting;
            dataGridViewX1.CellDoubleClick += dataGridViewX1_CellDoubleClick;
            LoadData();
        }

        private void LoadData()
        {
            var caList = _dmKHService.GetAll();
            var col = dataGridViewX1.Columns["Ho_ten"];
            if (col != null)
                col.ReadOnly = true;

            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, caList);
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewX1.Columns[e.ColumnIndex].Name == "Gioi_tinh" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "M":
                        e.Value = "Nam";
                        break;
                    case "F":
                        e.Value = "Nữ";
                        break;
                    case "O":
                        e.Value = "Khác";
                        break;
                    default:
                        e.Value = "";
                        break;
                }
                e.FormattingApplied = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy service quốc gia từ DI nếu cần, hoặc truyền null nếu không dùng
            var form = new GPBH.UI.Forms.KhachHang(_dmKHService, Program.ServiceProvider.GetService(typeof(DMQGService)) as DMQGService, null, isSelectMode: true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var passport = dataGridViewX1.CurrentRow?.Cells["Passport"].Value?.ToString();
            if (string.IsNullOrEmpty(passport)) return;

            var khachHang = _dmKHService.GetByPassport(passport);
            if (khachHang == null) return;

            var form = new GPBH.UI.Forms.KhachHang(_dmKHService, Program.ServiceProvider.GetService(typeof(DMQGService)) as DMQGService, passport, isSelectMode: true);
            form.DataKhachHang = khachHang;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var khachHangMoi = form.GetCustomerFromForm();
                _dmKHService.EditCustomer(khachHangMoi);
                LoadData();
            }
        }
        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua_Click(sender, EventArgs.Empty);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = dataGridViewX1.CurrentRow;
            if (row == null || row.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var passport = row.Cells["Passport"].Value?.ToString();
            if (string.IsNullOrEmpty(passport))
            {
                MessageBox.Show("Không lấy được thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng với Passport: {passport}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _dmKHService.DeleteCustomer(passport);
                    LoadData();
                    MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa khách hàng thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim().ToLower();
            var allList = _dmKHService.GetAll();

            var filtered = allList.Where(x =>
                (!string.IsNullOrEmpty(x.Passport) && x.Passport.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Ho) && x.Ho.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Ten_dem) && x.Ten_dem.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Ten) && x.Ten.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Dien_thoai) && x.Dien_thoai.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Email) && x.Email.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Dia_chi) && x.Dia_chi.ToLower().Contains(keyword))
            ).ToList();

            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, filtered);
        }


    }
}
