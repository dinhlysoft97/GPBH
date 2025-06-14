namespace GPBH.UI.Forms
{
    partial class FormCa
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
            this.txtMaCa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenCa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtGioBD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtGioKT = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
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
            this.labelX1.Size = new System.Drawing.Size(32, 15);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Mã ca";
            // 
            // txtMaCa
            // 
            // 
            // 
            // 
            this.txtMaCa.Border.Class = "TextBoxBorder";
            this.txtMaCa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaCa.Location = new System.Drawing.Point(153, 27);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.PreventEnterBeep = true;
            this.txtMaCa.Size = new System.Drawing.Size(153, 20);
            this.txtMaCa.TabIndex = 1;
            // 
            // txtTenCa
            // 
            // 
            // 
            // 
            this.txtTenCa.Border.Class = "TextBoxBorder";
            this.txtTenCa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenCa.Location = new System.Drawing.Point(153, 57);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.PreventEnterBeep = true;
            this.txtTenCa.Size = new System.Drawing.Size(153, 20);
            this.txtTenCa.TabIndex = 3;
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
            this.labelX2.Size = new System.Drawing.Size(36, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tên ca";
            // 
            // txtGioBD
            // 
            // 
            // 
            // 
            this.txtGioBD.Border.Class = "TextBoxBorder";
            this.txtGioBD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGioBD.Location = new System.Drawing.Point(153, 89);
            this.txtGioBD.Name = "txtGioBD";
            this.txtGioBD.PreventEnterBeep = true;
            this.txtGioBD.Size = new System.Drawing.Size(153, 20);
            this.txtGioBD.TabIndex = 5;
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
            this.labelX3.Size = new System.Drawing.Size(59, 15);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Giờ bất đầu";
            // 
            // txtGioKT
            // 
            // 
            // 
            // 
            this.txtGioKT.Border.Class = "TextBoxBorder";
            this.txtGioKT.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGioKT.Location = new System.Drawing.Point(153, 120);
            this.txtGioKT.Name = "txtGioKT";
            this.txtGioKT.PreventEnterBeep = true;
            this.txtGioKT.Size = new System.Drawing.Size(153, 20);
            this.txtGioKT.TabIndex = 7;
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
            this.labelX4.Size = new System.Drawing.Size(61, 15);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Giờ kết thúc";
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(44, 158);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // btnDong
            // 
            this.btnDong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDong.Location = new System.Drawing.Point(134, 158);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDong.TabIndex = 12;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lbError
            // 
            // 
            // 
            // 
            this.lbError.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbError.Location = new System.Drawing.Point(44, 203);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(258, 23);
            this.lbError.TabIndex = 13;
            // 
            // FormCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(353, 238);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtGioKT);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtGioBD);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtTenCa);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtMaCa);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaCa;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenCa;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGioBD;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGioKT;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnDong;
        private DevComponents.DotNetBar.LabelX lbError;
    }
}