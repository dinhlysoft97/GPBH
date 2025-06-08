namespace GPBH.UI.UserControls
{
    partial class UserControlKhachHang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ColumnPassport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTenKh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNgayHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNgayCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPassport,
            this.ColumnMaKH,
            this.ColumnTenKh,
            this.ColumnNgayHH,
            this.ColumnNgayCap,
            this.ColumnQuocGia,
            this.ColumGioiTinh,
            this.ColumnNgaySinh,
            this.ColumnDiaChi,
            this.ColumnSDT,
            this.ColumnDiDong,
            this.ColumnEmail,
            this.ColumnTongTien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 50);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.Size = new System.Drawing.Size(1427, 347);
            this.dataGridViewX2.TabIndex = 4;
            // 
            // ColumnPassport
            // 
            this.ColumnPassport.HeaderText = "Passport No";
            this.ColumnPassport.Name = "ColumnPassport";
            // 
            // ColumnMaKH
            // 
            this.ColumnMaKH.HeaderText = "Mã khách hàng";
            this.ColumnMaKH.Name = "ColumnMaKH";
            // 
            // ColumnTenKh
            // 
            this.ColumnTenKh.HeaderText = "Tên khách hàng";
            this.ColumnTenKh.Name = "ColumnTenKh";
            // 
            // ColumnNgayHH
            // 
            this.ColumnNgayHH.HeaderText = "Ngày hết hạn hộ chiếu";
            this.ColumnNgayHH.Name = "ColumnNgayHH";
            // 
            // ColumnNgayCap
            // 
            this.ColumnNgayCap.HeaderText = "Ngày cấp hộ chiếu";
            this.ColumnNgayCap.Name = "ColumnNgayCap";
            // 
            // ColumnQuocGia
            // 
            this.ColumnQuocGia.HeaderText = "Quốc gia cấp";
            this.ColumnQuocGia.Name = "ColumnQuocGia";
            // 
            // ColumGioiTinh
            // 
            this.ColumGioiTinh.HeaderText = "Giới tính";
            this.ColumGioiTinh.Name = "ColumGioiTinh";
            // 
            // ColumnNgaySinh
            // 
            this.ColumnNgaySinh.HeaderText = "Ngày Sinh";
            this.ColumnNgaySinh.Name = "ColumnNgaySinh";
            // 
            // ColumnDiaChi
            // 
            this.ColumnDiaChi.HeaderText = "Địa chỉ";
            this.ColumnDiaChi.Name = "ColumnDiaChi";
            // 
            // ColumnSDT
            // 
            this.ColumnSDT.HeaderText = "Số điện thoại";
            this.ColumnSDT.Name = "ColumnSDT";
            // 
            // ColumnDiDong
            // 
            this.ColumnDiDong.HeaderText = "Di động";
            this.ColumnDiDong.Name = "ColumnDiDong";
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.HeaderText = "Email";
            this.ColumnEmail.Name = "ColumnEmail";
            // 
            // ColumnTongTien
            // 
            this.ColumnTongTien.HeaderText = "Tổng tiền mua";
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
            this.Size = new System.Drawing.Size(1434, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenKh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNgayHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNgayCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}
