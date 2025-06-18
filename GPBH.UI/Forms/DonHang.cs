using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using GPBH.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        private DonHangService _donHangService;
        private DMKHService _dMKHService;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;

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
        private TyGiaNT TyGiaGanNhat;
        private SysDMCuaHang CuaHang;
        private bool _isChangeTien = false;
        private bool _isEdit = false;
        private XPH5Dto _data;

        private BindingList<XCT5Dto> listChiTiet = new BindingList<XCT5Dto>();
        private List<GirdSysDinhDangFormDto> SysDinhDangs;
        private readonly bool isCurrencyVND;
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
            SysDinh_dang_formService sysDinh_Dang_FormService,
            XPH5Dto data = null)
        {
            InitializeComponent();
            // Đặt thuộc tính KeyPreview của Form là true trong Designer hoặc trong code
            this.KeyPreview = true;
        
            _dMQGService = dMQGService;
            _dMMTService = dMMTService;
            _dMHHService = dMHHService;
            _sysDMCuaHangService = sysDMCuaHangService;
            _dMTGService = dMTGService;
            _donHangService = donHangService;
            _dMKHService = dMKHService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            CuaHang = _sysDMCuaHangService.GetByMaCuaHang(AppGlobals.MaCH);
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH);
            _dMNTs = _dMMTService.GetAll();
            isCurrencyVND = CuaHang.Ma_nt == GPBHConstant.CurrencyVND; 
            _data = data;
            _isEdit = data != null;
            SetUpUI();
            if (!_isEdit)
                LoadData();
            else
                LoadDataEdit();
            InitUcHangHoaPopup();
            RegisterEvents();
        }
        #endregion

        #region Private Methods

        private string GetFormat(string column)
        {
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }

        private void LoadDataEdit()
        {
            if (_isEdit && _data != null)
            {
                TyGiaGanNhat = new TyGiaNT
                {
                    Ma_nt = _data.Ma_nt,
                    Ty_gia = _data.Ty_gia.Value
                };

                this.Text = "Sửa đơn hàng";
                listChiTiet = new BindingList<XCT5Dto>(_data.XCT5s);
                LoadDataCombobox();
                BindDataKhachHang(_dMKHService.GetByPassport(_data.Passport));
                ucHangHoa.SetData(_dMHHService.GetAll());

                lbTenDangNhap.Text = _data.Nguoi_tao;
                lbQuay.Text = _data.Ma_quay;
                lbCa.Text = AppGlobals.MaCa;
                lbMST.Text = _data.Ma_cqt;
                lnSHD.Text = _data.So_hddt;

                txtTQDVND.Value = (double)_data.Tong_thu_nt * (double)_data.Ty_gia;
                lbTGNT.Text = $"{_data.Ma_nt}: {TyGiaGanNhat.Ty_gia.ToString(GetFormat("Format_tien"))}";

                lbSoChungTu.Text = _data.So_chung_tu;
                lbMaPhieu.Text = _data.Ma_phieu;

                cbbTt1_loai.SelectedValue = _data.Tt1_loai;
                cbbTt1_ma_nt.SelectedValue = _data.Tt1_ma_nt;
                txtTt1_tien_tt.Value = (double)_data.Tt1_tien_tt;
                txtTt1_tien_nt.Value = (double)_data.Tt1_tien_nt;

                cbbTt2_loai.SelectedValue = _data.Tt2_loai;
                cbbTt2_ma_nt.SelectedValue = _data.Tt2_ma_nt;
                txtTt2_tien_tt.Value = (double)_data.Tt2_tien_tt;
                txtTt2_tien_nt.Value = (double)_data.Tt2_tien_nt;

                cbbTt3_loai.SelectedValue = _data.Tt3_loai;
                cbbTt3_ma_nt.SelectedValue = _data.Tt3_ma_nt;
                txtTt3_tien_tt.Value = (double)_data.Tt3_tien_tt;
                txtTt3_tien_nt.Value = (double)_data.Tt3_tien_nt;

                txtTt_tong.Value = (double)_data.Tt_tong;
                txtTong_nhan.Value = (double)_data.Tong_nhan;
                txtTra_lai_nt.Value = (double)_data.Tra_lai_nt;
                txtTra_lai.Value = (double)_data.Tra_lai;
                cbTra_lai.SelectedValue = _data.Ma_tra_lai;

                txtTong_tien_hang_nt.Value = (double)_data.Tong_tien_hang_nt;
                txtTong_giam_gia_nt.Value = (double)_data.Tong_giam_gia_nt;
                txtTong_thu_nt.Value = (double)_data.Tong_thu_nt;

                if (_data.XCT5s != null)
                {
                    dataGridViewX1.DataSource = listChiTiet;
                }
            }
        }

        private void SetUpUI()
        {
            dataGridViewX1.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);

            // hiển thị tiền ngoại tệ
            dataGridViewX1.Columns["Gia_ban_nt"].HeaderText = $"Giá {CuaHang.Ma_nt}";
            dataGridViewX1.Columns["Gg_tien_nt"].HeaderText = $"Tiền giảm {CuaHang.Ma_nt}";
            dataGridViewX1.Columns["Tien_ban_nt"].HeaderText = $"Thành tiền {CuaHang.Ma_nt}";
            lbQuyDoiTienTe.Text = $"";
            lbTT1.Text = lbTT2.Text = lbTT3.Text = lbTTH.Text = lbTTT.Text = lbGiamGia.Text = lbTongThu.Text = lbTraLai.Text = $"({CuaHang.Ma_nt})";

            // Thiết lập các cột hiển thị trong DataGridViewX
            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("Ma_hh", 1);
            dataGridViewX1.SetDisplayIndex("Dvt", 2);
            dataGridViewX1.SetDisplayIndex("Ten_hh", 3);
            dataGridViewX1.SetDisplayIndex("So_luong", 4);
            dataGridViewX1.SetDisplayIndex("Gia_ban_nt", 5);
            dataGridViewX1.SetDisplayIndex("Gia_ban", 6);
            dataGridViewX1.SetDisplayIndex("Gg_ty_le", 7);
            dataGridViewX1.SetDisplayIndex("Gg_tien_nt", 8);
            dataGridViewX1.SetDisplayIndex("Gg_tien", 9);
            dataGridViewX1.SetDisplayIndex("Tien_ban_nt", 10);
            dataGridViewX1.SetDisplayIndex("Tien_ban", 11);
            dataGridViewX1.SetDisplayIndex("Gg_ly_do", 12);

            if (isCurrencyVND)
            {
                // Ẩn cột tiền ngoại tệ nếu là VND
                dataGridViewX1.Columns["Gia_ban"].Visible = false;
                dataGridViewX1.Columns["Gg_tien"].Visible = false;
                dataGridViewX1.Columns["Tien_ban"].Visible = false;
            }

            // Thiết lập các cột không hiển thị
            dataGridViewX1.SetCellAlignment("So_luong", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Gia_ban_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Gia_ban", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Gg_ty_le", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Gg_tien_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Gg_tien", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Tien_ban_nt", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Tien_ban", DataGridViewContentAlignment.MiddleRight);

            // Format các cột tiền
            dataGridViewX1.SetFormat("So_luong", GetFormat("Format_so_luong"));
            dataGridViewX1.SetFormat("Gia_ban_nt", GetFormat("Format_gia_nt"));
            dataGridViewX1.SetFormat("Gia_ban", GetFormat("Format_gia"));
            dataGridViewX1.SetFormat("Gg_ty_le", GetFormat("Format_gia"));
            dataGridViewX1.SetFormat("Gg_tien_nt", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Gg_tien", GetFormat("Format_gia"));
            dataGridViewX1.SetFormat("Tien_ban_nt", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Tien_ban", GetFormat("Format_gia"));

            // Format các cột tiền controls 
            txtTong_tien_hang_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTong_giam_gia_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTong_thu_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTQDVND.DisplayFormat(GetFormat("Format_tien"));

            txtTt1_tien_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTt2_tien_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTt3_tien_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTt1_tien_tt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTt2_tien_tt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTt3_tien_tt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTt_tong.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTong_nhan.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTra_lai_nt.DisplayFormat(GetFormat("Format_tien_nt"));
            txtTra_lai.DisplayFormat(GetFormat("Format_tien"));
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
            cbbTt1_ma_nt.SelectedValue = tyGia.Ma_nt;
            cbbTt2_ma_nt.SelectedValue = tyGia.Ma_nt;
            cbbTt3_ma_nt.SelectedValue = tyGia.Ma_nt;
            cbTra_lai.SelectedValue = tyGia.Ma_nt;
            TyGiaGanNhat = tyGia;

            lbTGNT.Text = $"{TyGiaGanNhat.Ma_nt}: {TyGiaGanNhat.Ty_gia.ToString(GetFormat("Format_tien"))}";
            dataGridViewX1.DataSource = listChiTiet;
        }

        private void LoadDataCombobox()
        {
            ComboBoxHelper.BindData(cbbTt1_loai, _thanhToans, "Value", "Key", true);
            ComboBoxHelper.BindData(cbbTt2_loai, _thanhToans, "Value", "Key", true);
            ComboBoxHelper.BindData(cbbTt3_loai, _thanhToans, "Value", "Key", true);

            ComboBoxHelper.BindData(cbbTt1_ma_nt, _dMNTs, nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
            ComboBoxHelper.BindData(cbbTt2_ma_nt, new List<DMNT>(_dMNTs), nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
            ComboBoxHelper.BindData(cbbTt3_ma_nt, new List<DMNT>(_dMNTs), nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
            ComboBoxHelper.BindData(cbTra_lai, new List<DMNT>(_dMNTs), nameof(DMNT.Ma_nt), nameof(DMNT.Ma_nt), true);
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
            lbMST.Text = CuaHang?.Ma_cqt ?? string.Empty;
            lnSHD.Text = string.Empty;
        }

        /// <summary>
        /// Hiển thị form chọn khách hàng, sau đó bind dữ liệu khách hàng lên form.
        /// </summary>
        private void LoadFormKhachHang(string passport)
        {
            // Sử dụng DI để tạo form khách hàng và demo
            var formKhachHang = this.ShowForm<KhachHang>(passport);
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
            ucHangHoa.TbChange += TbHH_Change;
            dataGridViewX1.RowsRemoved += dataGridViewX1_RowsRemoved;
            dataGridViewX1.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewX1_CellEndEdit);

            cbbTt1_ma_nt.SelectedIndexChanged += ThanhToan1_TextChanged;
            cbbTt2_ma_nt.SelectedIndexChanged += ThanhToan2_TextChanged;
            cbbTt3_ma_nt.SelectedIndexChanged += ThanhToan3_TextChanged;
            txtTt1_tien_tt.ValueChanged += ThanhToan1_TextChanged;
            txtTt2_tien_tt.ValueChanged += ThanhToan2_TextChanged;
            txtTt3_tien_tt.ValueChanged += ThanhToan3_TextChanged;

            txtTt1_tien_nt.ValueChanged += NgoaiTe1_TextChanged;
            txtTt2_tien_nt.ValueChanged += NgoaiTe2_TextChanged;
            txtTt3_tien_nt.ValueChanged += NgoaiTe3_TextChanged;
            txtTong_nhan.ValueChanged += TxtTNNT_TextChanged;
            txtTra_lai_nt.ValueChanged += TxtTLNT_TextChanged;
            cbTra_lai.SelectedIndexChanged += TxtTLNT_TextChanged;

            RegisterHideUcHangHoaEvents();
        }

        // Xử lý sự kiện KeyDown
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Lưu và in
            if (e.KeyCode == Keys.F2)
            {
                HandlerKeyF2();
            }
            // xóa dữ liệu chi tiết
            if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.F7) && dataGridViewX1.SelectedRows.Count > 0)
            {
                // Xác nhận xóa
                var confirm = MessageBoxEx.Show("Bạn có chắc muốn xóa dòng đã chọn?", "Xóa", MessageBoxButtons.YesNo);
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
                var confirm = MessageBoxEx.Show("Bạn có chắc muốn xóa hết dữ liệu chi tiết không?", "Có", MessageBoxButtons.YesNo);
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
                HandlerKeyF12();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn F12 để tạo đơn hàng.
        /// </summary>
        private void HandlerKeyF12()
        {
            if (!_isEdit) // tạo mới
            {
                var validator = ValidatorData();
                // Tạo nháp đơn hàng
                if (validator)
                    TaoDonHang(TrangThaiDonHang.Draft);
            }
            else
            {
                var validator = ValidatorData();
                if (validator)
                    UpdateSoChungTuTinhTonKho(TrangThaiDonHang.Draft);
            }
        }


        /// <summary>
        /// Xử lý sự kiện khi nhấn F2 để lưu hoặc cập nhật số chứng từ.
        /// </summary>
        private void HandlerKeyF2()
        {
            if (!_isEdit) // tạo mới
            {
                var validator = ValidatorData();
                if (validator)
                    TaoDonHang(TrangThaiDonHang.Confirmed);
            }
            else
            {
                if (_data != null && string.IsNullOrEmpty(_data.So_chung_tu))
                    UpdateSoChungTuTinhTonKho(TrangThaiDonHang.Confirmed);
            }
        }

        /// <summary>
        /// Validator trước khi lưu
        /// </summary>
        /// <returns></returns>
        private bool ValidatorData()
        {
            if (string.IsNullOrEmpty(txtCCCD.Text.Trim()) || string.IsNullOrEmpty(txtQuocTinh.Text.Trim()) || string.IsNullOrEmpty(txtTenKhachHang.Text.Trim()))
            {
                MessageBoxEx.Show("Vui lòng nhập thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadFormKhachHang(string.Empty);
                return false;
            }

            if (listChiTiet.Count == 0)
            {
                MessageBoxEx.Show("Vui lòng thêm ít nhất một mặt hàng trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (!string.IsNullOrEmpty(ucHangHoa.Tb.Text))
                    ucHangHoa.ShowDropDown();
                return false;
            }
            else
            {
                foreach (DataGridViewRow item in dataGridViewX1.Rows)
                {
                    // Đảm bảo không phải dòng mới (add new row)
                    if (item.IsNewRow) continue;
                    var row = item.DataBoundItem as XCT5Dto;
                    var maHang = row.Ma_hh?.ToString().Trim() ?? string.Empty;
                    if (string.IsNullOrEmpty(maHang))
                    {
                        MessageBox.Show("Mã hàng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridViewX1.CurrentCell = item.Cells["Ma_hh"];
                        dataGridView1_EditingControlShowing(null, null);
                        return false;
                    }
                }
            }

            if (txtTra_lai_nt.Value < 0)
            {
                MessageBoxEx.Show("Tổng trả đang bị âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTra_lai_nt.Focus();
                return false;
            }

            // check hạn mức
            var tongTienThanhToan = (decimal)txtTt_tong.Value * (_data != null ? _data.Ty_gia : TyGiaGanNhat.Ty_gia);
            if (tongTienThanhToan > CuaHang.Han_muc_tm)
            {
                MessageBoxEx.Show($"Hạn mức thanh toán tối đa là {CuaHang.Han_muc_tm.ToString(GetFormat("Format_tien"))} {CuaHang.Ma_nt_qd}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTong_nhan.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Tính toán tổng tiền và hiển thị lên form.
        /// </summary>
        /// <returns></returns>
        private void TaoDonHang(TrangThaiDonHang trangThaiDonHang)
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
                }
            }
        }

        /// <summary>
        /// Tạo đơn hàng và lưu vào cơ sở dữ liệu, sau đó cập nhật số chứng từ và tính toán tồn kho.
        /// </summary>
        /// <returns></returns>
        private void UpdateSoChungTuTinhTonKho(TrangThaiDonHang trangThaiDonHang)
        {
            XPH5Dto donHangDto = MapDataToSave(trangThaiDonHang);
            var (data, result) = _donHangService.UpdateSoChungTuTinhTonKho(donHangDto);
            if (result)
            {
                // Hiển thị thông báo thành công
                MessageBoxEx.Show("Câp nhật số chừng từ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbSoChungTu.Text = $"{data.So_chung_tu}";
                lbMaPhieu.Text = $"{data.Ma_phieu}";
            }
        }

        /// <summary>
        /// Chuyển đổi dữ liệu từ form sang DTO để lưu vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="trangThaiDonHang"></param>
        /// <returns></returns>
        private XPH5Dto MapDataToSave(TrangThaiDonHang trangThaiDonHang)
        {
            decimal.TryParse(txtTt1_tien_tt.Text, out decimal tt1_tien_tt);
            decimal.TryParse(txtTt1_tien_nt.Text, out decimal tt1_tien_nt);

            decimal.TryParse(txtTt2_tien_tt.Text, out decimal tt2_tien_tt);
            decimal.TryParse(txtTt2_tien_nt.Text, out decimal tt2_tien_nt);

            decimal.TryParse(txtTt3_tien_tt.Text, out decimal tt3_tien_tt);
            decimal.TryParse(txtTt3_tien_nt.Text, out decimal tt3_tien_nt);

            decimal.TryParse(txtTt_tong.Text, out decimal tongTienThanhToan);
            decimal.TryParse(txtTong_nhan.Text, out decimal tongNhan);
            decimal.TryParse(txtTra_lai_nt.Text, out decimal traLaiNT);
            decimal.TryParse(txtTra_lai.Text, out decimal traLai);

            decimal.TryParse(txtTong_tien_hang_nt.Text, out decimal tongTienHangNT);
            decimal.TryParse(txtTong_giam_gia_nt.Text, out decimal tongGiamGiaNT);
            decimal.TryParse(txtTong_thu_nt.Text, out decimal tongThuNT);
            var donHangDto = new XPH5Dto
            {
                Ma_cua_hang = AppGlobals.MaCH,
                Ma_phieu = lbMaPhieu.Text.Trim(),
                Ma_chung_tu = "X05",
                Ngay_chung_tu = DateTime.Now.Date,
                Ma_nt = TyGiaGanNhat.Ma_nt,
                Ty_gia = TyGiaGanNhat.Ty_gia,
                Ma_quay = AppGlobals.MaQuay,
                Ma_cqt = CuaHang.Ma_cqt,
                Xuat_hddt = false,
                So_hddt = string.Empty,
                Xuat_hq = false,
                Ma_kho = AppGlobals.MaKho,
                Passport = txtCCCD.Text.Trim(),
                Ten_khach = txtTenKhachHang.Text.Trim(),

                Tt1_loai = cbbTt1_loai.SelectedValue?.ToString(),
                Tt1_ma_nt = cbbTt1_ma_nt.SelectedValue?.ToString(),
                Tt1_tien_tt = tt1_tien_tt,
                Tt1_tien_nt = tt1_tien_nt,

                Tt2_loai = cbbTt2_loai.SelectedValue?.ToString(),
                Tt2_ma_nt = cbbTt2_ma_nt.SelectedValue?.ToString(),
                Tt2_tien_tt = tt2_tien_tt,
                Tt2_tien_nt = tt2_tien_nt,

                Tt3_loai = cbbTt3_loai.SelectedValue?.ToString(),
                Tt3_ma_nt = cbbTt3_ma_nt.SelectedValue?.ToString(),
                Tt3_tien_tt = tt3_tien_tt,
                Tt3_tien_nt = tt3_tien_nt,

                Tt_tong = tongTienThanhToan,
                Tong_nhan = tongNhan,
                Tra_lai_nt = traLaiNT,
                Tra_lai = traLai,
                Ma_tra_lai = cbTra_lai.SelectedValue?.ToString(),
                Tong_tien_hang_nt = tongTienHangNT,
                Tong_tien_hang = tongTienHangNT * TyGiaGanNhat.Ty_gia,
                Tong_giam_gia_nt = tongGiamGiaNT,
                Tong_giam_gia = tongGiamGiaNT * TyGiaGanNhat.Ty_gia,
                Tong_thu_nt = tongThuNT,
                Tong_thu = tongThuNT * TyGiaGanNhat.Ty_gia,

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
            donHangDto.Ma_nhom_kh = CuaHang.Ma_nhom_kh;
            donHangDto.Ma_loai_hinh = CuaHang.Ma_loai_hinh;
            donHangDto.Ma_doi_tuong = CuaHang.Ma_doi_tuong;
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
            if (cbTra_lai.SelectedValue == null)
                return;

            var maNT = cbTra_lai.SelectedValue.ToString();
            var tyGia = _dMTGService.GetTyGiaByMaNT(maNT);

            if (tyGia == null)
                return;

            decimal.TryParse(txtTra_lai_nt.Text, out decimal soTienTraLaiNT);

            if (tyGia.Ma_nt == CuaHang.Ma_nt)
            {
                txtTra_lai.Value = (double)soTienTraLaiNT;
            }
            else
            {
                var soTienNT = (soTienTraLaiNT * TyGiaGanNhat.Ty_gia) / tyGia.Ty_gia;
                txtTra_lai.Value = (double)soTienNT;
            }

            lbQuyDoiTienTe.Text = $"{txtTra_lai_nt.Text} {CuaHang.Ma_nt} =  {txtTra_lai.Value.ToString(GetFormat("Format_tien"))} {maNT}";
        }

        private void NgoaiTe1_TextChanged(object sender, EventArgs e)
        {
            HandelChangeNgoaiTe(cbbTt1_ma_nt, txtTt1_tien_nt, txtTt1_tien_tt);
            SetFormatThanhToan(cbbTt1_ma_nt, txtTt1_tien_tt);
        }

        private void NgoaiTe2_TextChanged(object sender, EventArgs e)
        {
            HandelChangeNgoaiTe(cbbTt2_ma_nt, txtTt2_tien_nt, txtTt2_tien_tt);
            SetFormatThanhToan(cbbTt2_ma_nt, txtTt2_tien_tt);
        }

        private void NgoaiTe3_TextChanged(object sender, EventArgs e)
        {
            HandelChangeNgoaiTe(cbbTt3_ma_nt, txtTt3_tien_nt, txtTt3_tien_tt);
            SetFormatThanhToan(cbbTt3_ma_nt, txtTt3_tien_tt);
        }

        private void ThanhToan1_TextChanged(object sender, EventArgs e)
        {
            HandelChangeThanhToan(cbbTt1_ma_nt, txtTt1_tien_tt, txtTt1_tien_nt);
            SetFormatThanhToan(cbbTt1_ma_nt, txtTt1_tien_tt);
        }

        private void ThanhToan2_TextChanged(object sender, EventArgs e)
        {
            HandelChangeThanhToan(cbbTt2_ma_nt, txtTt2_tien_tt, txtTt2_tien_nt);
            SetFormatThanhToan(cbbTt2_ma_nt, txtTt2_tien_tt);
        }

        private void ThanhToan3_TextChanged(object sender, EventArgs e)
        {
            HandelChangeThanhToan(cbbTt3_ma_nt, txtTt3_tien_tt, txtTt3_tien_nt);
            SetFormatThanhToan(cbbTt3_ma_nt, txtTt3_tien_tt);
        }

        private void SetFormatThanhToan(ComboBoxEx cbbTt_ma_nt, DoubleInput txtTt_tien_tt)
        {
            if (cbbTt_ma_nt.SelectedValue.ToString().ToLower() == GPBHConstant.CurrencyVND.ToLower())
                txtTt_tien_tt.DisplayFormat(GetFormat("Format_tien"));
            else
                txtTt_tien_tt.DisplayFormat(GetFormat("Format_tien_nt"));
        }

        private void HandelChangeThanhToan(ComboBoxEx cbbTt_ma_nt, DoubleInput txtTt_tien_1, DoubleInput txtTt_tien_2)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;
            try
            {
                if (cbbTt_ma_nt.SelectedValue == null)
                    return;

                var maNT = cbbTt_ma_nt.SelectedValue.ToString();
                var tyGia = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGia == null)
                    return;

                if (tyGia.Ma_nt == CuaHang.Ma_nt)
                {
                    txtTt_tien_2.Value = txtTt_tien_1.Value;
                }
                else
                {
                    var soTienVND = txtTt_tien_1.Value * (double)tyGia.Ty_gia;
                    var soTienQuyDoi = soTienVND / (double)TyGiaGanNhat.Ty_gia;

                    txtTt_tien_2.Value = soTienQuyDoi;
                }
            }
            finally
            {
                TinhTongThanhToan();
                _isChangeTien = false;
            }
        }

        private void HandelChangeNgoaiTe(ComboBoxEx cbbTt_ma_nt, DoubleInput txtTt_tien_1, DoubleInput txtTt_tien_2)
        {
            if (_isChangeTien) return;
            _isChangeTien = true;
            try
            {
                if (cbbTt_ma_nt.SelectedValue == null)
                    return;

                var maNT = cbbTt_ma_nt.SelectedValue.ToString();
                var tyGia = _dMTGService.GetTyGiaByMaNT(maNT);

                if (tyGia == null)
                    return;

                if (tyGia.Ma_nt == CuaHang.Ma_nt)
                {
                    txtTt_tien_2.Value = txtTt_tien_1.Value;
                }
                else
                {
                    var soTienVND = txtTt_tien_1.Value * (double)TyGiaGanNhat.Ty_gia;
                    var soTienQuyDoi = soTienVND / (double)tyGia.Ty_gia;

                    txtTt_tien_2.Value = soTienQuyDoi;
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
            decimal.TryParse(txtTt1_tien_nt.Text, out decimal soTienNT1);
            decimal.TryParse(txtTt2_tien_nt.Text, out decimal soTienNT2);
            decimal.TryParse(txtTt3_tien_nt.Text, out decimal soTienNT3);
            txtTt_tong.Value = (double)(soTienNT1 + soTienNT2 + soTienNT3);
        }

        private void TinhTraLai()
        {
            decimal.TryParse(txtTong_nhan.Text, out decimal tongNhan);
            decimal.TryParse(txtTong_thu_nt.Text, out decimal tongThu);
            txtTra_lai_nt.Value = (double)(tongNhan - tongThu);
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
            else if (listChiTiet.Any(z => z.Ma_hh == null))
            {
                var rowNull = listChiTiet.FirstOrDefault(x => x.Ma_hh == null);
                rowNull.Ma_hh = e.MaHH;
                TinhToanRow(rowNull);
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
            var giaBanHH = _dMHHService.GiaBanHangHoa(item.Ma_hh, CuaHang.Ma_nt);
            //if (giaBanHH == null)
            //{
            //    MessageBoxEx.Show($"Không tìm thấy giá bán cho hàng hóa {item.Ma_hh} trong ngày {DateTime.Now.ToShortDateString()}");
            //    return;
            //}

            //if (giaBanHH?.TyGiaNT == null)
            //{
            //    MessageBoxEx.Show($"Không tìm thấy tỷ giá trong ngày {DateTime.Now.ToShortDateString()}");
            //    return;
            //}

            var giaNT = giaBanHH?.Gia_ban ?? 0;
            var giaVND = giaBanHH?.Gia_ban * giaBanHH?.TyGiaNT?.Ty_gia ?? 1;

            item.Gia_ban_nt = giaNT;
            item.Gia_ban = giaVND;

            if (item.So_luong.HasValue && item.Gia_ban.HasValue && item.Gia_ban_nt.HasValue && item.Gg_ty_le.HasValue)
            {
                var tienGiamNT = (decimal)Math.Round((double)(item.So_luong * giaNT * item.Gg_ty_le / 100), 2);
                var tienGiamVND = (decimal)Math.Round((double)(item.So_luong * giaVND * item.Gg_ty_le / 100), 0);

                item.Gg_tien_nt = tienGiamNT;
                item.Gg_tien = tienGiamVND;

                var thanhTienNT = item.So_luong * item.Gia_ban_nt - tienGiamNT;
                item.Tien_ban_nt = thanhTienNT;
                item.Tien_ban = thanhTienNT * giaBanHH?.TyGiaNT?.Ty_gia ?? 0;
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

            txtTong_tien_hang_nt.Value = (double)tongTienHang;
            txtTong_giam_gia_nt.Value = (double)tienGiam;
            txtTong_thu_nt.Value = (double)(tongTienHang - tienGiam);
            txtTQDVND.Value = (double)(tongThu * TyGiaGanNhat.Ty_gia);

            TinhTraLai();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện khi thay đổi giá trị trong TextBox hàng hóa (ucHangHoa).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbHH_Change(object sender, TextBoxEventArgs e)
        {
            ucHangHoaPopup.Tb.Text = e.Text;
            if (ucHangHoaPopup.Visible)
            {
                ucHangHoaPopup.Visible = false;
                ucHangHoaPopup.TsDropDown.Close();
            }
            ucHangHoaPopup.TsDropDown.Close();
        }

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
            //if (!string.IsNullOrEmpty(ucHangHoa.Tb.Text))
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
                    item.Gg_ty_le = 0;

                // Tính toán lại dòng và tổng
                TinhToanRow(item);
                TinhTongCong();
            }
        }
        #endregion
    }
}