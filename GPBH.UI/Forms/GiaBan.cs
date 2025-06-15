using DevComponents.DotNetBar;
using GPBH.Business.Dtos;
using GPBH.Business;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using GPBH.UI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPBH.Data.Entities;

namespace GPBH.UI.Forms
{
    public partial class GiaBan : Form
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public GiaBan(SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
            LoadData();
        }

        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;

            CbbCuaHang_SelectedIndexChanged(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GiaBan_Load(object sender, EventArgs e)
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;

            CbbCuaHang_SelectedIndexChanged(null, null);
        }

        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbbCuaHang.SelectedItem as SysDMCuaHang;
            if (selected == null) return;
            dataGridViewX1.BindData(_sysDMCuaHangService.GetGiaBanByCuaHang(selected.Ma_cua_hang));
        }
    }
}
