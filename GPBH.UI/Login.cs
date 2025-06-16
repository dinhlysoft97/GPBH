using DevComponents.DotNetBar;
using DevComponents.Editors;
using GPBH.Business;
using GPBH.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class Login : Office2007Form
    {
        #region Fields & Constructor

        private readonly SysDMNSDService _userService;
        private readonly SysDMCuaHangService _storeService;

        public Login(SysDMNSDService userService, SysDMCuaHangService storeService)
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép bắt phím trên toàn form
            this.KeyDown += Form_KeyDown;

            _userService = userService;
            _storeService = storeService;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Bắt phím Enter trên toàn form để đăng nhập nhanh.
        /// </summary>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleLogin();
            }
        }

        /// <summary>
        /// Xử lý khi click nút Đăng nhập.
        /// </summary>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            HandleLogin();
        }

        #endregion

        #region Business Logic

        /// <summary>
        /// Xử lý đăng nhập; kiểm tra hợp lệ, gọi service, cập nhật thông tin toàn cục và mở MainForm nếu thành công.
        /// </summary>
        private void HandleLogin()
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBoxEx.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _userService.DangNhap(tenDangNhap, matKhau);

            if (user != null && !string.IsNullOrEmpty(user.TenDangNhap))
            {
                // Đăng nhập thành công
                AppGlobals.CurrentUser = user;
                AppGlobals.TgDangNhap = DateTime.Now;

                // Khởi tạo và show MainForm bằng DI
                var main = ActivatorUtilities.CreateInstance<MainForm>(Program.ServiceProvider);
                main.Show();
                this.Hide();
            }
            else
            {
                // Đăng nhập thất bại
                MessageBoxEx.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}