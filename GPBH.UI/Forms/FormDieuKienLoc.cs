using GPBH.Business;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class FormDieuKienLoc : Form
    {
        private readonly DMKHService _dmkhService;
        private readonly DMHHService _dmhhService;
        private readonly DMNTService _dmntService;
        public FormDieuKienLoc(DMKHService dmkhService, DMHHService dmhhService, DMNTService dmntService)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _dmkhService = dmkhService;
            _dmhhService = dmhhService;
            _dmntService = dmntService;
            this.Load += FormDieuKienLoc_Load;
        }

        private void buttonLoc_Click(object sender, EventArgs e)
        {
            // Lấy điều kiện lọc từ các control
            string maKhachHang = ccbKhachHang.Text;
            string maHangHoa = ccbMaHang.Text;
            string maNgoaiTe = ccbMaNgoaiTe.Text;
            string passport = ccbPassport.Text;
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            string noiBan = AppGlobals.MaCH;

            var dt = ReportBanHangService.GetBaoCaoBanTheoKhachHang(passport, maHangHoa, maNgoaiTe, maKhachHang, tuNgay, denNgay, noiBan);

            var uc = new UserControlKetQuaLoc(dt, tuNgay, denNgay, maNgoaiTe);
            var frm = new Form
            {
                Text = "Kết quả lọc",
                Width = 5000,
                Height = 1500
            };
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(uc);
            frm.ShowDialog();
        }

        private void FormDieuKienLoc_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            // Load khách hàng
            ccbKhachHang.DataSource = _dmkhService.GetAll();
            ccbKhachHang.DisplayMember = "Tên khách hang";
            ccbKhachHang.ValueMember = "Ho_ten";
            ccbKhachHang.SelectedIndex = -1;

            // Load hộ chiếu
            ccbPassport.DataSource = _dmkhService.GetAll();
            ccbPassport.DisplayMember = "Số hộ chiếu";
            ccbPassport.ValueMember = "Passport";
            ccbPassport.SelectedIndex = -1;

            ccbMaHang.DataSource = _dmhhService.GetAll();
            ccbMaHang.DisplayMember = "Mã hàng";
            ccbMaHang.ValueMember = "Ma_hh";
            ccbMaHang.SelectedIndex = -1;

            var ngoaiTeList = _dmntService.GetAll();
            ccbMaNgoaiTe.DataSource = _dmntService.GetAll();
            ccbMaNgoaiTe.DisplayMember = "Mã hàng";
            ccbMaNgoaiTe.ValueMember = "Ma_nt";
            ccbMaNgoaiTe.SelectedIndex = -1;

        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            ccbKhachHang.SelectedIndex = -1;
            ccbPassport.SelectedIndex = -1;
            ccbMaHang.SelectedIndex = -1;
            ccbMaNgoaiTe.SelectedIndex = -1;

            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            dtpTuNgay.Focus();
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.ColseForm();
        }
    }
}
