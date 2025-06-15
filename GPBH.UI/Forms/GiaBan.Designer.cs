namespace GPBH.UI.Forms
{
    partial class GiaBan
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
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Ma_cua_hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_ap_dung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbCuaHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_cua_hang,
            this.Ngay_ap_dung,
            this.Ma_hh,
            this.Gia_ban});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(2, 34);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewX1.Size = new System.Drawing.Size(1303, 512);
            this.dataGridViewX1.TabIndex = 18;
            // 
            // Ma_cua_hang
            // 
            this.Ma_cua_hang.DataPropertyName = "Ma_cua_hang";
            this.Ma_cua_hang.HeaderText = "Mã cửa hàng";
            this.Ma_cua_hang.Name = "Ma_cua_hang";
            this.Ma_cua_hang.ReadOnly = true;
            this.Ma_cua_hang.Width = 253;
            // 
            // Ngay_ap_dung
            // 
            this.Ngay_ap_dung.DataPropertyName = "Ngay_ap_dung";
            this.Ngay_ap_dung.HeaderText = "Ngày áp dụng";
            this.Ngay_ap_dung.Name = "Ngay_ap_dung";
            this.Ngay_ap_dung.ReadOnly = true;
            this.Ngay_ap_dung.Width = 253;
            // 
            // Ma_hh
            // 
            this.Ma_hh.DataPropertyName = "Ma_hh";
            this.Ma_hh.HeaderText = "Mã hàng hóa";
            this.Ma_hh.Name = "Ma_hh";
            this.Ma_hh.ReadOnly = true;
            this.Ma_hh.Width = 254;
            // 
            // Gia_ban
            // 
            this.Gia_ban.DataPropertyName = "Gia_ban";
            this.Gia_ban.HeaderText = "Giá bán";
            this.Gia_ban.Name = "Gia_ban";
            this.Gia_ban.Width = 253;
            // 
            // cbbCuaHang
            // 
            this.cbbCuaHang.DisplayMember = "Text";
            this.cbbCuaHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCuaHang.FormattingEnabled = true;
            this.cbbCuaHang.ItemHeight = 14;
            this.cbbCuaHang.Location = new System.Drawing.Point(68, 9);
            this.cbbCuaHang.Name = "cbbCuaHang";
            this.cbbCuaHang.Size = new System.Drawing.Size(172, 20);
            this.cbbCuaHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCuaHang.TabIndex = 20;
            this.cbbCuaHang.Click += new System.EventHandler(this.CbbCuaHang_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 15);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "Cửa hàng";
            // 
            // GiaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 583);
            this.Controls.Add(this.cbbCuaHang);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dataGridViewX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GiaBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giá bán";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_cua_hang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_ap_dung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia_ban;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCuaHang;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}