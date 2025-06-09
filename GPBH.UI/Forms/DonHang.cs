using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
        private DMQGService _dMQGService;
        private DMNTService _dMMTService;
        private DMHHService _dMHHService;
        private SysDMCuaHangService _sysDMCuaHangService;
        private DMTGService _dMTGService;

        sealed class ThanhToan
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        private readonly List<ThanhToan> _thanhToans = new List<ThanhToan>
        {
            new ThanhToan() { Key = "TM", Value = "Tiền mặt" },
            new ThanhToan() { Key = "CK", Value = "Chuyển khoản" },
            new ThanhToan() { Key = "CT", Value = "Công ty" },
            new ThanhToan() { Key = "NT", Value = "Ngoại tệ" }
        };

        private List<DMNT> _dMNTs = new List<DMNT>();
        private TyGiaNT TyGiaCuaHang;
        private bool _isChangeTien = false;
        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form Đơn Hàng, load thông tin khách hàng và khởi tạo popup hàng hóa.
        /// </summary>
        public DonHang(DMQGService dMQGService, DMNTService dMMTService, DMHHService dMHHService, SysDMCuaHangService sysDMCuaHangService, DMTGService dMTGService)
        {
            InitializeComponent();
            // Đặt thuộc tính KeyPreview của Form là true trong Designer hoặc trong code
            this.KeyPreview = true;

            _dMQGService = dMQGService;
            _dMMTService = dMMTService;
            _dMHHService = dMHHService;
            _sysDMCuaHangService = sysDMCuaHangService;
            _dMTGService = dMTGService;
            SetUpUI();
            LoadData();
            InitUcHangHoaPopup();
            RegisterEvents();
        }


        #endregion

        #region Private Methods
        private void SetUpUI()
        {
            dataGridViewX1.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // hiển thị tiền ngoại tệ
            dataGridViewX1.Columns["Gia_ban_nt"].HeaderText = $"Giá {AppGlobals.DMCuaHang.Ma_nt}";
            dataGridViewX1.Columns["Gg_tien_nt"].HeaderText = $"Tiền giảm {AppGlobals.DMCuaHang.Ma_nt}";
            dataGridViewX1.Columns["Tien_ban_nt"].HeaderText = $"Thành tiền {AppGlobals.DMCuaHang.Ma_nt}";
            lb1NTQuyDoi.Text = $"1 {AppGlobals.DMCuaHang.Ma_nt} = ";
            lbTT1.Text = lbTT2.Text = lbTT3.Text = lbTTH.Text = lbTTT.Text = lbGiamGia.Text = lbTongThu.Text = lbTraLai.Text = $"({AppGlobals.DMCuaHang.Ma_nt})";
            _dMNTs = _dMMTService.GetAll();
        }
        /// <summary>
        /// Tải dữ liệu cần thiết cho form, ví dụ như danh sách hàng hóa, khách hàng, v.v.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadData()
        {
            LoadFormKhachHang(string.Empty);
            LoadInfoDonHang();
            LoadDataCombobox();
            ucHangHoa.SetData(_dMHHService.GetAll());
            var tyGia = _sysDMCuaHangService.GetTyGiaByMaCuaHang(AppGlobals.MaCH);
            txtTQDVND.Text = tyGia.Ty_gia.ToString("#,##0");
            lbTGNT.Text = $"{AppGlobals.DMCuaHang.Ma_nt}: {tyGia.Ty_gia.ToString("#,##0")}";
            lbTGNT2.Text = tyGia.Ty_gia.ToString("#,##0");
            cbbTTNT1.SelectedValue = tyGia.Ma_nt;
            cbbTTNT2.SelectedValue = tyGia.Ma_nt;
            cbbTTNT3.SelectedValue = tyGia.Ma_nt;
            cbTLNT.SelectedValue = tyGia.Ma_nt;

            TyGiaCuaHang = tyGia;
        }

        private void LoadDataCombobox()
        {
            ComboBoxHelper.BindData(cbbTT1, _thanhToans, "Value", "Key", true);
            ComboBoxHelper.BindData(cbbTT2, _thanhToans, "Value", "Key", true);
            ComboBoxHelper.BindData(cbbTT3, _thanhToans, "Value", "Key", true);

            ComboBoxHelper.BindData(cbbTTNT1, _dMNTs, nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
            ComboBoxHelper.BindData(cbbTTNT2, new List<DMNT>(_dMNTs), nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
            ComboBoxHelper.BindData(cbbTTNT3, new List<DMNT>(_dMNTs), nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
            ComboBoxHelper.BindData(cbTLNT, new List<DMNT>(_dMNTs), nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
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
        private void LoadFormKhachHang(string passport)
        {
            // Sử dụng DI để tạo form khách hàng và demo
            var formKhachHang = ActivatorUtilities.CreateInstance<KhachHang>(Program.ServiceProvider, passport);
            formKhachHang.ShowDialog();
            if (formKhachHang.DataKhachHang != null)
                BindDataKhachHang(formKhachHang.DataKhachHang);
        }

        /// <summary>
        /// Bind dữ liệu khách hàng lên các control trên form.
        /// </summary>
        /// <param name="khachhang">Đối tượng khách hàng</param>
        private void BindDataKhachHang(DMKH khachhang)
        {
            var quocGia = _dMQGService.GetByMaQuocGia(khachhang.Quoc_gia);
            txtCCCD.Text = khachhang?.Passport?.Trim() ?? "";
            txtDiaChi.Text = khachhang?.Dia_chi ?? "";
            txtQuocTinh.Text = quocGia?.Ten_Quoc_gia ?? "";
            txtTenKhachHang.Text = $"{khachhang?.Ho} {khachhang?.Ten_dem} {khachhang?.Ten}".Trim();
        }

        /// <summary>
        /// Khởi tạo control popup chọn hàng hóa và thêm vào form.
        /// </summary>
        private void InitUcHangHoaPopup()
        {
            ucHangHoaPopup = new ucHangHoa();
            ucHangHoaPopup.SetData(_dMHHService.GetAll());
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
            dataGridViewX1.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewX1_CellEndEdit);
            dataGridViewX1.KeyDown += dataGridViewX1_KeyDown;
            txtTTNT1.ValueChanged += TxtTTNT1_TextChanged;
            txtTTNT2.ValueChanged += TxtTTNT2_TextChanged;
            txtTTNT3.ValueChanged += TxtTTNT3_TextChanged;
            cbbTTNT1.SelectedIndexChanged += TxtTTNT1_TextChanged;
            cbbTTNT2.SelectedIndexChanged += TxtTTNT2_TextChanged;
            cbbTTNT3.SelectedIndexChanged += TxtTTNT3_TextChanged;

            txtQDTTNT1.ValueChanged += TxtQDTTNT1_TextChanged;
            txtQDTTNT2.ValueChanged += TxtQDTTNT2_TextChanged;
            txtQDTTNT3.ValueChanged += TxtQDTTNT3_TextChanged;
            txtTNNT.ValueChanged += TxtTNNT_TextChanged;
            txtTLNT.ValueChanged += TxtTLNT_TextChanged;
            cbTLNT.SelectedIndexChanged += TxtTLNT_TextChanged;

            RegisterHideUcHangHoaEvents();
        }

        // Xử lý sự kiện KeyDown
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa hết dữ liệu chi tiết không?", "Có", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dataGridViewX1.Rows.Clear(); 
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                LoadFormKhachHang(txtCCCD.Text);
            }
            else if (e.KeyCode == Keys.F12)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn đóng form đơn hàng?", "Có", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.F7) && dataGridViewX1.SelectedRows.Count > 0)
            {
                // Xác nhận xóa
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa dòng đã chọn?", "Xóa", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            dataGridViewX1.Rows.Remove(row);
                            TinhTongCong();
                        }
                    }
                }
            }
        }

        private void TxtTNNT_TextChanged(object sender, EventArgs e)
        {
            TinhTraLai();
        }

        private void TxtTLNT_TextChanged(object sender, EventArgs e)
        {
            if (cbTLNT.SelectedValue == null)
                return;

            var maNT = cbTLNT.SelectedValue.ToString();
            var tyGiaNT = _dMTGService.GetTyGiaByMaNT(maNT);

            if (tyGiaNT == null)
                return;

            decimal.TryParse(txtTLNT.Text, out decimal soTienTraLaiNT);

            if (tyGiaNT.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
            {
                txtQDTLNT.Text = soTienTraLaiNT.ToString("N2");
            }
            else
            {
                var soTienNT = (soTienTraLaiNT * TyGiaCuaHang.Ty_gia) / tyGiaNT.Ty_gia;
                txtQDTLNT.Text = soTienNT.ToString("N2");
            }
        }

        private void TxtQDTTNT1_TextChanged(object sender, EventArgs e)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;

            try
            {
                if (cbbTTNT1.SelectedValue == null)
                    return;

                var maNT = cbbTTNT1.SelectedValue.ToString();
                var tyGiaNT = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGiaNT == null)
                    return;

                if (!decimal.TryParse(txtQDTTNT1.Text, out decimal soTienQuyDoi))
                {
                    txtTTNT1.Text = "0";
                    return;
                }

                if (tyGiaNT.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
                {
                    txtTTNT1.Text = soTienQuyDoi.ToString("N2");
                }
                else
                {
                    var soTienNT = (soTienQuyDoi * TyGiaCuaHang.Ty_gia) / tyGiaNT.Ty_gia;
                    txtTTNT1.Text = soTienNT.ToString("N2");
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void TxtQDTTNT2_TextChanged(object sender, EventArgs e)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;

            try
            {
                if (cbbTTNT2.SelectedValue == null)
                    return;

                var maNT = cbbTTNT2.SelectedValue.ToString();
                var tyGiaNT = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGiaNT == null)
                    return;

                if (!decimal.TryParse(txtQDTTNT2.Text, out decimal soTienQuyDoi))
                {
                    txtTTNT2.Text = "0";
                    return;
                }

                if (tyGiaNT.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
                {
                    txtTTNT2.Text = soTienQuyDoi.ToString("N2");
                }
                else
                {
                    var soTienNT = (soTienQuyDoi * TyGiaCuaHang.Ty_gia) / tyGiaNT.Ty_gia;
                    txtTTNT2.Text = soTienNT.ToString("N2");
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void TxtQDTTNT3_TextChanged(object sender, EventArgs e)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;

            try
            {
                if (cbbTTNT3.SelectedValue == null)
                    return;

                var maNT = cbbTTNT3.SelectedValue.ToString();
                var tyGiaNT = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGiaNT == null)
                    return;

                if (!decimal.TryParse(txtQDTTNT3.Text, out decimal soTienQuyDoi))
                {
                    txtTTNT3.Text = "0";
                    return;
                }

                if (tyGiaNT.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
                {
                    txtTTNT3.Text = soTienQuyDoi.ToString("N2");
                }
                else
                {
                    var soTienNT = (soTienQuyDoi * TyGiaCuaHang.Ty_gia) / tyGiaNT.Ty_gia;
                    txtTTNT3.Text = soTienNT.ToString("N2");
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void TxtTTNT1_TextChanged(object sender, EventArgs e)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;
            try
            {
                if (cbbTTNT1.SelectedValue == null)
                    return;

                var maNT = cbbTTNT1.SelectedValue.ToString();
                var tyGia = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGia == null)
                    return;

                if (!decimal.TryParse(txtTTNT1.Text, out decimal soTienNT))
                {
                    txtQDTTNT1.Text = "0";
                    return;
                }

                if (tyGia.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
                {
                    txtQDTTNT1.Text = soTienNT.ToString("N2");
                }
                else
                {
                    var soTienVND = soTienNT * tyGia.Ty_gia;
                    var soTienQuyDoi = soTienVND / TyGiaCuaHang.Ty_gia;

                    txtQDTTNT1.Text = soTienQuyDoi.ToString("N2");
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void TxtTTNT2_TextChanged(object sender, EventArgs e)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;
            try
            {
                if (cbbTTNT2.SelectedValue == null)
                    return;

                var maNT = cbbTTNT2.SelectedValue.ToString();
                var tyGia = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGia == null)
                    return;

                if (!decimal.TryParse(txtTTNT2.Text, out decimal soTienNT))
                {
                    txtQDTTNT2.Text = "0";
                    return;
                }

                if (tyGia.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
                {
                    txtQDTTNT2.Text = soTienNT.ToString("N2");
                }
                else
                {
                    var soTienVND = soTienNT * tyGia.Ty_gia;
                    var soTienQuyDoi = soTienVND / TyGiaCuaHang.Ty_gia;

                    txtQDTTNT2.Text = soTienQuyDoi.ToString("N2");
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void TxtTTNT3_TextChanged(object sender, EventArgs e)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;
            try
            {
                if (cbbTTNT3.SelectedValue == null)
                    return;

                var maNT = cbbTTNT3.SelectedValue.ToString();
                var tyGia = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGia == null)
                    return;

                if (!decimal.TryParse(txtTTNT3.Text, out decimal soTienNT))
                {
                    txtQDTTNT3.Text = "0";
                    return;
                }

                if (tyGia.Ma_nt == AppGlobals.DMCuaHang.Ma_nt)
                {
                    txtQDTTNT3.Text = soTienNT.ToString("N2");
                }
                else
                {
                    var soTienVND = soTienNT * tyGia.Ty_gia;
                    var soTienQuyDoi = soTienVND / TyGiaCuaHang.Ty_gia;

                    txtQDTTNT3.Text = soTienQuyDoi.ToString("N2");
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void TinhTongThanhToan()
        {
            decimal.TryParse(txtQDTTNT1.Text, out decimal soTienNT1);
            decimal.TryParse(txtQDTTNT2.Text, out decimal soTienNT2);
            decimal.TryParse(txtQDTTNT3.Text, out decimal soTienNT3);
            txtQDNTTTT.Text = (soTienNT1 + soTienNT2 + soTienNT3).ToString("N2");
        }

        private void TinhTraLai()
        {
            decimal.TryParse(txtTNNT.Text, out decimal tongNhan);
            decimal.TryParse(txtTT.Text, out decimal tongThu);
            txtTLNT.Text = (tongNhan - tongThu).ToString("N2");
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
            ucHangHoa.Tb.Click += UcHangHoaOnClick;
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
                    TinhToanRow(row.Index);
                    TinhTongCong();
                    break;
                }
            }
            if (!found)
            {
                int idx = dataGridViewX1.Rows.Add();
                var newRow = dataGridViewX1.Rows[idx];
                newRow.Cells["Ma_hh"].Value = e.MaHH;
                newRow.Cells["Ten_hh"].Value = e.TenHH;
                newRow.Cells["So_luong"].Value = 1;
                TinhToanRow(newRow.Index);
                TinhTongCong();
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

        private void TinhToanRow(int rowIndex)
        {
            var maHang = dataGridViewX1.Rows[rowIndex].Cells["Ma_hh"].Value?.ToString();
            // get Giá bán
            var giaBanHH = _dMHHService.GiaBanHangHoa(maHang, AppGlobals.DMCuaHang.Ma_nt);
            if (giaBanHH == null)
            {
                MessageBox.Show($"Không tìm thấy giá bán cho hàng hóa {maHang} trong ngày {DateTime.Now.ToShortDateString()}");
                return;
            }

            if (giaBanHH?.TyGiaNT == null)
            {
                MessageBox.Show($"Không tìm thấy tỷ giá trong ngày {DateTime.Now.ToShortDateString()}");
                return;
            }

            var giaNT = giaBanHH?.Gia_ban ?? 0;
            var giaVND = giaBanHH?.Gia_ban * giaBanHH.TyGiaNT.Ty_gia;

            var row = dataGridViewX1.Rows[rowIndex];
            row.Cells["Gia_ban_nt"].Value = giaNT;
            row.Cells["Gia_ban"].Value = giaVND;

            if (
                decimal.TryParse(row.Cells["So_luong"].Value?.ToString(), out decimal soLuong)
                && decimal.TryParse(row.Cells["Gia_ban"].Value?.ToString(), out decimal giaBan)
                && decimal.TryParse(row.Cells["Gia_ban_nt"].Value?.ToString(), out decimal giaBanNT)
                && decimal.TryParse(row.Cells["Gg_ty_le"].Value?.ToString(), out decimal giamGiaTyle)
                )
            {
                var tienGiamNT = soLuong * giaNT * giamGiaTyle / 100;
                var tienGiamVND = soLuong * giaVND * giamGiaTyle / 100;

                row.Cells["Gg_tien_nt"].Value = tienGiamNT;
                row.Cells["Gg_tien"].Value = tienGiamVND;

                var thanhTienNT = soLuong * giaBanNT - tienGiamNT;
                row.Cells["Tien_ban_nt"].Value = thanhTienNT;
                row.Cells["Tien_ban"].Value = thanhTienNT * giaBanHH.TyGiaNT.Ty_gia;
            }
        }

        private void TinhTongCong()
        {
            decimal tongTienHang = 0;
            decimal tienGiam = 0;
            decimal tongThu = 0;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                if (!row.IsNewRow && decimal.TryParse(row.Cells["Gia_ban_nt"].Value?.ToString(), out decimal giaTienNT)
                    && decimal.TryParse(row.Cells["So_luong"].Value?.ToString(), out decimal soluong)
                    && decimal.TryParse(row.Cells["Gg_tien_nt"].Value?.ToString(), out decimal tienGiamNT))
                {
                    tongTienHang += giaTienNT * soluong;
                    tienGiam += tienGiamNT;
                    tongThu += tongTienHang - tienGiam;
                }
            }

            txtTTH.Text = tongTienHang.ToString("N2");
            txtTG.Text = tienGiam.ToString("N2");
            txtTT.Text = (tongTienHang - tienGiam).ToString("N2");
            txtTQDVND.Text = (tongThu * TyGiaCuaHang.Ty_gia).ToString("N2");

            TinhTraLai();
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
        /// Show popup khi click vào.
        /// </summary>
        private void UcHangHoaOnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucHangHoa.Tb.Text))
                ucHangHoa.ShowDropDown();
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


        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var col = dataGridViewX1.Columns[e.ColumnIndex];
            var columsFormatNumber = new List<string> { "So_luong", "Gia_ban_nt", "Gia_ban", "Gg_ty_le", "Gg_tien", "Tien_ban", "Gg_tien_nt", "Tien_ban_nt" };
            if (columsFormatNumber.Contains(col.Name)) // hoặc tên cột bạn muốn format số
            {
                var cell = dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    // Thử chuyển thành số (decimal hoặc double tuỳ ý)
                    if (decimal.TryParse(cell.Value.ToString(), out decimal result))
                        if (col.Name == "Gg_ty_le" && (result < 1 || result > 99))
                        {
                            cell.Value = 1;
                        }
                        else
                        {
                            cell.Value = result; // Khi đó format sẽ tự động áp dụng
                        }
                    else
                    {
                        cell.Value = 1;
                    }
                }

                // Tính toán lại dòng hiện tại (nếu cần)
                TinhToanRow(e.RowIndex);

                // Tính lại tổng cộng toàn lưới (nếu cần)
                TinhTongCong();
            }
        }

        #endregion
    }
}