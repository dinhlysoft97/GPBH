namespace GPBH.UI.Forms
{
    partial class KhachHang
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtCCCD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbbQuocTich = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtHo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenDem = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSDT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtNgayCap = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dtHetHan = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtNgaySinh = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.btnChon = new DevComponents.DotNetBar.ButtonX();
            this.lbMessage = new DevComponents.DotNetBar.LabelX();
            this.cbbGioiTinh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDiaChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHetHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(25, 33);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 15);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Số passport/CCCD*";
            // 
            // txtCCCD
            // 
            // 
            // 
            // 
            this.txtCCCD.Border.Class = "TextBoxBorder";
            this.txtCCCD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCCCD.Location = new System.Drawing.Point(144, 30);
            this.txtCCCD.MaxLength = 20;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.PreventEnterBeep = true;
            this.txtCCCD.Size = new System.Drawing.Size(222, 20);
            this.txtCCCD.TabIndex = 1;
            this.txtCCCD.TextChanged += new System.EventHandler(this.txtCCCD_TextChanged);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(373, 33);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(53, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Quốc tịch*";
            // 
            // cbbQuocTich
            // 
            this.cbbQuocTich.DisplayMember = "Text";
            this.cbbQuocTich.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbQuocTich.FormattingEnabled = true;
            this.cbbQuocTich.ItemHeight = 14;
            this.cbbQuocTich.Location = new System.Drawing.Point(432, 30);
            this.cbbQuocTich.Name = "cbbQuocTich";
            this.cbbQuocTich.Size = new System.Drawing.Size(129, 20);
            this.cbbQuocTich.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbQuocTich.TabIndex = 2;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(25, 64);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(85, 15);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Tên khách hàng*";
            // 
            // txtHo
            // 
            // 
            // 
            // 
            this.txtHo.Border.Class = "TextBoxBorder";
            this.txtHo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHo.Location = new System.Drawing.Point(144, 61);
            this.txtHo.Name = "txtHo";
            this.txtHo.PreventEnterBeep = true;
            this.txtHo.Size = new System.Drawing.Size(133, 20);
            this.txtHo.TabIndex = 3;
            // 
            // txtTenDem
            // 
            // 
            // 
            // 
            this.txtTenDem.Border.Class = "TextBoxBorder";
            this.txtTenDem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDem.Location = new System.Drawing.Point(289, 61);
            this.txtTenDem.Name = "txtTenDem";
            this.txtTenDem.PreventEnterBeep = true;
            this.txtTenDem.Size = new System.Drawing.Size(133, 20);
            this.txtTenDem.TabIndex = 4;
            // 
            // txtTen
            // 
            // 
            // 
            // 
            this.txtTen.Border.Class = "TextBoxBorder";
            this.txtTen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTen.Location = new System.Drawing.Point(431, 61);
            this.txtTen.Name = "txtTen";
            this.txtTen.PreventEnterBeep = true;
            this.txtTen.Size = new System.Drawing.Size(130, 20);
            this.txtTen.TabIndex = 5;
            // 
            // txtSDT
            // 
            // 
            // 
            // 
            this.txtSDT.Border.Class = "TextBoxBorder";
            this.txtSDT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSDT.Location = new System.Drawing.Point(144, 93);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.PreventEnterBeep = true;
            this.txtSDT.Size = new System.Drawing.Size(133, 20);
            this.txtSDT.TabIndex = 6;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(25, 96);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(71, 15);
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "Số điện thoại*";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(373, 96);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(43, 15);
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "Giới tính";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(25, 157);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(49, 15);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "Ngày cấp";
            // 
            // dtNgayCap
            // 
            // 
            // 
            // 
            this.dtNgayCap.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtNgayCap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayCap.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtNgayCap.ButtonDropDown.Visible = true;
            this.dtNgayCap.IsPopupCalendarOpen = false;
            this.dtNgayCap.Location = new System.Drawing.Point(144, 154);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtNgayCap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayCap.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtNgayCap.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtNgayCap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayCap.MonthCalendar.DisplayMonth = new System.DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtNgayCap.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtNgayCap.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgayCap.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtNgayCap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayCap.MonthCalendar.TodayButtonVisible = true;
            this.dtNgayCap.Name = "dtNgayCap";
            this.dtNgayCap.Size = new System.Drawing.Size(133, 20);
            this.dtNgayCap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtNgayCap.TabIndex = 9;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(373, 157);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(41, 15);
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "Hết hạn";
            // 
            // dtHetHan
            // 
            // 
            // 
            // 
            this.dtHetHan.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtHetHan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHetHan.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtHetHan.ButtonDropDown.Visible = true;
            this.dtHetHan.IsPopupCalendarOpen = false;
            this.dtHetHan.Location = new System.Drawing.Point(432, 154);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtHetHan.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHetHan.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtHetHan.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtHetHan.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHetHan.MonthCalendar.DisplayMonth = new System.DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtHetHan.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtHetHan.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHetHan.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtHetHan.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHetHan.MonthCalendar.TodayButtonVisible = true;
            this.dtHetHan.Name = "dtHetHan";
            this.dtHetHan.Size = new System.Drawing.Size(129, 20);
            this.dtHetHan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtHetHan.TabIndex = 10;
            // 
            // dtNgaySinh
            // 
            // 
            // 
            // 
            this.dtNgaySinh.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtNgaySinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtNgaySinh.ButtonDropDown.Visible = true;
            this.dtNgaySinh.IsPopupCalendarOpen = false;
            this.dtNgaySinh.Location = new System.Drawing.Point(144, 185);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtNgaySinh.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.MonthCalendar.DisplayMonth = new System.DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.MonthCalendar.TodayButtonVisible = true;
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(133, 20);
            this.dtNgaySinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtNgaySinh.TabIndex = 11;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(25, 188);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(51, 15);
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "Ngày sinh";
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.Location = new System.Drawing.Point(144, 216);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PreventEnterBeep = true;
            this.txtEmail.Size = new System.Drawing.Size(222, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(25, 219);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(30, 15);
            this.labelX9.TabIndex = 17;
            this.labelX9.Text = "Email";
            // 
            // btnChon
            // 
            this.btnChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChon.Location = new System.Drawing.Point(486, 252);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(75, 23);
            this.btnChon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChon.TabIndex = 18;
            this.btnChon.Text = "Chọn (Enter)";
            // 
            // lbMessage
            // 
            // 
            // 
            // 
            this.lbMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMessage.ForeColor = System.Drawing.Color.Black;
            this.lbMessage.Location = new System.Drawing.Point(25, 252);
            this.lbMessage.MaximumSize = new System.Drawing.Size(437, 23);
            this.lbMessage.MinimumSize = new System.Drawing.Size(437, 23);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(437, 23);
            this.lbMessage.TabIndex = 21;
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.DisplayMember = "Text";
            this.cbbGioiTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.ItemHeight = 14;
            this.cbbGioiTinh.Location = new System.Drawing.Point(432, 93);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(129, 20);
            this.cbbGioiTinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbGioiTinh.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            // 
            // 
            // 
            this.txtDiaChi.Border.Class = "TextBoxBorder";
            this.txtDiaChi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiaChi.Location = new System.Drawing.Point(144, 123);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PreventEnterBeep = true;
            this.txtDiaChi.Size = new System.Drawing.Size(417, 20);
            this.txtDiaChi.TabIndex = 8;
            // 
            // labelX15
            // 
            this.labelX15.AutoSize = true;
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(25, 126);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(36, 15);
            this.labelX15.TabIndex = 23;
            this.labelX15.Text = "Địa chỉ";
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 285);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.labelX15);
            this.Controls.Add(this.cbbGioiTinh);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.dtNgaySinh);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.dtHetHan);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.dtNgayCap);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtTenDem);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cbbQuocTich);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHetHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCCCD;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbQuocTich;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDem;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTen;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSDT;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtNgayCap;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtHetHan;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtNgaySinh;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.ButtonX btnChon;
        private DevComponents.DotNetBar.LabelX lbMessage;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbGioiTinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDiaChi;
        private DevComponents.DotNetBar.LabelX labelX15;
    }
}