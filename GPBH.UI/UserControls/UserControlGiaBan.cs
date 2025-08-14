using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlGiaBan : UserControl
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;
        private SysDinh_dang_formService _sysDinh_Dang_FormService;
        private List<GirdSysDinhDangFormDto> SysDinhDangs;
        private string DateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

        public UserControlGiaBan
            (
                SysDMCuaHangService sysDMCuaHangService,
                SysDinh_dang_formService sysDinh_Dang_FormService
            )
        {
            InitializeComponent();
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            _sysDMCuaHangService = sysDMCuaHangService;
            SysDinhDangs = sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            LoadData();
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            //dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString()));
            var data = _sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString());
            var dataGrid = data.Select(z => new GirdGiaBanDto()
            {
                Ma_cua_hang = z.Ma_cua_hang,
                Ngay_ap_dung = z.Ngay_ap_dung,
                Ma_hh = z.Ma_hh,
                Gia_ban = z.Gia_ban
            }).ToList();

            DataGridViewFilterHelper.ApplyFilter(dataGridViewX1, dataGrid);
            if (dataGridViewX1.Columns.Contains("Ngay_ap_dung"))
            {
                var colNgayApDung = dataGridViewX1.Columns["Ngay_ap_dung"];
                colNgayApDung.DefaultCellStyle.Format = DateFormat;
            }
            dataGridViewX1.SetFormat("Gia_ban", GetFormat("Format_gia_nt"));
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbbCuaHang.SelectedItem as CuaHangDto;
            if (selected == null) return;
            // dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(selected.Ma_cua_hang));
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

        private string GetFormat(string column)
        {
            var dinhDang = SysDinhDangs.FirstOrDefault(z => z.Field_name == column);
            if (dinhDang != null)
                return dinhDang.Field_format;
            return string.Empty;
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

            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, menuName).data.Where(z => !z.Field_hide).OrderBy(z => z.Field_order).ToList();
            var data = dataGridViewX1.DataSource as BindingList<GirdGiaBanDto>;
            ExportHelper.ExportToExcel(data, fields, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}
