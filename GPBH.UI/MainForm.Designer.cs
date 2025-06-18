namespace GPBH.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sideBar1 = new DevComponents.DotNetBar.SideBar();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.collapsibleSplitContainer1 = new DevComponents.DotNetBar.Controls.CollapsibleSplitContainer();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.lbCopyright = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.lbTenDangNhap = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lbMaCH = new DevComponents.DotNetBar.LabelItem();
            this.lbMaQuay = new DevComponents.DotNetBar.LabelItem();
            this.lbMaKho = new DevComponents.DotNetBar.LabelItem();
            this.lbMayChu = new DevComponents.DotNetBar.LabelItem();
            this.lbCSDL = new DevComponents.DotNetBar.LabelItem();
            this.lbTgDangNhap = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // sideBar1
            // 
            this.sideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.sideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None;
            this.sideBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar1.ExpandedPanel = null;
            this.sideBar1.Location = new System.Drawing.Point(0, 0);
            this.sideBar1.Margin = new System.Windows.Forms.Padding(2);
            this.sideBar1.Name = "sideBar1";
            this.sideBar1.Size = new System.Drawing.Size(112, 862);
            this.sideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sideBar1.TabIndex = 0;
            this.sideBar1.Text = "sideBar1";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1314, 862);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Text = "tabControl1";
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.collapsibleSplitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.sideBar1);
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.AllowDrop = true;
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1443, 862);
            this.collapsibleSplitContainer1.SplitterDistance = 112;
            this.collapsibleSplitContainer1.SplitterWidth = 17;
            this.collapsibleSplitContainer1.TabIndex = 2;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.LightBlue;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lbCopyright,
            this.lbTenDangNhap,
            this.lbMaCH,
            this.lbMaQuay,
            this.lbMaKho,
            this.lbMayChu,
            this.lbCSDL,
            this.lbTgDangNhap});
            this.bar1.Location = new System.Drawing.Point(0, 843);
            this.bar1.Margin = new System.Windows.Forms.Padding(2);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1443, 19);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // lbCopyright
            // 
            this.lbCopyright.ForeColor = System.Drawing.Color.Red;
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.SingleLineColor = System.Drawing.Color.LightGray;
            this.lbCopyright.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem2});
            this.lbCopyright.Text = "Copyright@";
            this.lbCopyright.Width = 200;
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "labelItem1";
            this.labelItem2.Width = 500;
            // 
            // lbTenDangNhap
            // 
            this.lbTenDangNhap.ForeColor = System.Drawing.Color.Black;
            this.lbTenDangNhap.Name = "lbTenDangNhap";
            this.lbTenDangNhap.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1});
            this.lbTenDangNhap.Text = "Tên đăng nhập:";
            this.lbTenDangNhap.Width = 300;
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Black;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "Tên đăng nhập:";
            this.labelItem1.Width = 500;
            // 
            // lbMaCH
            // 
            this.lbMaCH.ForeColor = System.Drawing.Color.Black;
            this.lbMaCH.Name = "lbMaCH";
            this.lbMaCH.Text = "Mã cửa hàng:";
            this.lbMaCH.Width = 200;
            // 
            // lbMaQuay
            // 
            this.lbMaQuay.ForeColor = System.Drawing.Color.Black;
            this.lbMaQuay.Name = "lbMaQuay";
            this.lbMaQuay.Text = "Mã quày:";
            this.lbMaQuay.Width = 200;
            // 
            // lbMaKho
            // 
            this.lbMaKho.ForeColor = System.Drawing.Color.Black;
            this.lbMaKho.Name = "lbMaKho";
            this.lbMaKho.Text = "Mã kho:";
            this.lbMaKho.Width = 200;
            // 
            // lbMayChu
            // 
            this.lbMayChu.ForeColor = System.Drawing.Color.Black;
            this.lbMayChu.Name = "lbMayChu";
            this.lbMayChu.Text = "Máy chủ:";
            this.lbMayChu.Width = 250;
            // 
            // lbCSDL
            // 
            this.lbCSDL.ForeColor = System.Drawing.Color.Black;
            this.lbCSDL.Name = "lbCSDL";
            this.lbCSDL.Text = "CSDL:";
            this.lbCSDL.Width = 250;
            // 
            // lbTgDangNhap
            // 
            this.lbTgDangNhap.ForeColor = System.Drawing.Color.Black;
            this.lbTgDangNhap.Name = "lbTgDangNhap";
            this.lbTgDangNhap.Text = "Tg đăng nhập:";
            this.lbTgDangNhap.Width = 268;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 862);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Giải Pháp Bán Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SideBar sideBar1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.Controls.CollapsibleSplitContainer collapsibleSplitContainer1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelItem lbCopyright;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem lbTenDangNhap;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lbMaCH;
        private DevComponents.DotNetBar.LabelItem lbMaQuay;
        private DevComponents.DotNetBar.LabelItem lbMaKho;
        private DevComponents.DotNetBar.LabelItem lbMayChu;
        private DevComponents.DotNetBar.LabelItem lbCSDL;
        private DevComponents.DotNetBar.LabelItem lbTgDangNhap;
    }
}