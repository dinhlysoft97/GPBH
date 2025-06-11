namespace GPBH.UI.Forms
{
    partial class PhanQuyen
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
            this.btnDong = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xem = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Them = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Sua = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Xoa = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.In = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Excel = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stt,
            this.MenuId,
            this.MenuName,
            this.Xem,
            this.Them,
            this.Sua,
            this.Xoa,
            this.In,
            this.Excel});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 13);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(1068, 300);
            this.dataGridViewX1.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDong.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDong.Location = new System.Drawing.Point(93, 319);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(3, 319);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            // 
            // Stt
            // 
            this.Stt.DataPropertyName = "Stt";
            this.Stt.HeaderText = "Stt";
            this.Stt.Name = "Stt";
            this.Stt.ReadOnly = true;
            // 
            // MenuId
            // 
            this.MenuId.DataPropertyName = "MenuId";
            this.MenuId.HeaderText = "MenuId";
            this.MenuId.Name = "MenuId";
            this.MenuId.ReadOnly = true;
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "Tên menu";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            // 
            // Xem
            // 
            this.Xem.Checked = true;
            this.Xem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Xem.CheckValue = null;
            this.Xem.DataPropertyName = "Xem";
            this.Xem.HeaderText = "Xem";
            this.Xem.Name = "Xem";
            this.Xem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Xem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Them
            // 
            this.Them.Checked = true;
            this.Them.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Them.CheckValue = null;
            this.Them.DataPropertyName = "Them";
            this.Them.HeaderText = "Them";
            this.Them.Name = "Them";
            // 
            // Sua
            // 
            this.Sua.Checked = true;
            this.Sua.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Sua.CheckValue = null;
            this.Sua.DataPropertyName = "Sua";
            this.Sua.HeaderText = "Sửa";
            this.Sua.Name = "Sua";
            // 
            // Xoa
            // 
            this.Xoa.Checked = true;
            this.Xoa.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Xoa.CheckValue = null;
            this.Xoa.DataPropertyName = "Xoa";
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.Name = "Xoa";
            // 
            // In
            // 
            this.In.Checked = true;
            this.In.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.In.CheckValue = null;
            this.In.DataPropertyName = "In";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            // 
            // Excel
            // 
            this.Excel.Checked = true;
            this.Excel.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Excel.CheckValue = null;
            this.Excel.DataPropertyName = "Excel";
            this.Excel.HeaderText = "Excel";
            this.Excel.Name = "Excel";
            // 
            // PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 342);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân quyền";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX btnDong;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Xem;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Them;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Sua;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Xoa;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn In;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Excel;
    }
}