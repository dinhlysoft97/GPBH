using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.DTO;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;
using static GPBH.UI.UserControls.ucHangHoa;

namespace GPBH.UI.Forms
{
    public partial class DonHang : Office2007Form
    {
        #region Private Fields

        // Popup chọn hàng hóa
        private ucHangHoa ucHangHoaPopup;

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form Đơn Hàng, load thông tin khách hàng và khởi tạo popup hàng hóa.
        /// </summary>
        public DonHang()
        {
            InitializeComponent();
            LoadData();
            InitUcHangHoaPopup();
            RegisterEvents();
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Tải dữ liệu cần thiết cho form, ví dụ như danh sách hàng hóa, khách hàng, v.v.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadData()
        {
            LoadFormKhachHang();
            LoadInfoDonHang();
        }

        /// <summary>
        /// Tải thông tin đơn hàng
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadInfoDonHang()
        {
            lbTenDangNhap.Text = AppGlobals.CurrentUser?.TenDangNhap;
            lbQuay.Text = AppGlobals.MaQuay;
            lbCa.Text = AppGlobals.MaCa;
        }

        /// <summary>
        /// Hiển thị form chọn khách hàng, sau đó bind dữ liệu khách hàng lên form.
        /// </summary>
        private void LoadFormKhachHang()
        {
            // Sử dụng DI để tạo form khách hàng và demo
            var formKhachHang = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider);
            formKhachHang.ShowDialog();

            BindDataKhachHang(formKhachHang.DataKhachHang);
        }

        /// <summary>
        /// Bind dữ liệu khách hàng lên các control trên form.
        /// </summary>
        /// <param name="khachhang">Đối tượng khách hàng</param>
        private void BindDataKhachHang(DMKHDto khachhang)
        {
            txtCCCD.Text = khachhang?.Passport?.Trim() ?? "";
            txtDiaChi.Text = khachhang?.Dia_chi ?? "";
            txtQuocTinh.Text = khachhang?.Ten_Quoc_Gia ?? "";
            txtTenKhachHang.Text = $"{khachhang?.Ho} {khachhang?.Ten_dem} {khachhang?.Ten}".Trim();
        }

        /// <summary>
        /// Khởi tạo control popup chọn hàng hóa và thêm vào form.
        /// </summary>
        private void InitUcHangHoaPopup()
        {
            ucHangHoaPopup = new ucHangHoa();
            ucHangHoaPopup.Visible = false;
            this.Controls.Add(ucHangHoaPopup);
            ucHangHoaPopup.BringToFront();
        }

        /// <summary>
        /// Đăng ký các sự kiện cho form.
        /// </summary>
        private void RegisterEvents()
        {
            dataGridViewX1.EditingControlShowing += dataGridView1_EditingControlShowing;
            ucHangHoaPopup.HangHoaSelected += UcHangHoaPopup_HangHoaSelected;
            ucHangHoa.HangHoaSelected += UcHangHoaPopup_HangHoaSelected;
            dataGridViewX1.RowsRemoved += dataGridViewX1_RowsRemoved;
            RegisterHideUcHangHoaEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện để ẩn popup chọn hàng hóa khi click/scroll/resize ngoài vùng popup.
        /// </summary>
        private void RegisterHideUcHangHoaEvents()
        {
            this.Click += HideUcHangHoaOnClick;
            dataGridViewX1.Click += HideUcHangHoaOnClick;
            groupPanel1.Click += HideUcHangHoaOnClick;
            groupPanel2.Click += HideUcHangHoaOnClick;
            groupPanel3.Click += HideUcHangHoaOnClick;
            groupPanel4.Click += HideUcHangHoaOnClick;
            groupPanel5.Click += HideUcHangHoaOnClick;
            groupPanel6.Click += HideUcHangHoaOnClick;
            bar1.Click += HideUcHangHoaOnClick;
            dataGridViewX1.Scroll += HideUcHangHoaOnScrollOrResize;
            dataGridViewX1.Resize += HideUcHangHoaOnScrollOrResize;
        }

        /// <summary>
        /// Cập nhật lại cột số thứ tự (STT) trên lưới hàng hóa.
        /// </summary>
        private void UpdateSTT()
        {
            int stt = 1;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối cùng để nhập mới
                row.Cells["STT"].Value = stt++;
            }
        }

