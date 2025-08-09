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
        private string DateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
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
            dataGridViewX1.SetFormat("Ngay_cap", DateFormat);
            dataGridViewX1.SetFormat("Ngay_hh", DateFormat);
            dataGridViewX1.SetFormat("Ngay_sinh", DateFormat);
            dataGridViewX1.SetFormat("Xnc_ngay_cap", DateFormat);
            dataGridViewX1.SetFormat("Xnc_ngay_hh", DateFormat);

            dataGridViewX1.SetFormat("Tong_tien_hang", GetFormat("Format_tien"));


            // Thiết lập các cột hiển thị trong DataGridViewX
            //dataGridViewX1.SetDisplayIndex("Passport", 0);
            //dataGridViewX1.SetDisplayIndex("Ho_ten", 1);
            //dataGridViewX1.SetDisplayIndex("Ngay_cap", 2);
            //dataGridViewX1.SetDisplayIndex("Ngay_hh", 3);
            //dataGridViewX1.SetDisplayIndex("Quoc_gia", 4);
            //dataGridViewX1.SetDisplayIndex("Gioi_tinh", 5);
            //dataGridViewX1.SetDisplayIndex("Ngay_sinh", 6);
            //dataGridViewX1.SetDisplayIndex("Dia_chi", 7);
            //dataGridViewX1.SetDisplayIndex("Dien_thoai", 8);
            //dataGridViewX1.SetDisplayIndex("Email", 9);
            //dataGridViewX1.SetDisplayIndex("Xnc_ngay_cap", 10);
            //dataGridViewX1.SetDisplayIndex("Xnc_ngay_hh", 11);
            //dataGridViewX1.SetDisplayIndex("So_hieu", 12);
            //dataGridViewX1.SetDisplayIndex("Ten_tau_bay", 13);
            //dataGridViewX1.SetDisplayIndex("Han_muc", 14);
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

            var form = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider, passport, true, false);
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

            var form = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider, passport, true, true);
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

        private string GetFormat(string column)
        {
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }
    }
}
