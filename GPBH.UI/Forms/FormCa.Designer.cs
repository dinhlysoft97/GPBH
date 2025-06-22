namespace GPBH.UI.Forms
{
    partial class FormCa
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
            this.Ma_ca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_ca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gio_bd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gio_kt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_ca,
            this.Ten_ca,
            this.Gio_bd,
            this.Gio_kt});
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
            this.dataGridViewX1.Size = new System.Drawing.Size(1053, 534);
            this.dataGridViewX1.TabIndex = 18;
            // 
            // Ma_ca
            // 
            this.Ma_ca.DataPropertyName = "Ma_ca";
            this.Ma_ca.HeaderText = "Mã ca";
            this.Ma_ca.Name = "Ma_ca";
            this.Ma_ca.ReadOnly = true;
            this.Ma_ca.Width = 253;
            // 
            // Ten_ca
            // 
            this.Ten_ca.DataPropertyName = "Ten_ca";
            this.Ten_ca.HeaderText = "Tên ca";
            this.Ten_ca.Name = "Ten_ca";
            this.Ten_ca.ReadOnly = true;
            this.Ten_ca.Width = 253;
            // 
            // Gio_bd
            // 
            this.Gio_bd.DataPropertyName = "Gio_bd";
            this.Gio_bd.HeaderText = "Giờ bắt đầu";
            this.Gio_bd.Name = "Gio_bd";
            this.Gio_bd.ReadOnly = true;
            this.Gio_bd.Width = 253;
            // 
            // Gio_kt
            // 
            this.Gio_kt.DataPropertyName = "Gio_kt";
            this.Gio_kt.HeaderText = "Giờ kết thúc";
            this.Gio_kt.Name = "Gio_kt";
            this.Gio_kt.ReadOnly = true;
            this.Gio_kt.Width = 253;
            // 
            // FormCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 583);
            this.Controls.Add(this.dataGridViewX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ca";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_ca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_ca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gio_bd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gio_kt;
    }
}