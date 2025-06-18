namespace GPBH.UI.Forms
{
    partial class TyGia
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
            this.Ma_nt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_ap_dung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ty_gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_nt,
            this.Ngay_ap_dung,
            this.Ty_gia});
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
            this.dataGridViewX1.Size = new System.Drawing.Size(799, 534);
            this.dataGridViewX1.TabIndex = 18;
            // 
            // Ma_nt
            // 
            this.Ma_nt.DataPropertyName = "Ma_nt";
            this.Ma_nt.HeaderText = "Mã ngoại tệ";
            this.Ma_nt.Name = "Ma_nt";
            this.Ma_nt.ReadOnly = true;
            this.Ma_nt.Width = 253;
            // 
            // Ngay_ap_dung
            // 
            this.Ngay_ap_dung.DataPropertyName = "Ngay_ap_dung";
            this.Ngay_ap_dung.HeaderText = "Ngày áp dụng";
            this.Ngay_ap_dung.Name = "Ngay_ap_dung";
            this.Ngay_ap_dung.ReadOnly = true;
            this.Ngay_ap_dung.Width = 253;
            // 
            // Ty_gia
            // 
            this.Ty_gia.DataPropertyName = "Ty_gia";
            this.Ty_gia.HeaderText = "Tỷ giá";
            this.Ty_gia.Name = "Ty_gia";
            this.Ty_gia.ReadOnly = true;
            this.Ty_gia.Width = 253;
            // 
            // TyGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 583);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TyGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tỷ giá";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_nt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_ap_dung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ty_gia;
    }
}