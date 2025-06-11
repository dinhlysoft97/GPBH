namespace GPBH.UI.Forms
{
    partial class NguoiSuDung
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
            this.txtTenDayDu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenDangNhap = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtXacNhanMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.checkCapLaiQuyen = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkAdmin = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkKSD = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnDong = new DevComponents.DotNetBar.ButtonX();
            this.lbError = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(44, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(57, 15);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên đầy đủ";
            // 
            // txtTenDayDu
            // 
            // 
            // 
            // 
            this.txtTenDayDu.Border.Class = "TextBoxBorder";
            this.txtTenDayDu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDayDu.Location = new System.Drawing.Point(153, 27);
            this.txtTenDayDu.Name = "txtTenDayDu";
            this.txtTenDayDu.PreventEnterBeep = true;
            this.txtTenDayDu.Size = new System.Drawing.Size(153, 20);
            this.txtTenDayDu.TabIndex = 1;
            // 
            // txtTenDangNhap
            // 
            // 
            // 
            // 
            this.txtTenDangNhap.Border.Class = "TextBoxBorder";
            this.txtTenDangNhap.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDangNhap.Location = new System.Drawing.Point(153, 57);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.PreventEnterBeep = true;
            this.txtTenDangNhap.Size = new System.Drawing.Size(153, 20);
            this.txtTenDangNhap.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(44, 60);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(76, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tên đăng nhập";
            // 
            // txtMatKhau
            // 
            // 
            // 
            // 
            this.txtMatKhau.Border.Class = "TextBoxBorder";
            this.txtMatKhau.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMatKhau.Location = new System.Drawing.Point(153, 89);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.PreventEnterBeep = true;
            this.txtMatKhau.Size = new System.Drawing.Size(153, 20);
            this.txtMatKhau.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(44, 92);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(48, 15);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Mật khẩu";
            // 
            // txtXacNhanMatKhau
            // 
            // 
            // 
            // 
            this.txtXacNhanMatKhau.Border.Class = "TextBoxBorder";
            this.txtXacNhanMatKhau.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(153, 120);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '*';
            this.txtXacNhanMatKhau.PreventEnterBeep = true;
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(153, 20);
            this.txtXacNhanMatKhau.TabIndex = 7;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(44, 123);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(91, 15);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Nhập lại mật khẩu";
            // 
            // checkCapLaiQuyen
            // 
            this.checkCapLaiQuyen.AutoSize = true;
            // 
            // 
            // 
            this.checkCapLaiQuyen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkCapLaiQuyen.Location = new System.Drawing.Point(44, 165);
            this.checkCapLaiQuyen.Name = "checkCapLaiQuyen";
            this.checkCapLaiQuyen.Size = new System.Drawing.Size(90, 15);
            this.checkCapLaiQuyen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkCapLaiQuyen.TabIndex = 8;
            this.checkCapLaiQuyen.Text = "Cấp lại quyền";
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            // 
            // 
            // 
            this.checkAdmin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkAdmin.Location = new System.Drawing.Point(145, 165);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(54, 15);
            this.checkAdmin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkAdmin.TabIndex = 9;
            this.checkAdmin.Text = "Admin";
            // 
            // checkKSD
            // 
            this.checkKSD.AutoSize = true;
            // 
            // 
            // 
            this.checkKSD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkKSD.Location = new System.Drawing.Point(206, 165);
            this.checkKSD.Name = "checkKSD";
            this.checkKSD.Size = new System.Drawing.Size(96, 15);
            this.checkKSD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkKSD.TabIndex = 10;
            this.checkKSD.Text = "Không sử dụng";
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(44, 213);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            // 
            // btnDong
            // 
            this.btnDong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDong.Location = new System.Drawing.Point(134, 213);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDong.TabIndex = 12;
            this.btnDong.Text = "Đóng";
            // 
            // lbError
            // 
            // 
            // 
            // 
            this.lbError.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbError.Location = new System.Drawing.Point(44, 187);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(258, 23);
            this.lbError.TabIndex = 13;
            // 
            // NguoiSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 238);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.checkKSD);
            this.Controls.Add(this.checkAdmin);
            this.Controls.Add(this.checkCapLaiQuyen);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtTenDayDu);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NguoiSuDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Người sửa dụng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDayDu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDangNhap;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMatKhau;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtXacNhanMatKhau;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkCapLaiQuyen;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkAdmin;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkKSD;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnDong;
        private DevComponents.DotNetBar.LabelX lbError;
    }
}