using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlDonHang : UserControl
    {
        #region Fields & Constructor

        private readonly DonHangService _donHangService;
        private readonly SysDMCuaHangService _sysDMCuaHangService;
        private SysDMCuaHang CuaHang;
        private int _lastRowIndex = -1;

        public UserControlDonHang(DonHangService donHangService, SysDMCuaHangService sysDMCuaHangService)
        {
            _donHangService = donHangService;
            _sysDMCuaHangService = sysDMCuaHangService;
            CuaHang = _sysDMCuaHangService.GetByMaCuaHang(AppGlobals.MaCH);
            InitializeComponent();
            InitializeUI();
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Khởi tạo UI, load dữ liệu và đăng ký sự kiện.
        /// </summary>
        private void InitializeUI()
        {
            SetUpUI();
            RegisterEvents();
            LoadData();
        }

        /// <summary>
        /// Đăng ký các sự kiện cho control.
        /// </summary>
        private void RegisterEvents()
        {
            dataGridViewX1.CellDoubleClick += DataGridViewX1_CellDoubleClick;
            dataGridViewX1.SelectionChanged += DataGridViewX1_SelectionChanged;
            dataGridViewX1.KeyDown += DataGridViewX1_KeyDown;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTim.Click += BtnTim_Click;
        }

        #endregion

        #region Data Loading & Binding

        /// <summary>
        /// Load toàn bộ người dùng lên lưới và apply filter.
        /// </summary>
        private void LoadData()
        {
            var donHangs = _donHangService.TiemKiem(dtTu.Value.Date, dtTu.Value.Date);
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, donHangs);
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetFormRowTheoCuaHang();
            };
        }

        /// <summary>
        /// Tìm kiếm theo từ khóa và bind lại dữ liệu.
        /// </summary>
        private void TimKiem()
        {
            var donHangs = _donHangService.TiemKiem(dtTu.Value.Date, dtTu.Value.Date);
            SetUpUI();
            dataGridViewX1.BindData(donHangs, true);
            SetFormRowTheoCuaHang();
        }

        public void SetFormRowTheoCuaHang()
        {
            dataGridViewX1.Columns["Ma_cua_hang"].Visible = false;
            dataGridViewX1.Columns["Ma_Phieu"].Visible = false;
            int index = 0;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                // bỏ dòng đầu tiền filter
                if (index == 0)
                {
                    index++;
                    continue;
                }

                var maCuaHang = row.Cells["Ma_cua_hang"].Value?.ToString();
                var cuaHang = _sysDMCuaHangService.GetByMaCuaHang(maCuaHang);

                row.SetRowFormat(new List<string> { "Tong_tien_hang_nt", "Tong_nhan", "Tra_lai_nt" }, cuaHang.Format_tien_nt);
                row.SetRowFormat(new List<string> { "Ty_gia" }, cuaHang.Format_tien);
            }
        }

        private void SetFormRowChiTietTheoCuaHang(string maCuaHang)
        {
            foreach (DataGridViewRow row in dataGridViewX2.Rows)
            {
                var cuaHang = _sysDMCuaHangService.GetByMaCuaHang(maCuaHang);

                row.SetRowFormat(new List<string> { "So_luong" }, cuaHang.Format_so_luong);
                row.SetRowFormat(new List<string> { "Gia_ban_nt" }, cuaHang.Format_gia_nt);
                row.SetRowFormat(new List<string> { "Gia_ban" }, cuaHang.Format_gia);
                row.SetRowFormat(new List<string> { "Gg_ty_le" }, cuaHang.Format_gia);
                row.SetRowFormat(new List<string> { "Gg_tien_nt" }, cuaHang.Format_tien_nt);
                row.SetRowFormat(new List<string> { "Gg_tien" }, cuaHang.Format_tien);
                row.SetRowFormat(new List<string> { "Tien_ban_nt" }, cuaHang.Format_tien_nt);
                row.SetRowFormat(new List<string> { "Tien_ban" }, cuaHang.Format_tien);
            }
        }

        #endregion

        #region UI Setup

        /// <summary>
        /// Setup hiển thị cho DataGridView: căn giữa, format, sắp xếp cột.
        /// </summary>
        private void SetUpUI()
        {
            dtTu.Value = DateTime.Now.Date;
            dtDen.Value = DateTime.Now.Date;

            // Lưới master 
            // Kiểm tra nếu không có cột nào thì không cần làm gì 
            if (dataGridViewX1.Columns.Count == 0) return;

            dataGridViewX2.Columns["Gia_ban_nt"].HeaderText = $"Giá {CuaHang.Ma_nt}";
            dataGridViewX2.Columns["Gg_tien_nt"].HeaderText = $"Tiền giảm {CuaHang.Ma_nt}";
            dataGridViewX2.Columns["Tien_ban_nt"].HeaderText = $"Thành tiền {CuaHang.Ma_nt}";

            // Canh giữa header
            dataGridViewX1.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
     

            // Sắp xếp vị trí các cột
            SetColumnDisplayIndex();

            // Căn chỉnh và format dữ liệu
            SetColumnFormatting();

            // lưới detail
            if (dataGridViewX2.Columns.Count == 0) return;

            dataGridViewX2.SetDisplayIndex("Ma_hh", 0);
            dataGridViewX2.SetDisplayIndex("Ten_hh", 1);
            dataGridViewX2.SetDisplayIndex("So_luong", 2);
            dataGridViewX2.SetDisplayIndex("Gia_ban_nt", 3);
            dataGridViewX2.SetDisplayIndex("Gia_ban", 4);
            dataGridViewX2.SetDisplayIndex("Gg_ty_le", 5);
            dataGridViewX2.SetDisplayIndex("Gg_tien_nt", 6);
            dataGridViewX2.SetDisplayIndex("Gg_tien", 7);
            dataGridViewX2.SetDisplayIndex("Tien_ban_nt", 8);
            dataGridViewX2.SetDisplayIndex("Tien_ban", 9);

            dataGridViewX2.SetCellAlignment("So_luong", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Gia_ban_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Gia_ban", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Gg_ty_le", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Gg_tien_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Gg_tien", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Tien_ban_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX2.SetCellAlignment("Tien_ban", DataGridViewContentAlignment.MiddleRight);
        }

        /// <summary>
        /// Đặt lại vị trí các cột theo yêu cầu.
        /// </summary>
        private void SetColumnDisplayIndex()
        {
            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("So_chung_tu", 1);
            dataGridViewX1.SetDisplayIndex("Ngay_chung_tu", 2);
            dataGridViewX1.SetDisplayIndex("Passport", 3);
            dataGridViewX1.SetDisplayIndex("Ten_khach", 4);
            dataGridViewX1.SetDisplayIndex("Tong_tien_hang_nt", 5);
            dataGridViewX1.SetDisplayIndex("Tong_nhan", 6);
            dataGridViewX1.SetDisplayIndex("Tra_lai_nt", 7);
            dataGridViewX1.SetDisplayIndex("Ty_gia", 8);
            dataGridViewX1.SetDisplayIndex("Ma_cua_hang", 9);
            dataGridViewX1.SetDisplayIndex("Ma_Phieu", 10);
        }

        /// <summary>
        /// Căn chỉnh và format cho các cột dữ liệu.
        /// </summary>
        private void SetColumnFormatting()
        {
            dataGridViewX1.SetCellAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.SetCellAlignment("Tong_tien_hang_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Tong_nhan", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Tra_lai_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Ty_gia", DataGridViewContentAlignment.MiddleRight);

            dataGridViewX1.SetFormat("Ngay_chung_tu", "dd/MM/yyyy");
        }


        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý phím tắt trên DataGridView.
        /// </summary>
        private void DataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                HandleXoa();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) => TimKiem();

        private void BtnTim_Click(object sender, EventArgs e) => TimKiem();

        private void BtnThem_Click(object sender, EventArgs e)
        {
            var formNew = ActivatorUtilities.CreateInstance<DonHang>(Program.ServiceProvider);
            formNew.ShowDialog();
            TimKiem(); // Sau khi thêm, load lại dữ liệu
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            var item = GetSelectedDonHang();
            if (item != null)
            {
                var data = _donHangService.GetDonHang(item.Ma_phieu);
                var formNew = ActivatorUtilities.CreateInstance<DonHang>(Program.ServiceProvider, data);
                formNew.ShowDialog();
            }
        }
        private void BtnXoa_Click(object sender, EventArgs e) => HandleXoa();

        /// <summary>
        /// Xử lý xóa người dùng.
        /// </summary>
        private void HandleXoa()
        {
            var item = GetSelectedDonHang();
            if (item == null) return;

            var maPhieu = item.Ma_phieu;
            var resultDialog = MessageBoxEx.Show($"Bạn có chắc muốn xóa đơn hàng: {item.Ma_phieu}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.Yes)
            {
                var (result, message) = _donHangService.XoaDonHang(maPhieu);
                if (result)
                {
                    MessageBoxEx.Show("Xóa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TimKiem();
                }
                else
                {
                    MessageBoxEx.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Double click vào row để sửa thông tin người dùng.
        /// </summary>
        private void DataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridViewX1.Rows[e.RowIndex].DataBoundItem as GirdDonHangDto;
                var maPhieu = row.Ma_phieu;
                if (!string.IsNullOrEmpty(maPhieu))
                {
                    var data = _donHangService.GetDonHang(maPhieu);
                    var formNew = ActivatorUtilities.CreateInstance<DonHang>(Program.ServiceProvider, data);
                    formNew.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn một dòng trong DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            var curRow = dataGridViewX1.CurrentRow;
            // Bỏ qua dòng filter (dòng đầu), và những trường hợp không hợp lệ
            if (curRow == null || curRow.IsNewRow || curRow.Index == 0)
                return;
            if (_lastRowIndex == curRow.Index)
                return; // Không chuyển row, bỏ qua

            _lastRowIndex = curRow.Index; // Cập nhật index

            var row = curRow.DataBoundItem as GirdDonHangDto;
            if (row == null) return;

            var maCH = row.Ma_cua_hang;
            if (!string.IsNullOrEmpty(maCH))
            {
                var maPhieu = row.Ma_phieu;
                dataGridViewX2.BindData(_donHangService.GetDonHangChiTiet(maPhieu));
                SetFormRowChiTietTheoCuaHang(maCH);
            }
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Lấy user đang chọn trên lưới (bỏ qua dòng filter đầu).
        /// </summary>
        /// <returns>GirdNguoiSuDungDto hoặc null</returns>
        private GirdDonHangDto GetSelectedDonHang()
        {
            if (dataGridViewX1.CurrentRow != null &&
                dataGridViewX1.CurrentRow.Index > 0 &&
                dataGridViewX1.CurrentRow.DataBoundItem is GirdDonHangDto item)
            {
                return item;
            }
            MessageBoxEx.Show("Vui lòng chọn dòng dữ liệu hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        #endregion

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SetFormRowTheoCuaHang();
            var data = new List<MyData>
            {
                new MyData { Ten = "Bút bi", SoLuong = 100, Gia = 3500, NgayTao = new DateTime(2025, 6, 1) },
                new MyData { Ten = "Sách toán", SoLuong = 50, Gia = 22000, NgayTao = new DateTime(2025, 6, 2) },
                new MyData { Ten = "Vở kẻ ngang", SoLuong = 200, Gia = 8000, NgayTao = new DateTime(2025, 6, 3) },
                new MyData { Ten = "Thước kẻ", SoLuong = 75, Gia = 6000, NgayTao = new DateTime(2025, 6, 4) }
            };
            var fields = new[]
            {
                new { Property = "Ten", Header = "Tên", Width = 20d, Format = "" },
                new { Property = "SoLuong", Header = "Số lượng", Width = 12d, Format = "#,##0" },
                new { Property = "Gia", Header = "Giá", Width = 15d, Format = "#,##0.00" },
                new { Property = "NgayTao", Header = "Ngày tạo", Width = 18d, Format = "dd/MM/yyyy" }
            };

            ExportHelper.ExportToExcel(data, fields);
        }

        public class MyData
        {
            public string Ten { get; set; }
            public int SoLuong { get; set; }
            public decimal Gia { get; set; }
            public DateTime NgayTao { get; set; }
        }
    }
}
