using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class KhachHang : Office2007Form
    {
        #region Private Fields

        private readonly DMKHService _dmkhService;
        private readonly DMQGService _dMQGService;
        private bool isKhachHangSelected = false;
        private readonly bool _isSelectMode;
        private readonly bool _isEditMode;
        private readonly List<GioiTinh> GioiTinhs = new List<GioiTinh>
        {
            new GioiTinh() { Key ="M" ,Value = "Nam" },
            new GioiTinh() { Key = "F", Value = "Nữ" },
            new GioiTinh() { Key = "O", Value = "Khác" },
        };

        #endregion

        #region Public Properties

        /// <summary>
        /// Dữ liệu khách hàng được chọn hoặc vừa thêm.
        /// </summary>
        public DMKH DataKhachHang { get; set; }

        #endregion

        #region Nested Classes

        /// <summary>
        /// Lớp phụ trợ cho giới tính.
        /// </summary>
        public class GioiTinh
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        #endregion

        #region Constructor

        public KhachHang(DMKHService dmkhService, DMQGService dMQGService, string passport, bool isSelectMode = false)
        {
            InitializeComponent();
            this.KeyPreview = true; // Cho phép bắt phím Enter trên toàn form
            _dmkhService = dmkhService;
            _dMQGService = dMQGService;
            _isSelectMode = isSelectMode;
            if (!string.IsNullOrEmpty(passport))
            {
                var khachHang = _dmkhService.GetByPassport(passport);
                if (khachHang != null)
                {
                    _isEditMode = true;
                    DataKhachHang = khachHang;
                    FillCustomerData(khachHang);
                }
                else
                {
                    _isEditMode = false;
                }
                txtCCCD.Text = passport;
            }
            else
            {
                _isEditMode = false;
            }

            LoadData();
            RegisterEvents();

            if (!string.IsNullOrEmpty(passport))
                txtCCCD.Text = passport;

            if (_isSelectMode)
                btnChon.Text = "Lưu(Enter)";
            else
                btnChon.Text = "Chọn(Enter)";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load dữ liệu cho các combobox giới tính, quốc tịch.
        /// </summary>
        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbGioiTinh, GioiTinhs, "Value", "Key", true);
            var dataQD = _dMQGService.GetAll();
            ComboBoxHelper.BindData(cbbQuocTich, dataQD, nameof(DMQG.Ten_Quoc_gia), nameof(DMQG.Quoc_gia), true);
        }

        /// <summary>
        /// Đăng ký các sự kiện cho các control.
        /// </summary>
        private void RegisterEvents()
        {
            txtTongTien.KeyPress += txtSoTien_KeyPress;
            txtTongTien.Leave += txtSoTien_Leave;
            txtEmail.Leave += txtEmail_Leave;
            this.KeyDown += Form_KeyDown;
            txtCCCD.TextChanged += txtCCCD_TextChanged;
            btnChon.Click += btnChon_Click;
        }

        /// <summary>
        /// Điền dữ liệu khách hàng đã có lên form.
        /// </summary>
        public void FillCustomerData(DMKH khachHang)
        {
            txtCCCD.Text = khachHang.Passport?.Trim() ?? "";
            txtHo.Text = khachHang.Ho ?? "";
            txtTen.Text = khachHang.Ten ?? "";
            txtTenDem.Text = khachHang.Ten_dem ?? "";
            txtDiaChi.Text = khachHang.Dia_chi ?? "";
            txtSDT.Text = khachHang.Dien_thoai ?? "";
            dtNgayCap.Value = khachHang.Ngay_cap ?? DateTime.Now;
            dtHetHan.Value = khachHang.Ngay_hh ?? DateTime.Now;
            dtNgaySinh.Value = khachHang.Ngay_sinh ?? DateTime.Now;
            txtEmail.Text = khachHang.Email ?? "";
            dtTTXNCNgayCap.Value = khachHang.Xnc_ngay_cap ?? DateTime.Now;
            dtTTXNCHetHan.Value = khachHang.Xnc_ngay_hh ?? DateTime.Now;
            txPhuongTien.Text = khachHang.So_hieu ?? "";
            txtTauBay.Text = khachHang.Ten_tau_bay ?? "";
            txtTongTien.Text = khachHang.Han_muc?.ToString("#,##0") ?? "0";
            cbbGioiTinh.SelectedValue = khachHang.Gioi_tinh;
            cbbQuocTich.SelectedValue = khachHang.Quoc_gia;
        }

        /// <summary>
        /// Xóa toàn bộ dữ liệu trên form khách hàng.
        /// </summary>
        private void ClearCustomerFields()
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtTenDem.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            dtNgayCap.IsEmpty = true;
            dtHetHan.IsEmpty = true;
            dtNgaySinh.IsEmpty = true;
            txtEmail.Text = "";
            dtTTXNCNgayCap.IsEmpty = true;
            dtTTXNCHetHan.IsEmpty = true;
            txPhuongTien.Text = "";
            txtTauBay.Text = "";
            txtTongTien.Text = "0";
        }

        /// <summary>
        /// Kiểm tra các trường bắt buộc đã nhập đủ hay chưa.
        /// </summary>
        private bool ValidateRequiredFields()
        {
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                ShowMessage("Vui lòng nhập số CCCD.", txtCCCD);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHo.Text))
            {
                ShowMessage("Vui lòng nhập Họ.", txtHo);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                ShowMessage("Vui lòng nhập Tên.", txtTen);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                ShowMessage("Vui lòng nhập SĐT.", txtSDT);
                return false;
            }
            ClearMessage();
            return true;
        }

        /// <summary>
        /// Kiểm tra định dạng email cơ bản.
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Lấy dữ liệu khách hàng từ form.
        /// </summary>
        public DMKH GetCustomerFromForm()
        {
            return new DMKH
            {
                Passport = txtCCCD.Text.Trim(),
                Ho = txtHo.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                Ten_dem = txtTenDem.Text.Trim(),
                Ngay_cap = dtNgayCap.IsEmpty ? (DateTime?)null : dtNgayCap.Value,
                Ngay_hh = dtHetHan.IsEmpty ? (DateTime?)null : dtHetHan.Value,
                Ngay_sinh = dtNgaySinh.IsEmpty ? (DateTime?)null : dtNgaySinh.Value,
                Quoc_gia = cbbQuocTich.SelectedValue?.ToString(),
                Gioi_tinh = cbbGioiTinh.SelectedValue?.ToString(),
                Dia_chi = txtDiaChi.Text.Trim(),
                Dien_thoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Xnc_ngay_cap = dtTTXNCNgayCap.IsEmpty ? (DateTime?)null : dtTTXNCNgayCap.Value,
                Xnc_ngay_hh = dtTTXNCHetHan.IsEmpty ? (DateTime?)null : dtTTXNCHetHan.Value,
                Han_muc = decimal.TryParse(txtTongTien.Text.Replace(",", "").Replace(".", ""), out var hanMuc) ? hanMuc : (decimal?)null,
                So_hieu = txPhuongTien.Text.Trim(),
                Ten_tau_bay = txtTauBay.Text.Trim()
            };
        }

        /// <summary>
        /// Hiện thông báo lỗi ra label và focus vào control nếu có.
        /// </summary>
        private void ShowMessage(string msg, Control focusControl = null)
        {
            lbMessage.Text = msg;
            lbMessage.BackColor = System.Drawing.Color.Red;
            if (focusControl != null) focusControl.Focus();
        }

        /// <summary>
        /// Xóa thông báo lỗi trên form.
        /// </summary>
        private void ClearMessage()
        {
            lbMessage.Text = "";
            lbMessage.BackColor = System.Drawing.Color.Transparent;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Bắt phím Enter trên form để lưu và in nhanh.
        /// </summary>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleClick();
            }
        }

        /// <summary>
        /// Khi thay đổi số CCCD, tự động tìm và fill dữ liệu khách hàng nếu có.
        /// </summary>
        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            var khachHang = _dmkhService.GetByPassport(txtCCCD.Text.Trim());
            if (khachHang != null)
            {
                DataKhachHang = khachHang;
                FillCustomerData(khachHang);
                isKhachHangSelected = true;
                ClearMessage();
            }
            else
            {
                ClearCustomerFields();
                isKhachHangSelected = false;
            }
        }

        /// <summary>
        /// Sự kiện click nút "Chọn" hoặc phím Enter: chọn khách đã có hoặc thêm mới khách hàng.
        /// </summary>
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (_isSelectMode)
            {
                // Thực hiện lưu (thêm mới hoặc cập nhật)
                if (!ValidateRequiredFields())
                    return;

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                {
                    ShowMessage("Email không đúng định dạng!", txtEmail);
                    return;
                }

                var khDto = GetCustomerFromForm();
                if (_isEditMode) 
                    _dmkhService.EditCustomer(khDto);
                else
                    _dmkhService.AddCustomer(khDto);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Xử lý chọn/thêm khách hàng khi click nút hoặc nhấn enter.
        /// </summary>
        private void HandleClick()
        {
            if (isKhachHangSelected)
            {
                this.Close();
            }
            else
            {
                if (!ValidateRequiredFields())
                    return;

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                {
                    ShowMessage("Email không đúng định dạng!", txtEmail);
                    return;
                }

                var khDto = GetCustomerFromForm();
                DataKhachHang = _dmkhService.AddCustomer(khDto);
                this.Close();
            }
        }

        /// <summary>
        /// Chỉ cho nhập số tiền, dấu phân cách.
        /// </summary>
        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txt.Text.Contains(",") || txt.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Định dạng lại số tiền khi rời khỏi textbox.
        /// </summary>
        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtTongTien.Text.Replace(",", "").Replace(".", ""), out value))
            {
                txtTongTien.Text = value.ToString("#,##0");
            }
        }

        /// <summary>
        /// Kiểm tra email hợp lệ khi rời khỏi textbox.
        /// </summary>
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                ShowMessage("Email không đúng định dạng!", txtEmail);
            }
            else
            {
                ClearMessage();
            }
        }

        #endregion
    }
}