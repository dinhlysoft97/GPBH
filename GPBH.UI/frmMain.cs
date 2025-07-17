using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Constant;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class frmMain : Office2007Form
    {
        private readonly SysMenuService _sysMenuService;
        public frmMain(SysMenuService sysMenuService, DMcaService dMcaService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _sysMenuService = sysMenuService;
            SetData();
            this.FormClosing += frmMain_FormClosing;
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExportDataTool_Click(object sender, EventArgs e)
        {
           
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void expandableSplitter1_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {

        }
        // Mở tab động, mỗi menu 1 UserControl
        private void OpenTab(string key, string title)
        {
            // Nếu đã có tab thì chuyển qua
            foreach (TabItem tab in tabControl1.Tabs)
            {
                if (tab.Name == key)
                {
                    tabControl1.SelectedTab = tab;
                    return;
                }
            }

            // Tạo tab mới
            var newTab = new TabItem() { Text = title, Name = key };
            var panel = new TabControlPanel();
            panel.Dock = DockStyle.Fill;
            panel.TabItem = newTab;

            // Dùng UserControl tương ứng
            UserControl uc = null;
            Form form = null;
            switch (key)
            {
                case "DonHang":
                    uc = ActivatorUtilities.CreateInstance<UserControlDonHang>(Program.ServiceProvider);
                    break;
                case "BanHangTheoKhachHang":
                    uc = ActivatorUtilities.CreateInstance<UserControlBanHangTheoKhachHang>(Program.ServiceProvider);
                    break;
                case "DinhDangForm":
                    form = ActivatorUtilities.CreateInstance<DinhDangForm>(Program.ServiceProvider);
                    break;
                case "NguoiDung":
                    uc = ActivatorUtilities.CreateInstance<UserControlNguoiSuDung>(Program.ServiceProvider);
                    break;
                case "ThamSo":
                    form = ActivatorUtilities.CreateInstance<ThamSo>(Program.ServiceProvider);
                    break;
                case "DoiMatKhau":
                    form = ActivatorUtilities.CreateInstance<DoiMatKhau>(Program.ServiceProvider);
                    break;
                case "Ca":
                    form = ActivatorUtilities.CreateInstance<FormCa>(Program.ServiceProvider);
                    break;
                case "QuocGia":
                    form = ActivatorUtilities.CreateInstance<QuocGia>(Program.ServiceProvider);
                    break;
                case "KhachHang":
                    uc = ActivatorUtilities.CreateInstance<UserControlKhachHang>(Program.ServiceProvider);
                    break;
                case "HangHoa":
                    form = ActivatorUtilities.CreateInstance<HangHoa>(Program.ServiceProvider);
                    break;
                case "NgoaiTe":
                    form = ActivatorUtilities.CreateInstance<NgoaiTe>(Program.ServiceProvider);
                    break;
                case "TyGia":
                    form = ActivatorUtilities.CreateInstance<TyGia>(Program.ServiceProvider);
                    break;
                case "GiaBan":
                    form = ActivatorUtilities.CreateInstance<GiaBan>(Program.ServiceProvider);
                    break;
                default:
                    MessageBoxEx.Show("Bạn không có quyền truy cập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            if (form != null)
            {
                form.Show();
            }
            else
            {
                uc.Dock = DockStyle.Fill;
                panel.Controls.Add(uc);
                tabControl1.Controls.Add(panel);
                tabControl1.Tabs.Add(newTab);
                newTab.AttachedControl = panel;

                tabControl1.SelectedTab = newTab;
            }
        }

        private void SetData()
        {
            lbCopyright.Text = $"Copyright© {DateTime.Now.Year}";
            lbTenDangNhap.Text = $"Tên đăng nhâp: {AppGlobals.CurrentUser.TenDangNhap}";
            lbMayChu.Text = $"Máy chủ: {AppGlobals.Host} {(!string.IsNullOrEmpty(AppGlobals.Port) ? $", {AppGlobals.Port}" : string.Empty)}";
            lbCSDL.Text = $"CSDL: {AppGlobals.Database}";
            lbMaCH.Text = $"Mã cửa hàng: {AppGlobals.MaCH}";
            lbMaQuay.Text = $"Mã quầy: {AppGlobals.MaQuay}";
            lbMaKho.Text = $"Mã kho: {AppGlobals.MaKho}";
            lbTgDangNhap.Text = $"Thời gian đăng nhập: {AppGlobals.TgDangNhap:dd/MM/yyyy HH:mm}";
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnDonhang_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnBanhangtheokhach_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            // Ví dụ: hỏi người dùng xác nhận trước khi đóng
            var result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Ngăn không cho đóng form
            }
            else
            {
                foreach (Form frm in Application.OpenForms.OfType<Form>().ToList())
                {
                    if (!(frm is frmMain))
                        frm.Close();
                }
                Application.Exit();
            }
        }

        private void btnThamso_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;    
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnNguoidung_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnCabanhang_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnQuocgia_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnNgoaite_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnTygia_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnKhachhang_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnHanghoa_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnGiaban_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void btnDinhdangform_Click(object sender, EventArgs e)
        {
            var ctlButton = (ButtonX)sender;
            OpenTab(ctlButton.Tag.ToString(), ctlButton.Text);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           // btnDonhang_Click(btnBanhang as object, e);
        }
    }
}
