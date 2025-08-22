using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlKhachHang : UserControl
    {
        private readonly DMKHService _dmKHService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;
        private List<GirdSysDinhDangFormDto> SysDinhDangs;
        public UserControlKhachHang(DMKHService dMKHService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _dmKHService = dMKHService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            dataGridViewX1.CellFormatting += dataGridViewX1_CellFormatting;
            dataGridViewX1.CellDoubleClick += dataGridViewX1_CellDoubleClick;
            dataGridViewX1.KeyDown += DataGridViewX1_KeyDown;
            SepUpUI();
            LoadData();
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                dataGridViewX1.SetGirdReadOnly();
            };
        }

        private void SepUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "KhachHang").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
        }

        private void LoadData()
        {
            var caList = _dmKHService.GetAll();
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
            var hasPermission = CheckPermissionHelper.HasPerrmission("KhachHang", GPBHConstant.Action.Them);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            // Lấy service quốc gia từ DI nếu cần, hoặc truyền null nếu không dùng
            var form = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider, string.Empty, true, false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("KhachHang", GPBHConstant.Action.Sua);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var passport = dataGridViewX1.CurrentRow?.Cells["Passport"].Value?.ToString();
            if (string.IsNullOrEmpty(passport)) return;

            var khachHang = _dmKHService.GetByPassport(passport);
            if (khachHang == null) return;

            var form = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider, passport, true, true, false);
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
            // btnSua_Click(sender, EventArgs.Empty);

            var hasPermission = CheckPermissionHelper.HasPerrmission("KhachHang", GPBHConstant.Action.Sua);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var passport = dataGridViewX1.CurrentRow?.Cells["Passport"].Value?.ToString();
            if (string.IsNullOrEmpty(passport)) return;

            var khachHang = _dmKHService.GetByPassport(passport);
            if (khachHang == null) return;

            var form = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider, passport, true, false, true);
            form.DataKhachHang = khachHang;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var khachHangMoi = form.GetCustomerFromForm();
                _dmKHService.EditCustomer(khachHangMoi);
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("KhachHang", GPBHConstant.Action.Xoa);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

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
                (!string.IsNullOrEmpty(x.Ho_ten) && x.Ho_ten.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Dien_thoai) && x.Dien_thoai.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Email) && x.Email.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(x.Dia_chi) && x.Dia_chi.ToLower().Contains(keyword))
            ).ToList();

            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, filtered);
        }
        private void DataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Chặn luôn không cho đi tiếp
            }
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string menuName = "KhachHang";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }


            ExportHelper.ExportGridToExcel(dataGridViewX1, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}
