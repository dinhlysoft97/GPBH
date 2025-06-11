using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class Login : Office2007Form
    {
        private readonly SysDMNSDService _productService;
        private readonly SysDMCuaHangService _sysDMCuaHangService;
        public Login(SysDMNSDService productService, SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            // Đặt thuộc tính KeyPreview của Form là true trong Designer hoặc trong code
            this.KeyPreview = true;

            this.KeyDown += Form_KeyDown;
            _productService = productService;
            _sysDMCuaHangService = sysDMCuaHangService;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleClick();
            }
        }

        private void btnDangNhap_Click(object sender, System.EventArgs e)
        {
            HandleClick();
        }

        private void HandleClick()
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _productService.DangNhap(tenDangNhap, matKhau);

            if (user != null && !string.IsNullOrEmpty(user.TenDangNhap))
            {
                // Đăng nhập thành công
                //MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu thông tin user vào biến global hoặc truyền vào form chính
                AppGlobals.CurrentUser = user;
                AppGlobals.DMCuaHang = _sysDMCuaHangService.GetByMaCuaHang(AppGlobals.MaCH);
                AppGlobals.TgDangNhap = DateTime.Now;

                // call form dot net bar
                var main = ActivatorUtilities.CreateInstance<MainForm>(Program.ServiceProvider);
                main.Show();
                this.Hide();
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
