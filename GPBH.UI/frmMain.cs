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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            BuildMenu();
            SetData();
            this.KeyDown += frmMain_KeyDown; ;
            this.FormClosed += frmMain_FormClosed;
            this.FormClosing += frmMain_FormClosing;
            this.Load += frmMain_Load;
        }
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Xử lý giải phóng tài nguyên, ghi log, v.v.
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bool bXem = CheckPermissionHelper.HasPerrmission("Donhang", GPBHConstant.Action.Xem);
            if (bXem)
            {
                OpenTab("DonHang", "Màn hình chính", ActivatorUtilities.CreateInstance<UserControlDonHang>(Program.ServiceProvider));
                this.Focus();
            }
        }
        // Sự kiện đóng tab
        private void TabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            // Đóng tab khi bấm nút x trên tab
            tabControl1.Tabs.Remove(e.TabItem);
            if (e.TabItem.AttachedControl != null)
                tabControl1.Controls.Remove(e.TabItem.AttachedControl);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Kiểm tra nếu ALT+F4
                if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                {
                    // Chặn đóng form
                    e.Cancel = true;
                }
                else
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
                            if (!(frm is frmMain))
                                frm.Close();
                        }
                    }
                }
            }
        }
        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BuildDynamicMenu(string menuName, string menuTitle, int tabIndex, List<SysMenu> subMenu)
        {
            DevComponents.DotNetBar.ExpandablePanel expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();

            expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;

            expandablePanel2.DisabledBackColor = System.Drawing.Color.Empty;
            expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            expandablePanel2.ExpandOnTitleClick = true;
            expandablePanel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            expandablePanel2.Location = new System.Drawing.Point(0, 344);
            expandablePanel2.Margin = new System.Windows.Forms.Padding(6);
            expandablePanel2.Name = menuName;
            expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel2.Style.GradientAngle = 90;
            expandablePanel2.TabIndex = tabIndex;
            expandablePanel2.TitleHeight = 45;
            expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            expandablePanel2.TitleStyle.GradientAngle = 90;
            expandablePanel2.TitleStyle.MarginLeft = 12;
            expandablePanel2.TitleText = menuTitle;
            expandablePanel2.Height = subMenu.Count * 32 + expandablePanel2.TitleHeight;

            var ipSubMenuContain = new ItemPanel();
            ipSubMenuContain.BackgroundStyle.BackColor = System.Drawing.Color.White;
            ipSubMenuContain.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            ipSubMenuContain.BackgroundStyle.BorderBottomWidth = 1;
            ipSubMenuContain.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            ipSubMenuContain.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            ipSubMenuContain.BackgroundStyle.BorderLeftWidth = 1;
            ipSubMenuContain.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            ipSubMenuContain.BackgroundStyle.BorderRightWidth = 1;
            ipSubMenuContain.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            ipSubMenuContain.BackgroundStyle.BorderTopWidth = 1;
            ipSubMenuContain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ipSubMenuContain.BackgroundStyle.PaddingBottom = 1;
            ipSubMenuContain.BackgroundStyle.PaddingLeft = 1;
            ipSubMenuContain.BackgroundStyle.PaddingRight = 1;
            ipSubMenuContain.BackgroundStyle.PaddingTop = 1;
            ipSubMenuContain.ContainerControlProcessDialogKey = true;
            ipSubMenuContain.Dock = System.Windows.Forms.DockStyle.Fill;
            ipSubMenuContain.DragDropSupport = true;

            ipSubMenuContain.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            ipSubMenuContain.Location = new System.Drawing.Point(0, 52);
            ipSubMenuContain.Margin = new System.Windows.Forms.Padding(6);
            ipSubMenuContain.Name = "ip" + menuName;
            ipSubMenuContain.ReserveLeftSpace = false;
            //ipSubMenuContain.Size = new System.Drawing.Size(288, 240);
            ipSubMenuContain.TabIndex = 3;
            ipSubMenuContain.Text = "#";
            foreach (var ob in subMenu)
            {
                var hasPermission = CheckPermissionHelper.HasPerrmission(ob.MenuId, GPBHConstant.Action.Xem);
                if (hasPermission && (int)ob.Type == tabIndex)
                {
                    ButtonItem buttonItem = new ButtonItem();
                    buttonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    // Corrected line: Convert the string path to an Icon object
                    if (!string.IsNullOrEmpty(ob.Picture) && File.Exists(Application.StartupPath + @"\Images\" + ob.Picture))
                    {
                        buttonItem.Image = Image.FromFile(Application.StartupPath + @"\Images\" + ob.Picture);
                    }
                    else
                    {
                        buttonItem.Image = Image.FromFile(Application.StartupPath + @"\Images\empty.png");
                    }
                    buttonItem.Name = ob.MenuId;
                    buttonItem.Text = ob.MenuName;
                    buttonItem.Click += new System.EventHandler(Menu_Click);

                    ipSubMenuContain.Items.Add(buttonItem, ipSubMenuContain.Items.Count);
                }
            }
            if (ipSubMenuContain.Items.Count == 0)
            {
                // Nếu không có menu con nào thì không cần tạo ExpandablePanel
                return;
            }
            expandablePanel2.Controls.Add(ipSubMenuContain);
            epMenu.Controls.Add(expandablePanel2);
            expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            if (tabIndex == 1)
            {
                expandablePanel2.Expanded = true; // Mặc định mở rộng menu Bán hàng
            }
            else
            {
                expandablePanel2.Expanded = false; // Các menu khác thì thu gọn
            }
            ipSubMenuContain.Refresh();
            expandablePanel2.Refresh();
        }
        public class MenuData
        {
            public string Name { get; set; }
            public string Title { get; set; }
            public int Type { get; set; }
        }
        private void BuildMenu()
        {
            var menuDatas = _sysMenuService.GetAllMenus();
            // Tạo menu mẫu (có thể tạo trong designer hoặc code)
            var menus = new List<MenuData>
            {
                new MenuData { Name = "banHang", Title = "Bán hàng", Type = 1 },
                new MenuData { Name = "baoCao", Title = "Báo cáo", Type = 2 },
                new MenuData { Name = "danhMuc", Title = "Danh mục", Type = 3 },
                new MenuData { Name = "caiDat", Title = "Cài đặt", Type = 4 }
            };
            foreach (var menu in menus.OrderByDescending(o => o.Type))
            {
                var subMenu = menuDatas.Where(w => (int)w.Type == menu.Type).OrderBy(z => z.Stt).ToList();
                BuildDynamicMenu(menu.Name, menu.Title, menu.Type, subMenu);
            }

            epMenu.ResumeLayout(false);

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
            //sideBar1.Images = imgList;
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
                case "TaoDonHang":
                    //form = ActivatorUtilities.CreateInstance<DonHang>(Program.ServiceProvider);
                    form = ActivatorUtilities.CreateInstance<DonHang1>(Program.ServiceProvider);
                    if (form is DonHang1 formNew)
                    {
                        if (formNew.FormKhachHangIsClose)
                        {
                            formNew.Hide();
                        }
                        else
                        {
                            formNew.ShowDialog();
                        }
                        return;
                    }
                    break;
                case "DonHang":
                    uc = ActivatorUtilities.CreateInstance<UserControlDonHang>(Program.ServiceProvider);
                    break;
                case "BanHangTheoKhachHang":
                    uc = ActivatorUtilities.CreateInstance<UserControlBanHangTheoKhachHang>(Program.ServiceProvider);
                    break;
                case "DinhDangForm":
                    uc = ActivatorUtilities.CreateInstance<UserControlDinhDangForm>(Program.ServiceProvider);
                    break;
                case "NguoiDung":
                    uc = ActivatorUtilities.CreateInstance<UserControlNguoiSuDung>(Program.ServiceProvider);
                    break;
                case "ThamSo":
                    uc = ActivatorUtilities.CreateInstance<UserControlThamSo>(Program.ServiceProvider);
                    break;
                case "DoiMatKhau":
                    form = ActivatorUtilities.CreateInstance<DoiMatKhau>(Program.ServiceProvider);
                    break;
                case "Ca":
                    uc = ActivatorUtilities.CreateInstance<UserControlCa>(Program.ServiceProvider);
                    break;
                case "QuocGia":
                    uc = ActivatorUtilities.CreateInstance<UserControlQuocGia>(Program.ServiceProvider);
                    break;
                case "KhachHang":
                    uc = ActivatorUtilities.CreateInstance<UserControlKhachHang>(Program.ServiceProvider);
                    break;
                case "HangHoa":
                    uc = ActivatorUtilities.CreateInstance<UserControlHangHoa>(Program.ServiceProvider);
                    break;
                case "NgoaiTe":
                    uc = ActivatorUtilities.CreateInstance<UserControlNgoaiTe>(Program.ServiceProvider);
                    break;
                case "TyGia":
                    uc = ActivatorUtilities.CreateInstance<UserControlTyGia>(Program.ServiceProvider);
                    break;
                case "GiaBan":
                    uc = ActivatorUtilities.CreateInstance<UserControlGiaBan>(Program.ServiceProvider);
                    break;
                default:
                    MessageBoxEx.Show("Bạn không có quyền truy cập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            if (form != null)
            {
                form.ShowDialog();
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
    }
}
