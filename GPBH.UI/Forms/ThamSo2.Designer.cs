namespace GPBH.UI.Forms
{
    partial class ThamSo2
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
            this.txtKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTen = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtGiaTri = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtMoTa = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(7, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(21, 15);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Key";
            // 
            // txtKey
            // 
            // 
            // 
            // 
            this.txtKey.Border.Class = "TextBoxBorder";
            this.txtKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKey.Location = new System.Drawing.Point(49, 9);
            this.txtKey.Name = "txtKey";
            this.txtKey.PreventEnterBeep = true;
            this.txtKey.Size = new System.Drawing.Size(112, 20);
            this.txtKey.TabIndex = 1;
            // 
            // txtTen
            // 
            // 
            // 
            // 
            this.txtTen.Border.Class = "TextBoxBorder";
            this.txtTen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTen.Location = new System.Drawing.Point(203, 9);
            this.txtTen.Name = "txtTen";
            this.txtTen.PreventEnterBeep = true;
            this.txtTen.Size = new System.Drawing.Size(136, 20);
            this.txtTen.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(176, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(21, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tên";
            // 
            // txtGiaTri
            // 
            // 
            // 
            // 
            this.txtGiaTri.Border.Class = "TextBoxBorder";
            this.txtGiaTri.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGiaTri.Location = new System.Drawing.Point(49, 36);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.PreventEnterBeep = true;
            this.txtGiaTri.Size = new System.Drawing.Size(290, 20);
            this.txtGiaTri.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(7, 39);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(32, 15);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Giá trị";
            // 
            // txtMoTa
            // 
            // 
            // 
            // 
            this.txtMoTa.Border.Class = "TextBoxBorder";
            this.txtMoTa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMoTa.Location = new System.Drawing.Point(49, 63);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PreventEnterBeep = true;
            this.txtMoTa.Size = new System.Drawing.Size(289, 44);
            this.txtMoTa.TabIndex = 7;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(7, 68);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(30, 15);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Mô tả";
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(263, 114);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 22;
            this.btnLuu.Text = "Cập nhật";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // ThamSo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 144);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ThamSo2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tham số";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtKey;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTen;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGiaTri;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        public DevComponents.DotNetBar.Controls.TextBoxX txtMoTa;
    }
}