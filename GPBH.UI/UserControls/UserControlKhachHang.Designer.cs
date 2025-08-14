using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    partial class UserControlKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bubbleBar1 = new DevComponents.DotNetBar.BubbleBar();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnXuatExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnTim = new DevComponents.DotNetBar.ButtonX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ho_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_cap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quoc_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gioi_tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_sinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dien_thoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong_tien_hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // bubbleBar1
            // 
            this.bubbleBar1.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Bottom;
            this.bubbleBar1.AntiAlias = true;
            // 
            // 
            // 
            this.bubbleBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bubbleBar1.ButtonBackAreaStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBar1.ButtonBackAreaStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderBottomWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.bubbleBar1.ButtonBackAreaStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderLeftWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderRightWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.bubbleBar1.ButtonBackAreaStyle.BorderTopWidth = 1;
            this.bubbleBar1.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingBottom = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingLeft = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingRight = 3;
            this.bubbleBar1.ButtonBackAreaStyle.PaddingTop = 3;
            this.bubbleBar1.ImageSizeNormal = new System.Drawing.Size(24, 24);
            this.bubbleBar1.Location = new System.Drawing.Point(163, 24);
            this.bubbleBar1.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight;
            this.bubbleBar1.Name = "bubbleBar1";
            this.bubbleBar1.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar1.Size = new System.Drawing.Size(8, 8);
            this.bubbleBar1.TabIndex = 5;
            this.bubbleBar1.Text = "bubbleBar1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnXuatExcel);
            this.panelEx1.Controls.Add(this.btnTim);
            this.panelEx1.Controls.Add(this.txtSearch);
            this.panelEx1.Controls.Add(this.btnXoa);
            this.panelEx1.Controls.Add(this.btnSua);
            this.panelEx1.Controls.Add(this.btnThem);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1447, 54);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 10;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXuatExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXuatExcel.Location = new System.Drawing.Point(657, 16);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXuatExcel.TabIndex = 15;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnTim
            // 
            this.btnTim.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTim.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTim.Location = new System.Drawing.Point(576, 16);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTim.TabIndex = 14;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(278, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(291, 20);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.WatermarkText = "Tìm kiếm";
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.Location = new System.Drawing.Point(179, 16);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.Location = new System.Drawing.Point(97, 16);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.Location = new System.Drawing.Point(15, 16);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Passport,
            this.Ho_ten,
            this.Ngay_cap,
            this.Ngay_hh,
            this.Quoc_gia,
            this.Gioi_tinh,
            this.Ngay_sinh,
            this.Dia_chi,
            this.Dien_thoai,
            this.Email,
            this.Tong_tien_hang});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 54);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersWidth = 51;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(1447, 721);
            this.dataGridViewX1.TabIndex = 14;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            // 
            // Passport
            // 
            this.Passport.DataPropertyName = "Passport";
            this.Passport.HeaderText = "Passport No";
            this.Passport.MinimumWidth = 6;
            this.Passport.Name = "Passport";
            this.Passport.ReadOnly = true;
            this.Passport.Width = 90;
            // 
            // Ho_ten
            // 
            this.Ho_ten.DataPropertyName = "Ho_ten";
            this.Ho_ten.HeaderText = "Tên khách hàng";
            this.Ho_ten.Name = "Ho_ten";
            this.Ho_ten.ReadOnly = true;
            this.Ho_ten.Width = 111;
            // 
            // Ngay_cap
            // 
            this.Ngay_cap.DataPropertyName = "Ngay_cap";
            this.Ngay_cap.HeaderText = "Ngày cấp Hộ chiếu";
            this.Ngay_cap.Name = "Ngay_cap";
            this.Ngay_cap.ReadOnly = true;
            this.Ngay_cap.Width = 124;
            // 
            // Ngay_hh
            // 
            this.Ngay_hh.DataPropertyName = "Ngay_hh";
            this.Ngay_hh.HeaderText = "Giờ kết hết hạn Hộ chiếu";
            this.Ngay_hh.Name = "Ngay_hh";
            this.Ngay_hh.ReadOnly = true;
            this.Ngay_hh.Width = 151;
            // 
            // Quoc_gia
            // 
            this.Quoc_gia.DataPropertyName = "Quoc_gia";
            this.Quoc_gia.HeaderText = "Quốc gia";
            this.Quoc_gia.Name = "Quoc_gia";
            this.Quoc_gia.ReadOnly = true;
            this.Quoc_gia.Width = 75;
            // 
            // Gioi_tinh
            // 
            this.Gioi_tinh.DataPropertyName = "Gioi_tinh";
            this.Gioi_tinh.HeaderText = "Giới tính";
            this.Gioi_tinh.Name = "Gioi_tinh";
            this.Gioi_tinh.ReadOnly = true;
            this.Gioi_tinh.Width = 72;
            // 
            // Ngay_sinh
            // 
            this.Ngay_sinh.DataPropertyName = "Ngay_sinh";
            this.Ngay_sinh.HeaderText = "Ngày sinh";
            this.Ngay_sinh.Name = "Ngay_sinh";
            this.Ngay_sinh.ReadOnly = true;
            this.Ngay_sinh.Width = 79;
            // 
            // Dia_chi
            // 
            this.Dia_chi.DataPropertyName = "Dia_chi";
            this.Dia_chi.HeaderText = "Địa chỉ";
            this.Dia_chi.Name = "Dia_chi";
            this.Dia_chi.ReadOnly = true;
            this.Dia_chi.Width = 65;
            // 
            // Dien_thoai
            // 
            this.Dien_thoai.DataPropertyName = "Dien_thoai";
            this.Dien_thoai.HeaderText = "Điện thoại";
            this.Dien_thoai.Name = "Dien_thoai";
            this.Dien_thoai.ReadOnly = true;
            this.Dien_thoai.Width = 80;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 57;
            // 
            // Tong_tien_hang
            // 
            this.Tong_tien_hang.DataPropertyName = "Tong_tien_hang";
            this.Tong_tien_hang.HeaderText = "Tổng tiền mua";
            this.Tong_tien_hang.Name = "Tong_tien_hang";
            this.Tong_tien_hang.ReadOnly = true;
            // 
            // UserControlKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bubbleBar1);
            this.Name = "UserControlKhachHang";
            this.Size = new System.Drawing.Size(1447, 775);
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.BubbleBar bubbleBar1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnXuatExcel;
        private DevComponents.DotNetBar.ButtonX btnTim;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DataGridViewTextBoxColumn Passport;
        private DataGridViewTextBoxColumn Ho_ten;
        private DataGridViewTextBoxColumn Ngay_cap;
        private DataGridViewTextBoxColumn Ngay_hh;
        private DataGridViewTextBoxColumn Quoc_gia;
        private DataGridViewTextBoxColumn Gioi_tinh;
        private DataGridViewTextBoxColumn Ngay_sinh;
        private DataGridViewTextBoxColumn Dia_chi;
        private DataGridViewTextBoxColumn Dien_thoai;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Tong_tien_hang;
    }
}