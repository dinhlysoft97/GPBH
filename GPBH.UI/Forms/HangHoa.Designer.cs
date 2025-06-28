namespace GPBH.UI.Forms
{
    partial class HangHoa
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(2, 12);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewX1.Size = new System.Drawing.Size(1139, 534);
            this.dataGridViewX1.TabIndex = 18;
            // 
            // Ma_hh
            // 
            this.Ma_hh.DataPropertyName = "Ma_hh";
            this.Ma_hh.HeaderText = "Mã hàng";
            this.Ma_hh.Name = "Ma_hh";
            this.Ma_hh.ReadOnly = true;
            // 
            // Ten_hh
            // 
            this.Ten_hh.DataPropertyName = "Ten_hh";
            this.Ten_hh.HeaderText = "Tên hàng";
            this.Ten_hh.Name = "Ten_hh";
            this.Ten_hh.ReadOnly = true;
            // 
            // Dvt
            // 
            this.Dvt.DataPropertyName = "Dvt";
            this.Dvt.HeaderText = "Đơn vị tính";
            this.Dvt.Name = "Dvt";
            this.Dvt.ReadOnly = true;
            // 
            // Ma_nhom_hh
            // 
            this.Ma_nhom_hh.DataPropertyName = "Ma_nhom_hh";
            this.Ma_nhom_hh.HeaderText = "Nhóm hàng";
            this.Ma_nhom_hh.Name = "Ma_nhom_hh";
            this.Ma_nhom_hh.ReadOnly = true;
            // 
            // Thuong_hieu
            // 
            this.Thuong_hieu.DataPropertyName = "Thuong_hieu";
            this.Thuong_hieu.HeaderText = "Thương hiệu";
            this.Thuong_hieu.Name = "Thuong_hieu";
            this.Thuong_hieu.ReadOnly = true;
            // 
            // Ma_nsx
            // 
            this.Ma_nsx.DataPropertyName = "Ma_nsx";
            this.Ma_nsx.HeaderText = "Mã nhà sản xuất";
            this.Ma_nsx.Name = "Ma_nsx";
            this.Ma_nsx.ReadOnly = true;
            // 
            // Ten_nsx
            // 
            this.Ten_nsx.DataPropertyName = "Ten_nsx";
            this.Ten_nsx.HeaderText = "Tên nhà sản xuất";
            this.Ten_nsx.Name = "Ten_nsx";
            this.Ten_nsx.ReadOnly = true;
            // 
            // Nuoc_sx
            // 
            this.Nuoc_sx.DataPropertyName = "Nuoc_sx";
            this.Nuoc_sx.HeaderText = "Nước sản xuất";
            this.Nuoc_sx.Name = "Nuoc_sx";
            this.Nuoc_sx.ReadOnly = true;
            // 
            // Chieu_dai
            // 
            this.Chieu_dai.DataPropertyName = "Chieu_dai";
            this.Chieu_dai.HeaderText = "Chiều dài";
            this.Chieu_dai.Name = "Chieu_dai";
            this.Chieu_dai.ReadOnly = true;
            // 
            // Trong_luong
            // 
            this.Trong_luong.DataPropertyName = "Trong_luong";
            this.Trong_luong.HeaderText = "Trọng lượng";
            this.Trong_luong.Name = "Trong_luong";
            this.Trong_luong.ReadOnly = true;
            // 
            // Chieu_cao
            // 
            this.Chieu_cao.DataPropertyName = "Chieu_cao";
            this.Chieu_cao.HeaderText = "Chiều cao";
            this.Chieu_cao.Name = "Chieu_cao";
            this.Chieu_cao.ReadOnly = true;
            // 
            // HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 583);
            this.Controls.Add(this.dataGridViewX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hàng hóa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


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