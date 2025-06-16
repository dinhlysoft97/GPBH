using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace GPBH.UI.Forms
{
    partial class DonHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbMaPhieu = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.lbSoChungTu = new DevComponents.DotNetBar.LabelX();
            this.lbTGNT = new DevComponents.DotNetBar.LabelX();
            this.lbNgayHoaDon = new DevComponents.DotNetBar.LabelX();
            this.lbSCT = new DevComponents.DotNetBar.LabelX();
            this.lbCa = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.lbQuay = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.lbTenDangNhap = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.lbMST = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lbTen = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtTenKhachHang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtQuocTinh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCCCD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDiaChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia_ban_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gg_ty_le = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gg_tien_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gg_tien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tien_ban_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tien_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gg_ly_do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtTt_tong = new DevComponents.Editors.DoubleInput();
            this.txtTt3_tien_nt = new DevComponents.Editors.DoubleInput();
            this.txtTt2_tien_nt = new DevComponents.Editors.DoubleInput();
            this.txtTt1_tien_nt = new DevComponents.Editors.DoubleInput();
            this.txtTt3_tien_tt = new DevComponents.Editors.DoubleInput();
            this.txtTt2_tien_tt = new DevComponents.Editors.DoubleInput();
            this.txtTt1_tien_tt = new DevComponents.Editors.DoubleInput();
            this.lbTTT = new DevComponents.DotNetBar.LabelX();
            this.lbTT3 = new DevComponents.DotNetBar.LabelX();
            this.cbbTt3_ma_nt = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbTt3_loai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbTT2 = new DevComponents.DotNetBar.LabelX();
            this.cbbTt2_ma_nt = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbTt2_loai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbTT1 = new DevComponents.DotNetBar.LabelX();
            this.cbbTt1_ma_nt = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbTt1_loai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtTQDVND = new DevComponents.Editors.DoubleInput();
            this.labelX28 = new DevComponents.DotNetBar.LabelX();
            this.txtTong_thu_nt = new DevComponents.Editors.DoubleInput();
            this.labelX29 = new DevComponents.DotNetBar.LabelX();
            this.txtTong_giam_gia_nt = new DevComponents.Editors.DoubleInput();
            this.lbTongThu = new DevComponents.DotNetBar.LabelX();
            this.txtTong_tien_hang_nt = new DevComponents.Editors.DoubleInput();
            this.labelX27 = new DevComponents.DotNetBar.LabelX();
            this.lbGiamGia = new DevComponents.DotNetBar.LabelX();
            this.labelX25 = new DevComponents.DotNetBar.LabelX();
            this.lbTTH = new DevComponents.DotNetBar.LabelX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lbQuyDoiTienTe = new DevComponents.DotNetBar.LabelX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem9 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem10 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem11 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem12 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem13 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem14 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem15 = new DevComponents.DotNetBar.LabelItem();
            this.labelX34 = new DevComponents.DotNetBar.LabelX();
            this.lbTraLai = new DevComponents.DotNetBar.LabelX();
            this.labelX37 = new DevComponents.DotNetBar.LabelX();
            this.cbTra_lai = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lbTongNhan = new DevComponents.DotNetBar.LabelX();
            this.labelX32 = new DevComponents.DotNetBar.LabelX();
            this.txtTong_nhan = new DevComponents.Editors.DoubleInput();
            this.txtTra_lai_nt = new DevComponents.Editors.DoubleInput();
            this.txtTra_lai = new DevComponents.Editors.DoubleInput();
            this.ucHangHoa = new GPBH.UI.UserControls.ucHangHoa();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt_tong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt3_tien_nt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt2_tien_nt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt1_tien_nt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt3_tien_tt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt2_tien_tt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt1_tien_tt)).BeginInit();
            this.groupPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTQDVND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_thu_nt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_giam_gia_nt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_tien_hang_nt)).BeginInit();
            this.groupPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_nhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTra_lai_nt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTra_lai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.BackColor = System.Drawing.Color.LightGray;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.lbMaPhieu);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.Controls.Add(this.lbSoChungTu);
            this.groupPanel2.Controls.Add(this.lbTGNT);
            this.groupPanel2.Controls.Add(this.lbNgayHoaDon);
            this.groupPanel2.Controls.Add(this.lbSCT);
            this.groupPanel2.Controls.Add(this.lbCa);
            this.groupPanel2.Controls.Add(this.labelX13);
            this.groupPanel2.Controls.Add(this.lbQuay);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.Controls.Add(this.lbTenDangNhap);
            this.groupPanel2.Controls.Add(this.labelX9);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.lbMST);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(717, 3);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(706, 115);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "Thông tin đơn hàng";
            // 
            // lbMaPhieu
            // 
            this.lbMaPhieu.AutoSize = true;
            this.lbMaPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbMaPhieu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMaPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaPhieu.Location = new System.Drawing.Point(413, 57);
            this.lbMaPhieu.Margin = new System.Windows.Forms.Padding(2);
            this.lbMaPhieu.Name = "lbMaPhieu";
            this.lbMaPhieu.Size = new System.Drawing.Size(0, 0);
            this.lbMaPhieu.TabIndex = 31;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(343, 57);
            this.labelX10.Margin = new System.Windows.Forms.Padding(2);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(51, 15);
            this.labelX10.TabIndex = 30;
            this.labelX10.Text = "Mã phiếu:";
            // 
            // lbSoChungTu
            // 
            this.lbSoChungTu.AutoSize = true;
            this.lbSoChungTu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbSoChungTu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSoChungTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoChungTu.Location = new System.Drawing.Point(413, 30);
            this.lbSoChungTu.Margin = new System.Windows.Forms.Padding(2);
            this.lbSoChungTu.Name = "lbSoChungTu";
            this.lbSoChungTu.Size = new System.Drawing.Size(0, 0);
            this.lbSoChungTu.TabIndex = 29;
            // 
            // lbTGNT
            // 
            this.lbTGNT.AutoSize = true;
            this.lbTGNT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTGNT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTGNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTGNT.Location = new System.Drawing.Point(594, 30);
            this.lbTGNT.Margin = new System.Windows.Forms.Padding(2);
            this.lbTGNT.Name = "lbTGNT";
            this.lbTGNT.Size = new System.Drawing.Size(65, 15);
            this.lbTGNT.TabIndex = 28;
            this.lbTGNT.Text = "USD: 25,000";
            // 
            // lbNgayHoaDon
            // 
            this.lbNgayHoaDon.AutoSize = true;
            this.lbNgayHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbNgayHoaDon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbNgayHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayHoaDon.Location = new System.Drawing.Point(594, 57);
            this.lbNgayHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.lbNgayHoaDon.Name = "lbNgayHoaDon";
            this.lbNgayHoaDon.Size = new System.Drawing.Size(89, 15);
            this.lbNgayHoaDon.TabIndex = 27;
            this.lbNgayHoaDon.Text = "Ngày: 26/06/2025";
            // 
            // lbSCT
            // 
            this.lbSCT.AutoSize = true;
            this.lbSCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbSCT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSCT.Location = new System.Drawing.Point(343, 30);
            this.lbSCT.Margin = new System.Windows.Forms.Padding(2);
            this.lbSCT.Name = "lbSCT";
            this.lbSCT.Size = new System.Drawing.Size(70, 15);
            this.lbSCT.TabIndex = 26;
            this.lbSCT.Text = "Số chứng từ: ";
            // 
            // lbCa
            // 
            this.lbCa.AutoSize = true;
            this.lbCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbCa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCa.Location = new System.Drawing.Point(617, 5);
            this.lbCa.Margin = new System.Windows.Forms.Padding(2);
            this.lbCa.Name = "lbCa";
            this.lbCa.Size = new System.Drawing.Size(9, 15);
            this.lbCa.TabIndex = 25;
            this.lbCa.Text = "1";
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            this.labelX13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(594, 5);
            this.labelX13.Margin = new System.Windows.Forms.Padding(2);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(20, 15);
            this.labelX13.TabIndex = 24;
            this.labelX13.Text = "Ca:";
            // 
            // lbQuay
            // 
            this.lbQuay.AutoSize = true;
            this.lbQuay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbQuay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbQuay.Location = new System.Drawing.Point(530, 5);
            this.lbQuay.Margin = new System.Windows.Forms.Padding(2);
            this.lbQuay.Name = "lbQuay";
            this.lbQuay.Size = new System.Drawing.Size(9, 15);
            this.lbQuay.TabIndex = 23;
            this.lbQuay.Text = "1";
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            this.labelX11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(497, 5);
            this.labelX11.Margin = new System.Windows.Forms.Padding(2);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(38, 15);
            this.labelX11.TabIndex = 22;
            this.labelX11.Text = "Quầy: ";
            // 
            // lbTenDangNhap
            // 
            this.lbTenDangNhap.AutoSize = true;
            this.lbTenDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTenDangNhap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTenDangNhap.Location = new System.Drawing.Point(406, 5);
            this.lbTenDangNhap.Margin = new System.Windows.Forms.Padding(2);
            this.lbTenDangNhap.Name = "lbTenDangNhap";
            this.lbTenDangNhap.Size = new System.Drawing.Size(38, 15);
            this.lbTenDangNhap.TabIndex = 21;
            this.lbTenDangNhap.Text = "ADMIN";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(343, 5);
            this.labelX9.Margin = new System.Windows.Forms.Padding(2);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(62, 15);
            this.labelX9.TabIndex = 20;
            this.labelX9.Text = "Người dùng:";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.FontBold = true;
            this.labelX8.Location = new System.Drawing.Point(224, 31);
            this.labelX8.Margin = new System.Windows.Forms.Padding(2);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(53, 15);
            this.labelX8.TabIndex = 3;
            this.labelX8.Text = "00000001";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.FontBold = true;
            this.labelX7.Location = new System.Drawing.Point(107, 31);
            this.labelX7.Margin = new System.Windows.Forms.Padding(2);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(70, 15);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "Số hóa đơn: ";
            // 
            // lbMST
            // 
            this.lbMST.AutoSize = true;
            this.lbMST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbMST.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMST.FontBold = true;
            this.lbMST.Location = new System.Drawing.Point(224, 5);
            this.lbMST.Margin = new System.Windows.Forms.Padding(2);
            this.lbMST.Name = "lbMST";
            this.lbMST.Size = new System.Drawing.Size(73, 15);
            this.lbMST.TabIndex = 1;
            this.lbMST.Text = "M - 25 -45707";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.FontBold = true;
            this.labelX6.Location = new System.Drawing.Point(107, 5);
            this.labelX6.Margin = new System.Windows.Forms.Padding(2);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(120, 15);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Mã của Cơ quan thuế: ";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.lbTen);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.txtTenKhachHang);
            this.groupPanel1.Controls.Add(this.txtQuocTinh);
            this.groupPanel1.Controls.Add(this.txtCCCD);
            this.groupPanel1.Controls.Add(this.txtDiaChi);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(708, 115);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Khách hàng";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(376, 29);
            this.labelX5.Margin = new System.Windows.Forms.Padding(2);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(49, 15);
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "Quốc tịch";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTen.Location = new System.Drawing.Point(86, 52);
            this.lbTen.Margin = new System.Windows.Forms.Padding(2);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(81, 15);
            this.lbTen.TabIndex = 18;
            this.lbTen.Text = "Tên khách hàng";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(86, 29);
            this.labelX2.Margin = new System.Windows.Forms.Padding(2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(97, 15);
            this.labelX2.TabIndex = 17;
            this.labelX2.Text = "Số Passport/CCCD";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(86, 6);
            this.labelX1.Margin = new System.Windows.Forms.Padding(2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(36, 15);
            this.labelX1.TabIndex = 16;
            this.labelX1.Text = "Địa chỉ";
            // 
            // txtTenKhachHang
            // 
            // 
            // 
            // 
            this.txtTenKhachHang.Border.Class = "TextBoxBorder";
            this.txtTenKhachHang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenKhachHang.Enabled = false;
            this.txtTenKhachHang.Location = new System.Drawing.Point(190, 52);
            this.txtTenKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.PreventEnterBeep = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(426, 20);
            this.txtTenKhachHang.TabIndex = 15;
            // 
            // txtQuocTinh
            // 
            // 
            // 
            // 
            this.txtQuocTinh.Border.Class = "TextBoxBorder";
            this.txtQuocTinh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuocTinh.Enabled = false;
            this.txtQuocTinh.Location = new System.Drawing.Point(447, 29);
            this.txtQuocTinh.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuocTinh.Name = "txtQuocTinh";
            this.txtQuocTinh.PreventEnterBeep = true;
            this.txtQuocTinh.Size = new System.Drawing.Size(169, 20);
            this.txtQuocTinh.TabIndex = 14;
            // 
            // txtCCCD
            // 
            // 
            // 
            // 
            this.txtCCCD.Border.Class = "TextBoxBorder";
            this.txtCCCD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCCCD.Enabled = false;
            this.txtCCCD.Location = new System.Drawing.Point(190, 29);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(2);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.PreventEnterBeep = true;
            this.txtCCCD.Size = new System.Drawing.Size(169, 20);
            this.txtCCCD.TabIndex = 13;
            // 
            // txtDiaChi
            // 
            // 
            // 
            // 
            this.txtDiaChi.Border.Class = "TextBoxBorder";
            this.txtDiaChi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiaChi.Enabled = false;
            this.txtDiaChi.Location = new System.Drawing.Point(190, 6);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PreventEnterBeep = true;
            this.txtDiaChi.Size = new System.Drawing.Size(426, 20);
            this.txtDiaChi.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.10417F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.89583F));
            this.tableLayoutPanel1.Controls.Add(this.groupPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1426, 121);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.groupPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 121);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1426, 445);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.White;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.dataGridViewX1);
            this.groupPanel3.Controls.Add(this.bar1);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(3, 3);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1420, 442);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 0;
            this.groupPanel3.Text = "Thông tin hàng";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stt,
            this.Ma_hh,
            this.Ten_hh,
            this.Dvt,
            this.So_luong,
            this.Gia_ban_nt,
            this.Gia_ban,
            this.Gg_ty_le,
            this.Gg_tien_nt,
            this.Gg_tien,
            this.Tien_ban_nt,
            this.Tien_ban,
            this.Gg_ly_do});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 40);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersWidth = 51;
            this.dataGridViewX1.Size = new System.Drawing.Size(1414, 381);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // Stt
            // 
            this.Stt.DataPropertyName = "Stt";
            this.Stt.HeaderText = "Stt";
            this.Stt.Name = "Stt";
            this.Stt.ReadOnly = true;
            // 
            // Ma_hh
            // 
            this.Ma_hh.DataPropertyName = "Ma_hh";
            this.Ma_hh.FillWeight = 92.17722F;
            this.Ma_hh.HeaderText = "Mã hàng";
            this.Ma_hh.MinimumWidth = 6;
            this.Ma_hh.Name = "Ma_hh";
            this.Ma_hh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Ten_hh
            // 
            this.Ten_hh.DataPropertyName = "Ten_hh";
            this.Ten_hh.FillWeight = 96.0779F;
            this.Ten_hh.HeaderText = "Tên hàng";
            this.Ten_hh.MinimumWidth = 6;
            this.Ten_hh.Name = "Ten_hh";
            this.Ten_hh.ReadOnly = true;
            // 
            // Dvt
            // 
            this.Dvt.DataPropertyName = "Dvt";
            this.Dvt.HeaderText = "Đơn vị tính";
            this.Dvt.Name = "Dvt";
            this.Dvt.ReadOnly = true;
            // 
            // So_luong
            // 
            this.So_luong.DataPropertyName = "So_luong";
            this.So_luong.FillWeight = 99.17547F;
            this.So_luong.HeaderText = "Số lượng";
            this.So_luong.Name = "So_luong";
            // 
            // Gia_ban_nt
            // 
            this.Gia_ban_nt.DataPropertyName = "Gia_ban_nt";
            this.Gia_ban_nt.FillWeight = 101.808F;
            this.Gia_ban_nt.HeaderText = "Giá NT";
            this.Gia_ban_nt.Name = "Gia_ban_nt";
            // 
            // Gia_ban
            // 
            this.Gia_ban.DataPropertyName = "Gia_ban";
            this.Gia_ban.FillWeight = 103.379F;
            this.Gia_ban.HeaderText = "Giá VNĐ";
            this.Gia_ban.Name = "Gia_ban";
            // 
            // Gg_ty_le
            // 
            this.Gg_ty_le.DataPropertyName = "Gg_ty_le";
            this.Gg_ty_le.FillWeight = 106.3268F;
            this.Gg_ty_le.HeaderText = "% Giảm";
            this.Gg_ty_le.Name = "Gg_ty_le";
            // 
            // Gg_tien_nt
            // 
            this.Gg_tien_nt.DataPropertyName = "Gg_tien_nt";
            this.Gg_tien_nt.HeaderText = "Tiền giảm NT";
            this.Gg_tien_nt.Name = "Gg_tien_nt";
            // 
            // Gg_tien
            // 
            this.Gg_tien.DataPropertyName = "Gg_tien";
            this.Gg_tien.FillWeight = 106.7926F;
            this.Gg_tien.HeaderText = "Tiền giảm";
            this.Gg_tien.Name = "Gg_tien";
            // 
            // Tien_ban_nt
            // 
            this.Tien_ban_nt.DataPropertyName = "Tien_ban_nt";
            this.Tien_ban_nt.FillWeight = 103.449F;
            this.Tien_ban_nt.HeaderText = "Thành tiền NT";
            this.Tien_ban_nt.Name = "Tien_ban_nt";
            // 
            // Tien_ban
            // 
            this.Tien_ban.DataPropertyName = "Tien_ban";
            this.Tien_ban.FillWeight = 101.9336F;
            this.Tien_ban.HeaderText = "Thành tiền VNĐ";
            this.Tien_ban.Name = "Tien_ban";
            // 
            // Gg_ly_do
            // 
            this.Gg_ly_do.DataPropertyName = "Gg_ly_do";
            this.Gg_ly_do.FillWeight = 100.1636F;
            this.Gg_ly_do.HeaderText = "Lý do giảm";
            this.Gg_ly_do.Name = "Gg_ly_do";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.White;
            this.bar1.Controls.Add(this.ucHangHoa);
            this.bar1.Controls.Add(this.labelX4);
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.MinimumSize = new System.Drawing.Size(0, 40);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1414, 40);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(85, 6);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(58, 24);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Mã vạch";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.89792F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.10208F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel2.Controls.Add(this.groupPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupPanel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupPanel5, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 566);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1426, 193);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.LightGray;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.txtTt_tong);
            this.groupPanel4.Controls.Add(this.txtTt3_tien_nt);
            this.groupPanel4.Controls.Add(this.txtTt2_tien_nt);
            this.groupPanel4.Controls.Add(this.txtTt1_tien_nt);
            this.groupPanel4.Controls.Add(this.txtTt3_tien_tt);
            this.groupPanel4.Controls.Add(this.txtTt2_tien_tt);
            this.groupPanel4.Controls.Add(this.txtTt1_tien_tt);
            this.groupPanel4.Controls.Add(this.lbTTT);
            this.groupPanel4.Controls.Add(this.lbTT3);
            this.groupPanel4.Controls.Add(this.cbbTt3_ma_nt);
            this.groupPanel4.Controls.Add(this.cbbTt3_loai);
            this.groupPanel4.Controls.Add(this.lbTT2);
            this.groupPanel4.Controls.Add(this.cbbTt2_ma_nt);
            this.groupPanel4.Controls.Add(this.cbbTt2_loai);
            this.groupPanel4.Controls.Add(this.lbTT1);
            this.groupPanel4.Controls.Add(this.cbbTt1_ma_nt);
            this.groupPanel4.Controls.Add(this.cbbTt1_loai);
            this.groupPanel4.Controls.Add(this.labelX17);
            this.groupPanel4.Controls.Add(this.labelX16);
            this.groupPanel4.Controls.Add(this.labelX15);
            this.groupPanel4.Controls.Add(this.labelX14);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(3, 3);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(613, 187);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 0;
            this.groupPanel4.Text = "Thanh toán(Alt +P)";
            // 
            // txtTt_tong
            // 
            // 
            // 
            // 
            this.txtTt_tong.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt_tong.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt_tong.DisplayFormat = "#,##0.00";
            this.txtTt_tong.Enabled = false;
            this.txtTt_tong.Increment = 1D;
            this.txtTt_tong.Location = new System.Drawing.Point(459, 118);
            this.txtTt_tong.Name = "txtTt_tong";
            this.txtTt_tong.ShowUpDown = true;
            this.txtTt_tong.Size = new System.Drawing.Size(99, 20);
            this.txtTt_tong.TabIndex = 44;
            // 
            // txtTt3_tien_nt
            // 
            // 
            // 
            // 
            this.txtTt3_tien_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt3_tien_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt3_tien_nt.DisplayFormat = "#,##0.00";
            this.txtTt3_tien_nt.Increment = 1D;
            this.txtTt3_tien_nt.Location = new System.Drawing.Point(459, 90);
            this.txtTt3_tien_nt.Name = "txtTt3_tien_nt";
            this.txtTt3_tien_nt.ShowUpDown = true;
            this.txtTt3_tien_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTt3_tien_nt.TabIndex = 43;
            // 
            // txtTt2_tien_nt
            // 
            // 
            // 
            // 
            this.txtTt2_tien_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt2_tien_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt2_tien_nt.DisplayFormat = "#,##0.00";
            this.txtTt2_tien_nt.Increment = 1D;
            this.txtTt2_tien_nt.Location = new System.Drawing.Point(459, 60);
            this.txtTt2_tien_nt.Name = "txtTt2_tien_nt";
            this.txtTt2_tien_nt.ShowUpDown = true;
            this.txtTt2_tien_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTt2_tien_nt.TabIndex = 42;
            // 
            // txtTt1_tien_nt
            // 
            // 
            // 
            // 
            this.txtTt1_tien_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt1_tien_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt1_tien_nt.DisplayFormat = "#,##0.00";
            this.txtTt1_tien_nt.Increment = 1D;
            this.txtTt1_tien_nt.Location = new System.Drawing.Point(459, 26);
            this.txtTt1_tien_nt.Name = "txtTt1_tien_nt";
            this.txtTt1_tien_nt.ShowUpDown = true;
            this.txtTt1_tien_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTt1_tien_nt.TabIndex = 41;
            // 
            // txtTt3_tien_tt
            // 
            // 
            // 
            // 
            this.txtTt3_tien_tt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt3_tien_tt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt3_tien_tt.DisplayFormat = "#,##0.00";
            this.txtTt3_tien_tt.Increment = 1D;
            this.txtTt3_tien_tt.Location = new System.Drawing.Point(344, 90);
            this.txtTt3_tien_tt.Name = "txtTt3_tien_tt";
            this.txtTt3_tien_tt.ShowUpDown = true;
            this.txtTt3_tien_tt.Size = new System.Drawing.Size(99, 20);
            this.txtTt3_tien_tt.TabIndex = 40;
            // 
            // txtTt2_tien_tt
            // 
            // 
            // 
            // 
            this.txtTt2_tien_tt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt2_tien_tt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt2_tien_tt.DisplayFormat = "#,##0.00";
            this.txtTt2_tien_tt.Increment = 1D;
            this.txtTt2_tien_tt.Location = new System.Drawing.Point(344, 59);
            this.txtTt2_tien_tt.Name = "txtTt2_tien_tt";
            this.txtTt2_tien_tt.ShowUpDown = true;
            this.txtTt2_tien_tt.Size = new System.Drawing.Size(99, 20);
            this.txtTt2_tien_tt.TabIndex = 39;
            // 
            // txtTt1_tien_tt
            // 
            // 
            // 
            // 
            this.txtTt1_tien_tt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTt1_tien_tt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTt1_tien_tt.DisplayFormat = "#,##0.00";
            this.txtTt1_tien_tt.Increment = 1D;
            this.txtTt1_tien_tt.Location = new System.Drawing.Point(344, 27);
            this.txtTt1_tien_tt.Name = "txtTt1_tien_tt";
            this.txtTt1_tien_tt.ShowUpDown = true;
            this.txtTt1_tien_tt.Size = new System.Drawing.Size(99, 20);
            this.txtTt1_tien_tt.TabIndex = 38;
            // 
            // lbTTT
            // 
            this.lbTTT.AutoSize = true;
            this.lbTTT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTTT.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTTT.Location = new System.Drawing.Point(575, 121);
            this.lbTTT.Margin = new System.Windows.Forms.Padding(2);
            this.lbTTT.Name = "lbTTT";
            this.lbTTT.Size = new System.Drawing.Size(33, 15);
            this.lbTTT.TabIndex = 37;
            this.lbTTT.Text = "(USD)";
            this.lbTTT.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbTT3
            // 
            this.lbTT3.AutoSize = true;
            this.lbTT3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTT3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTT3.Location = new System.Drawing.Point(575, 91);
            this.lbTT3.Margin = new System.Windows.Forms.Padding(2);
            this.lbTT3.Name = "lbTT3";
            this.lbTT3.Size = new System.Drawing.Size(33, 15);
            this.lbTT3.TabIndex = 35;
            this.lbTT3.Text = "(USD)";
            this.lbTT3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbbTt3_ma_nt
            // 
            this.cbbTt3_ma_nt.DisplayMember = "Text";
            this.cbbTt3_ma_nt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTt3_ma_nt.FormattingEnabled = true;
            this.cbbTt3_ma_nt.ItemHeight = 16;
            this.cbbTt3_ma_nt.Location = new System.Drawing.Point(231, 89);
            this.cbbTt3_ma_nt.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTt3_ma_nt.Name = "cbbTt3_ma_nt";
            this.cbbTt3_ma_nt.Size = new System.Drawing.Size(99, 22);
            this.cbbTt3_ma_nt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTt3_ma_nt.TabIndex = 32;
            // 
            // cbbTt3_loai
            // 
            this.cbbTt3_loai.DisplayMember = "Text";
            this.cbbTt3_loai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTt3_loai.FormattingEnabled = true;
            this.cbbTt3_loai.ItemHeight = 16;
            this.cbbTt3_loai.Location = new System.Drawing.Point(120, 89);
            this.cbbTt3_loai.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTt3_loai.Name = "cbbTt3_loai";
            this.cbbTt3_loai.Size = new System.Drawing.Size(99, 22);
            this.cbbTt3_loai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTt3_loai.TabIndex = 31;
            // 
            // lbTT2
            // 
            this.lbTT2.AutoSize = true;
            this.lbTT2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTT2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTT2.Location = new System.Drawing.Point(575, 60);
            this.lbTT2.Margin = new System.Windows.Forms.Padding(2);
            this.lbTT2.Name = "lbTT2";
            this.lbTT2.Size = new System.Drawing.Size(33, 15);
            this.lbTT2.TabIndex = 30;
            this.lbTT2.Text = "(USD)";
            this.lbTT2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbbTt2_ma_nt
            // 
            this.cbbTt2_ma_nt.DisplayMember = "Text";
            this.cbbTt2_ma_nt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTt2_ma_nt.FormattingEnabled = true;
            this.cbbTt2_ma_nt.ItemHeight = 16;
            this.cbbTt2_ma_nt.Location = new System.Drawing.Point(231, 58);
            this.cbbTt2_ma_nt.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTt2_ma_nt.Name = "cbbTt2_ma_nt";
            this.cbbTt2_ma_nt.Size = new System.Drawing.Size(99, 22);
            this.cbbTt2_ma_nt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTt2_ma_nt.TabIndex = 27;
            // 
            // cbbTt2_loai
            // 
            this.cbbTt2_loai.DisplayMember = "Text";
            this.cbbTt2_loai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTt2_loai.FormattingEnabled = true;
            this.cbbTt2_loai.ItemHeight = 16;
            this.cbbTt2_loai.Location = new System.Drawing.Point(120, 58);
            this.cbbTt2_loai.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTt2_loai.Name = "cbbTt2_loai";
            this.cbbTt2_loai.Size = new System.Drawing.Size(99, 22);
            this.cbbTt2_loai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTt2_loai.TabIndex = 26;
            // 
            // lbTT1
            // 
            this.lbTT1.AutoSize = true;
            this.lbTT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTT1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTT1.Location = new System.Drawing.Point(575, 28);
            this.lbTT1.Margin = new System.Windows.Forms.Padding(2);
            this.lbTT1.Name = "lbTT1";
            this.lbTT1.Size = new System.Drawing.Size(33, 15);
            this.lbTT1.TabIndex = 25;
            this.lbTT1.Text = "(USD)";
            this.lbTT1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbbTt1_ma_nt
            // 
            this.cbbTt1_ma_nt.DisplayMember = "Text";
            this.cbbTt1_ma_nt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTt1_ma_nt.FormattingEnabled = true;
            this.cbbTt1_ma_nt.ItemHeight = 16;
            this.cbbTt1_ma_nt.Location = new System.Drawing.Point(231, 26);
            this.cbbTt1_ma_nt.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTt1_ma_nt.Name = "cbbTt1_ma_nt";
            this.cbbTt1_ma_nt.Size = new System.Drawing.Size(99, 22);
            this.cbbTt1_ma_nt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTt1_ma_nt.TabIndex = 22;
            // 
            // cbbTt1_loai
            // 
            this.cbbTt1_loai.DisplayMember = "Text";
            this.cbbTt1_loai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTt1_loai.FormattingEnabled = true;
            this.cbbTt1_loai.ItemHeight = 16;
            this.cbbTt1_loai.Location = new System.Drawing.Point(120, 26);
            this.cbbTt1_loai.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTt1_loai.Name = "cbbTt1_loai";
            this.cbbTt1_loai.Size = new System.Drawing.Size(99, 22);
            this.cbbTt1_loai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTt1_loai.TabIndex = 21;
            // 
            // labelX17
            // 
            this.labelX17.AutoSize = true;
            this.labelX17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(86, 121);
            this.labelX17.Margin = new System.Windows.Forms.Padding(2);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(82, 15);
            this.labelX17.TabIndex = 20;
            this.labelX17.Text = "Tổng thanh toán";
            // 
            // labelX16
            // 
            this.labelX16.AutoSize = true;
            this.labelX16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(33, 91);
            this.labelX16.Margin = new System.Windows.Forms.Padding(2);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(67, 15);
            this.labelX16.TabIndex = 19;
            this.labelX16.Text = "Thanh toán 3";
            // 
            // labelX15
            // 
            this.labelX15.AutoSize = true;
            this.labelX15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(33, 60);
            this.labelX15.Margin = new System.Windows.Forms.Padding(2);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(67, 15);
            this.labelX15.TabIndex = 18;
            this.labelX15.Text = "Thanh toán 2";
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            this.labelX14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(33, 28);
            this.labelX14.Margin = new System.Windows.Forms.Padding(2);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(67, 15);
            this.labelX14.TabIndex = 17;
            this.labelX14.Text = "Thanh toán 1";
            // 
            // groupPanel6
            // 
            this.groupPanel6.BackColor = System.Drawing.Color.LightGray;
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.txtTQDVND);
            this.groupPanel6.Controls.Add(this.labelX28);
            this.groupPanel6.Controls.Add(this.txtTong_thu_nt);
            this.groupPanel6.Controls.Add(this.labelX29);
            this.groupPanel6.Controls.Add(this.txtTong_giam_gia_nt);
            this.groupPanel6.Controls.Add(this.lbTongThu);
            this.groupPanel6.Controls.Add(this.txtTong_tien_hang_nt);
            this.groupPanel6.Controls.Add(this.labelX27);
            this.groupPanel6.Controls.Add(this.lbGiamGia);
            this.groupPanel6.Controls.Add(this.labelX25);
            this.groupPanel6.Controls.Add(this.lbTTH);
            this.groupPanel6.Controls.Add(this.labelX22);
            this.groupPanel6.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel6.Location = new System.Drawing.Point(622, 3);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(425, 187);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 3;
            this.groupPanel6.Text = "Tổng cộng";
            // 
            // txtTQDVND
            // 
            // 
            // 
            // 
            this.txtTQDVND.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTQDVND.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTQDVND.DisplayFormat = "#,##0.00";
            this.txtTQDVND.Enabled = false;
            this.txtTQDVND.Increment = 1D;
            this.txtTQDVND.Location = new System.Drawing.Point(236, 123);
            this.txtTQDVND.Name = "txtTQDVND";
            this.txtTQDVND.ShowUpDown = true;
            this.txtTQDVND.Size = new System.Drawing.Size(99, 20);
            this.txtTQDVND.TabIndex = 48;
            // 
            // labelX28
            // 
            this.labelX28.AutoSize = true;
            this.labelX28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX28.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX28.Location = new System.Drawing.Point(182, 124);
            this.labelX28.Margin = new System.Windows.Forms.Padding(2);
            this.labelX28.Name = "labelX28";
            this.labelX28.Size = new System.Drawing.Size(33, 15);
            this.labelX28.TabIndex = 46;
            this.labelX28.Text = "(VND)";
            this.labelX28.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTong_thu_nt
            // 
            // 
            // 
            // 
            this.txtTong_thu_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTong_thu_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTong_thu_nt.DisplayFormat = "#,##0.00";
            this.txtTong_thu_nt.Enabled = false;
            this.txtTong_thu_nt.Increment = 1D;
            this.txtTong_thu_nt.Location = new System.Drawing.Point(236, 95);
            this.txtTong_thu_nt.Name = "txtTong_thu_nt";
            this.txtTong_thu_nt.ShowUpDown = true;
            this.txtTong_thu_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTong_thu_nt.TabIndex = 47;
            // 
            // labelX29
            // 
            this.labelX29.AutoSize = true;
            this.labelX29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX29.Location = new System.Drawing.Point(89, 124);
            this.labelX29.Margin = new System.Windows.Forms.Padding(2);
            this.labelX29.Name = "labelX29";
            this.labelX29.Size = new System.Drawing.Size(66, 15);
            this.labelX29.TabIndex = 45;
            this.labelX29.Text = "Tổng quy đổi";
            // 
            // txtTong_giam_gia_nt
            // 
            // 
            // 
            // 
            this.txtTong_giam_gia_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTong_giam_gia_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTong_giam_gia_nt.DisplayFormat = "#,##0.00";
            this.txtTong_giam_gia_nt.Enabled = false;
            this.txtTong_giam_gia_nt.Increment = 1D;
            this.txtTong_giam_gia_nt.Location = new System.Drawing.Point(236, 65);
            this.txtTong_giam_gia_nt.Name = "txtTong_giam_gia_nt";
            this.txtTong_giam_gia_nt.ShowUpDown = true;
            this.txtTong_giam_gia_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTong_giam_gia_nt.TabIndex = 46;
            // 
            // lbTongThu
            // 
            this.lbTongThu.AutoSize = true;
            this.lbTongThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTongThu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTongThu.Location = new System.Drawing.Point(182, 93);
            this.lbTongThu.Margin = new System.Windows.Forms.Padding(2);
            this.lbTongThu.Name = "lbTongThu";
            this.lbTongThu.Size = new System.Drawing.Size(33, 15);
            this.lbTongThu.TabIndex = 43;
            this.lbTongThu.Text = "(USD)";
            this.lbTongThu.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTong_tien_hang_nt
            // 
            // 
            // 
            // 
            this.txtTong_tien_hang_nt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTong_tien_hang_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTong_tien_hang_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTong_tien_hang_nt.DisplayFormat = "#,##0.00";
            this.txtTong_tien_hang_nt.Enabled = false;
            this.txtTong_tien_hang_nt.Increment = 1D;
            this.txtTong_tien_hang_nt.Location = new System.Drawing.Point(236, 31);
            this.txtTong_tien_hang_nt.Name = "txtTong_tien_hang_nt";
            this.txtTong_tien_hang_nt.ShowUpDown = true;
            this.txtTong_tien_hang_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTong_tien_hang_nt.TabIndex = 45;
            // 
            // labelX27
            // 
            this.labelX27.AutoSize = true;
            this.labelX27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX27.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX27.Location = new System.Drawing.Point(89, 93);
            this.labelX27.Margin = new System.Windows.Forms.Padding(2);
            this.labelX27.Name = "labelX27";
            this.labelX27.Size = new System.Drawing.Size(46, 15);
            this.labelX27.TabIndex = 42;
            this.labelX27.Text = "Tổng thu";
            // 
            // lbGiamGia
            // 
            this.lbGiamGia.AutoSize = true;
            this.lbGiamGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbGiamGia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbGiamGia.Location = new System.Drawing.Point(182, 63);
            this.lbGiamGia.Margin = new System.Windows.Forms.Padding(2);
            this.lbGiamGia.Name = "lbGiamGia";
            this.lbGiamGia.Size = new System.Drawing.Size(33, 15);
            this.lbGiamGia.TabIndex = 40;
            this.lbGiamGia.Text = "(USD)";
            this.lbGiamGia.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX25
            // 
            this.labelX25.AutoSize = true;
            this.labelX25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX25.Location = new System.Drawing.Point(89, 63);
            this.labelX25.Margin = new System.Windows.Forms.Padding(2);
            this.labelX25.Name = "labelX25";
            this.labelX25.Size = new System.Drawing.Size(47, 15);
            this.labelX25.TabIndex = 39;
            this.labelX25.Text = "Giảm giá";
            // 
            // lbTTH
            // 
            this.lbTTH.AutoSize = true;
            this.lbTTH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbTTH.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTTH.Location = new System.Drawing.Point(182, 31);
            this.lbTTH.Margin = new System.Windows.Forms.Padding(2);
            this.lbTTH.Name = "lbTTH";
            this.lbTTH.Size = new System.Drawing.Size(33, 15);
            this.lbTTH.TabIndex = 38;
            this.lbTTH.Text = "(USD)";
            this.lbTTH.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX22
            // 
            this.labelX22.AutoSize = true;
            this.labelX22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Location = new System.Drawing.Point(89, 31);
            this.labelX22.Margin = new System.Windows.Forms.Padding(2);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(76, 15);
            this.labelX22.TabIndex = 21;
            this.labelX22.Text = "Tổng tiền hàng";
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.LightGray;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.lbQuyDoiTienTe);
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Location = new System.Drawing.Point(1053, 3);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(312, 187);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 2;
            this.groupPanel5.Text = "Quy đổi tiền tệ";
            // 
            // lbQuyDoiTienTe
            // 
            this.lbQuyDoiTienTe.AutoSize = true;
            this.lbQuyDoiTienTe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbQuyDoiTienTe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbQuyDoiTienTe.Location = new System.Drawing.Point(51, 28);
            this.lbQuyDoiTienTe.Margin = new System.Windows.Forms.Padding(2);
            this.lbQuyDoiTienTe.Name = "lbQuyDoiTienTe";
            this.lbQuyDoiTienTe.Size = new System.Drawing.Size(62, 15);
            this.lbQuyDoiTienTe.TabIndex = 48;
            this.lbQuyDoiTienTe.Text = "Tiền quy đổi";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.labelItem2,
            this.labelItem3,
            this.labelItem4,
            this.labelItem7,
            this.labelItem8,
            this.labelItem9,
            this.labelItem10,
            this.labelItem11,
            this.labelItem12,
            this.labelItem13,
            this.labelItem14,
            this.labelItem15});
            this.bar2.Location = new System.Drawing.Point(0, 820);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1426, 19);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 25;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Black;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "F1: Hướng dẫn ";
            // 
            // labelItem2
            // 
            this.labelItem2.ForeColor = System.Drawing.Color.Black;
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "| ";
            // 
            // labelItem3
            // 
            this.labelItem3.ForeColor = System.Drawing.Color.Black;
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "F2: Lưu và in ";
            // 
            // labelItem4
            // 
            this.labelItem4.ForeColor = System.Drawing.Color.Black;
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "| ";
            // 
            // labelItem7
            // 
            this.labelItem7.ForeColor = System.Drawing.Color.Black;
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "F7: Xóa dòng ";
            // 
            // labelItem8
            // 
            this.labelItem8.ForeColor = System.Drawing.Color.Black;
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "| ";
            // 
            // labelItem9
            // 
            this.labelItem9.ForeColor = System.Drawing.Color.Black;
            this.labelItem9.Name = "labelItem9";
            this.labelItem9.Text = "F8: Xóa hết ";
            // 
            // labelItem10
            // 
            this.labelItem10.Name = "labelItem10";
            this.labelItem10.Text = "| ";
            // 
            // labelItem11
            // 
            this.labelItem11.ForeColor = System.Drawing.Color.Black;
            this.labelItem11.Name = "labelItem11";
            this.labelItem11.Text = "F9: Chọn khách hàng ";
            // 
            // labelItem12
            // 
            this.labelItem12.ForeColor = System.Drawing.Color.Black;
            this.labelItem12.Name = "labelItem12";
            this.labelItem12.Text = "| ";
            // 
            // labelItem13
            // 
            this.labelItem13.ForeColor = System.Drawing.Color.Black;
            this.labelItem13.Name = "labelItem13";
            this.labelItem13.Text = "F10: Nhập mã vạch ";
            // 
            // labelItem14
            // 
            this.labelItem14.BackColor = System.Drawing.Color.Transparent;
            this.labelItem14.ForeColor = System.Drawing.Color.Black;
            this.labelItem14.Name = "labelItem14";
            this.labelItem14.Text = "| ";
            // 
            // labelItem15
            // 
            this.labelItem15.BackColor = System.Drawing.Color.Transparent;
            this.labelItem15.ForeColor = System.Drawing.Color.Black;
            this.labelItem15.Name = "labelItem15";
            this.labelItem15.Text = "F12: Lưu tạm";
            // 
            // labelX34
            // 
            this.labelX34.AutoSize = true;
            // 
            // 
            // 
            this.labelX34.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX34.Location = new System.Drawing.Point(236, 780);
            this.labelX34.Margin = new System.Windows.Forms.Padding(2);
            this.labelX34.Name = "labelX34";
            this.labelX34.Size = new System.Drawing.Size(33, 15);
            this.labelX34.TabIndex = 38;
            this.labelX34.Text = "(USD)";
            this.labelX34.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbTraLai
            // 
            this.lbTraLai.AutoSize = true;
            // 
            // 
            // 
            this.lbTraLai.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTraLai.Location = new System.Drawing.Point(456, 780);
            this.lbTraLai.Margin = new System.Windows.Forms.Padding(2);
            this.lbTraLai.Name = "lbTraLai";
            this.lbTraLai.Size = new System.Drawing.Size(33, 15);
            this.lbTraLai.TabIndex = 41;
            this.lbTraLai.Text = "(USD)";
            this.lbTraLai.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX37
            // 
            this.labelX37.AutoSize = true;
            // 
            // 
            // 
            this.labelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX37.Location = new System.Drawing.Point(496, 780);
            this.labelX37.Margin = new System.Windows.Forms.Padding(2);
            this.labelX37.Name = "labelX37";
            this.labelX37.Size = new System.Drawing.Size(9, 15);
            this.labelX37.TabIndex = 44;
            this.labelX37.Text = "=";
            this.labelX37.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbTra_lai
            // 
            this.cbTra_lai.DisplayMember = "Text";
            this.cbTra_lai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTra_lai.FormattingEnabled = true;
            this.cbTra_lai.ItemHeight = 16;
            this.cbTra_lai.Location = new System.Drawing.Point(620, 776);
            this.cbTra_lai.Margin = new System.Windows.Forms.Padding(2);
            this.cbTra_lai.Name = "cbTra_lai";
            this.cbTra_lai.Size = new System.Drawing.Size(102, 22);
            this.cbTra_lai.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbTra_lai.TabIndex = 38;
            // 
            // lbTongNhan
            // 
            this.lbTongNhan.AutoSize = true;
            // 
            // 
            // 
            this.lbTongNhan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTongNhan.Location = new System.Drawing.Point(65, 780);
            this.lbTongNhan.Margin = new System.Windows.Forms.Padding(2);
            this.lbTongNhan.Name = "lbTongNhan";
            this.lbTongNhan.Size = new System.Drawing.Size(55, 15);
            this.lbTongNhan.TabIndex = 45;
            this.lbTongNhan.Text = "Tổng nhận";
            this.lbTongNhan.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX32
            // 
            this.labelX32.AutoSize = true;
            // 
            // 
            // 
            this.labelX32.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX32.Location = new System.Drawing.Point(304, 780);
            this.labelX32.Margin = new System.Windows.Forms.Padding(2);
            this.labelX32.Name = "labelX32";
            this.labelX32.Size = new System.Drawing.Size(33, 15);
            this.labelX32.TabIndex = 46;
            this.labelX32.Text = "Trả lại";
            this.labelX32.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTong_nhan
            // 
            // 
            // 
            // 
            this.txtTong_nhan.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTong_nhan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTong_nhan.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTong_nhan.DisplayFormat = "#,##0.00";
            this.txtTong_nhan.Increment = 1D;
            this.txtTong_nhan.Location = new System.Drawing.Point(125, 777);
            this.txtTong_nhan.Name = "txtTong_nhan";
            this.txtTong_nhan.ShowUpDown = true;
            this.txtTong_nhan.Size = new System.Drawing.Size(99, 20);
            this.txtTong_nhan.TabIndex = 49;
            // 
            // txtTra_lai_nt
            // 
            // 
            // 
            // 
            this.txtTra_lai_nt.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTra_lai_nt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTra_lai_nt.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTra_lai_nt.DisplayFormat = "#,##0.00";
            this.txtTra_lai_nt.Enabled = false;
            this.txtTra_lai_nt.Increment = 1D;
            this.txtTra_lai_nt.Location = new System.Drawing.Point(342, 777);
            this.txtTra_lai_nt.Name = "txtTra_lai_nt";
            this.txtTra_lai_nt.ShowUpDown = true;
            this.txtTra_lai_nt.Size = new System.Drawing.Size(99, 20);
            this.txtTra_lai_nt.TabIndex = 50;
            // 
            // txtTra_lai
            // 
            // 
            // 
            // 
            this.txtTra_lai.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTra_lai.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTra_lai.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTra_lai.DisplayFormat = "#,##0.00";
            this.txtTra_lai.Enabled = false;
            this.txtTra_lai.Increment = 1D;
            this.txtTra_lai.Location = new System.Drawing.Point(513, 777);
            this.txtTra_lai.Name = "txtTra_lai";
            this.txtTra_lai.ShowUpDown = true;
            this.txtTra_lai.Size = new System.Drawing.Size(99, 20);
            this.txtTra_lai.TabIndex = 51;
            // 
            // ucHangHoa
            // 
            this.ucHangHoa.Location = new System.Drawing.Point(156, 9);
            this.ucHangHoa.Name = "ucHangHoa";
            this.ucHangHoa.Size = new System.Drawing.Size(151, 24);
            this.ucHangHoa.TabIndex = 1;
            // 
            // DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 839);
            this.Controls.Add(this.txtTra_lai);
            this.Controls.Add(this.txtTra_lai_nt);
            this.Controls.Add(this.txtTong_nhan);
            this.Controls.Add(this.labelX32);
            this.Controls.Add(this.lbTongNhan);
            this.Controls.Add(this.cbTra_lai);
            this.Controls.Add(this.labelX37);
            this.Controls.Add(this.lbTraLai);
            this.Controls.Add(this.labelX34);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1444, 885);
            this.Name = "DonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo đơn hàng";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt_tong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt3_tien_nt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt2_tien_nt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt1_tien_nt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt3_tien_tt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt2_tien_tt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTt1_tien_tt)).EndInit();
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTQDVND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_thu_nt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_giam_gia_nt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_tien_hang_nt)).EndInit();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTong_nhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTra_lai_nt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTra_lai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.LabelItem labelItem9;
        private DevComponents.DotNetBar.LabelItem labelItem10;
        private DevComponents.DotNetBar.LabelItem labelItem11;
        private DevComponents.DotNetBar.LabelItem labelItem12;
        private DevComponents.DotNetBar.LabelItem labelItem13;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDiaChi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQuocTinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCCCD;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenKhachHang;
        private DevComponents.DotNetBar.LabelX lbTen;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lbCa;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX lbQuay;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX lbTenDangNhap;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX lbMST;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTt1_loai;
        private DevComponents.DotNetBar.LabelX labelX17;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX lbTTT;
        private DevComponents.DotNetBar.LabelX lbTT3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTt3_ma_nt;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTt3_loai;
        private DevComponents.DotNetBar.LabelX lbTT2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTt2_ma_nt;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTt2_loai;
        private DevComponents.DotNetBar.LabelX lbTT1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTt1_ma_nt;
        private DevComponents.DotNetBar.LabelX lbTTH;
        private DevComponents.DotNetBar.LabelX labelX22;
        private DevComponents.DotNetBar.LabelX labelX28;
        private DevComponents.DotNetBar.LabelX labelX29;
        private DevComponents.DotNetBar.LabelX lbTongThu;
        private DevComponents.DotNetBar.LabelX labelX27;
        private DevComponents.DotNetBar.LabelX lbGiamGia;
        private DevComponents.DotNetBar.LabelX labelX25;
        private DevComponents.DotNetBar.LabelX lbQuyDoiTienTe;
        private DevComponents.DotNetBar.LabelX labelX34;
        private DevComponents.DotNetBar.LabelX lbTraLai;
        private DevComponents.DotNetBar.LabelX labelX37;
        private DevComponents.DotNetBar.LabelX lbTongNhan;
        private DevComponents.DotNetBar.LabelX labelX32;
        private UserControls.ucHangHoa ucHangHoa;
        private DevComponents.Editors.DoubleInput txtTt3_tien_tt;
        private DevComponents.Editors.DoubleInput txtTt2_tien_tt;
        private DevComponents.Editors.DoubleInput txtTt_tong;
        private DevComponents.Editors.DoubleInput txtTt3_tien_nt;
        private DevComponents.Editors.DoubleInput txtTt2_tien_nt;
        private DevComponents.Editors.DoubleInput txtTt1_tien_nt;
        private DevComponents.Editors.DoubleInput txtTong_nhan;
        private DevComponents.Editors.DoubleInput txtTra_lai_nt;
        private DevComponents.Editors.DoubleInput txtTQDVND;
        private DevComponents.Editors.DoubleInput txtTong_thu_nt;
        private DevComponents.Editors.DoubleInput txtTong_giam_gia_nt;
        private DevComponents.Editors.DoubleInput txtTra_lai;
        private DevComponents.Editors.DoubleInput txtTong_tien_hang_nt;
        private DevComponents.DotNetBar.LabelX lbSCT;
        private DevComponents.DotNetBar.LabelX lbTGNT;
        private DevComponents.DotNetBar.LabelX lbNgayHoaDon;
        private DevComponents.DotNetBar.LabelItem labelItem14;
        private DevComponents.DotNetBar.LabelItem labelItem15;
        private DevComponents.DotNetBar.LabelX lbSoChungTu;
        private DevComponents.DotNetBar.LabelX lbMaPhieu;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.Editors.DoubleInput txtTt1_tien_tt;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbTra_lai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dvt;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia_ban_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gg_ty_le;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gg_tien_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gg_tien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tien_ban_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tien_ban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gg_ly_do;
    }
}