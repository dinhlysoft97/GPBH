using DevComponents.DotNetBar;
using GPBH.Business;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class Login : Office2007Form
    {
        private readonly SysDMNSDService _productService;
        public Login(SysDMNSDService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private void btnDangNhap_Click(object sender, System.EventArgs e)
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
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu thông tin user vào biến global hoặc truyền vào form chính
                AppGlobals.CurrentUser = user;

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
