using DevComponents.DotNetBar;
using DevComponents.Editors;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
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
        private readonly DMcaService _dmcaService;

        public Login(SysDMNSDService userService, SysDMCuaHangService storeService, DMcaService dmcaService)
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép bắt phím trên toàn form
            this.KeyDown += Form_KeyDown;

            _userService = userService;
            _storeService = storeService;
            _dmcaService = dmcaService;

            LoadCa();
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

        private void LoadCa()
        {
            var danhSachCa = _dmcaService.GetAll();
            var now = DateTime.Now.TimeOfDay;
            DMca caHienTai = null;

            foreach (var ca in danhSachCa)
            {
                if (TimeSpan.TryParse(ca.Gio_bd, out var gioBD) && TimeSpan.TryParse(ca.Gio_kt, out var gioKT))
                {
                    if (gioKT < gioBD)
                    {
                        if (now >= gioBD || now < gioKT)
                        {
                            caHienTai = ca;
                            break;
                        }
                    }
                    else
                    {
                        if (now >= gioBD && now < gioKT)
                        {
                            caHienTai = ca;
                            break;
                        }
                    }
                }
            }

            cbbCa.DataSource = danhSachCa;
            cbbCa.DisplayMember = "Ma_ca";
            cbbCa.ValueMember = "Ma_ca";
            if (caHienTai != null)
                cbbCa.SelectedValue = caHienTai.Ma_ca;
        }
    }
}