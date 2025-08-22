using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GPBH.Business;
using GPBH.Business.Dtos;
using GPBH.Business.Services;
using GPBH.UI.Constant;
using GPBH.UI.Extentions;
using GPBH.UI.Forms;
using GPBH.UI.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GPBH.UI.UserControls
{
    public partial class UserControlThamSo : UserControl
    {
        #region Fields & Constructor

        private readonly SysDMCuaHangService _sysDMCuaHangService;
        private readonly SysDinh_dang_formService _sysDinh_Dang_FormService;

        public UserControlThamSo(SysDMCuaHangService sysDMCuaHangService, SysDinh_dang_formService sysDinh_Dang_FormService)
        {
            InitializeComponent();
            _sysDMCuaHangService = sysDMCuaHangService;
            _sysDinh_Dang_FormService = sysDinh_Dang_FormService;
            InitializeUI();
            dgThamSo.DataBindingComplete += (s, e) =>
            {
                SetUpUI();
            };
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Khởi tạo UI, load dữ liệu và đăng ký sự kiện.
        /// </summary>
        private void InitializeUI()
        {
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
            var fields = _sysDinh_Dang_FormService.GetDinhDang(AppGlobals.MaCH, "ThamSo").data.ToList();
            dgThamSo.ApplyColumnConfig(fields);
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
        }
        private void dgThamSo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgThamSo.SetRowPositionPaint(e);
        }

        #endregion

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string menuName = "ThamSo";
            var hasPermission = CheckPermissionHelper.HasPerrmission(menuName, GPBHConstant.Action.Excel);
            if (!hasPermission)
            {
                CheckPermissionHelper.ShowMessage();
                return;
            }

            ExportHelper.ExportGridToExcel(dgThamSo, $"{menuName}_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }
    }
}