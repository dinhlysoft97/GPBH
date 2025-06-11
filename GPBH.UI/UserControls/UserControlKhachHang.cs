using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;
using System;
using System.Collections;
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
        public UserControlKhachHang()
        {
            InitializeComponent();
            _dmkhService = new DMKHService(Program.ServiceProvider);
            LoadKhachHang();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FormAddDMKH(Program.ServiceProvider, null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHang();
                }
            }
        }

        private void LoadKhachHang()
        {
            try
            {
                var service = new DMKHService(Program.ServiceProvider);
                var list = service.GetAllCustomer();
                dataGridViewX1.DataSource = list;
                DataGridViewFilterHelper.ApplyFillter<DMKH>(dataGridViewX1, list);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewKhachHang_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow == null)
                return;

            var passport = dataGridViewX1.CurrentRow.Cells["Passport"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(passport))
                return;

            var serviceProvider = Program.ServiceProvider;

            // Lấy thông tin khách hàng từ service
            var dmkhService = new DMKHService(serviceProvider);
            var customer = dmkhService.GetByPassport(passport);
            if (customer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new FormAddDMKH(serviceProvider, customer))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHang();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var passport = dataGridViewX1.CurrentRow.Cells["Passport"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(passport))
            {
                MessageBox.Show("Không xác định được khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var service = new DMKHService(Program.ServiceProvider);
                service.DeleteCustomer(passport);
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
