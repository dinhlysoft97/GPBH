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
            dgThamSo.CellDoubleClick += dgThamSo_CellDoubleClick;
        }

        #endregion

        #region Data Loading & Binding

        /// <summary>
        /// Load dữ liệu tham số hệ thống lên lưới.
        /// </summary>
        private void LoadData()
        {
            dgThamSo.BindData(_sysDMCuaHangService.GetThamSo(AppGlobals.MaCH).data);
        }

        #endregion

        #region UI Setup

        /// <summary>
        /// Cài đặt hiển thị, định dạng và thứ tự các cột trên DataGridView.
        /// </summary>
        private void SetUpUI()
        {
            if (dgThamSo.Columns.Count == 0) return;

            // Canh giữa header cho cột STT
            dgThamSo.SetHeaderAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
            dgThamSo.Columns["Stt"].Visible = false; // Ẩn cột STT
            // Sắp xếp vị trí các cột
            dgThamSo.SetDisplayIndex("Stt", 0);
            dgThamSo.SetDisplayIndex("Key", 1);
            dgThamSo.SetDisplayIndex("Ten", 2);
            dgThamSo.SetDisplayIndex("GiaTri", 3);
            dgThamSo.SetDisplayIndex("Mota", 4);

            // Căn chỉnh dữ liệu trong cột STT
            dgThamSo.SetCellAlignment("Stt", DataGridViewContentAlignment.MiddleCenter);
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

            var data = dgThamSo.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgThamSo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0 && e.ColumnIndex >= 0)
            //{
            var row = dgThamSo.Rows[e.RowIndex].DataBoundItem as GirdSystemSettingDto;
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
        private void dgThamSo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgThamSo.SetRowPositionPaint(e);
        }

        #endregion

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportGridToExcel(dgThamSo, "ThamSo_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}