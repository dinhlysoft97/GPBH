using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static GPBH.UI.UserControls.ucHangHoa;
using static System.Runtime.CompilerServices.RuntimeHelpers;

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
        private DonHangService _donHangService;
        private DMKHService _dMKHService;

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
        private bool _isEdit = false;
        private XPH5Dto _data;

        private BindingList<XCT5Dto> listChiTiet = new BindingList<XCT5Dto>();

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form Đơn Hàng, load thông tin khách hàng và khởi tạo popup hàng hóa.
        /// </summary>
        public DonHang(
            DMQGService dMQGService,
            DMNTService dMMTService,
            DMHHService dMHHService,
            SysDMCuaHangService sysDMCuaHangService,
            DMTGService dMTGService,
            DonHangService donHangService,
            DMKHService dMKHService,
            XPH5Dto data = null)
        {
            InitializeComponent();
            // Đặt thuộc tính KeyPreview của Form là true trong Designer hoặc trong code
            this.KeyPreview = true;

            _data = data;
            _isEdit = data != null;
            _dMQGService = dMQGService;
            _dMMTService = dMMTService;
            _dMHHService = dMHHService;
            _sysDMCuaHangService = sysDMCuaHangService;
            _dMTGService = dMTGService;
            _donHangService = donHangService;
            _dMKHService = dMKHService;
            SetUpUI();
            LoadData();
            InitUcHangHoaPopup();
            RegisterEvents();
            LoadDataForm();
        }
        #endregion

        #region Private Methods

        private void LoadDataForm()
        {
            if (_isEdit && _data != null && _data.XCT5s != null)
            {
                this.Text = "Sửa đơn hàng";
                listChiTiet = new BindingList<XCT5Dto>(_data.XCT5s);
                dataGridViewX1.DataSource = listChiTiet;
            }
        }

        private void SetUpUI()
        {
            dataGridViewX1.Columns["Stt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // hiển thị tiền ngoại tệ
            dataGridViewX1.Columns["Gia_ban_nt"].HeaderText = $"Giá {AppGlobals.DMCuaHang.Ma_nt}";
            dataGridViewX1.Columns["Gg_tien_nt"].HeaderText = $"Tiền giảm {AppGlobals.DMCuaHang.Ma_nt}";
            dataGridViewX1.Columns["Tien_ban_nt"].HeaderText = $"Thành tiền {AppGlobals.DMCuaHang.Ma_nt}";
            lb1NTQuyDoi.Text = $"1 {AppGlobals.DMCuaHang.Ma_nt} = ";
            lbTT1.Text = lbTT2.Text = lbTT3.Text = lbTTH.Text = lbTTT.Text = lbGiamGia.Text = lbTongThu.Text = lbTraLai.Text = $"({AppGlobals.DMCuaHang.Ma_nt})";


            dataGridViewX1.Columns["Stt"].DisplayIndex = 0;
            dataGridViewX1.Columns["Ma_hh"].DisplayIndex = 1;
            dataGridViewX1.Columns["Dvt"].DisplayIndex = 2;
            dataGridViewX1.Columns["Ten_hh"].DisplayIndex = 3;
            dataGridViewX1.Columns["So_luong"].DisplayIndex = 4;
            dataGridViewX1.Columns["Gia_ban_nt"].DisplayIndex = 5;
            dataGridViewX1.Columns["Gia_ban"].DisplayIndex = 6;
            dataGridViewX1.Columns["Gg_ty_le"].DisplayIndex = 7;
            dataGridViewX1.Columns["Gg_tien_nt"].DisplayIndex = 8;
            dataGridViewX1.Columns["Gg_tien"].DisplayIndex = 9;
            dataGridViewX1.Columns["Tien_ban_nt"].DisplayIndex = 10;
            dataGridViewX1.Columns["Tien_ban"].DisplayIndex = 11;
            dataGridViewX1.Columns["Gg_ly_do"].DisplayIndex = 12;


            _dMNTs = _dMMTService.GetAll();
        }
        /// <summary>
        /// Tải dữ liệu cần thiết cho form, ví dụ như danh sách hàng hóa, khách hàng, v.v.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoadData()
        {
            if (!_isEdit)
                LoadFormKhachHang(string.Empty);
            LoadInfoDonHang();
            LoadDataCombobox();
            ucHangHoa.SetData(_dMHHService.GetAll());
            var tyGia = _sysDMCuaHangService.GetTyGiaByMaCuaHang(AppGlobals.MaCH);
            txtTQDVND.Text = tyGia.Ty_gia.ToString("#,##0");
            lbTGNT.Text = $"{tyGia.Ma_nt}: {tyGia.Ty_gia.ToString("#,##0")}";
            lbTGNT2.Text = tyGia.Ty_gia.ToString("#,##0");
            cbbTTNT1.SelectedValue = tyGia.Ma_nt;
            cbbTTNT2.SelectedValue = tyGia.Ma_nt;
            cbbTTNT3.SelectedValue = tyGia.Ma_nt;
            cbTLNT.SelectedValue = tyGia.Ma_nt;

            TyGiaCuaHang = tyGia;

            dataGridViewX1.DataSource = listChiTiet;
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
            // Lưu và in
            if (e.KeyCode == Keys.F2)
            {
                if (!_isEdit) // tạo mới
                {
                    if (listChiTiet.Count == 0)
                        MessageBoxEx.Show("Vui lòng thêm ít nhất một mặt hàng trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {

                        TaoDonHang(TrangThaiDonHang.Confirmed);
                    }
                }
                else
                {
                    if (_data != null && string.IsNullOrEmpty(_data.So_chung_tu))
                        UpdateSoChungTuTinhTonKho();
                }
            }
            // xóa dữ liệu chi tiết
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
                            var item = row.DataBoundItem as XCT5Dto;
                            if (item != null) listChiTiet.Remove(item);
                            TinhTongCong();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.F8)
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
            // Lưu tạo đơn hàng
            else if (e.KeyCode == Keys.F12)
            {
                if (!_isEdit) // tạo mới
                {
                    if (listChiTiet.Count == 0)
                        MessageBoxEx.Show("Vui lòng thêm ít nhất một mặt hàng trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        // Tạo nháp đơn hàng
                        TaoDonHang(TrangThaiDonHang.Draft);
                    }
                }
                else
                {
                    if (listChiTiet.Count == 0)
                        MessageBoxEx.Show("Vui lòng thêm ít nhất một mặt hàng trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {

                    }
                }
            }
        }

        /// <summary>
        /// Tính toán tổng tiền và hiển thị lên form.
        /// </summary>
        /// <returns></returns>
        private XPH5Dto TaoDonHang(TrangThaiDonHang trangThaiDonHang)
        {
            XPH5Dto donHangDto = MapDataToSave(trangThaiDonHang);
            if (string.IsNullOrEmpty(donHangDto.Ma_phieu))
            {
                var (data, result) = _donHangService.TaoDonHang(donHangDto);
                if (result)
                {
                    // Hiển thị thông báo thành công
                    MessageBoxEx.Show("Tạo đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbSoChungTu.Text = $"{data.So_chung_tu}";
                    lbMaPhieu.Text = $"{data.Ma_phieu}";
                    // Sau khi gọi service lưu và nhận về newDonHang
                    OpenEditForm(data); // Mở lại form cho phép sửa tiếp
                    return data;
                }
            }

            return null;
        }

        /// <summary>
        /// Tạo đơn hàng và lưu vào cơ sở dữ liệu, sau đó cập nhật số chứng từ và tính toán tồn kho.
        /// </summary>
        /// <returns></returns>
        private XPH5Dto UpdateSoChungTuTinhTonKho()
        {
            XPH5Dto donHangDto = MapDataToSave(TrangThaiDonHang.Confirmed);
            var (data, result) = _donHangService.UpdateSoChungTuTinhTonKho(donHangDto);
            if (result)
            {
                // Hiển thị thông báo thành công
                MessageBoxEx.Show("Câp nhật số chừng từ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbSoChungTu.Text = $"{data.So_chung_tu}";
                lbMaPhieu.Text = $"{data.Ma_phieu}";
                OpenEditForm(data); // Mở lại form cho phép sửa tiếp
                return data;
            }

            return null;
        }

        /// <summary>
        /// Chuyển đổi dữ liệu từ form sang DTO để lưu vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="trangThaiDonHang"></param>
        /// <returns></returns>
        private XPH5Dto MapDataToSave(TrangThaiDonHang trangThaiDonHang)
        {
            decimal.TryParse(txtTTNT1.Text, out decimal tt1Tien);
            decimal.TryParse(txtTGTT1.Text, out decimal tt1TyGia);
            decimal.TryParse(txtTTNT1.Text, out decimal tl1TienNT);

            decimal.TryParse(txtTTNT2.Text, out decimal tt2Tien);
            decimal.TryParse(txtTGTT2.Text, out decimal tt2TyGia);
            decimal.TryParse(txtTTNT2.Text, out decimal tl2TienNT);

            decimal.TryParse(txtTTNT3.Text, out decimal tt3Tien);
            decimal.TryParse(txtTGTT3.Text, out decimal tt3TyGia);
            decimal.TryParse(txtTTNT3.Text, out decimal tl3TienNT);

            decimal.TryParse(txtQDNTTTT.Text, out decimal tongTienThanhToan);
            decimal.TryParse(txtTLNT.Text, out decimal traLaiNT);
            decimal.TryParse(txtQDTLNT.Text, out decimal traLai);

            decimal.TryParse(txtTTHNT.Text, out decimal tongTienHangNT);
            decimal.TryParse(txtTGNT.Text, out decimal tongGiamGiaNT);
            decimal.TryParse(txtTTHNT.Text, out decimal tongThuNT);
            var donHangDto = new XPH5Dto
            {
                Ma_cua_hang = AppGlobals.MaCH,
                Ma_phieu = lbMaPhieu.Text.Trim(),
                Ma_chung_tu = "X05",
                Ngay_chung_tu = DateTime.Now.Date,
                Ma_nt = TyGiaCuaHang.Ma_nt,
                Ty_gia = TyGiaCuaHang.Ty_gia,
                Ma_quay = AppGlobals.MaQuay,
                Ma_cqt = AppGlobals.DMCuaHang.Ma_cqt,
                Xuat_hddt = false,
                So_hddt = string.Empty,
                Xuat_hq = false,
                Ma_kho = AppGlobals.MaKho,
                Passport = txtCCCD.Text.Trim(),
                Ten_khach = txtTenKhachHang.Text.Trim(),

                Tt1_loai = cbbTT1.SelectedValue?.ToString(),
                Tt1_ma_nt = cbbTTNT1.SelectedValue?.ToString(),
                Tt1_tien_tt = tt1Tien,
                Tt1_ty_gia = tt1TyGia,
                Tl1_tien_nt = tl1TienNT,

                Tt2_loai = cbbTT2.SelectedValue?.ToString(),
                Tt2_ma_nt = cbbTTNT2.SelectedValue?.ToString(),
                Tt2_tien_tt = tt2Tien,
                Tt2_ty_gia = tt2TyGia,
                Tl2_tien_nt = tl2TienNT,

                Tt3_loai = cbbTT3.SelectedValue?.ToString(),
                Tt3_ma_nt = cbbTTNT3.SelectedValue?.ToString(),
                Tt3_tien_tt = tt3Tien,
                Tt3_ty_gia = tt3TyGia,
                Tl3_tien_nt = tl3TienNT,

                Tt_tong = tongTienThanhToan,
                Tra_lai_nt = traLaiNT,
                Tra_lai = traLai,
                Tong_tien_hang_nt = tongTienHangNT,
                Tong_tien_hang = tongTienHangNT * TyGiaCuaHang.Ty_gia,
                Tong_giam_gia_nt = tongGiamGiaNT,
                Tong_giam_gia = tongGiamGiaNT * TyGiaCuaHang.Ty_gia,
                Tong_thu_nt = tongThuNT,
                Tong_thu = tongThuNT * TyGiaCuaHang.Ty_gia,

                // Trạng thái
                Trang_thai = trangThaiDonHang
            };

            var listDonHang = dataGridViewX1.DataSource as BindingList<XCT5Dto>;
            if (listDonHang != null)
            {
                donHangDto.XCT5s = listDonHang.ToList();
            }
            donHangDto.Tong_so_luong = donHangDto.XCT5s.Sum(x => x.So_luong);

            // khách hàng
            var khachHang = _dMKHService.GetByPassport(txtCCCD.Text.Trim());
            donHangDto.Xnc_ngay_cap = khachHang.Xnc_ngay_cap;
            donHangDto.Xnc_ngay_hh = khachHang.Xnc_ngay_hh;
            donHangDto.So_hieu = khachHang.So_hieu;
            donHangDto.Ten_tau_bay = khachHang.Ten_tau_bay;
            donHangDto.Han_muc = khachHang.Han_muc;

            // Cửa hàng
            donHangDto.Ma_nhom_kh = AppGlobals.DMCuaHang.Ma_nhom_kh;
            donHangDto.Ma_loai_hinh = AppGlobals.DMCuaHang.Ma_loai_hinh;
            donHangDto.Ma_doi_tuong = AppGlobals.DMCuaHang.Ma_doi_tuong;
            return donHangDto;
        }

        public void OpenEditForm(XPH5Dto newDonHang)
        {
            this.Hide();
            // Nếu form là dạng modal (ShowDialog)
            var donHang = ActivatorUtilities.CreateInstance<DonHang>(Program.ServiceProvider, newDonHang);
            donHang.ShowDialog();
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
                txtTGTT1.Value = (double)tyGiaNT.Ty_gia;
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
                txtTGTT2.Value = (double)tyGiaNT.Ty_gia;
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
                txtTGTT3.Value = (double)tyGiaNT.Ty_gia;
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
                txtTGTT1.Value = (double)tyGia.Ty_gia;
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
                txtTGTT2.Value = (double)tyGia.Ty_gia;
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
                txtTGTT3.Value = (double)tyGia.Ty_gia;
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
                var item = row.DataBoundItem as XCT5Dto;
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối cùng để nhập mới
                item.Stt = stt++;
            }
        }

        /// <summary>
        /// Thêm mới hoặc tăng số lượng hàng hóa đã chọn lên lưới.
        /// </summary>
        /// <param name="e">Event args chứa thông tin hàng hóa</param>
        private void AddOrUpdateHangHoaToGrid(HangHoaSelectedEventArgs e)
        {
            // Tìm xem mã hàng đã có trong list chưa
            var existed = listChiTiet.FirstOrDefault(x => x.Ma_hh == e.MaHH);
            if (existed != null)
            {
                existed.So_luong += 1;
                TinhToanRow(existed);
            }
            else
            {
                var newItem = new XCT5Dto
                {
                    Ma_hh = e.MaHH,
                    Ten_hh = e.TenHH,
                    Dvt = e.Dvt,
                    So_luong = 1,
                    Gg_ty_le = 0 // gán mặc định nếu có
                };
                TinhToanRow(newItem);
                listChiTiet.Add(newItem);
            }
            TinhTongCong();
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

        private void TinhToanRow(XCT5Dto item)
        {
            // get Giá bán
            var giaBanHH = _dMHHService.GiaBanHangHoa(item.Ma_hh, AppGlobals.DMCuaHang.Ma_nt);
            if (giaBanHH == null)
            {
                MessageBox.Show($"Không tìm thấy giá bán cho hàng hóa {item.Ma_hh} trong ngày {DateTime.Now.ToShortDateString()}");
                return;
            }

            if (giaBanHH?.TyGiaNT == null)
            {
                MessageBox.Show($"Không tìm thấy tỷ giá trong ngày {DateTime.Now.ToShortDateString()}");
                return;
            }

            var giaNT = giaBanHH?.Gia_ban ?? 0;
            var giaVND = giaBanHH?.Gia_ban * giaBanHH.TyGiaNT.Ty_gia;

            item.Gia_ban_nt = giaNT;
            item.Gia_ban = giaVND;

            if (item.So_luong.HasValue && item.Gia_ban.HasValue && item.Gia_ban_nt.HasValue && item.Gg_ty_le.HasValue)
            {
                var tienGiamNT = item.So_luong * giaNT * item.Gg_ty_le / 100;
                var tienGiamVND = item.So_luong * giaVND * item.Gg_ty_le / 100;

                item.Gg_tien_nt = tienGiamNT;
                item.Gg_tien = tienGiamVND;

                var thanhTienNT = item.So_luong * item.Gia_ban_nt - tienGiamNT;
                item.Tien_ban_nt = thanhTienNT;
                item.Tien_ban = thanhTienNT * giaBanHH.TyGiaNT.Ty_gia;
            }

            dataGridViewX1.Refresh();
        }

        private void TinhTongCong()
        {
            decimal tongTienHang = 0;
            decimal tienGiam = 0;
            decimal tongThu = 0;
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                var item = row.DataBoundItem as XCT5Dto;
                if (!row.IsNewRow && item.Gia_ban_nt.HasValue && item.So_luong.HasValue && item.Gg_tien_nt.HasValue)
                {
                    tongTienHang += item.Gia_ban_nt.Value * item.So_luong.Value;
                    tienGiam += item.Gg_tien_nt.Value;
                    tongThu += tongTienHang - tienGiam;
                }
            }

            txtTTHNT.Text = tongTienHang.ToString("N2");
            txtTGNT.Text = tienGiam.ToString("N2");
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


        /// <summary>
        /// Xử lý khi kết thúc edit một cell: cập nhật lại object, tính toán lại nếu cần.
        /// </summary>
        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridViewX1.Rows[e.RowIndex].DataBoundItem as XCT5Dto;
            if (item == null) return;

            var col = dataGridViewX1.Columns[e.ColumnIndex];
            var columnsFormatNumber = new List<string> { "So_luong", "Gia_ban_nt", "Gia_ban", "Gg_ty_le", "Gg_tien", "Tien_ban", "Gg_tien_nt", "Tien_ban_nt" };
            if (columnsFormatNumber.Contains(col.Name))
            {
                // Nếu Gg_ty_le nhập ngoài khoảng 1-99 thì về 1
                if (col.Name == "Gg_ty_le" && (item.Gg_ty_le < 1 || item.Gg_ty_le > 99))
                    item.Gg_ty_le = 1;

                // Tính toán lại dòng và tổng
                TinhToanRow(item);
                TinhTongCong();
            }
        }
        #endregion
    }
}