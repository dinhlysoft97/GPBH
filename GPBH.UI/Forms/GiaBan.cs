using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class GiaBan : Office2007Form
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public GiaBan(SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
            LoadData();
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString()));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(cbbCuaHang.SelectedValue.ToString()));
        }
    }
}
