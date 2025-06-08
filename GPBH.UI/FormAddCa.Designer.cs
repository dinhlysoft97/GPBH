using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    partial class FormAddCa
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
            this.txtMaCa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.txtGioBD = new System.Windows.Forms.TextBox();
            this.txtGioKT = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(118, 54);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.Size = new System.Drawing.Size(100, 20);
            this.txtMaCa.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã ca *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên ca *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giờ bắt đầu *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giờ kết thúc *";
            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(118, 88);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(100, 20);
            this.txtTenCa.TabIndex = 5;
            // 
            // txtGioBD
            // 
            this.txtGioBD.Location = new System.Drawing.Point(118, 132);
            this.txtGioBD.Name = "txtGioBD";
            this.txtGioBD.Size = new System.Drawing.Size(100, 20);
            this.txtGioBD.TabIndex = 6;
            // 
            // txtGioKT
            // 
            this.txtGioKT.Location = new System.Drawing.Point(118, 164);
            this.txtGioKT.Name = "txtGioKT";
            this.txtGioKT.Size = new System.Drawing.Size(100, 20);
            this.txtGioKT.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAddCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtGioKT);
            this.Controls.Add(this.txtGioBD);
            this.Controls.Add(this.txtTenCa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaCa);
            this.Name = "FormAddCa";
            this.Text = "Thông tin Ca";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        #endregion

        private System.Windows.Forms.TextBox txtMaCa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.TextBox txtGioBD;
        private System.Windows.Forms.TextBox txtGioKT;
        private System.Windows.Forms.Button button1;
    }
}