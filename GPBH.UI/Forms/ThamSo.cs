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
    public partial class ThamSo : Office2007Form
    {
        #region Fields & Constructor

        private readonly SysDMCuaHangService _sysDMCuaHangService;

        public ThamSo(SysDMCuaHangService sysDMCuaHangService)
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
            cbbCuaHang.SelectedIndexChanged += CbbCuaHang_SelectedIndexChanged;
        }

        #endregion

        #region Data Loading & Binding

        /// <summary>
        /// Load dữ liệu tham số hệ thống lên lưới.
        /// </summary>
        private void LoadData()
        {
            ComboBoxHelper.BindData(cbbCuaHang, _sysDMCuaHangService.GetAll(), "Ten_cua_hang", "Ma_cua_hang");
            cbbCuaHang.SelectedValue = AppGlobals.MaCH;
            var result = _sysDMCuaHangService.GetThamSo(cbbCuaHang.SelectedValue.ToString());
            dataGridViewX1.BindData(result.data);
            if (result.hasSave)
            {
                lbWarning.Visible = false;
            }
            else
            {
                lbWarning.Visible = true;
            }
        }

        #endregion

        #region UI Setup

        /// <summary>
        /// Cài đặt hiển thị, định dạng và thứ tự các cột trên DataGridView.
        /// </summary>
        private void SetUpUI()
        {
            if (dataGridViewX1.Columns.Count == 0) return;

            // Sắp xếp vị trí các cột
            dataGridViewX1.SetDisplayIndex("Key", 0);
            dataGridViewX1.SetDisplayIndex("Ten", 1);
            dataGridViewX1.SetDisplayIndex("GiaTri", 2);
            dataGridViewX1.SetDisplayIndex("Mota", 3);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Lưu dữ liệu tham số khi click nút Lưu.
        /// </summary>
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var data = dataGridViewX1.GetData<GirdSystemSettingDto>();
            _sysDMCuaHangService.LuuThamSo(data, AppGlobals.MaCH);
            lbWarning.Visible = false;
            MessageBoxEx.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CbbCuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = _sysDMCuaHangService.GetThamSo(cbbCuaHang.SelectedValue.ToString());
            dataGridViewX1.BindData(result.data);
        }

        #endregion

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewX1.SetRowPositionPaint(e);
        }
    }
}
