using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlGiaBan : UserControl
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;

        public UserControlGiaBan
            (
                SysDMCuaHangService sysDMCuaHangService,
                SysDinh_dang_formService sysDinh_Dang_FormService
            )
        {
            InitializeComponent();
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            _sysDMCuaHangService = sysDMCuaHangService;
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            LoadData();
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
            dataGridViewX1.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
        }

        private void SetUpUI()
        {
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "GiaBan").data.ToList();
            dataGridViewX1.ApplyColumnConfig(fields);
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            var data = _sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString());
            var dataGrid = data.Select(z => new GirdGiaBanDto()
            {
                Ma_cua_hang = z.Ma_cua_hang,
                Ngay_ap_dung = z.Ngay_ap_dung,
                Ma_hh = z.Ma_hh,
                Gia_ban = z.Gia_ban
            }).ToList();

            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, dataGrid);
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbbCuaHang.SelectedItem as CuaHangDto;
            if (selected == null) return;
            var data = _sysDMCuaHangService.GetGiaBanByCuaHang(selected.Ma_cua_hang);
            var dataGrid = data.Select(z => new GirdGiaBanDto()
            {
                Ma_cua_hang = z.Ma_cua_hang,
                Ngay_ap_dung = z.Ngay_ap_dung,
                Ma_hh = z.Ma_hh,
                Gia_ban = z.Gia_ban
            }).ToList();
            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, dataGrid);
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string menuName = "GiaBan";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            ExportHelper.ExportGridToExcel(dataGridViewX1, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"), isIgnoreRowFirst: true);
        }
    }
}
