using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.UI.Extentions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class DoiMatKhau : Office2007Form
    {
        private readonly SysDMNSDService _sysDMNSDService;
        public DoiMatKhau(SysDMNSDService sysDMNSDService)
        {
            InitializeComponent();
            _sysDMNSDService = sysDMNSDService;

            LoadData(AppGlobals.CurrentUser.TenDangNhap);
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click; ;
            btnDong.Click += BtnDong_Click;
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.ColseForm();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var validator = ValidatorData();
            if (validator)
            {
                lbError.Text = "";
                lbError.BackColor = System.Drawing.Color.Transparent;
                var nguoiDung = _sysDMNSDService.DangNhap(txtTenDangNhap.Text, txtMatKhauCu.Text);
                if (nguoiDung != null)
                {
                    _sysDMNSDService.DoiMatKhau(nguoiDung.TenDangNhap, txtMatKhauMoi.Text);
                    MessageBoxEx.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var result = MessageBoxEx.Show("Báo bạn cần phải đăng nhập lại phần mềm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        AppGlobals.CurrentUser = null;
                        foreach (Form frm in Application.OpenForms.OfType<Form>().ToList())
                        {
                            if (!(frm is Login))
                                frm.Close();
                            else
                                frm.Show();
                        }
                    }
                }
                else
                {
                    MessageBoxEx.Show("Mật khẩu không đúng. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhauCu.Focus();
                }
            }
        }

        private bool ValidatorData()
        {
            var result = true;
            string message = string.Empty;

            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
            {
                txtMatKhauCu.Focus();
                message = "Mật khẩu cũ không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                txtMatKhauCu.Focus();
                message = "Mật khẩu mới không được để trống.";
                result = false;
            }
            else if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                txtXacNhanMatKhau.Focus();
                message = "Mật khẩu xác nhận không được để trống.";
                result = false;
            }
            else if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
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
        private void LoadData(string tenDangNhap)
        {
            txtTenDangNhap.Enabled = false;

            var data = _sysDMNSDService.GetByTenDangNhap(tenDangNhap);
            txtTenDangNhap.Text = data.TenDangNhap;
        }
    }
}
