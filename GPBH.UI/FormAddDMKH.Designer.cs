using GPBH.UI.Placeholder;
using System.Drawing;
using System.Windows.Forms;

namespace GPBH.UI
{
    partial class FormAddDMKH
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textPassport = new System.Windows.Forms.TextBox();
            this.textHo = new System.Windows.Forms.TextBox();
            this.textSDT = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textTen = new System.Windows.Forms.TextBox();
            this.textTenDem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDropDownQuocTich = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.textBoxDropDownGioiTinh = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.dtpNgayCap = new System.Windows.Forms.DateTimePicker();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dtpHetHan = new System.Windows.Forms.DateTimePicker();
            this.textMaKH = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Passport *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quốc tịch *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày cấp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số điện thoại *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textPassport
            // 
            this.textPassport.Location = new System.Drawing.Point(112, 23);
            this.textPassport.Name = "textPassport";
            this.textPassport.Size = new System.Drawing.Size(141, 20);
            this.textPassport.TabIndex = 8;
            // 
            // textHo
            // 
            this.textHo.Location = new System.Drawing.Point(112, 70);
            this.textHo.Name = "textHo";
            this.textHo.Size = new System.Drawing.Size(141, 20);
            this.textHo.TabIndex = 9;
            // 
            // textSDT
            // 
            this.textSDT.Location = new System.Drawing.Point(112, 256);
            this.textSDT.Name = "textSDT";
            this.textSDT.Size = new System.Drawing.Size(141, 20);
            this.textSDT.TabIndex = 13;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(112, 304);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(201, 20);
            this.textEmail.TabIndex = 14;
            // 
            // textTen
            // 
            this.textTen.Location = new System.Drawing.Point(406, 70);
            this.textTen.Name = "textTen";
            this.textTen.Size = new System.Drawing.Size(141, 20);
            this.textTen.TabIndex = 15;
            // 
            // textTenDem
            // 
            this.textTenDem.Location = new System.Drawing.Point(259, 70);
            this.textTenDem.Name = "textTenDem";
            this.textTenDem.Size = new System.Drawing.Size(141, 20);
            this.textTenDem.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã KH/CCCD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Giới tính";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Hết hạn";
            // 
            // textBoxDropDownQuocTich
            // 
            // 
            // 
            // 
            this.textBoxDropDownQuocTich.BackgroundStyle.Class = "TextBoxBorder";
            this.textBoxDropDownQuocTich.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDropDownQuocTich.ButtonDropDown.Visible = true;
            this.textBoxDropDownQuocTich.Location = new System.Drawing.Point(112, 117);
            this.textBoxDropDownQuocTich.Name = "textBoxDropDownQuocTich";
            this.textBoxDropDownQuocTich.Size = new System.Drawing.Size(141, 19);
            this.textBoxDropDownQuocTich.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.textBoxDropDownQuocTich.TabIndex = 20;
            this.textBoxDropDownQuocTich.Text = "";
            // 
            // textBoxDropDownGioiTinh
            // 
            // 
            // 
            // 
            this.textBoxDropDownGioiTinh.BackgroundStyle.Class = "TextBoxBorder";
            this.textBoxDropDownGioiTinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxDropDownGioiTinh.ButtonDropDown.Visible = true;
            this.textBoxDropDownGioiTinh.Location = new System.Drawing.Point(406, 119);
            this.textBoxDropDownGioiTinh.Name = "textBoxDropDownGioiTinh";
            this.textBoxDropDownGioiTinh.Size = new System.Drawing.Size(141, 19);
            this.textBoxDropDownGioiTinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.textBoxDropDownGioiTinh.TabIndex = 21;
            this.textBoxDropDownGioiTinh.Text = "";
            // 
            // dtpNgayCap
            // 
            this.dtpNgayCap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayCap.Location = new System.Drawing.Point(112, 158);
            this.dtpNgayCap.Name = "dtpNgayCap";
            this.dtpNgayCap.Size = new System.Drawing.Size(141, 20);
            this.dtpNgayCap.TabIndex = 22;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(112, 210);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(141, 20);
            this.dtpNgaySinh.TabIndex = 23;
            // 
            // dtpHetHan
            // 
            this.dtpHetHan.CustomFormat = "dd/MM/yyyy";
            this.dtpHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHetHan.Location = new System.Drawing.Point(406, 164);
            this.dtpHetHan.Name = "dtpHetHan";
            this.dtpHetHan.Size = new System.Drawing.Size(141, 20);
            this.dtpHetHan.TabIndex = 24;
            // 
            // textMaKH
            // 
            this.textMaKH.Location = new System.Drawing.Point(407, 20);
            this.textMaKH.Name = "textMaKH";
            this.textMaKH.Size = new System.Drawing.Size(140, 20);
            this.textMaKH.TabIndex = 25;
            // 
            // FormAddDMKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 392);
            this.Controls.Add(this.textMaKH);
            this.Controls.Add(this.dtpHetHan);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.dtpNgayCap);
            this.Controls.Add(this.textBoxDropDownGioiTinh);
            this.Controls.Add(this.textBoxDropDownQuocTich);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textTenDem);
            this.Controls.Add(this.textTen);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textSDT);
            this.Controls.Add(this.textHo);
            this.Controls.Add(this.textPassport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddDMKH";
            this.Text = "FormAddDSKH";
            this.ResumeLayout(false);
            this.PerformLayout();
            textBoxDropDownGioiTinh.DropDownItems.Clear();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textPassport;
        private System.Windows.Forms.TextBox textHo;
        private System.Windows.Forms.TextBox textSDT;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textTen;
        private System.Windows.Forms.TextBox textTenDem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown textBoxDropDownQuocTich;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown textBoxDropDownGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgayCap;
        private DateTimePicker dtpNgaySinh;
        private DateTimePicker dtpHetHan;
        private TextBox textMaKH;
    }
}