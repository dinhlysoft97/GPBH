using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPBH.UI.Forms
{
    public partial class ThamSo2 : Office2007Form
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public ThamSo2(SysDMCuaHangService sysDMCuaHangService, GirdSystemSettingDto data)
        {
            _sysDMCuaHangService = sysDMCuaHangService;
            InitializeComponent();
            if (data != null)
            {
                txtKey.Enabled = false;
                txtKey.Text = data.Key;
                txtTen.Text = data.Ten;
                txtGiaTri.Text = data.GiaTri;
                txtMoTa.Text = data.Mota;
            }
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            _sysDMCuaHangService.LuuThamSo(
              new GirdSystemSettingDto
              {
                  Key = txtKey.Text,
                  Ten = txtTen.Text,
                  GiaTri = txtGiaTri.Text,
                  Mota = txtMoTa.Text
              }
              , AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
