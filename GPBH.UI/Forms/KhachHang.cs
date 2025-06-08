using DevComponents.DotNetBar;
using GPBH.Business.Services;
using GPBH.Data.Entities;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
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
        private readonly List<GioiTinh> GioiTinhs = new List<GioiTinh>
        {
            new GioiTinh() { Key ="M" ,Value = "Nam" },
            new GioiTinh() { Key = "F", Value = "Nữ" },
            new GioiTinh() { Key = "O", Value = "Khác" },
        };

        #endregion

        #region Public Properties

        public DMKH DataKhachHang { get; set; }

        #endregion

        #region Nested Classes

        public class GioiTinh
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        #endregion

        #region Constructor

        public KhachHang(DMKHService dmkhService, DMQGService dMQGService)
        {
            InitializeComponent();
            _dmkhService = dmkhService;
            _dMQGService = dMQGService;
            LoadData();
            RegisterEvents();
        }

        #endregion

        #region Private Methods

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbGioiTinh, GioiTinhs, "Value", "Key", true);
            var dataQD = _dMQGService.GetAll();
            ComboBoxHelper.BindData(cbbQuocTich, dataQD, nameof(DMQG.Ten_Quoc_gia), nameof(DMQG.Quoc_gia), true);
        }

        private void RegisterEvents()
        {
            txtTongTien.KeyPress += txtSoTien_KeyPress;
            txtTongTien.Leave += txtSoTien_Leave;
            txtEmail.Leave += txtEmail_Leave;
        }

        private void FillCustomerData(DMKH khachHang)
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

        private void ClearCustomerFields()
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtTenDem.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            dtNgayCap.Value = DateTime.Now;
            dtHetHan.Value = DateTime.Now;
            dtNgaySinh.Value = DateTime.Now;
            txtEmail.Text = "";
            dtTTXNCNgayCap.Value = DateTime.Now;
            dtTTXNCHetHan.Value = DateTime.Now;
            txPhuongTien.Text = "";
            txtTauBay.Text = "";
            txtTongTien.Text = "0";
        }

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

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            // Regex email cơ bản
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private DMKH GetCustomerFromForm()
        {
            return new DMKH
            {
                Passport = txtCCCD.Text.Trim(),
                Ho = txtHo.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                Ten_dem = txtTenDem.Text.Trim(),
                Ngay_cap = dtNgayCap.Value,
                Ngay_hh = dtHetHan.Value,
                Ngay_sinh = dtNgaySinh.Value,
                Quoc_gia = cbbQuocTich.SelectedValue?.ToString(),
                Gioi_tinh = cbbGioiTinh.SelectedValue?.ToString(),
                Dia_chi = txtDiaChi.Text.Trim(),
                Dien_thoai = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Xnc_ngay_cap = dtTTXNCNgayCap.Value,
                Xnc_ngay_hh = dtTTXNCHetHan.Value,
                Han_muc = decimal.TryParse(txtTongTien.Text, out var hanMuc) ? hanMuc : (decimal?)null,
                So_hieu = txPhuongTien.Text.Trim(),
                Ten_tau_bay = txtTauBay.Text.Trim()
            };
        }

        private void ShowMessage(string msg, Control focusControl = null)
        {
            lbMessage.Text = msg;
            lbMessage.BackColor = System.Drawing.Color.Red;
            if (focusControl != null) focusControl.Focus();
        }

        private void ClearMessage()
        {
            lbMessage.Text = "";
            lbMessage.BackColor = System.Drawing.Color.Transparent;
        }

        #endregion

        #region Event Handlers

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            var khachHang = _dmkhService.GetCustomerByPassport(txtCCCD.Text.Trim());
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

        private void btnChon_Click(object sender, EventArgs e)
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

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtTongTien.Text.Replace(",", "").Replace(".", ""), out value))
            {
                txtTongTien.Text = value.ToString("#,##0");
            }
        }

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