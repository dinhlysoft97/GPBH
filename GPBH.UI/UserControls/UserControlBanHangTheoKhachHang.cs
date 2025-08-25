using GPBH.Business;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlBanHangTheoKhachHang : UserControl
    {
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
            dataGridViewX1.AutoGenerateColumns = false;
            LoadDataCbb();
            buttonLoc_Click(null, null);
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
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
            var frm = ActivatorUtilities.CreateInstance<ReportBanHang>(Program.ServiceProvider, data, tuNgay, denNgay, maNgoaiTe);
            frm.ShowDialog();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            string menuName = "BanHangTheoKhachHang";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            // Lấy điều kiện lọc từ các control
            //string maKhachHang = ccbKhachHang.SelectedValue?.ToString() ?? string.Empty;
            //string maHangHoa = ccbMaHang.SelectedValue?.ToString() ?? string.Empty;
            //string maNgoaiTe = ccbMaNgoaiTe.SelectedValue?.ToString() ?? string.Empty;
            //string passport = ccbPassport.SelectedValue?.ToString() ?? string.Empty;
            //DateTime tuNgay = dtpTuNgay.Value;
            //DateTime denNgay = dtpDenNgay.Value;
            //string noiBan = AppGlobals.MaCH;

            //var data = _reportBanHangService.GetViewBaoCaoBanTheoKhachHang(passport, maHangHoa, maNgoaiTe, maKhachHang, tuNgay, denNgay, noiBan);
            //var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "BanHangTheoKhachHang").data.Where(z => !z.Field_hide).OrderBy(z => z.Field_order).ToList();

            //ExportHelper.ExportToExcel(data, fields);

            ExportHelper.ExportGridToExcel(dataGridViewX1, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
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

        private void SetUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "BanHangTheoKhachHang").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
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

            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "BanHangTheoKhachHang").data.ToList();
            var dataSort = data.ApplySortSystemDinhDang(fields);
            return _reportBanHangService.ToDataTable(dataSort);
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }
    }
}
