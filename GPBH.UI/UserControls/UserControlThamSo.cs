using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Extentions;
using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlThamSo : UserControl
    {
        private readonly SysDMCuaHangService _sysDMCuaHangService;
        public UserControlThamSo(SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
            SetUpUI();
            LoadData();
            RegisterEvents();
        }
        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click; ;
        }

        private void LoadData()
        {
            dataGridViewX1.BindData(_sysDMCuaHangService.GetThamSo(AppGlobals.MaCH));
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Phân quyền người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetUpUI()
        {
            // Canh giữa header
            dataGridViewX1.Columns["Stt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Số thứ tự các cột
            dataGridViewX1.Columns["Stt"].DisplayIndex = 0;
            dataGridViewX1.Columns["Key"].DisplayIndex = 1;
            dataGridViewX1.Columns["Ten"].DisplayIndex = 2;
            dataGridViewX1.Columns["GiaTri"].DisplayIndex = 3;
            dataGridViewX1.Columns["Mota"].DisplayIndex = 4;

            // Foramt columns
            dataGridViewX1.Columns["Stt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
