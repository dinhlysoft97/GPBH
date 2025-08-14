namespace GPBH.UI.UserControls
{
    partial class UserControlDinhDangForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new DevComponents.DotNetBar.ButtonX();
            this.cbbCode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbbCuaHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbWarning = new DevComponents.DotNetBar.LabelX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field_order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Field_hide = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Field_width = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Field_format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default_sort = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.Ten_ban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXuatExcel);
            this.panel2.Controls.Add(this.cbbCode);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.cbbCuaHang);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1685, 37);
            this.panel2.TabIndex = 8;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXuatExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXuatExcel.Location = new System.Drawing.Point(605, 6);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // cbbCode
            // 
            this.cbbCode.DisplayMember = "Text";
            this.cbbCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCode.FormattingEnabled = true;
            this.cbbCode.ItemHeight = 14;
            this.cbbCode.Location = new System.Drawing.Point(376, 8);
            this.cbbCode.Name = "cbbCode";
            this.cbbCode.Size = new System.Drawing.Size(221, 20);
            this.cbbCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCode.TabIndex = 2;
            this.cbbCode.SelectedIndexChanged += new System.EventHandler(this.CbbCode_SelectedIndexChanged);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(295, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 15);
            this.labelX2.TabIndex = 27;
            this.labelX2.Text = "Loại định dạng";
            // 
            // cbbCuaHang
            // 
            this.cbbCuaHang.DisplayMember = "Text";
            this.cbbCuaHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCuaHang.FormattingEnabled = true;
            this.cbbCuaHang.ItemHeight = 14;
            this.cbbCuaHang.Location = new System.Drawing.Point(68, 8);
            this.cbbCuaHang.Name = "cbbCuaHang";
            this.cbbCuaHang.Size = new System.Drawing.Size(221, 20);
            this.cbbCuaHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCuaHang.TabIndex = 1;
            this.cbbCuaHang.SelectedIndexChanged += new System.EventHandler(this.CbbCuaHang_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(7, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 15);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "Cửa hàng";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbWarning);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 811);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1685, 41);
            this.panel1.TabIndex = 9;
            // 
            // lbWarning
            // 
            this.lbWarning.AutoSize = true;
            this.lbWarning.BackColor = System.Drawing.Color.Gold;
            // 
            // 
            // 
            this.lbWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbWarning.Location = new System.Drawing.Point(84, 12);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(313, 15);
            this.lbWarning.TabIndex = 25;
            this.lbWarning.Text = " Đây là data mẫu setup, vui lòng bấm cập nhật để lưu lại dữ liệu!";
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(3, 8);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Cập nhật";
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stt,
            this.Code_name,
            this.MenuId,
            this.MenuName,
            this.Field_name,
            this.Field_type,
            this.Field_title,
            this.Field_order,
            this.Field_hide,
            this.Field_width,
            this.Field_format,
            this.Default_sort,
            this.Ten_ban});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 37);
            this.dataGridViewX1.Name = "dataGridViewX1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.Size = new System.Drawing.Size(1685, 774);
            this.dataGridViewX1.TabIndex = 4;
            // 
            // Stt
            // 
            this.Stt.DataPropertyName = "Stt";
            this.Stt.HeaderText = "Stt";
            this.Stt.Name = "Stt";
            this.Stt.ReadOnly = true;
            this.Stt.Width = 45;
            // 
            // Code_name
            // 
            this.Code_name.DataPropertyName = "Code_name";
            this.Code_name.HeaderText = "Mã chức năng";
            this.Code_name.Name = "Code_name";
            this.Code_name.Width = 93;
            // 
            // MenuId
            // 
            this.MenuId.DataPropertyName = "MenuId";
            this.MenuId.HeaderText = "MenuId";
            this.MenuId.Name = "MenuId";
            this.MenuId.Width = 68;
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "Tên menu";
            this.MenuName.Name = "MenuName";
            this.MenuName.Width = 74;
            // 
            // Field_name
            // 
            this.Field_name.DataPropertyName = "Field_name";
            this.Field_name.HeaderText = "Tên trường";
            this.Field_name.Name = "Field_name";
            this.Field_name.Width = 78;
            // 
            // Field_type
            // 
            this.Field_type.DataPropertyName = "Field_type";
            this.Field_type.HeaderText = "Kiểu dữ liệu hiển thị";
            this.Field_type.Name = "Field_type";
            this.Field_type.Width = 150;
            // 
            // Field_title
            // 
            this.Field_title.DataPropertyName = "Field_title";
            this.Field_title.HeaderText = "Tiêu đề trường";
            this.Field_title.Name = "Field_title";
            this.Field_title.Width = 120;
            // 
            // Field_order
            // 
            this.Field_order.DataPropertyName = "Field_order";
            this.Field_order.HeaderText = "Thứ tự sắp xếp";
            this.Field_order.Name = "Field_order";
            this.Field_order.Width = 79;
            // 
            // Field_hide
            // 
            this.Field_hide.Checked = true;
            this.Field_hide.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Field_hide.CheckValue = null;
            this.Field_hide.DataPropertyName = "Field_hide";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Field_hide.DefaultCellStyle = dataGridViewCellStyle2;
            this.Field_hide.HeaderText = "Không hiển thị";
            this.Field_hide.Name = "Field_hide";
            this.Field_hide.Width = 63;
            // 
            // Field_width
            // 
            // 
            // 
            // 
            this.Field_width.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Field_width.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Field_width.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Field_width.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Field_width.DataPropertyName = "Field_width";
            this.Field_width.HeaderText = "Độ rộng cột";
            this.Field_width.Increment = 1D;
            this.Field_width.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Field_width.Name = "Field_width";
            this.Field_width.Width = 81;
            // 
            // Field_format
            // 
            this.Field_format.DataPropertyName = "Field_format";
            this.Field_format.HeaderText = "Định dạng hiển thị";
            this.Field_format.Name = "Field_format";
            this.Field_format.Width = 98;
            // 
            // Default_sort
            // 
            this.Default_sort.DataPropertyName = "Default_sort";
            this.Default_sort.DisplayMember = "Text";
            this.Default_sort.DropDownHeight = 106;
            this.Default_sort.DropDownWidth = 121;
            this.Default_sort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Default_sort.HeaderText = "Sắp xếp";
            this.Default_sort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Default_sort.IntegralHeight = false;
            this.Default_sort.ItemHeight = 15;
            this.Default_sort.Name = "Default_sort";
            this.Default_sort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Default_sort.Width = 51;
            // 
            // Ten_ban
            // 
            this.Ten_ban.DataPropertyName = "Ten_ban";
            this.Ten_ban.HeaderText = "Tên bảng";
            this.Ten_ban.Name = "Ten_ban";
            this.Ten_ban.Width = 120;
            // 
            // UserControlDinhDangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UserControlDinhDangForm";
            this.Size = new System.Drawing.Size(1685, 852);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btnXuatExcel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCode;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCuaHang;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX lbWarning;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field_order;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Field_hide;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Field_width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field_format;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Default_sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_ban;
    }
}
