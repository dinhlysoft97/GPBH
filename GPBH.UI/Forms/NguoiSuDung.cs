using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Data.Entities;
using GPBH.UI.Extentions;
using System;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class NguoiSuDung : Office2007Form
    {
        private readonly SysDMNSDService _sysDMNSDService;
        private SysDMNSD _data;
        private bool _isEdit = false;
        public NguoiSuDung(SysDMNSDService sysDMNSDService, SysDMNSD data = null)
        {
            InitializeComponent();
            _sysDMNSDService = sysDMNSDService;

            _data = data;
            _isEdit = data != null;
            if (_isEdit)
                LoadDataEdit();
            RegisterEvents();
        }

        private void LoadDataEdit()
        {
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtXacNhanMatKhau.Enabled = false;

            txtMatKhau.Text = _data.MatKhau;
            txtXacNhanMatKhau.Text = _data.MatKhau;
            txtTenDayDu.Text = _data.TenDayDu;
            txtTenDangNhap.Text = _data.TenDangNhap;
            checkAdmin.Checked = _data.IsAdmin;
            checkCapLaiQuyen.Checked = _data.CapLaiQuyen;
            checkKSD.Checked = _data.Ksd;
            this.Text = "Cập nhật người dùng: " + _data.TenDayDu;
        }

        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click; ;
            btnDong.Click += BtnDong_Click;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var validator = ValidatorData();
            if (validator)
            {
                lbError.Text = "";
                lbError.BackColor = System.Drawing.Color.Transparent;
                var user = new SysDMNSD
                {
                    TenDayDu = txtTenDayDu.Text.Trim(),
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text,
                    IsAdmin = checkAdmin.Checked,
                    CapLaiQuyen = checkCapLaiQuyen.Checked,
                    Ksd = checkKSD.Checked,
                };

                if (_isEdit)
                {
                    _sysDMNSDService.Sua(user);
                    MessageBoxEx.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
                else
                {
                    // Kiểm tra tên đăng nhập đã tồn tại chưa
                    var existingUser = _sysDMNSDService.CheckTrungTenDangNhap(user.TenDangNhap);
                    if (existingUser)
                    {
                        txtTenDangNhap.Focus();
                        MessageBoxEx.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var data = _sysDMNSDService.TaoMoi(user);
                    MessageBoxEx.Show("Tạo đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    this.ShowForm<NguoiSuDung>(data);
                }
            }
        }

        private bool ValidatorData()
        {
            var result = true;
            string message = string.Empty;
            if (string.IsNullOrWhiteSpace(txtTenDayDu.Text))
            {
                txtTenDayDu.Focus();
                message = "Tên đầy đủ không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                txtTenDangNhap.Focus();
                message = "Tên đăng nhập không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Focus();
                message = "Mật khẩu không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                txtXacNhanMatKhau.Focus();
                message = "Mật khẩu xác nhận không được để trống.";
                result = false;
            }
            else if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                txtXacNhanMatKhau.Focus();
                message = "Mật khẩu xác nhận không khớp.";
                result = false;
            }

            if (!result)
            {
                lbError.Text = message;
                lbError.BackColor = System.Drawing.Color.Red;
                result = false;
            }

            return result;
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.ColseForm();
        }
    }
}
