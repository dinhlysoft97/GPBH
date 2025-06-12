namespace GPBH.UI.Forms
{
    partial class DinhDangForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbbCuaHang = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(5, 30);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(1516, 749);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 15);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Cửa hàng";
            // 
            // cbbCuaHang
            // 
            this.cbbCuaHang.DisplayMember = "Text";
            this.cbbCuaHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCuaHang.FormattingEnabled = true;
            this.cbbCuaHang.ItemHeight = 14;
            this.cbbCuaHang.Location = new System.Drawing.Point(69, 6);
            this.cbbCuaHang.Name = "cbbCuaHang";
            this.cbbCuaHang.Size = new System.Drawing.Size(172, 20);
            this.cbbCuaHang.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCuaHang.TabIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(5, 790);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Cập nhật";
            // 
            // Stt
            // 
            this.Stt.DataPropertyName = "Stt";
            this.Stt.HeaderText = "Stt";
            this.Stt.Name = "Stt";
            this.Stt.ReadOnly = true;
            // 
            // Code_name
            // 
            this.Code_name.DataPropertyName = "Code_name";
            this.Code_name.HeaderText = "Mã chức năng";
            this.Code_name.Name = "Code_name";
            this.Code_name.ReadOnly = true;
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
            // Field_name
            // 
            this.Field_name.DataPropertyName = "Field_name";
            this.Field_name.HeaderText = "Tên trường";
            this.Field_name.Name = "Field_name";
            this.Field_name.ReadOnly = true;
            // 
            // Field_type
            // 
            this.Field_type.DataPropertyName = "Field_type";
            this.Field_type.HeaderText = "Kiểu dữ liệu hiển thị";
            this.Field_type.Name = "Field_type";
            this.Field_type.ReadOnly = true;
            // 
            // Field_title
            // 
            this.Field_title.DataPropertyName = "Field_title";
            this.Field_title.HeaderText = "Tiêu đề trường";
            this.Field_title.Name = "Field_title";
            // 
            // Field_order
            // 
            this.Field_order.DataPropertyName = "Field_order";
            this.Field_order.HeaderText = "Thứ tự sắp xếp";
            this.Field_order.Name = "Field_order";
            // 
            // Field_hide
            // 
            this.Field_hide.Checked = true;
            this.Field_hide.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Field_hide.CheckValue = null;
            this.Field_hide.DataPropertyName = "Field_hide";
            this.Field_hide.HeaderText = "Không hiển thị";
            this.Field_hide.Name = "Field_hide";
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
            // 
            // Field_format
            // 
            this.Field_format.DataPropertyName = "Field_format";
            this.Field_format.HeaderText = "Định dạng hiển thị";
            this.Field_format.Name = "Field_format";
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
            // 
            // Ten_ban
            // 
            this.Ten_ban.DataPropertyName = "Ten_ban";
            this.Ten_ban.HeaderText = "Tên bảng";
            this.Ten_ban.Name = "Ten_ban";
            // 
            // DinhDangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 821);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cbbCuaHang);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dataGridViewX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DinhDangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Định dạng form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCuaHang;
        private DevComponents.DotNetBar.ButtonX btnLuu;
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