        /// <summary>
        /// Thêm mới hoặc tăng số lượng hàng hóa đã chọn lên lưới.
        /// </summary>
        /// <param name="e">Event args chứa thông tin hàng hóa</param>
        private void AddOrUpdateHangHoaToGrid(HangHoaSelectedEventArgs e)
        {
            bool found = false;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells["Ma_hh"].Value?.ToString();
                if (cellValue == e.MaHH)
                {
                    int currentQty = 0;
                    int.TryParse(row.Cells["So_luong"].Value?.ToString(), out currentQty);
                    row.Cells["So_luong"].Value = currentQty + 1;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                int idx = dataGridViewX1.Rows.Add();
                var newRow = dataGridViewX1.Rows[idx];
                newRow.Cells["Ma_hh"].Value = e.MaHH;
                newRow.Cells["Ten_hh"].Value = e.TenHH;
                // newRow.Cells["Dvt"].Value = e.Dvt;
                newRow.Cells["So_luong"].Value = 1;
            }
            UpdateSTT();
        }

        /// <summary>
        /// Ẩn popup chọn hàng hóa nếu đang hiển thị.
        /// </summary>
        private void HideUcHangHoaPopup()
        {
            if (ucHangHoaPopup.Visible)
            {
                ucHangHoaPopup.Visible = false;
                ucHangHoaPopup.TsDropDown.Close();
            }
            ucHangHoa.TsDropDown.Close();
        }

        /// <summary>
        /// Hiển thị popup chọn hàng hóa ngay dưới cell Ma_hh đang edit.
        /// </summary>
        /// <param name="colIndex">Chỉ số cột</param>
        /// <param name="rowIndex">Chỉ số dòng</param>
        private void ShowUcHangHoaPopupAtCell(int colIndex, int rowIndex)
        {
            // Lấy vị trí cell trên màn hình
            Rectangle cellRect = dataGridViewX1.GetCellDisplayRectangle(colIndex, rowIndex, true);
            Point locationOnForm = dataGridViewX1.PointToScreen(cellRect.Location);
            Point locationOnParent = this.PointToClient(locationOnForm);

            // Hiển thị ucHangHoa ngay dưới cell Ma_hh
            ucHangHoaPopup.Location = new Point(locationOnParent.X, locationOnParent.Y + cellRect.Height);
            ucHangHoaPopup.Visible = true;
            ucHangHoaPopup.Tb.TabIndex = 0;
            ucHangHoaPopup.Tb.Focus();
            ucHangHoaPopup.ShowDropDown();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện khi chọn hàng hóa trên popup.
        /// </summary>
        private void UcHangHoaPopup_HangHoaSelected(object sender, HangHoaSelectedEventArgs e)
        {
            AddOrUpdateHangHoaToGrid(e);
            HideUcHangHoaPopup();
        }

        /// <summary>
        /// Xử lý khi bắt đầu edit một cell trên lưới, hiển thị popup nếu là cột mã hàng hóa.
        /// </summary>
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int colIndex = dataGridViewX1.CurrentCell.ColumnIndex;
            int rowIndex = dataGridViewX1.CurrentCell.RowIndex;
            if (dataGridViewX1.Columns[colIndex].Name == "Ma_hh")
            {
                ShowUcHangHoaPopupAtCell(colIndex, rowIndex);
            }
            else
            {
                HideUcHangHoaPopup();
            }
        }

        /// <summary>
        /// Ẩn popup khi click ra ngoài.
        /// </summary>
        private void HideUcHangHoaOnClick(object sender, EventArgs e)
        {
            HideUcHangHoaPopup();
        }

        /// <summary>
        /// Ẩn popup khi scroll hoặc resize lưới hàng hóa.
        /// </summary>
        private void HideUcHangHoaOnScrollOrResize(object sender, EventArgs e)
        {
            HideUcHangHoaPopup();
        }

        /// <summary>
        /// Cập nhật lại STT khi xóa dòng trên lưới.
        /// </summary>
        private void dataGridViewX1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateSTT();
        }

        /// <summary>
        /// Ẩn popup khi click chuột bất kỳ trên form.
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            HideUcHangHoaPopup();
            base.OnMouseDown(e);
        }

        #endregion
    }
}