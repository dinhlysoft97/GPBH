using DevComponents.DotNetBar;
using GPBH.UI.UserControls;
using System;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class FormMainDotNetBar : Office2007Form
    {
        public FormMainDotNetBar()
        {
            InitializeComponent();

            // Tạo menu mẫu (có thể tạo trong designer hoặc code)
            var group = new DevComponents.DotNetBar.SideBarPanelItem() { Text = "Quản lý" };
            var item1 = new DevComponents.DotNetBar.ButtonItem("btnUser", "Quản lý người dùng");
            var item2 = new DevComponents.DotNetBar.ButtonItem("btnProduct", "Quản lý sản phẩm");

            // Nếu muốn có menu con, dùng SubItems
            var subMenu = new DevComponents.DotNetBar.ButtonItem("btnCategory", "Quản lý danh mục");
            var subMenuChild = new DevComponents.DotNetBar.ButtonItem("btnCategoryChild", "Danh mục con");
            subMenu.SubItems.Add(subMenuChild);

            group.SubItems.Add(item1);
            group.SubItems.Add(item2);
            group.SubItems.Add(subMenu);
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

            // Gắn event đóng tab
            tabControl1.TabItemClose += TabControl1_TabItemClose;
        }

        // Xử lý click menu
        private void Menu_Click(object sender, EventArgs e)
        {
            var btn = sender as ButtonItem;
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
                case "btnUser":
                    uc = new UserControlDonHang();
                    break;
                case "btnProduct":
                    uc = new UserControlBanHangTheoKhachHang();
                    break;
                default:
                    MessageBox.Show("Tính năng đang phát triển!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
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
            //if (e.Action == eTabStripAction.Close)
            //{
                tabControl1.Tabs.Remove(e.TabItem);
                tabControl1.Controls.Remove(e.TabItem.AttachedControl);
           // }
        }
    }
}
