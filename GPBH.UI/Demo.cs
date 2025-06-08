using GPBH.UI.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static GPBH.UI.UserControls.ucHangHoa;

namespace GPBH.UI
{
    public partial class Demo : Form
    {
        private ucHangHoa ucHangHoaPopup;

        public Demo()
        {
            InitializeComponent();

            // Đảm bảo DataGridView đã có cột "Ma_hh"
            // dataGridView1.EditingControlShowing += ... phải gán sau InitializeComponent!
            this.dataGridViewX1.EditingControlShowing += dataGridView1_EditingControlShowing;

            // Khởi tạo popup, có thể khởi tạo lần đầu luôn, hoặc mỗi lần cần mới tạo
            ucHangHoaPopup = new ucHangHoa();
            ucHangHoaPopup.Visible = false;
            this.Controls.Add(ucHangHoaPopup);
            ucHangHoaPopup.BringToFront();

            // Đăng ký sự kiện cho Form và DataGridView
            this.Click += HideUcHangHoaOnClick; 
            this.Click += HideUcHangHoaOnClick;
            this.dataGridViewX1.Scroll += HideUcHangHoaOnScrollOrResize;
            this.dataGridViewX1.Resize += HideUcHangHoaOnScrollOrResize;
            // Đăng ký lắng nghe event
            ucHangHoaPopup.HangHoaSelected += UcHangHoaPopup_HangHoaSelected;
            ucHangHoa1.HangHoaSelected += UcHangHoaPopup_HangHoaSelected; 
            dataGridViewX1.RowsRemoved += dataGridViewX1_RowsRemoved;
        }

        private void UcHangHoaPopup_HangHoaSelected(object sender, HangHoaSelectedEventArgs e)
        {
            // Tìm xem mã hàng này đã có trên lưới chưa
            bool found = false;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                // Bỏ qua dòng mới để thêm
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["Ma_hh"].Value?.ToString();
                if (cellValue == e.MaHH)
                {
                    // Nếu đã có mã, cộng số lượng lên 1
                    int currentQty = 0;
                    int.TryParse(row.Cells["Soluong"].Value?.ToString(), out currentQty);
                    row.Cells["Soluong"].Value = currentQty + 1;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                // Nếu chưa có mã này, thêm dòng mới
                int idx = dataGridViewX1.Rows.Add();
                var newRow = dataGridViewX1.Rows[idx];
                newRow.Cells["Ma_hh"].Value = e.MaHH;
                newRow.Cells["Ten_hh"].Value = e.TenHH;
               // newRow.Cells["Dvt"].Value = e.Dvt;
                newRow.Cells["Soluong"].Value = 1;
            }

            // Sau khi thêm hoặc update
            UpdateSTT();

            ucHangHoaPopup.Visible = false;
            ucHangHoaPopup.TsDropDown.Close();
        }


        private void UcHangHoaPopup2_HangHoaSelected(object sender, HangHoaSelectedEventArgs e)
        {
            // Tìm xem mã hàng này đã có trên lưới chưa
            bool found = false;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                // Bỏ qua dòng mới để thêm
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["Ma_hh"].Value?.ToString();
                if (cellValue == e.MaHH)
                {
                    // Nếu đã có mã, cộng số lượng lên 1
                    int currentQty = 0;
                    int.TryParse(row.Cells["Soluong"].Value?.ToString(), out currentQty);
                    row.Cells["Soluong"].Value = currentQty + 1;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                // Nếu chưa có mã này, thêm dòng mới
                int idx = dataGridViewX1.Rows.Add();
                var newRow = dataGridViewX1.Rows[idx];
                newRow.Cells["Ma_hh"].Value = e.MaHH;
                newRow.Cells["Ten_hh"].Value = e.TenHH;
                // newRow.Cells["Dvt"].Value = e.Dvt;
                newRow.Cells["Soluong"].Value = 1;
            }

            // Sau khi thêm hoặc update
            UpdateSTT();

            ucHangHoaPopup.Visible = false;
            ucHangHoaPopup.TsDropDown.Close();
        }


        private void UpdateSTT()
        {
            int stt = 1;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối cùng để nhập mới
                row.Cells["STT"].Value = stt++;
            }
        }
        private void dataGridViewX1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSTT();
        }

        // Sự kiện khi bắt đầu edit một cell
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Kiểm tra xem cell đang edit có phải cột Ma_hh không
            int colIndex = dataGridViewX1.CurrentCell.ColumnIndex;
            if (dataGridViewX1.Columns[colIndex].Name == "Ma_hh")
            {
                // Lấy vị trí cell trên màn hình
                Rectangle cellRect = dataGridViewX1.GetCellDisplayRectangle(colIndex, dataGridViewX1.CurrentCell.RowIndex, true);
                Point locationOnForm = dataGridViewX1.PointToScreen(cellRect.Location);
                Point locationOnParent = this.PointToClient(locationOnForm);

                // Hiển thị ucHangHoa ngay dưới cell Ma_hh
                ucHangHoaPopup.Location = new Point(locationOnParent.X, locationOnParent.Y + cellRect.Height);
                ucHangHoaPopup.Visible = true;
                ucHangHoaPopup.Tb.TabIndex = 0;
                ucHangHoaPopup.Tb.Focus();
                ucHangHoaPopup.ShowDropDown();
                ucHangHoaPopup.Tb.TabIndex = 0;
                ucHangHoaPopup.Tb.Focus();
            }
            else
            {
                // Ẩn popup nếu không phải cột Ma_hh
                ucHangHoaPopup.Visible = false;
                ucHangHoaPopup.TsDropDown.Close();
            }
        }

        // Ẩn ucHangHoa khi click ra ngoài
        private void HideUcHangHoaOnClick(object sender, EventArgs e)
        {
            if (ucHangHoaPopup.Visible)
                ucHangHoaPopup.Visible = false;
        }

        // Ẩn khi scroll hoặc resize grid (tránh bị lệch popup)
        private void HideUcHangHoaOnScrollOrResize(object sender, EventArgs e)
        {
            if (ucHangHoaPopup.Visible)
                ucHangHoaPopup.Visible = false;
        }

        // Nếu muốn ẩn khi click bất cứ đâu trên Form, ghi đè phương thức OnMouseDown:
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (ucHangHoaPopup.Visible)
                ucHangHoaPopup.Visible = false;

            base.OnMouseDown(e);
        }
    }
}