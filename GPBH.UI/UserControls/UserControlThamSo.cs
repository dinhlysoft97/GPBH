using DevComponents.DotNetBar;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlThamSo : UserControl
    {
        #region Fields & Constructor

        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public UserControlThamSo(SysDMCuaHangService sysDMCuaHangService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
            InitializeUI();
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Khởi tạo UI, load dữ liệu và đăng ký sự kiện.
        /// </summary>
        private void InitializeUI()
        {
            SetUpUI();
            LoadData();
            RegisterEvents();
        }

        /// <summary>
        /// Đăng ký các sự kiện cho control.
        /// </summary>
        private void RegisterEvents()
        {
            btnLuu.Click += BtnLuu_Click;
            dataGridViewX1.CellDoubleClick += DataGridViewX1_CellDoubleClick;
        }

        #endregion

        #region Data Loading & Binding

        /// <summary>
        /// Load dữ liệu tham số hệ thống lên lưới.
        /// </summary>
        private void LoadData()
        {
            dataGridViewX1.BindData(_sysDMCuaHangService.GetThamSo(AppGlobals.MaCH).data);
        }

        #endregion

        #region UI Setup

        /// <summary>
        /// Cài đặt hiển thị, định dạng và thứ tự các cột trên DataGridView.
        /// </summary>
        private void SetUpUI()
        {
            if (dataGridViewX1.Columns.Count == 0) return;

            // Canh giữa header cho cột STT
            dataGridViewX1.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dataGridViewX1.Columns["Stt"].Visible = false; // Ẩn cột STT
            // Sắp xếp vị trí các cột
            dataGridViewX1.SetDisplayIndex("Stt", 0);
            dataGridViewX1.SetDisplayIndex("Key", 1);
            dataGridViewX1.SetDisplayIndex("Ten", 2);
            dataGridViewX1.SetDisplayIndex("GiaTri", 3);
            dataGridViewX1.SetDisplayIndex("Mota", 4);

            // Căn chỉnh dữ liệu trong cột STT
            dataGridViewX1.SetCellAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Lưu dữ liệu tham số khi click nút Lưu.
        /// </summary>
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var hasPermission = CheckPermissionHelper.HasPerrmission("ThamSo", GPBHConstant.Action.Sua);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            var data = dataGridViewX1.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            //{
            var row = dataGridViewX1.Rows[e.RowIndex].DataBoundItem as GirdSystemSettingDto;
            var key = row.Key;
            var maCH = AppGlobals.MaCH;
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(maCH))
            {
                var data = _sysDMCuaHangService.GetThamSo(maCH);
                var dataKey = data.data.Find(x => x.Key == key);
                var formNew = ActivatorUtilities.CreateInstance<ThamSo2>(Program.ServiceProvider, dataKey);
                formNew.ShowDialog();
                LoadData();
            }
            //  }
        }
        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }

        #endregion
    }
}