namespace GPBH.UI.UserControls
{
    partial class UserControlBanHangTheoKhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noi_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_chung_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_khach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong_tien_hang_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thanh_tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thanh_tien_vn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new DevComponents.DotNetBar.ButtonX();
            this.buttonLamMoi = new DevComponents.DotNetBar.ButtonX();
            this.ccbMaNgoaiTe = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ccbMaHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ccbPassport = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ccbKhachHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonLoc = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtpDenNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtpTuNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stt,
            this.Noi_ban,
            this.So_chung_tu,
            this.Ngay_ban,
            this.Passport,
            this.Ten_khach,
            this.Tong_tien_hang_nt,
            this.Ma_hang,
            this.So_luong,
            this.Thanh_tien,
            this.Thanh_tien_vn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(2, 104);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersWidth = 51;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.Size = new System.Drawing.Size(1195, 565);
            this.dataGridViewX1.TabIndex = 10;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            // 
            // Stt
            // 
            this.Stt.DataPropertyName = "Stt";
            this.Stt.HeaderText = "Stt";
            this.Stt.Name = "Stt";
            this.Stt.ReadOnly = true;
            // 
            // Noi_ban
            // 
            this.Noi_ban.DataPropertyName = "Noi_ban";
            this.Noi_ban.HeaderText = "Nơi bán";
            this.Noi_ban.Name = "Noi_ban";
            this.Noi_ban.ReadOnly = true;
            // 
            // So_chung_tu
            // 
            this.So_chung_tu.DataPropertyName = "So_don_hang";
            this.So_chung_tu.HeaderText = "Số đơn hàng";
            this.So_chung_tu.MinimumWidth = 6;
            this.So_chung_tu.Name = "So_chung_tu";
            this.So_chung_tu.ReadOnly = true;
            // 
            // Ngay_ban
            // 
            this.Ngay_ban.DataPropertyName = "Ngay_ban";
            this.Ngay_ban.HeaderText = "Ngày bán";
            this.Ngay_ban.MinimumWidth = 6;
            this.Ngay_ban.Name = "Ngay_ban";
            this.Ngay_ban.ReadOnly = true;
            // 
            // Passport
            // 
            this.Passport.DataPropertyName = "Passport";
            this.Passport.HeaderText = "Hộ chiếu";
            this.Passport.Name = "Passport";
            this.Passport.ReadOnly = true;
            // 
            // Ten_khach
            // 
            this.Ten_khach.DataPropertyName = "Ten_khachhang";
            this.Ten_khach.HeaderText = "Tên khách hàng";
            this.Ten_khach.Name = "Ten_khach";
            this.Ten_khach.ReadOnly = true;
            // 
            // Tong_tien_hang_nt
            // 
            this.Tong_tien_hang_nt.DataPropertyName = "Ten_hang";
            this.Tong_tien_hang_nt.HeaderText = "Tên hàng";
            this.Tong_tien_hang_nt.Name = "Tong_tien_hang_nt";
            this.Tong_tien_hang_nt.ReadOnly = true;
            // 
            // Ma_hang
            // 
            this.Ma_hang.DataPropertyName = "Ma_hang";
            this.Ma_hang.HeaderText = "Mã hàng";
            this.Ma_hang.Name = "Ma_hang";
            this.Ma_hang.ReadOnly = true;
            // 
            // So_luong
            // 
            this.So_luong.DataPropertyName = "So_luong";
            this.So_luong.HeaderText = "Số lượng";
            this.So_luong.Name = "So_luong";
            this.So_luong.ReadOnly = true;
            // 
            // Thanh_tien
            // 
            this.Thanh_tien.DataPropertyName = "Thanh_tien";
            this.Thanh_tien.HeaderText = "Thành tiền";
            this.Thanh_tien.Name = "Thanh_tien";
            this.Thanh_tien.ReadOnly = true;
            // 
            // Thanh_tien_vn
            // 
            this.Thanh_tien_vn.DataPropertyName = "Thanh_tien_vn";
            this.Thanh_tien_vn.HeaderText = "Thành tiền VND";
            this.Thanh_tien_vn.Name = "Thanh_tien_vn";
            this.Thanh_tien_vn.ReadOnly = true;
            // 
            // btnIn
            // 
            this.btnIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIn.Location = new System.Drawing.Point(649, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIn.Size = new System.Drawing.Size(81, 23);
            this.btnIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnIn.TabIndex = 9;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.Click += new System.EventHandler(this.BtnIn_Click);
            // 
            // buttonLamMoi
            // 
            this.buttonLamMoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLamMoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLamMoi.Location = new System.Drawing.Point(555, 35);
            this.buttonLamMoi.Name = "buttonLamMoi";
            this.buttonLamMoi.Size = new System.Drawing.Size(81, 23);
            this.buttonLamMoi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonLamMoi.TabIndex = 8;
            this.buttonLamMoi.Text = "Làm mới";
            this.buttonLamMoi.Click += new System.EventHandler(this.buttonLamMoi_Click);
            // 
            // ccbMaNgoaiTe
            // 
            this.ccbMaNgoaiTe.DisplayMember = "Text";
            this.ccbMaNgoaiTe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ccbMaNgoaiTe.FormattingEnabled = true;
            this.ccbMaNgoaiTe.ItemHeight = 14;
            this.ccbMaNgoaiTe.Location = new System.Drawing.Point(372, 62);
            this.ccbMaNgoaiTe.Name = "ccbMaNgoaiTe";
            this.ccbMaNgoaiTe.Size = new System.Drawing.Size(150, 20);
            this.ccbMaNgoaiTe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ccbMaNgoaiTe.TabIndex = 6;
            // 
            // ccbMaHang
            // 
            this.ccbMaHang.DisplayMember = "Text";
            this.ccbMaHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ccbMaHang.FormattingEnabled = true;
            this.ccbMaHang.ItemHeight = 14;
            this.ccbMaHang.Location = new System.Drawing.Point(109, 62);
            this.ccbMaHang.Name = "ccbMaHang";
            this.ccbMaHang.Size = new System.Drawing.Size(150, 20);
            this.ccbMaHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ccbMaHang.TabIndex = 5;
            // 
            // ccbPassport
            // 
            this.ccbPassport.DisplayMember = "Text";
            this.ccbPassport.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ccbPassport.FormattingEnabled = true;
            this.ccbPassport.ItemHeight = 14;
            this.ccbPassport.Location = new System.Drawing.Point(372, 36);
            this.ccbPassport.Name = "ccbPassport";
            this.ccbPassport.Size = new System.Drawing.Size(150, 20);
            this.ccbPassport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ccbPassport.TabIndex = 4;
            // 
            // ccbKhachHang
            // 
            this.ccbKhachHang.DisplayMember = "Text";
            this.ccbKhachHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ccbKhachHang.FormattingEnabled = true;
            this.ccbKhachHang.ItemHeight = 14;
            this.ccbKhachHang.Location = new System.Drawing.Point(109, 36);
            this.ccbKhachHang.Name = "ccbKhachHang";
            this.ccbKhachHang.Size = new System.Drawing.Size(150, 20);
            this.ccbKhachHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ccbKhachHang.TabIndex = 3;
            // 
            // buttonLoc
            // 
            this.buttonLoc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLoc.Location = new System.Drawing.Point(555, 10);
            this.buttonLoc.Name = "buttonLoc";
            this.buttonLoc.Size = new System.Drawing.Size(81, 23);
            this.buttonLoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonLoc.TabIndex = 7;
            this.buttonLoc.Text = "Lọc";
            this.buttonLoc.Click += new System.EventHandler(this.buttonLoc_Click);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(286, 65);
            this.labelX6.Margin = new System.Windows.Forms.Padding(2);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(60, 15);
            this.labelX6.TabIndex = 40;
            this.labelX6.Text = "Mã ngoại tệ";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(23, 65);
            this.labelX5.Margin = new System.Windows.Forms.Padding(2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(45, 15);
            this.labelX5.TabIndex = 39;
            this.labelX5.Text = "Mã hàng";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(286, 39);
            this.labelX4.Margin = new System.Windows.Forms.Padding(2);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(60, 15);
            this.labelX4.TabIndex = 38;
            this.labelX4.Text = "Số hộ chiếu";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(23, 39);
            this.labelX3.Margin = new System.Windows.Forms.Padding(2);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(61, 15);
            this.labelX3.TabIndex = 37;
            this.labelX3.Text = "Khách hàng";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(286, 14);
            this.labelX2.Margin = new System.Windows.Forms.Padding(2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(49, 15);
            this.labelX2.TabIndex = 36;
            this.labelX2.Text = "Đến ngày";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 14);
            this.labelX1.Margin = new System.Windows.Forms.Padding(2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(42, 15);
            this.labelX1.TabIndex = 35;
            this.labelX1.Text = "Từ ngày";
            // 
            // dtpDenNgay
            // 
            // 
            // 
            // 
            this.dtpDenNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpDenNgay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDenNgay.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpDenNgay.ButtonDropDown.Visible = true;
            this.dtpDenNgay.IsPopupCalendarOpen = false;
            this.dtpDenNgay.Location = new System.Drawing.Point(372, 11);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtpDenNgay.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDenNgay.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpDenNgay.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpDenNgay.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDenNgay.MonthCalendar.DisplayMonth = new System.DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtpDenNgay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpDenNgay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpDenNgay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpDenNgay.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpDenNgay.MonthCalendar.TodayButtonVisible = true;
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 20);
            this.dtpDenNgay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpDenNgay.TabIndex = 2;
            // 
            // dtpTuNgay
            // 
            // 
            // 
            // 
            this.dtpTuNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpTuNgay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTuNgay.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpTuNgay.ButtonDropDown.Visible = true;
            this.dtpTuNgay.IsPopupCalendarOpen = false;
            this.dtpTuNgay.Location = new System.Drawing.Point(109, 11);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(2);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtpTuNgay.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTuNgay.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpTuNgay.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpTuNgay.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTuNgay.MonthCalendar.DisplayMonth = new System.DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtpTuNgay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpTuNgay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpTuNgay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpTuNgay.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTuNgay.MonthCalendar.TodayButtonVisible = true;
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 20);
            this.dtpTuNgay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpTuNgay.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Location = new System.Drawing.Point(649, 35);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(81, 23);
            this.btnExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExcel.TabIndex = 41;
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // UserControlBanHangTheoKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.buttonLamMoi);
            this.Controls.Add(this.ccbMaNgoaiTe);
            this.Controls.Add(this.ccbMaHang);
            this.Controls.Add(this.ccbPassport);
            this.Controls.Add(this.ccbKhachHang);
            this.Controls.Add(this.buttonLoc);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dataGridViewX1);
            this.Name = "UserControlBanHangTheoKhachHang";
            this.Size = new System.Drawing.Size(1199, 680);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTuNgay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnIn;
        private DevComponents.DotNetBar.ButtonX buttonLamMoi;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ccbMaNgoaiTe;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ccbMaHang;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ccbPassport;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ccbKhachHang;
        private DevComponents.DotNetBar.ButtonX buttonLoc;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpDenNgay;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpTuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noi_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_chung_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_khach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tong_tien_hang_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_hang;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thanh_tien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thanh_tien_vn;
        private DevComponents.DotNetBar.ButtonX btnExcel;
    }
}
