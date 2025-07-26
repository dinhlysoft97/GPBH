using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlBanHangTheoKhachHang : UserControl
    {
        private List<GirdSysDinhDangFormDto> SysDinhDangs = new List<GirdSysDinhDangFormDto>();
        private readonly DMKHService _dmkhService;
        private readonly DMHHService _dmhhService;
        private readonly DMNTService _dmntService;
        private readonly ReportBanHangService _reportBanHangService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;

        public UserControlBanHangTheoKhachHang
            (
                SysDinh_dang_formService sysDinh_Dang_FormService,
                DMKHService dmkhService, DMHHService dmhhService,
                DMNTService dmntService,
                ReportBanHangService reportBanHangService
            )
        {
            InitializeComponent();

            _dmkhService = dmkhService;
            _dmhhService = dmhhService;
            _dmntService = dmntService;
            _reportBanHangService = reportBanHangService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            SysDinhDangs = sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            dataGridViewX1.AutoGenerateColumns = false;
            LoadDataCbb();
            SetUpUI();
            dataGridViewX1.DataBindingComplete += DataGridViewX1_DataBindingComplete;
            foreach (DataGridViewColumn column in dataGridViewX1.Columns)
            {
                column.Resizable = DataGridViewTriState.True;
            }
        }

        private void LoadDataCbb()
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
            var useIndex = ngoaiTeList.FindIndex(x => x.Ma_nt == "USD");
            ccbMaNgoaiTe.SelectedIndex = useIndex >= 0 ? useIndex : -1;
        }

        private void BtnIn_Click(object sender, System.EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("BanHangTheoKhachHang", GPBHConstant.Action.In);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            string maNgoaiTe = ccbMaNgoaiTe.SelectedValue?.ToString() ?? string.Empty;
            var data = GetData();
            var frm = new ReportBanHang(data, tuNgay, denNgay, maNgoaiTe, SysDinhDangs);
            frm.ShowDialog();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("BanHangTheoKhachHang", GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            //var data = new List<MyData>
            //{
            //    new MyData { Ten = "Bút bi", SoLuong = 100, Gia = 3500, NgayTao = new DateTime(2025, 6, 1) },
            //    new MyData { Ten = "Sách toán", SoLuong = 50, Gia = 22000, NgayTao = new DateTime(2025, 6, 2) },
            //    new MyData { Ten = "Vở kẻ ngang", SoLuong = 200, Gia = 8000, NgayTao = new DateTime(2025, 6, 3) },
            //    new MyData { Ten = "Thước kẻ", SoLuong = 75, Gia = 6000, NgayTao = new DateTime(2025, 6, 4) }
            //};

            // Lấy điều kiện lọc từ các control
            string maKhachHang = ccbKhachHang.SelectedValue?.ToString() ?? string.Empty;
            string maHangHoa = ccbMaHang.SelectedValue?.ToString() ?? string.Empty;
            string maNgoaiTe = ccbMaNgoaiTe.SelectedValue?.ToString() ?? string.Empty;
            string passport = ccbPassport.SelectedValue?.ToString() ?? string.Empty;
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            string noiBan = AppGlobals.MaCH;

            var data = _reportBanHangService.GetViewBaoCaoBanTheoKhachHang(passport, maHangHoa, maNgoaiTe, maKhachHang, tuNgay, denNgay, noiBan);
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "BanHangTheoKhachHang").data.Where(z => !z.Field_hide).ToList();
            //var fields = new[]
            //{
            //    new { Property = "Ten", Header = "Tên", Width = 20d, Format = "" },
            //    new { Property = "SoLuong", Header = "Số lượng", Width = 12d, Format = "#,##0" },
            //    new { Property = "Gia", Header = "Giá", Width = 15d, Format = "#,##0.00" },
            //    new { Property = "NgayTao", Header = "Ngày tạo", Width = 18d, Format = "dd/MM/yyyy" }
            //};

            ExportHelper.ExportToExcel(data, fields);
        }

        private void DataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                var row = dataGridViewX1.Rows[i];
                if (row.IsNewRow) continue;

                row.Cells["Stt"].Value = i + 1;
                row.Cells["Stt"].ReadOnly = true;
            }
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

        private string GetFormat(string column)
        {
            if (SysDinhDangs == null)
                return string.Empty;
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
        }

        private void SetUpUI()
        {
            var colStt = dataGridViewX1.Columns["Stt"];
            colStt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStt.Visible = false;

            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("So_don_hang", 1);
            dataGridViewX1.SetDisplayIndex("Ngay_ban", 2);
            dataGridViewX1.SetDisplayIndex("Passport", 3);
            dataGridViewX1.SetDisplayIndex("Ten_khachhang", 4);
            dataGridViewX1.SetDisplayIndex("Tong_nhan", 5);
            dataGridViewX1.SetDisplayIndex("Tra_lai_nt", 6);
            dataGridViewX1.SetDisplayIndex("Thanh_tien", 7);
            dataGridViewX1.SetDisplayIndex("Thanh_tien_vn", 8);

            dataGridViewX1.SetCellAlignment("So_luong", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Thanh_tien", DataGridViewContentAlignment.MiddleRight);
            dataGridViewX1.SetCellAlignment("Thanh_tien_vn", DataGridViewContentAlignment.MiddleRight);

            // Format các cột tiền
            dataGridViewX1.SetFormat("Ty_gia", GetFormat("Format_gia"));
            dataGridViewX1.SetFormat("Tra_lai_nt", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Tong_nhan", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Thanh_tien", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Tong_tien_hang_nt", GetFormat("Format_tien_nt"));
            dataGridViewX1.SetFormat("Thanh_tien_vn", GetFormat("Format_tien"));
            dataGridViewX1.SetFormat("So_luong", GetFormat("Format_so_luong"));

            dtpTuNgay.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

            dtpDenNgay.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            var colNgayBan = dataGridViewX1.Columns["Ngay_ban"];
            colNgayBan.DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void buttonLoc_Click(object sender, EventArgs e)
        {
            var data = GetData();
            dataGridViewX1.DataSource = data;
        }

        public DataTable GetData()
        {
            // Lấy điều kiện lọc từ các control
            string maKhachHang = ccbKhachHang.SelectedValue?.ToString() ?? string.Empty;
            string maHangHoa = ccbMaHang.SelectedValue?.ToString() ?? string.Empty;
            string maNgoaiTe = ccbMaNgoaiTe.SelectedValue?.ToString() ?? string.Empty;
            string passport = ccbPassport.SelectedValue?.ToString() ?? string.Empty;
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            string noiBan = AppGlobals.MaCH;

            var data = _reportBanHangService.GetViewBaoCaoBanTheoKhachHang(passport, maHangHoa, maNgoaiTe, maKhachHang, tuNgay, denNgay, noiBan);
            return _reportBanHangService.ToDataTable(data);
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }
    }
}
