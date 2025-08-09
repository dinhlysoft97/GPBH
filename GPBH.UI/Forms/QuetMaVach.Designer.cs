namespace GPBH.UI.Forms
{
    partial class QuetMaVach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuetMaVach));
            this.txtMaVach = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSL = new DevComponents.Editors.DoubleInput();
            this.lbThongBao = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaVach
            // 
            // 
            // 
            // 
            this.txtMaVach.Border.Class = "TextBoxBorder";
            this.txtMaVach.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaVach.Location = new System.Drawing.Point(52, 23);
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.PreventEnterBeep = true;
            this.txtMaVach.Size = new System.Drawing.Size(100, 20);
            this.txtMaVach.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(2, 26);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 15);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Mã vạch";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(172, 26);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Số lượng";
            // 
            // txtSL
            // 
            // 
            // 
            // 
            this.txtSL.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSL.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSL.Increment = 1D;
            this.txtSL.Location = new System.Drawing.Point(233, 23);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(99, 20);
            this.txtSL.TabIndex = 3;
            // 
            // lbThongBao
            // 
            this.lbThongBao.BackColor = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.lbThongBao.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbThongBao.Location = new System.Drawing.Point(52, 50);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(280, 23);
            this.lbThongBao.TabIndex = 4;
            this.lbThongBao.Text = "Không tìm thấy mã vạch";
            // 
            // QuetMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 76);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtMaVach);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 115);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(364, 115);
            this.Name = "QuetMaVach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quét mã vạch";
            ((System.ComponentModel.ISupportInitialize)(this.txtSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtMaVach;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DoubleInput txtSL;
        private DevComponents.DotNetBar.LabelX lbThongBao;
    }
}