using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Forms;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class MainForm : Office2007Form
    {
        private readonly SysMenuService _sysMenuService;

        public MainForm(SysMenuService sysMenuService, DMcaService dMcaService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _sysMenuService = sysMenuService;
            BuildMenu();
            SetData();
            this.FormClosed += MainForm_FormClosed;
            this.FormClosing += MainForm_FormClosing;
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

        private void BuildMenu()
        {
            var menus = _sysMenuService.GetAllMenus();
            // Tạo menu mẫu (có thể tạo trong designer hoặc code)
            var group = new SideBarPanelItem() { Text = "Menu" };
            var nodeBanHang = new ButtonItem("banHang", "Bán hàng");
            var nodeBaoCao = new ButtonItem("baoCao", "Báo cáo");
            var nodeDanhMuc = new ButtonItem("danhMuc", "Danh mục");
            var nodeCaiDat = new ButtonItem("caiDat", "Cài đặt");

            ImageList imgList = new ImageList();
            SetImages(imgList);

            foreach (var menu in menus.OrderBy(z => z.Type).OrderBy(z => z.Stt))
            {
                var subMenu = new ButtonItem(menu.MenuId, menu.MenuName);

                int index = imgList.Images.IndexOfKey(menu.Picture);
                if (index == -1)
                    index = 0;
                subMenu.ImageIndex = index;

                if (menu.Type == SysMenuType.Document) nodeBanHang.SubItems.Add(subMenu);
                if (menu.Type == SysMenuType.Report) nodeBaoCao.SubItems.Add(subMenu);
                if (menu.Type == SysMenuType.Category) nodeDanhMuc.SubItems.Add(subMenu);
                if (menu.Type == SysMenuType.Setting) nodeCaiDat.SubItems.Add(subMenu);
            }

            group.SubItems.Add(nodeBanHang);
            group.SubItems.Add(nodeBaoCao);
            group.SubItems.Add(nodeDanhMuc);
            group.SubItems.Add(nodeCaiDat);
            sideBar1.Panels.Add(group);

            // Gắn event click cho toàn bộ menu
            foreach (ButtonItem btn in group.SubItems)
            {
                btn.Click += Menu_Click;
                if (btn.SubItems.Count > 0)
                {
                    foreach (ButtonItem c in btn.SubItems)
                        c.Click += Menu_Click;
                }
            }

            // ======= VẼ DẤU X VÀ ĐÓNG TAB TRÊN TABCONTROL =======
            // Đăng ký sự kiện vẽ custom nút Close
            tabControl1.CloseButtonOnTabsVisible = true;     // Hiển thị nút x trên từng tab
            tabControl1.CloseButtonVisible = false;           // Ẩn nút x tổng
            tabControl1.CloseButtonPosition = eTabCloseButtonPosition.Right;
            tabControl1.TabItemClose += TabControl1_TabItemClose;
        }

        private void SetImages(ImageList imgList)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            imgList.Images.Add("empty", emptyBitmap);
            //imgList.Images
            //    .Add("banhang", Image.FromFile(Path.Combine(Application.StartupPath, "Images", "banhang.png")));         // index 0
            //imgList.Images
            //    .Add("baocaobanhang", Image.FromFile(Path.Combine(Application.StartupPath, "Images", "baocaobanhang.png")));   // index 1
            sideBar1.Images = imgList;
        }

        // Xử lý click menu
        private void Menu_Click(object sender, EventArgs e)
        {
            var btn = sender as ButtonItem;
            if (btn != null && btn.SubItems.Count > 0)
            {
                // Menu cha có subitems, bỏ qua click
                return;
            }

            if (btn == null) return;
            OpenTab(btn.Name, btn.Text);
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
                    uc = new UserControlBanHangTheoKhachHang();
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
                    MessageBoxEx.Show("Tính năng đang phát triển!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void OpenTab(string key, string title, UserControl uc)
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


            uc.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);

            tabControl1.Controls.Add(panel);
            tabControl1.Tabs.Add(newTab);
            newTab.AttachedControl = panel;

            tabControl1.SelectedTab = newTab;
        }

        // Sự kiện đóng tab
        private void TabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            // Đóng tab khi bấm nút x trên tab
            tabControl1.Tabs.Remove(e.TabItem);
            if (e.TabItem.AttachedControl != null)
                tabControl1.Controls.Remove(e.TabItem.AttachedControl);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ví dụ: hỏi người dùng xác nhận trước khi đóng
            var result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn không cho đóng form
            }
            else
            {
                foreach (Form frm in Application.OpenForms.OfType<Form>().ToList())
                {
                    if (!(frm is MainForm))
                        frm.Close();
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Xử lý giải phóng tài nguyên, ghi log, v.v.
        }
    }
}