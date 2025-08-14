namespace GPBH.UI.Forms
{
    partial class HuongDanSuDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuongDanSuDung));
            this.pdfGuide = new PdfiumViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfGuide
            // 
            this.pdfGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfGuide.Location = new System.Drawing.Point(0, 0);
            this.pdfGuide.Name = "pdfGuide";
            this.pdfGuide.Size = new System.Drawing.Size(912, 660);
            this.pdfGuide.TabIndex = 0;
            // 
            // HuongDanSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 660);
            this.Controls.Add(this.pdfGuide);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HuongDanSuDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hướng dẫn nhập liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private PdfiumViewer.PdfViewer pdfGuide;
    }
}