using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlGiaBan : UserControl
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public UserControlGiaBan(SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
            dataGridViewX1.AutoGenerateColumns = false;
            LoadData();
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString()));
            if (dataGridViewX1.Columns.Contains("Ngay_ap_dung"))
            {
                var colNgayApDung = dataGridViewX1.Columns["Ngay_ap_dung"];
                colNgayApDung.DefaultCellStyle.Format = "dd/MM/yy";
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
    }
}
