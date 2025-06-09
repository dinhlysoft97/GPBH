using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    partial class UserControlKhachHang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DevComponents.DotNetBar.ButtonX btnDelete;

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
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_cap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quoc_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gioi_tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_sinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia_chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dien_thoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Di_dong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(100, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(0, 14);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(90, 30);
            this.buttonX1.TabIndex = 3;
            this.buttonX1.Text = "Thêm mới";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 50);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.Size = new System.Drawing.Size(1342, 347);
            this.dataGridViewX2.TabIndex = 4;
            dataGridViewX2.AutoGenerateColumns = false;
            this.dataGridViewX2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX2_CellDoubleClick);
            dataGridViewX2.Columns.Clear();

            // PassportNo
            var colPassportNo = new DataGridViewTextBoxColumn();
            colPassportNo.Name = "Passport";
            colPassportNo.HeaderText = "PassportNo";
            colPassportNo.DataPropertyName = "Passport";
            dataGridViewX2.Columns.Add(colPassportNo);

            // Mã khách hàng
            var colMaKH = new DataGridViewTextBoxColumn();
            colMaKH.HeaderText = "Mã khách hàng";
            colMaKH.DataPropertyName = "Passport";
            dataGridViewX2.Columns.Add(colMaKH);

            // Họ và tên
            var colHoTen = new DataGridViewTextBoxColumn();
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.Name = "colHoTen";
            dataGridViewX2.Columns.Add(colHoTen);

            // Ngày cấp hộ chiếu
            var colNgayCap = new DataGridViewTextBoxColumn();
            colNgayCap.HeaderText = "Ngày cấp hộ chiếu";
            colNgayCap.DataPropertyName = "Ngay_cap";
            colNgayCap.Name = "Ngay_cap";
            dataGridViewX2.Columns.Add(colNgayCap);

            // Ngày hết hạn hộ chiếu
            var colNgayHH = new DataGridViewTextBoxColumn();
            colNgayHH.HeaderText = "Ngày hết hạn hộ chiếu";
            colNgayHH.DataPropertyName = "Ngay_hh";
            colNgayHH.Name = "Ngay_hh";
            dataGridViewX2.Columns.Add(colNgayHH);

            // Quốc gia cấp
            var colQuocGia = new DataGridViewTextBoxColumn();
            colQuocGia.HeaderText = "Quốc gia cấp";
            colQuocGia.DataPropertyName = "Quoc_gia";
            colQuocGia.Name = "Quoc_gia";
            dataGridViewX2.Columns.Add(colQuocGia);

            // Giới tính
            var colGioiTinh = new DataGridViewTextBoxColumn();
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.DataPropertyName = "Gioi_tinh";
            colGioiTinh.Name = "Gioi_tinh";
            dataGridViewX2.Columns.Add(colGioiTinh);

            // Ngày sinh
            var colNgaySinh = new DataGridViewTextBoxColumn();
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.DataPropertyName = "Ngay_sinh";
            colNgaySinh.Name = "Ngay_sinh";
            dataGridViewX2.Columns.Add(colNgaySinh);

            // Địa chỉ
            var colDiaChi = new DataGridViewTextBoxColumn();
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.DataPropertyName = "Dia_chi";
            colDiaChi.Name = "Dia_chi";
            dataGridViewX2.Columns.Add(colDiaChi);

            // Điện thoại
            var colDienThoai = new DataGridViewTextBoxColumn();
            colDienThoai.HeaderText = "Điện thoại";
            colDienThoai.DataPropertyName = "Dien_thoai";
            colDienThoai.Name = "Dien_thoai";
            dataGridViewX2.Columns.Add(colDienThoai);

            // Di động
            var colDiDong = new DataGridViewTextBoxColumn();
            colDiDong.HeaderText = "Di động";
            colDiDong.DataPropertyName = "Di_dong";
            colDiDong.Name = "Di_dong";
            dataGridViewX2.Columns.Add(colDiDong);

            // Email
            var colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Name = "Email";
            dataGridViewX2.Columns.Add(colEmail);

            // Tổng tiền mua
            var colTongTien = new DataGridViewTextBoxColumn();
            colTongTien.HeaderText = "Tổng tiền mua";
            colTongTien.DataPropertyName = "TienMua";
            dataGridViewX2.Columns.Add(colTongTien);

            // 
            // Passport
            // 
            this.Passport.Name = "Passport";
            // 
            // Ho
            // 
            this.Ho.Name = "Ho";
            // 
            // TenKH
            // 
            this.TenKH.Name = "TenKH";
            // 
            // Ngay_hh
            // 
            this.Ngay_hh.Name = "Ngay_hh";
            // 
            // Ngay_cap
            // 
            this.Ngay_cap.Name = "Ngay_cap";
            // 
            // Quoc_gia
            // 
            this.Quoc_gia.Name = "Quoc_gia";
            // 
            // Gioi_tinh
            // 
            this.Gioi_tinh.Name = "Gioi_tinh";
            // 
            // Ngay_sinh
            // 
            this.Ngay_sinh.Name = "Ngay_sinh";
            // 
            // Dia_chi
            // 
            this.Dia_chi.Name = "Dia_chi";
            // 
            // Dien_thoai
            // 
            this.Dien_thoai.Name = "Dien_thoai";
            // 
            // Di_dong
            // 
            this.Di_dong.Name = "Di_dong";
            // 
            // Email
            // 
            this.Email.Name = "Email";
            // 
            // ColumnTongTien
            // 
            this.ColumnTongTien.Name = "ColumnTongTien";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm kiếm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 405);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UserControlKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnDelete);
            this.Name = "UserControlKhachHang";
            this.Size = new System.Drawing.Size(1343, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ho;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_cap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quoc_gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gioi_tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_sinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia_chi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dien_thoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Di_dong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTongTien;
    }
}
