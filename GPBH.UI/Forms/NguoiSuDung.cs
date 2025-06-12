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
        #region Fields & Constructor

        private readonly SysDMNSDService _sysDMNSDService;
        private SysDMNSD _data;
        private bool _isEdit = false;

        public NguoiSuDung(SysDMNSDService sysDMNSDService, SysDMNSD data = null)
        {
            InitializeComponent();
            _sysDMNSDService = sysDMNSDService;
            _data = data;
            _isEdit = data != null;

            InitializeForm();
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Khởi tạo form, load dữ liệu (nếu sửa), đăng ký sự kiện.
        /// </summary>
        private void InitializeForm()
        {
            if (_isEdit)
                LoadDataEdit();

            RegisterEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện cho nút.
        /// </summary>
        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click;
            btnDong.Click += BtnDong_Click;
        }

        #endregion

        #region Data Binding

        /// <summary>
        /// Load dữ liệu lên form khi sửa người dùng.
        /// </summary>
        private void LoadDataEdit()
        {
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtXacNhanMatKhau.Enabled = false;

            txtTenDangNhap.Text = _data.TenDangNhap;
            txtMatKhau.Text = _data.MatKhau;
            txtXacNhanMatKhau.Text = _data.MatKhau;
            txtTenDayDu.Text = _data.TenDayDu;
            checkAdmin.Checked = _data.IsAdmin;
            checkCapLaiQuyen.Checked = _data.CapLaiQuyen;
            checkKSD.Checked = _data.Ksd;
            this.Text = "Cập nhật người dùng: " + _data.TenDayDu;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Sự kiện click nút Lưu (thêm mới hoặc cập nhật người dùng).
        /// </summary>
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            lbError.Text = "";
            lbError.BackColor = System.Drawing.Color.Transparent;

            var user = GetUserFromForm();

            if (_isEdit)
            {
                _sysDMNSDService.Sua(user);
                MessageBoxEx.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Kiểm tra tên đăng nhập đã tồn tại chưa
                if (_sysDMNSDService.CheckTrungTenDangNhap(user.TenDangNhap))
                {
                    txtTenDangNhap.Focus();
                    MessageBoxEx.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var data = _sysDMNSDService.TaoMoi(user);
                MessageBoxEx.Show("Tạo người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hiển thị lại form để sửa ngay nếu muốn
                this.Hide();
                this.ShowForm<NguoiSuDung>(data);
            }
        }

        /// <summary>
        /// Sự kiện click nút Đóng.
        /// </summary>
        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.ColseForm();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Lấy dữ liệu người dùng từ form.
        /// </summary>
        private SysDMNSD GetUserFromForm()
        {
            return new SysDMNSD
            {
                TenDayDu = txtTenDayDu.Text.Trim(),
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text,
                IsAdmin = checkAdmin.Checked,
                CapLaiQuyen = checkCapLaiQuyen.Checked,
                Ksd = checkKSD.Checked,
            };
        }

        /// <summary>
        /// Kiểm tra hợp lệ dữ liệu form. Báo lỗi ra lbError.
        /// </summary>
        private bool ValidateForm()
        {
            string message = string.Empty;

            if (string.IsNullOrWhiteSpace(txtTenDayDu.Text))
            {
                txtTenDayDu.Focus();
                message = "Tên đầy đủ không được để trống.";
            }
            else if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                txtTenDangNhap.Focus();
                message = "Tên đăng nhập không được để trống.";
            }
            else if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Focus();
                message = "Mật khẩu không được để trống.";
            }
            else if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                txtXacNhanMatKhau.Focus();
                message = "Mật khẩu xác nhận không được để trống.";
            }
            else if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                txtXacNhanMatKhau.Focus();
                message = "Mật khẩu xác nhận không khớp.";
            }

            if (!string.IsNullOrEmpty(message))
            {
                lbError.Text = message;
                lbError.BackColor = System.Drawing.Color.Red;
                return false;
            }

            return true;
        }

        #endregion
    }
}