using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GPBH.UI.UserControls.DonHang
{
    public partial class UserControlThemDonHang : UserControl
    {
        public UserControlThemDonHang()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Vẽ lại title ở góc trái (tự đo chiều cao, vẽ text tại vị trí mong muốn)
            using (var brush = new SolidBrush(this.ForeColor))
            {
                var font = this.Font;
                var text = this.Text;
                e.Graphics.DrawString(text, font, brush, new PointF(10, 3)); // 10 là lề trái, 3 là lề trên
            }
        }

        private void UserControlThemDonHang_SizeChanged(object sender, EventArgs e)
        {
            ResizeAllControls(this);
        }

        /// <summary>
        /// Đệ quy cập nhật chiều rộng cho tất cả control con trong container
        /// </summary>
        private void ResizeAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // Nếu control là FlowLayoutPanel hoặc Panel, tiếp tục đệ quy các control con
                if (ctrl is FlowLayoutPanel || ctrl is Panel || ctrl is GroupBox || ctrl is DevComponents.DotNetBar.TabControl || ctrl is TableLayoutPanel || ctrl is GroupPanel || ctrl is Bar)
                {
                    // Cập nhật chiều rộng cho control con
                    ctrl.Width = parent.ClientSize.Width - ctrl.Margin.Left - ctrl.Margin.Right;
                    // Đệ quy cho các control con cấp dưới
                    ResizeAllControls(ctrl);
                }
                else
                {
                    // Nếu muốn các control con khác cũng giãn theo, bỏ comment dòng này:
                    // ctrl.Width = parent.ClientSize.Width - ctrl.Margin.Left - ctrl.Margin.Right;
                }
            }
        }
    }
}
