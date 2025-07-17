namespace GPBH.UI.UserControls
{
    partial class UserControlKetQuaLoc
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnIn = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_chung_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_chung_tu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_khach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong_tien_hang_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tong_nhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tra_lai_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ty_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_cua_hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_phieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bar1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(1339, 775);
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BackColor = System.Drawing.Color.White;
            this.bar1.Controls.Add(this.btnIn);
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Margin = new System.Windows.Forms.Padding(2);
            this.bar1.MinimumSize = new System.Drawing.Size(0, 40);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1339, 40);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnIn
            // 
            this.btnIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnIn.Location = new System.Drawing.Point(11, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIn.Size = new System.Drawing.Size(84, 23);
            this.btnIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stt,
            this.So_chung_tu,
            this.Ngay_chung_tu,
            this.Passport,
            this.Ten_khach,
            this.Tong_tien_hang_nt,
            this.Tong_nhan,
            this.Tra_lai_nt,
            this.Ty_gia,
            this.Ma_cua_hang,
            this.Ma_phieu});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 39);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersWidth = 51;
            this.dataGridViewX1.RowTemplate.Height = 24;
            this.dataGridViewX1.Size = new System.Drawing.Size(1339, 736);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            // 
            // Stt
            // 
            this.Stt.DataPropertyName = "Stt";
            this.Stt.HeaderText = "Stt";
            this.Stt.Name = "Stt";
            this.Stt.ReadOnly = true;
            // 
            // So_chung_tu
            // 
            this.So_chung_tu.DataPropertyName = "So_don_hang";
            this.So_chung_tu.HeaderText = "Số đơn hàng";
            this.So_chung_tu.MinimumWidth = 6;
            this.So_chung_tu.Name = "So_chung_tu";
            // 
            // Ngay_chung_tu
            // 
            this.Ngay_chung_tu.DataPropertyName = "Ngay_ban";
            this.Ngay_chung_tu.HeaderText = "Ngày";
            this.Ngay_chung_tu.MinimumWidth = 6;
            this.Ngay_chung_tu.Name = "Ngay_chung_tu";
            // 
            // Passport
            // 
            this.Passport.DataPropertyName = "Passport";
            this.Passport.HeaderText = "Mã khách hàng";
            this.Passport.Name = "Passport";
            // 
            // Ten_khach
            // 
            this.Ten_khach.DataPropertyName = "Ten_khachhang";
            this.Ten_khach.HeaderText = "Tên khách hàng";
            this.Ten_khach.Name = "Ten_khach";
            // 
            // Tong_tien_hang_nt
            // 
            this.Tong_tien_hang_nt.DataPropertyName = "Tong_tien_hang_nt";
            this.Tong_tien_hang_nt.HeaderText = "Tổng tiền hàng";
            this.Tong_tien_hang_nt.Name = "Tong_tien_hang_nt";
            // 
            // Tong_nhan
            // 
            this.Tong_nhan.DataPropertyName = "Tong_nhan";
            this.Tong_nhan.HeaderText = "Khách trả";
            this.Tong_nhan.Name = "Tong_nhan";
            // 
            // Tra_lai_nt
            // 
            this.Tra_lai_nt.DataPropertyName = "Tra_lai_nt";
            this.Tra_lai_nt.HeaderText = "Trả lại";
            this.Tra_lai_nt.Name = "Tra_lai_nt";
            // 
            // Ty_gia
            // 
            this.Ty_gia.DataPropertyName = "Ty_gia";
            this.Ty_gia.HeaderText = "Tủy giá";
            this.Ty_gia.Name = "Ty_gia";
            // 
            // Ma_cua_hang
            // 
            this.Ma_cua_hang.DataPropertyName = "Thanh_tien";
            this.Ma_cua_hang.HeaderText = "Thanh tiền";
            this.Ma_cua_hang.Name = "Ma_cua_hang";
            this.Ma_cua_hang.ReadOnly = true;
            // 
            // Ma_phieu
            // 
            this.Ma_phieu.DataPropertyName = "Thanh_tien_vn";
            this.Ma_phieu.HeaderText = "Thành tiền VND";
            this.Ma_phieu.Name = "Ma_phieu";
            this.Ma_phieu.ReadOnly = true;
            // 
            // UserControlKetQuaLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserControlKetQuaLoc";
            this.Size = new System.Drawing.Size(1339, 775);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonX btnIn;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_chung_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_chung_tu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_khach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tong_tien_hang_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tong_nhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tra_lai_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ty_gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_cua_hang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_phieu;
    }
}
