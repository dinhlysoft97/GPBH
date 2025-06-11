using GPBH.Business.Services;
using GPBH.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPBH.UI
{
    public partial class FormAddDMKH : Form
    {
        private readonly DMQGService _dsQuocGia;
        private DMKH _currentCustomer;
        public FormAddDMKH(IServiceProvider serviceProvider, DMKH customer = null)
        {
            InitializeComponent();
            _dsQuocGia = new DMQGService(Program.ServiceProvider);
            LoadGioiTinh();
            LoadQuocTich();


            if (customer != null)
            {
                _currentCustomer = customer;
                HienThiThongTinKhachHang();
            }
        }

        private void LoadQuocTich()
        {
            var dsQuocGia = _dsQuocGia.GetAll();
            textBoxDropDownQuocTich.DropDownItems.Clear();

            foreach (var qg in dsQuocGia)
            {
                var item = new DevComponents.DotNetBar.ButtonItem()
                {
                    Text = qg.Quoc_gia,
                    Tag = qg
                };
                item.Click += (s, e) =>
                {
                    textBoxDropDownQuocTich.Text = item.Text;
                };
                textBoxDropDownQuocTich.DropDownItems.Add(item);
            }
        }
        private void LoadGioiTinh()
        {
            textBoxDropDownGioiTinh.DropDownItems.Clear();

            var itemNam = new DevComponents.DotNetBar.ButtonItem() { Text = "Nam", Tag = "M" };
            itemNam.Click += (s, e) => { textBoxDropDownGioiTinh.Text = itemNam.Text; textBoxDropDownGioiTinh.Tag = itemNam.Tag; };
            textBoxDropDownGioiTinh.DropDownItems.Add(itemNam);

            var itemNu = new DevComponents.DotNetBar.ButtonItem() { Text = "Nữ", Tag = "F" };
            itemNu.Click += (s, e) => { textBoxDropDownGioiTinh.Text = itemNu.Text; textBoxDropDownGioiTinh.Tag = itemNu.Tag; };
            textBoxDropDownGioiTinh.DropDownItems.Add(itemNu);

            var itemKhac = new DevComponents.DotNetBar.ButtonItem() { Text = "Khác", Tag = "O" };
            itemKhac.Click += (s, e) => { textBoxDropDownGioiTinh.Text = itemKhac.Text; textBoxDropDownGioiTinh.Tag = itemKhac.Tag; };
            textBoxDropDownGioiTinh.DropDownItems.Add(itemKhac);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new DMKH
                {
                    Passport = textPassport.Text.Trim(),
                    Ho = textHo.Text.Trim(),
                    Ten_dem = textTenDem.Text.Trim(),
                    Ten = textTen.Text.Trim(),
                    Ngay_sinh = dtpNgaySinh.Value,
                    Ngay_cap = dtpNgayCap.Value,
                    Ngay_hh = dtpHetHan.Value,
                    Quoc_gia = textBoxDropDownQuocTich.Text,
                    Gioi_tinh = textBoxDropDownGioiTinh.Tag?.ToString() ?? "",
                    Dien_thoai = textSDT.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Ngay_sua = DateTime.Now,
                    Dia_chi = textDiaChi.Text.Trim(),
                    Xnc_ngay_cap = dateTimePickerNgayXNC.Value,
                    Xnc_ngay_hh = dateTimePickerHetHanXNC.Value,
                    So_hieu = textSoHieu.Text.Trim(),
                    Ten_tau_bay = textTenTauBay.Text.Trim(),
                    Han_muc = string.IsNullOrWhiteSpace(textHanMuc.Text) ? (decimal?)null : decimal.Parse(textHanMuc.Text)
                };

                var service = new DMKHService(Program.ServiceProvider);

                if (_currentCustomer == null)
                {
                    service.AddCustomer(customer);
                    MessageBox.Show("Khách hàng được thêm thành công!");
                }
                else
                {
                    customer.Nguoi_sua = "Tên người sửa";
                    service.EditCustomer(customer);
                    MessageBox.Show("Khách hàng được cập nhật thành công!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiThongTinKhachHang()
        {
            if (_currentCustomer == null) return;
            textPassport.Text = _currentCustomer.Passport;
            textHo.Text = _currentCustomer.Ho;
            textTenDem.Text = _currentCustomer.Ten_dem;
            textTen.Text = _currentCustomer.Ten;
            dtpNgaySinh.Value = _currentCustomer.Ngay_sinh ?? DateTime.Now;
            dtpNgayCap.Value = _currentCustomer.Ngay_cap ?? DateTime.Now;
            dtpHetHan.Value = _currentCustomer.Ngay_hh ?? DateTime.Now;
            textBoxDropDownQuocTich.Text = _currentCustomer.Quoc_gia;
            if (_currentCustomer.Gioi_tinh == "M")
                textBoxDropDownGioiTinh.Text = "Nam";
            else if (_currentCustomer.Gioi_tinh == "F")
                textBoxDropDownGioiTinh.Text = "Nữ";
            else if (_currentCustomer.Gioi_tinh == "O")
                textBoxDropDownGioiTinh.Text = "Khác";
            else
                textBoxDropDownGioiTinh.Text = string.Empty;
            textSDT.Text = _currentCustomer.Dien_thoai;
            textEmail.Text = _currentCustomer.Email;
            textDiaChi.Text = _currentCustomer.Dia_chi;
            dateTimePickerNgayXNC.Value = _currentCustomer.Xnc_ngay_cap ?? DateTime.Now;
            dateTimePickerHetHanXNC.Value = _currentCustomer.Xnc_ngay_hh ?? DateTime.Now;
            textSoHieu.Text = _currentCustomer.So_hieu;
            textTenTauBay.Text = _currentCustomer.Ten_tau_bay;
            textHanMuc.Text = _currentCustomer.Han_muc.HasValue ? _currentCustomer.Han_muc.Value.ToString("N0") : string.Empty;


        }
    }
}
