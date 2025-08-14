namespace GPBH.UI.UserControls
{
    partial class UserControlHangHoa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnXuatExcel = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Ma_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_nhom_hh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thuong_hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_nsx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_nsx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nuoc_sx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chieu_dai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trong_luong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chieu_cao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnXuatExcel);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1309, 41);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 20;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXuatExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXuatExcel.Location = new System.Drawing.Point(12, 9);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXuatExcel.TabIndex = 1;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_hh,
            this.Ten_hh,
            this.Dvt,
            this.Ma_nhom_hh,
            this.Thuong_hieu,
            this.Ma_nsx,
            this.Ten_nsx,
            this.Nuoc_sx,
            this.Chieu_dai,
            this.Trong_luong,
            this.Chieu_cao});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(1309, 739);
            this.dataGridViewX1.TabIndex = 2;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            // 
            // Ma_hh
            // 
            this.Ma_hh.DataPropertyName = "Ma_hh";
            this.Ma_hh.HeaderText = "Mã hàng";
            this.Ma_hh.Name = "Ma_hh";
            this.Ma_hh.ReadOnly = true;
            this.Ma_hh.Width = 74;
            // 
            // Ten_hh
            // 
            this.Ten_hh.DataPropertyName = "Ten_hh";
            this.Ten_hh.HeaderText = "Tên hàng";
            this.Ten_hh.Name = "Ten_hh";
            this.Ten_hh.ReadOnly = true;
            this.Ten_hh.Width = 78;
            // 
            // Dvt
            // 
            this.Dvt.DataPropertyName = "Dvt";
            this.Dvt.HeaderText = "Đơn vị tính";
            this.Dvt.Name = "Dvt";
            this.Dvt.ReadOnly = true;
            this.Dvt.Width = 85;
            // 
            // Ma_nhom_hh
            // 
            this.Ma_nhom_hh.DataPropertyName = "Ma_nhom_hh";
            this.Ma_nhom_hh.HeaderText = "Nhóm hàng";
            this.Ma_nhom_hh.Name = "Ma_nhom_hh";
            this.Ma_nhom_hh.ReadOnly = true;
            this.Ma_nhom_hh.Width = 87;
            // 
            // Thuong_hieu
            // 
            this.Thuong_hieu.DataPropertyName = "Thuong_hieu";
            this.Thuong_hieu.HeaderText = "Thương hiệu";
            this.Thuong_hieu.Name = "Thuong_hieu";
            this.Thuong_hieu.ReadOnly = true;
            this.Thuong_hieu.Width = 92;
            // 
            // Ma_nsx
            // 
            this.Ma_nsx.DataPropertyName = "Ma_nsx";
            this.Ma_nsx.HeaderText = "Mã nhà sản xuất";
            this.Ma_nsx.Name = "Ma_nsx";
            this.Ma_nsx.ReadOnly = true;
            this.Ma_nsx.Width = 111;
            // 
            // Ten_nsx
            // 
            this.Ten_nsx.DataPropertyName = "Ten_nsx";
            this.Ten_nsx.HeaderText = "Tên nhà sản xuất";
            this.Ten_nsx.Name = "Ten_nsx";
            this.Ten_nsx.ReadOnly = true;
            this.Ten_nsx.Width = 115;
            // 
            // Nuoc_sx
            // 
            this.Nuoc_sx.DataPropertyName = "Nuoc_sx";
            this.Nuoc_sx.HeaderText = "Nước sản xuất";
            this.Nuoc_sx.Name = "Nuoc_sx";
            this.Nuoc_sx.ReadOnly = true;
            this.Nuoc_sx.Width = 101;
            // 
            // Chieu_dai
            // 
            this.Chieu_dai.DataPropertyName = "Chieu_dai";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Chieu_dai.DefaultCellStyle = dataGridViewCellStyle2;
            this.Chieu_dai.HeaderText = "Chiều dài";
            this.Chieu_dai.Name = "Chieu_dai";
            this.Chieu_dai.ReadOnly = true;
            this.Chieu_dai.Width = 76;
            // 
            // Trong_luong
            // 
            this.Trong_luong.DataPropertyName = "Trong_luong";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Trong_luong.DefaultCellStyle = dataGridViewCellStyle3;
            this.Trong_luong.HeaderText = "Trọng lượng";
            this.Trong_luong.Name = "Trong_luong";
            this.Trong_luong.ReadOnly = true;
            this.Trong_luong.Width = 89;
            // 
            // Chieu_cao
            // 
            this.Chieu_cao.DataPropertyName = "Chieu_cao";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Chieu_cao.DefaultCellStyle = dataGridViewCellStyle4;
            this.Chieu_cao.HeaderText = "Chiều cao";
            this.Chieu_cao.Name = "Chieu_cao";
            this.Chieu_cao.ReadOnly = true;
            this.Chieu_cao.Width = 80;
            // 
            // UserControlHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.Name = "UserControlHangHoa";
            this.Size = new System.Drawing.Size(1309, 780);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnXuatExcel;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dvt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_nhom_hh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thuong_hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_nsx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_nsx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nuoc_sx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chieu_dai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trong_luong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chieu_cao;
    }
}
