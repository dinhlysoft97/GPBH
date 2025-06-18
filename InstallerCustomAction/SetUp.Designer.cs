namespace InstallerCustomAction
{
    partial class SetUp
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtMaQuay = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMaKho = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.txtCuaHang = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 15);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Mã cử hàng*";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 48);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(49, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Mã quày*";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 78);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(43, 15);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "Mã kho*";
            // 
            // txtMaQuay
            // 
            // 
            // 
            // 
            this.txtMaQuay.Border.Class = "TextBoxBorder";
            this.txtMaQuay.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaQuay.Location = new System.Drawing.Point(79, 48);
            this.txtMaQuay.Name = "txtMaQuay";
            this.txtMaQuay.PreventEnterBeep = true;
            this.txtMaQuay.Size = new System.Drawing.Size(121, 20);
            this.txtMaQuay.TabIndex = 2;
            // 
            // txtMaKho
            // 
            // 
            // 
            // 
            this.txtMaKho.Border.Class = "TextBoxBorder";
            this.txtMaKho.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaKho.Location = new System.Drawing.Point(79, 78);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.PreventEnterBeep = true;
            this.txtMaKho.Size = new System.Drawing.Size(121, 20);
            this.txtMaKho.TabIndex = 3;
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(65, 118);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtCuaHang
            // 
            // 
            // 
            // 
            this.txtCuaHang.Border.Class = "TextBoxBorder";
            this.txtCuaHang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCuaHang.Location = new System.Drawing.Point(79, 19);
            this.txtCuaHang.Name = "txtCuaHang";
            this.txtCuaHang.PreventEnterBeep = true;
            this.txtCuaHang.Size = new System.Drawing.Size(121, 20);
            this.txtCuaHang.TabIndex = 1;
            // 
            // SetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 154);
            this.Controls.Add(this.txtCuaHang);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtMaKho);
            this.Controls.Add(this.txtMaQuay);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuay;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaKho;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCuaHang;
    }
}

