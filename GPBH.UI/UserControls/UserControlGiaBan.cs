using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
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
            dataGridViewX1.AutoGenerateColumns = false;
            SysDinhDangs = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH).data;
            LoadData();
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;

            dataGridViewX1.SetFormat("Gia_ban", GetFormat("Format_gia_nt"));
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString()));
            if (dataGridViewX1.Columns.Contains("Ngay_ap_dung"))
            {
                var colNgayApDung = dataGridViewX1.Columns["Ngay_ap_dung"];
                colNgayApDung.DefaultCellStyle.Format = DateFormat;
            }
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbbCuaHang.SelectedItem as CuaHangDto;
            if (selected == null) return;
            dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(selected.Ma_cua_hang));

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
    }
}
