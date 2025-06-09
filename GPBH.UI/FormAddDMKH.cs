using GPBH.Business.DTO;
using GPBH.Business.Services;
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
        public DMKHDto NewKH { get; private set; }
        private readonly DMQGService _dsQuocGia;
        public FormAddDMKH(DMQGService dsQuocGia)
        {
            InitializeComponent();
            _dsQuocGia = dsQuocGia;
            LoadQuocTich();
            LoadGioiTinh();
        }

        // Constructor cho sửa
        public FormAddDMKH(DMQGService dsQuocGia, DMKHDto dto) : this(dsQuocGia)
        {
            if (dto != null)
            {
                textPassport.Text = dto.Passport;
                textHo.Text = dto.Ho;
                textTenDem.Text = dto.Ten_dem;
                textTen.Text = dto.Ten;
                dtpNgaySinh.Value = dto.Ngay_sinh ?? DateTime.Now;
                dtpNgayCap.Value = dto.Ngay_cap ?? DateTime.Now;
                dtpHetHan.Value = dto.Ngay_hh ?? DateTime.Now;
                textBoxDropDownQuocTich.Text = dto.Quoc_gia;
                textSDT.Text = dto.Dien_thoai;
                // Gán giới tính nếu có
                if (!string.IsNullOrEmpty(dto.Gioi_tinh))
                {
                    switch (dto.Gioi_tinh)
                    {
                        case "M":
                            textBoxDropDownGioiTinh.Text = "Nam";
                            textBoxDropDownGioiTinh.Tag = "M";
                            break;
                        case "F":
                            textBoxDropDownGioiTinh.Text = "Nữ";
                            textBoxDropDownGioiTinh.Tag = "F";
                            break;
                        default:
                            textBoxDropDownGioiTinh.Text = "Khác";
                            textBoxDropDownGioiTinh.Tag = "O";
                            break;
                    }
                }
                textEmail.Text = dto.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewKH = new DMKHDto
            {
                Passport = textPassport.Text.Trim(),
                Ten = textTen.Text.Trim(),
                Ho = textHo.Text.Trim(),
                Ten_dem = textTenDem.Text.Trim(),
                Ngay_sinh = dtpNgaySinh.Value,
                Ngay_cap = dtpNgayCap.Value,
                Ngay_hh = dtpHetHan.Value,
                Quoc_gia = textBoxDropDownQuocTich.Text,
                Gioi_tinh = textBoxDropDownGioiTinh.Tag?.ToString() ?? "",
                Dien_thoai = textSDT.Text.Trim(),

            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadQuocTich()
        {
            var dsQuocGia = _dsQuocGia.GetAllQuocGia();
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

    }
}
