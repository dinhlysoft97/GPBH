namespace GPBH.UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.bConfigSignIn = new DevComponents.DotNetBar.ButtonItem();
            this.bConfigQueue4Corp = new DevComponents.DotNetBar.ButtonItem();
            this.bRequest = new DevComponents.DotNetBar.ButtonItem();
            this.cmdForQuantity = new DevComponents.DotNetBar.ButtonItem();
            this.TaskPane1 = new DevComponents.DotNetBar.DockContainerItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.cmdPacket = new DevComponents.DotNetBar.ButtonItem();
            this.PrintSetup = new System.Windows.Forms.PrintDialog();
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
            this.epMenu = new DevComponents.DotNetBar.ExpandablePanel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // bConfigSignIn
            // 
            this.bConfigSignIn.Name = "bConfigSignIn";
            // 
            // bConfigQueue4Corp
            // 
            this.bConfigQueue4Corp.Name = "bConfigQueue4Corp";
            // 
            // bRequest
            // 
            this.bRequest.Name = "bRequest";
            // 
            // cmdForQuantity
            // 
            this.cmdForQuantity.Name = "cmdForQuantity";
            // 
            // TaskPane1
            // 
            this.TaskPane1.Name = "TaskPane1";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // cmdPacket
            // 
            this.cmdPacket.Name = "cmdPacket";
            // 
            // PrintSetup
            // 
            this.PrintSetup.UseEXDialog = true;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
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
            this.bar1.Location = new System.Drawing.Point(0, 533);
            this.bar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1149, 19);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 60;
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
            // epMenu
            // 
            this.epMenu.AutoScroll = true;
            this.epMenu.CanvasColor = System.Drawing.SystemColors.Control;
            this.epMenu.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.epMenu.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.epMenu.DisabledBackColor = System.Drawing.Color.Empty;
            this.epMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.epMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epMenu.HideControlsWhenCollapsed = true;
            this.epMenu.Location = new System.Drawing.Point(0, 0);
            this.epMenu.Name = "epMenu";
            this.epMenu.Size = new System.Drawing.Size(180, 533);
            this.epMenu.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.epMenu.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.epMenu.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.epMenu.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.epMenu.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epMenu.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epMenu.Style.GradientAngle = 90;
            this.epMenu.TabIndex = 69;
            this.epMenu.TitleHeight = 27;
            this.epMenu.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epMenu.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.epMenu.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epMenu.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epMenu.TitleStyle.GradientAngle = 90;
            this.epMenu.TitleStyle.MarginLeft = 6;
            this.epMenu.TitleText = "Chức năng";
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(180, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 533);
            this.tabControl1.TabIndex = 70;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Text = "tabControl1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 552);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.epMenu);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMain";
            this.Text = "Giải pháp bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DevComponents.DotNetBar.ButtonItem cmdForQuantity;
        private DevComponents.DotNetBar.DockContainerItem TaskPane1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ButtonItem cmdPacket;
        private System.Windows.Forms.PrintDialog PrintSetup;
        private DevComponents.DotNetBar.ButtonItem bRequest;
        private DevComponents.DotNetBar.ButtonItem bConfigSignIn;
        private DevComponents.DotNetBar.ButtonItem bConfigQueue4Corp;
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
        private DevComponents.DotNetBar.ExpandablePanel epMenu;
        private DevComponents.DotNetBar.TabControl tabControl1;
    }
}



