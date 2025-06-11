using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class MainForm : Office2007Form
    {
        private readonly SysMenuService _sysMenuService;

        public MainForm(SysMenuService sysMenuService)
        {
            InitializeComponent();
            _sysMenuService = sysMenuService;
            BuildMenu();
            SetData();
        }

        private void SetData()
        {
            lbCopyright.Text = $"Copyright© {DateTime.Now.Year}";
            lbTenDangNhap.Text = $"Tên đăng nhâp: {AppGlobals.CurrentUser.TenDangNhap}";
            lbMayChu.Text = "Máy chủ: (local)";
            lbCSDL.Text = "CSDL: GPBHDb";
            lbMaCH.Text = $"Mã cửa hàng: {AppGlobals.MaCH}";
            lbMaQuay.Text = $"Mã quầy: {AppGlobals.MaQuay}";
            lbTgDangNhap.Text = $"Thời gian đăng nhập: {AppGlobals.TgDangNhap.ToString("dd/MM/yyyy HH:mm")}";
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
            imgList.Images
                .Add("banhang", Image.FromFile(Path.Combine(Application.StartupPath, "Images", "banhang.png")));         // index 0
            imgList.Images
                .Add("baocaobanhang", Image.FromFile(Path.Combine(Application.StartupPath, "Images", "baocaobanhang.png")));   // index 1
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
            switch (key)
            {
                case "DonHang":
                    uc = new UserControlDonHang();
                    break;
                case "BanHangTheoKhachHang":
                    uc = new UserControlBanHangTheoKhachHang();
                    break;
                case "NguoiDung":
                    uc = ActivatorUtilities.CreateInstance<UserControlNguoiSuDung>(Program.ServiceProvider);
                    break;
                default:
                    MessageBoxEx.Show("Tính năng đang phát triển!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
            uc.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);

            tabControl1.Controls.Add(panel);
            tabControl1.Tabs.Add(newTab);
            newTab.AttachedControl = panel;

            tabControl1.SelectedTab = newTab;
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
    }
}