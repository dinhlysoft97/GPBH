using GPBH.Business.Services;
using GPBH.UI.UserControls;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class MainForm : Form
    {
        private readonly SysMenuService _sysMenuService;
        public MainForm(SysMenuService sysMenuService)
        {
            InitializeComponent();
            _sysMenuService = sysMenuService;

            CreateMenu();
            treeViewMenu.AfterSelect += TreeViewMenu_AfterSelect;
            tabControlMain.DrawItem += TabControlMain_DrawItem;
            tabControlMain.MouseDown += TabControlMain_MouseDown; // Để đóng tab bằng click giữa
        }

        // Tạo menu 2 cấp mẫu
        private void CreateMenu()
        {
            ImageList imgList = new ImageList();

            Bitmap emptyBitmap = new Bitmap(16, 16);
            imgList.Images.Add("empty", emptyBitmap);
            imgList.Images
                .Add("banhang", Image.FromFile(Path.Combine(Application.StartupPath, "Images", "banhang.png")));         // index 0
            imgList.Images
                .Add("baocaobanhang", Image.FromFile(Path.Combine(Application.StartupPath, "Images", "baocaobanhang.png")));   // index 1
            treeViewMenu.ImageList = imgList;

            var menus = _sysMenuService.GetAllMenus();
            // Menu gốc
            TreeNode nodeBanHang = new TreeNode("Bán hàng") { Name = "banHang" };
            TreeNode nodeBaoCao = new TreeNode("Báo cáo") { Name = "baoCao" };
            TreeNode nodeDanhMuc = new TreeNode("Danh mục") { Name = "danhMuc" };
            TreeNode nodeCaiDat = new TreeNode("Cài đặt") { Name = "caiDat" };


            foreach (var menu in menus)
            {
                if (menu.Type == 1) // chứng từ
                {
                    TreeNode node = new TreeNode(menu.MenuName) { Name = menu.Key };
                    if (!string.IsNullOrEmpty(menu.Picture))
                    {
                        node.ImageKey = menu.Picture;
                        node.SelectedImageKey = menu.Picture;
                    }
                    nodeBanHang.Nodes.Add(node);
                }
                if (menu.Type == 2) // báo cáo
                {
                    TreeNode node = new TreeNode(menu.MenuName) { Name = menu.Key };
                    if (!string.IsNullOrEmpty(menu.Picture))
                    {
                        node.ImageKey = menu.Picture;
                        node.SelectedImageKey = menu.Picture;
                    }
                    nodeBaoCao.Nodes.Add(node);
                }
                if (menu.Type == 3) // danh mục
                {
                    TreeNode node = new TreeNode(menu.MenuName) { Name = menu.Key };
                    if (!string.IsNullOrEmpty(menu.Picture))
                    {
                        node.ImageKey = menu.Picture;
                        node.SelectedImageKey = menu.Picture;
                    }
                    nodeDanhMuc.Nodes.Add(node);
                }
            }

            treeViewMenu.Nodes.Add(nodeBanHang);
            treeViewMenu.Nodes.Add(nodeBaoCao);
            treeViewMenu.Nodes.Add(nodeDanhMuc);
            treeViewMenu.Nodes.Add(nodeCaiDat);

            treeViewMenu.ExpandAll();
        }

        // Xử lý chọn menu
        private void TreeViewMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Chỉ thao tác khi chọn node con
            if (e.Node.Parent == null) return;

            string key = e.Node.Name;
            string title = e.Node.Text;

            OpenTab(key, title);
        }

        // Mở tab động
        private void OpenTab(string key, string title)
        {
            // Đã có tab chưa?
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (page.Name == key)
                {
                    tabControlMain.SelectedTab = page;
                    return;
                }
            }

            TabPage newPage = new TabPage(title) { Name = key };
            UserControl uc = null;
            switch (key)
            {
                case "DonHang":
                    uc = new UserControlDonHang();
                    break;

                case "BanHangTheoKhachHang":
                    uc = new UserControlBanHangTheoKhachHang();
                    break;

                default:
                    MessageBox.Show("Tính năng đang phát triển!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
            uc.Dock = DockStyle.Fill;
            newPage.Controls.Add(uc);
            tabControlMain.TabPages.Add(newPage);
            tabControlMain.SelectedTab = newPage;
        }

        // Đóng tab bằng click x
        private void TabControlMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < tabControlMain.TabPages.Count; i++)
                {
                    if (tabControlMain.GetTabRect(i).Contains(e.Location))
                    {
                        tabControlMain.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }

            for (int i = 0; i < tabControlMain.TabCount; i++)
            {
                Rectangle tabRect = tabControlMain.GetTabRect(i);
                Rectangle closeRect = new Rectangle(tabRect.Right - 18, tabRect.Top + (tabRect.Height - 12) / 2, 12, 12);

                if (closeRect.Contains(e.Location))
                {
                    tabControlMain.TabPages.RemoveAt(i);
                    break;
                }
            }

        }

        private void TabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = tabControlMain.TabPages[e.Index];
            var tabRect = tabControlMain.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            // Vẽ tiêu đề tab
            TextRenderer.DrawText(e.Graphics, tabPage.Text, e.Font,
                tabRect, tabPage.ForeColor, TextFormatFlags.Left);

            // Vẽ dấu X bên phải tab
            int x = tabRect.Right - 15;
            int y = tabRect.Top + (tabRect.Height - 12) / 2;
            Rectangle closeRect = new Rectangle(x, y, 12, 12);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.Gray, 2))
            {
                // Vẽ hình dấu X
                e.Graphics.DrawLine(pen, x + 3, y + 3, x + 9, y + 9);
                e.Graphics.DrawLine(pen, x + 9, y + 3, x + 3, y + 9);
            }

            // Nếu muốn highlight tab đang chọn
            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.DrawRectangle(Pens.DarkBlue, tabRect);
            }
        }
    }
}